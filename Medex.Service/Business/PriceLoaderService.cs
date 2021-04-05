using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Medex.Abstractions.Common;
using Medex.Abstractions.Persistence;
using Medex.Data.Primitives;
using Medex.Domains.Models;
using Medex.Service.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Medex.Service.Business
{
    public class PriceLoaderService : BaseService, IPriceLoaderService
    {
        private readonly IConfiguration _configuration;
        public PriceLoaderService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(dbContext, mapper)
        {
            _configuration = configuration;

        }

        private async Task<IDictionary<int, Tuple<Product, Distributor>>> LoadProductsItemsAsync(StreamReader streamReader, CsvParser parser)
        {
            var products = await _dbContext.Products.Include(x => x.GroupName)
                .Include(x => x.Manufacture)
                .Include(x => x.InterName).ToListAsync();
            var distributors = await _dbContext.Distributors.ToListAsync();
            var manufacturers = products.Select(x => x.Manufacture).Distinct().ToList();
            var interNames = products.Select(x => x.InterName).Distinct().ToList();
            var groupNames = products.Select(x => x.GroupName).Distinct().ToList();

            streamReader.BaseStream.Position = 0;
            var results = new Dictionary<int, Tuple<Product, Distributor>>();
            var index = 0;
            while (parser.Read())
            {
                if (parser.Record == null)
                    break;

                string productName = parser.Record[0]?.Trim();
                string interName = parser.Record[1]?.Trim();
                string groupName = parser.Record[2]?.Trim();
                string distribtorName = parser.Record[8]?.Trim();
                string manufacturerName = parser.Record[9]?.Trim();
                string country = parser.Record[10]?.Trim();

                Manufacturer manufacturer =
                    manufacturers.FirstOrDefault(x => x.Country == country && x.Name == manufacturerName);
                if (manufacturer == null)
                {
                    manufacturer = new Manufacturer
                    {
                        Country = country,
                        Name = manufacturerName
                    };
                    _dbContext.Manufacturers.Add(manufacturer);
                    manufacturers.Add(manufacturer);
                }

                Distributor distributor =
                    distributors.FirstOrDefault(x => x.Name == distribtorName);
                if (distributor == null)
                {
                    distributor = new Distributor
                    {
                        Name = distribtorName,
                    };
                    distributors.Add(distributor);
                    _dbContext.Distributors.Add(distributor);
                }

                GroupName group =
                    groupNames.FirstOrDefault(x => x.Name == groupName);
                if (group == null)
                {
                    group = new GroupName
                    {
                        Name = groupName,
                    };
                    groupNames.Add(group);
                    _dbContext.GroupNames.Add(group);
                }

                InterName inter =
                    interNames.FirstOrDefault(x => x.Name == interName);
                if (inter == null)
                {
                    inter = new InterName
                    {
                        Name = interName,
                    };
                    interNames.Add(inter);
                    _dbContext.InterNames.Add(inter);
                }

                Product product = products.FirstOrDefault(x => x.GroupName.Name == group.Name
                && x.Name == productName
                && x.InterName.Name == inter.Name
                && x.Manufacture.Name == manufacturer.Name
                && x.Manufacture.Country == manufacturer.Country);
                if (product == null)
                {
                    product = new Product
                    {
                        InterName = inter,
                        GroupName = group,
                        Manufacture = manufacturer,
                        Name = productName,
                    };
                    products.Add(product);
                    _dbContext.Products.Add(product);
                }
                results.Add(index, new Tuple<Product, Distributor>(product, distributor));
                index++;
            }
            await _dbContext.SaveChangesAsync();
            return results;
        }

        public async Task LoadPriceAsync(long priceId)
        {
            var price = await _dbContext.Prices.FirstOrDefaultAsync(x => x.Id == priceId);
            if ((EnumPriceStatusCode)price.Status == EnumPriceStatusCode.Processing)
            {
                throw new Exception("Price is already in processing");
            }
            if ((EnumPriceStatusCode)price.Status == EnumPriceStatusCode.Active)
            {
                throw new Exception("Price has already been processed");
            }

            price.Status = (int)EnumPriceStatusCode.Processing;
            await _dbContext.SaveChangesAsync();
            var document = await _dbContext.Documents.FirstOrDefaultAsync(x => x.Id == price.DocumentId);
           
            using (var ms = new MemoryStream(document.Data))
            {
                var decimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                var productsToInsert = new List<Product>();
                using (var streamReader = new StreamReader(ms, Encoding.GetEncoding("Windows-1251")))
                {
                    var configuration = new CsvConfiguration(Thread.CurrentThread.CurrentCulture);
                    configuration.Delimiter = _configuration.GetSection("CsvSettings").GetValue<string>("delimeter");
                    using (var parser = new CsvParser(streamReader, configuration))
                    {
                        IDictionary<int, Tuple<Product, Distributor>> productProcessResult = await LoadProductsItemsAsync(streamReader, parser);
                        streamReader.BaseStream.Position = 0L;
                        var index = 0;
                        var priceItems = new List<PriceItem>();
                        while (parser.Read())
                        {
                            decimal margin = 0;
                            margin = string.IsNullOrEmpty(parser.Record[3]) ? 0 : (decimal.TryParse(parser.Record[3].Replace("%", "")
                                .Replace(".", decimalSeparator).Replace(",", decimalSeparator), out margin) ? margin : 0);

                            decimal cost = 0;
                            cost = decimal.TryParse(parser.Record[4].Replace(".", decimalSeparator).Replace(",", decimalSeparator), out cost) ? cost : -1;
                            cost = string.IsNullOrEmpty(parser.Record[4]) || parser.Record[4].StartsWith("догов") ? -1 :
                                (parser.Record[4].StartsWith("ожидаемый") ? -2 : cost);

                            decimal costDollar = 0;
                            costDollar = decimal.TryParse(parser.Record[5].Replace(".", decimalSeparator).Replace(",", decimalSeparator), out costDollar) ? costDollar : -1;
                            costDollar = string.IsNullOrEmpty(parser.Record[5]) || parser.Record[5].StartsWith("догов") ? -1 :
                                (parser.Record[4].StartsWith("ожидаемый") ? -2 : costDollar);

                            decimal costEuro = 0;
                            costEuro = decimal.TryParse(parser.Record[6].Replace(".", decimalSeparator).Replace(",", decimalSeparator), out costEuro) ? costEuro : -1;
                            costEuro = string.IsNullOrEmpty(parser.Record[6]) || parser.Record[6].StartsWith("догов") ? -1 :
                                (parser.Record[6].StartsWith("ожидаемый") ? -2 : costEuro);
                            var priceItem = new PriceItem
                            {
                                PriceId = price.Id,
                                DistributorId = productProcessResult[index].Item2.Id,
                                ProductId = productProcessResult[index].Item1.Id,
                                Cost = cost,
                                CostInDollar = costDollar,
                                CostInEuro = costEuro,
                                Margin = margin,
                            };
                            priceItems.Add(priceItem);
                            index++;
                        }


                        price.Status = (int)EnumPriceStatusCode.Active;
                        await _dbContext.BulkAddAsync<PriceItem>(priceItems);
                        await _dbContext.SaveChangesAsync();
                    }
                }

            }
        }
    }
}
