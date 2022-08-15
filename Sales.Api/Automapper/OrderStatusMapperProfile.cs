using AutoMapper;
using Sales.Api.DTOs;
using Sales.Api.Models;

namespace Sales.Api.Automapper
{
    public class OrderStatusMapperProfile : Profile
    {
        public OrderStatusMapperProfile()
        {
            CreateMap<OrderStatus, OrderStatusDTO>()
                .ForMember(dest => dest.IdDTO, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NameDTO, opt => opt.MapFrom(src => src.Name));
        }
    }
}
