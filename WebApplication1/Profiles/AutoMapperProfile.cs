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
               .ForMember(property => property.Images, opt => opt.MapFrom(src => src.Images.Select(x => x.ImageUrl)))
               .ForMember(property => property.BookedStartDates, opt => opt.MapFrom(src => src.BookedNights.Select(x => x.Night.AddDays(-1))))
               .ForMember(property => property.BookedEndDates, opt => opt.MapFrom(src => src.BookedNights.Select(x => x.Night)))
               .ReverseMap();
        }
    }
}
