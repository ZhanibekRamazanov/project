using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;
using AutoMapper.Execution;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
            .ForMember(dest => dest.addressStreet, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault(x => x.IsMain).Street))
            .ForMember(dest => dest.phoneNumberNumber, opt => opt.MapFrom(src => src.PhoneNumbers.FirstOrDefault(x => x.IsMain).Number));



            CreateMap<Address, AddressDto>();
            CreateMap<PhoneNumber, PhoneNumberDto>();
            
            
        }
        
    }
}