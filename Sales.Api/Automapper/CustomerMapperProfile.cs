using AutoMapper;
using Sales.Api.DTOs;
using Sales.Api.Models;

namespace Sales.Api.Automapper
{
    public class CustomerMapperProfile : Profile
    {
        public CustomerMapperProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.IdDTO, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstNameDTO, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastNameDTO, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.UserNameDTO, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.FullNameDTO, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.PasswordDTO, opt => opt.MapFrom(src => src.Password));
        }
    }
}
