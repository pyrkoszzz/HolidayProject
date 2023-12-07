using AutoMapper;
using DataEntities.Entities;
using WebApp.Models;

namespace WebApp.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Property, PropertyDetailsModel>()
               .ForMember(property => property.Id, opt => opt.MapFrom(src => src.PropertyId))
               .ReverseMap();
        }
    }
}
