using AutoMapper;
using TheLuxe.Entity;
using TheLuxe.Model.ProductCategory;

namespace TheLuxe.API.MappingProfiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<tblProductCategory, uspMobileSelectProductCategory>();

            //CreateMap<tblProductCategory, uspSelectCategory>();
            //CreateMap<tblProductCategory, uspSelectProductCategory>();
            //CreateMap<tblProductCategory, uspSelectProductCategoryForMenu>();

            //CreateMap<Product, ProductToReturnDto>()
            //    .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            //    .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
            //    .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
