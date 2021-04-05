using AutoMapper;
using Medex.Data.Dto;
using Medex.Data.Primitives;
using Medex.Domains.Models;

namespace Medex.Service.Mappings
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            #region  Dictionaries
            CreateMap<DistributorDto, Distributor>();
            CreateMap<InterNameDto, InterName>();
            CreateMap<GroupNameDto, GroupName>();
            CreateMap<ManufacturerDto, Manufacturer>();
            CreateMap<InterName, InterNameDto>();
            CreateMap<GroupName, GroupNameDto>();
            CreateMap<Manufacturer, ManufacturerDto>();
            CreateMap<Document, DocumentDto>();
            CreateMap<Distributor, DistributorDto>();

            CreateMap<DocumentDto, Document>();

            #endregion

            #region Users
            CreateMap<User, UserDto>()
               .ForMember(x => x.FullName, x => x.MapFrom(y => $"{y.LastName} {y.FirstName} {y.MiddleName}"))
               .ForMember(x => x.UserRole, x => x.MapFrom(y => (EnumRoleCodes)y.UserRole));
            #endregion

            #region Product
            CreateMap<ProductDto, Product>()
                .ForMember(x => x.GroupName, x => x.MapFrom(p => p.GroupName))
                .ForMember(x => x.InterName, x => x.MapFrom(p => p.InterName))
                .ForMember(x => x.Manufacture, x => x.MapFrom(p => p.Manufacture));

            CreateMap<Product, ProductDto>()
                .ForMember(x => x.GroupName, x => x.MapFrom(p => p.GroupName))
                .ForMember(x => x.InterName, x => x.MapFrom(p => p.InterName))
                .ForMember(x => x.Manufacture, x => x.MapFrom(p => p.Manufacture));
            #endregion

            #region Price
            CreateMap<Document, DocumentDto>()
                .ForMember(x => x.CreatedOn, x => x.MapFrom(y => y.CreatedOn))
                .ForMember(x => x.Extension, x => x.MapFrom(y => y.Extension))
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name));
            CreateMap<PriceDto, Price>()
                .ForMember(x => x.Status, x => x.MapFrom(y => (int)y.Status));
            CreateMap<Price, PriceDto>()
                .ForMember(x => x.Status, x => x.MapFrom(y => (EnumPriceStatusCode)y.Status))
                .ForMember(x => x.Document, x => x.MapFrom(y => y.Document));

            CreateMap<PriceItem, PriceItemDto>()
             .ForMember(x => x.Distributor, x => x.MapFrom(p => p.Distributor.Name))
             .ForMember(x => x.Manufacturer, x => x.MapFrom(p => p.Product.Manufacture.Name))
             .ForMember(x => x.Country, x => x.MapFrom(p => p.Product.Manufacture.Country))
             .ForMember(x => x.PublicDate, x => x.MapFrom(p => p.Price.PublicDate))
             .ForMember(x => x.InterName, x => x.MapFrom(p => p.Product.InterName.Name))
             .ForMember(x => x.GroupName, x => x.MapFrom(p => p.Product.GroupName.Name))
             .ForMember(x => x.Name, x => x.MapFrom(p => p.Product.Name));
            #endregion
        }
    }
}
