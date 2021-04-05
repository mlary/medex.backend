// Decompiled with JetBrains decompiler
// Type: Medex.Infrastructure.Apps.UploadProductsFromCsv.App.Program
// Assembly: Medex.Infrastructure.Apps.UploadProductsFromCsv.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F44A748C-5493-4470-8F8D-835DEEC484DD
// Assembly location: C:\Users\hp\Downloads\Telegram Desktop\Medex.Infrastructure.Apps.UploadProductsFromCsv.App.exe

using CsvHelper;
using Medex.Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Medex.Infrastructure.Apps.UploadProductsFromCsv.App
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      Console.WriteLine("Enter delimeter. Default is ','");
      string str1 = Console.ReadLine();
      Console.WriteLine("Enter 1 to load single file or enter 2 to load multiple files");
      string str2 = Console.ReadLine();
      Dictionary<string, DateTime> dictionary = new Dictionary<string, DateTime>();
      if (str2 == "1")
      {
        Console.WriteLine("Enter filename...");
        string key = Console.ReadLine();
        Console.WriteLine("Enter public price date in yyyy-MM-dd format");
        DateTime exact = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", (IFormatProvider) null);
        dictionary.Add(key, exact);
      }
      else
      {
        Console.WriteLine("Enter directory");
        foreach (string file in Directory.GetFiles(Console.ReadLine()))
        {
          DateTime exact = DateTime.ParseExact(new FileInfo(file).Name.Replace(".csv", ""), "yyyy-MM-dd", (IFormatProvider) null);
          dictionary.Add(file, exact);
          Console.WriteLine(file);
          Console.WriteLine((object) exact);
        }
      }
      foreach (KeyValuePair<string, DateTime> keyValuePair in dictionary)
      {
        DateTime dateTime = keyValuePair.Value;
        Price price1 = new Price();
        price1.set_CreatedOn(DateTime.Now);
        price1.set_PublicDate(dateTime);
        Price price2 = price1;
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
        using (StreamReader streamReader1 = new StreamReader(keyValuePair.Key, Encoding.Default))
        {
          StreamReader streamReader2 = streamReader1;
          CsvHelper.Configuration.Configuration configuration = new CsvHelper.Configuration.Configuration();
          configuration.set_Delimiter(str1);
          CsvParser csvParser = new CsvParser((TextReader) streamReader2, configuration);
          using (WebTechDb webTechDb = new WebTechDb())
          {
            List<Product> list1 = ((IEnumerable<Product>) webTechDb.get_Products()).ToList<Product>();
            List<Manufacturer> list2 = ((IEnumerable<Manufacturer>) webTechDb.get_Manufacturers()).ToList<Manufacturer>();
            List<InterName> list3 = ((IEnumerable<InterName>) webTechDb.get_InterNames()).ToList<InterName>();
            List<GroupName> list4 = ((IEnumerable<GroupName>) webTechDb.get_GroupNames()).ToList<GroupName>();
            List<Distributor> list5 = ((IEnumerable<Distributor>) webTechDb.get_Distributors()).ToList<Distributor>();
            webTechDb.get_Prices().Add(price2);
            ((DbContext) webTechDb).SaveChanges();
            int num = 0;
            streamReader1.BaseStream.Position = 0L;
            while (true)
            {
              string[] strArray = csvParser.Read();
              if (strArray != null && strArray.Length != 0)
              {
                string country = strArray[10];
                string str3 = strArray[0];
                string interName = strArray[1];
                string groupName = strArray[2];
                string distribName = strArray[8];
                string manufName = strArray[9];
                Manufacturer manufacturer1 = ((IEnumerable<Manufacturer>) list2).FirstOrDefault<Manufacturer>((Func<Manufacturer, bool>) (s => s.get_Name() == manufName && s.get_Country() == country));
                Distributor distributor1 = ((IEnumerable<Distributor>) list5).FirstOrDefault<Distributor>((Func<Distributor, bool>) (s => s.get_Name() == distribName));
                GroupName groupName1 = ((IEnumerable<GroupName>) list4).FirstOrDefault<GroupName>((Func<GroupName, bool>) (s => s.get_Name() == groupName));
                InterName interName1 = ((IEnumerable<InterName>) list3).FirstOrDefault<InterName>((Func<InterName, bool>) (s => s.get_Name() == interName));
                if (manufacturer1 == null)
                {
                  Manufacturer manufacturer2 = new Manufacturer();
                  manufacturer2.set_Country(country);
                  manufacturer2.set_Name(manufName);
                  Manufacturer manufacturer3 = manufacturer2;
                  webTechDb.get_Manufacturers().Add(manufacturer3);
                  list2.Add(manufacturer3);
                  Console.WriteLine("Add manufacture. id {0}", (object) manufacturer3.get_Id());
                }
                if (distributor1 == null)
                {
                  Distributor distributor2 = new Distributor();
                  distributor2.set_Name(distribName);
                  Distributor distributor3 = distributor2;
                  webTechDb.get_Distributors().Add(distributor3);
                  list5.Add(distributor3);
                  Console.WriteLine("Add distributor. id {0}", (object) distributor3.get_Id());
                }
                if (groupName1 == null)
                {
                  GroupName groupName2 = new GroupName();
                  groupName2.set_Name(groupName);
                  GroupName groupName3 = groupName2;
                  webTechDb.get_GroupNames().Add(groupName3);
                  list4.Add(groupName3);
                  Console.WriteLine("Add group. id {0}", (object) groupName3.get_Id());
                }
                if (interName1 == null)
                {
                  InterName interName2 = new InterName();
                  interName2.set_Name(interName);
                  InterName interName3 = interName2;
                  webTechDb.get_InterNames().Add(interName3);
                  list3.Add(interName3);
                  Console.WriteLine("Add intername. id {0}", (object) interName3.get_Id());
                }
              }
              else
                break;
            }
            ((DbContext) webTechDb).SaveChanges();
            List<Manufacturer> list6 = ((IEnumerable<Manufacturer>) webTechDb.get_Manufacturers()).ToList<Manufacturer>();
            List<InterName> list7 = ((IEnumerable<InterName>) webTechDb.get_InterNames()).ToList<InterName>();
            List<GroupName> list8 = ((IEnumerable<GroupName>) webTechDb.get_GroupNames()).ToList<GroupName>();
            List<Distributor> list9 = ((IEnumerable<Distributor>) webTechDb.get_Distributors()).ToList<Distributor>();
            streamReader1.BaseStream.Position = 0L;
            while (true)
            {
              string[] strArray = csvParser.Read();
              if (strArray != null && strArray.Length != 0)
              {
                string country = strArray[10];
                string productName = strArray[0];
                string interName = strArray[1];
                string groupName = strArray[2];
                string distribName = strArray[8];
                string manufName = strArray[9];
                Manufacturer manuf = ((IEnumerable<Manufacturer>) list6).FirstOrDefault<Manufacturer>((Func<Manufacturer, bool>) (s => s.get_Name() == manufName && s.get_Country() == country));
                ((IEnumerable<Distributor>) list9).FirstOrDefault<Distributor>((Func<Distributor, bool>) (s => s.get_Name() == distribName));
                GroupName group = ((IEnumerable<GroupName>) list8).FirstOrDefault<GroupName>((Func<GroupName, bool>) (s => s.get_Name() == groupName));
                InterName inter = ((IEnumerable<InterName>) list7).FirstOrDefault<InterName>((Func<InterName, bool>) (s => s.get_Name() == interName));
                if (((IEnumerable<Product>) list1).FirstOrDefault<Product>((Func<Product, bool>) (s => s.get_ManufacturerId() == manuf.get_Id() && s.get_InterNameId() == inter.get_Id() && group.get_Id() == s.get_GroupNameId() && s.get_Name() == productName)) == null)
                {
                  Product product1 = new Product();
                  product1.set_GroupNameId(group.get_Id());
                  product1.set_ManufacturerId(manuf.get_Id());
                  product1.set_InterNameId(inter.get_Id());
                  product1.set_Name(productName);
                  product1.set_CreatedOn(DateTime.Now);
                  Product product2 = product1;
                  webTechDb.get_Products().Add(product2);
                  list1.Add(product2);
                  Console.WriteLine("Add products. ProductId {0} Name {1}", (object) product2.get_Id(), (object) productName);
                }
              }
              else
                break;
            }
            ((DbContext) webTechDb).SaveChanges();
            List<PriceItem> priceItemList = new List<PriceItem>();
            streamReader1.BaseStream.Position = 0L;
            List<Product> list10 = ((IEnumerable<Product>) webTechDb.get_Products()).ToList<Product>();
            while (true)
            {
              string[] strArray = csvParser.Read();
              if (strArray != null && strArray.Length != 0)
              {
                string productName = strArray[0];
                string interName = strArray[1];
                string groupName = strArray[2];
                string distribName = strArray[8];
                string manufName = strArray[9];
                string str3 = strArray[3].Replace("%", "");
                string str4 = strArray[4];
                string str5 = strArray[5];
                string str6 = strArray[6];
                string country = strArray[10];
                Manufacturer manuf = ((IEnumerable<Manufacturer>) list6).FirstOrDefault<Manufacturer>((Func<Manufacturer, bool>) (s => s.get_Name() == manufName && s.get_Country() == country));
                Distributor distributor = ((IEnumerable<Distributor>) list9).FirstOrDefault<Distributor>((Func<Distributor, bool>) (s => s.get_Name() == distribName));
                GroupName group = ((IEnumerable<GroupName>) list8).FirstOrDefault<GroupName>((Func<GroupName, bool>) (s => s.get_Name() == groupName));
                InterName inter = ((IEnumerable<InterName>) list7).FirstOrDefault<InterName>((Func<InterName, bool>) (s => s.get_Name() == interName));
                Product product = ((IEnumerable<Product>) list10).FirstOrDefault<Product>((Func<Product, bool>) (s => s.get_ManufacturerId() == manuf.get_Id() && s.get_InterNameId() == inter.get_Id() && group.get_Id() == s.get_GroupNameId() && s.get_Name() == productName));
                Decimal result = 0M;
                PriceItem priceItem1 = new PriceItem();
                priceItem1.set_Cost(string.IsNullOrEmpty(str4) ? -1M : (str4.StartsWith("догов") ? -1M : (str4.StartsWith("ожидаемый") ? -2M : (Decimal.TryParse(str4.Replace(",", "."), out result) ? Convert.ToDecimal(str4.Replace(",", ".")) : -1M))));
                priceItem1.set_CostInDollar(string.IsNullOrEmpty(str5) ? -1M : (str5.StartsWith("догов") ? -1M : (str5.StartsWith("ожидаемый") ? -2M : (Decimal.TryParse(str5.Replace(",", "."), out result) ? Convert.ToDecimal(str5.Replace(",", ".")) : -1M))));
                priceItem1.set_CostInEuro(string.IsNullOrEmpty(str6) ? -1M : (str6.StartsWith("догов") ? -1M : (str6.StartsWith("ожидаемый") ? -2M : (Decimal.TryParse(str6.Replace(",", "."), out result) ? Convert.ToDecimal(str6.Replace(",", ".")) : -1M))));
                priceItem1.set_Margin(string.IsNullOrEmpty(str3) ? 0M : (Decimal.TryParse(str3.Replace(",", "."), out result) ? Convert.ToDecimal(str3.Replace(",", ".")) : 0M));
                priceItem1.set_CreatedOn(DateTime.Now);
                priceItem1.set_Date(dateTime);
                priceItem1.set_DistributorId(distributor.get_Id());
                priceItem1.set_PriceId(price2.get_Id());
                priceItem1.set_ProductId(product.get_Id());
                PriceItem priceItem2 = priceItem1;
                int tickCount = Environment.TickCount;
                priceItemList.Add(priceItem2);
                if (num % 1000 == 0)
                {
                  webTechDb.get_PriceItems().AddRange((IEnumerable<PriceItem>) priceItemList);
                  ((DbContext) webTechDb).SaveChanges();
                  priceItemList.Clear();
                  Console.WriteLine("Add price item {0}, time {1}", (object) priceItem2.get_Id(), (object) (Environment.TickCount - tickCount));
                }
                Console.WriteLine("Add price item {0}, time {1}", (object) num, (object) (Environment.TickCount - tickCount));
                ++num;
              }
              else
                break;
            }
            if (priceItemList.Count > 0)
            {
              webTechDb.get_PriceItems().AddRange((IEnumerable<PriceItem>) priceItemList);
              ((DbContext) webTechDb).SaveChanges();
            }
          }
        }
      }
    }
  }
}
