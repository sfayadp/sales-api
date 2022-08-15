using AutoMapper;
using Sales.Api.DTOs;
using Sales.Api.Models;

namespace Sales.Api.Automapper
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.IdDTO, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NameDTO, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.UnitPriceDTO, opt => opt.MapFrom(src => src.UnitPrice));
        }
    }
}
