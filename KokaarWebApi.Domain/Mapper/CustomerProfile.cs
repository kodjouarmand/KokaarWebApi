using AutoMapper;
using KokaarWebApi.Domain.Entities;
using KokaarWebApi.Domain.ExtentionMethods;
using KokaarWepApi.Domain.DTO;

namespace KokaarWepApi.Business.Mapper
{
    public class CustomerProfile : Profile
    {        
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>()
            .ForMember(
                dest => dest.Age,
                opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));

            CreateMap<CustomerDTO, Customer>();
        }
    }
}
