using AutoMapper;

namespace MeetupsServerApp.Shared
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.Entities.Event, ViewModels.EventViewModel>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Desription, opt => opt.MapFrom(src => src.Desription))
                .ForMember(dest => dest.BeginDate, opt => opt.MapFrom(src => src.BeginDate))
                .ForMember(dest => dest.BeginTime, opt => opt.MapFrom(src => src.BeginTime))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.MeetupLink, opt => opt.MapFrom(src => src.MeetupLink))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
                .ForMember(dest => dest.OrganizerId, opt => opt.MapFrom(src => src.OrganizerId));

            CreateMap<ViewModels.EventViewModel, Data.Entities.Event>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Desription, opt => opt.MapFrom(src => src.Desription))
                .ForMember(dest => dest.BeginDate, opt => opt.MapFrom(src => src.BeginDate))
                .ForMember(dest => dest.BeginTime, opt => opt.MapFrom(src => src.BeginTime))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.MeetupLink, opt => opt.MapFrom(src => src.MeetupLink))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
                .ForMember(dest => dest.OrganizerId, opt => opt.MapFrom(src => src.OrganizerId));

        }
    }
}
