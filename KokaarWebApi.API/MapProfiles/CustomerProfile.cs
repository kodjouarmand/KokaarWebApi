using AutoMapper;
using KokaarWebApi.Domain.Entities;
using KokaarWebApi.Domain.DTO;
using KokaarWebApi.Utility.Extentions;

namespace KokaarWepApi.Service.MapProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));
        }
    }
}
