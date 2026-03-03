using AutoMapper;
using StoreApp.Data.Concrete;
using StoreApp.Web.Models;

namespace StoreApp.Web.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
