using AutoMapper;
using DataEntities;
using WebApp.Models;

namespace WebApp.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Property, PropertyDetailsModel>();
            CreateMap<PropertyDetailsModel, Property>();
        }
    }
}
