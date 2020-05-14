using AutoMapper;
using KokaarWebApi.Domain.Entities;
using KokaarWebApi.Domain.DataTransfertObjects;
using KokaarWebApi.Utility.Extentions;

namespace KokaarWepApi.Service.MapProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));
        }
    }
}
