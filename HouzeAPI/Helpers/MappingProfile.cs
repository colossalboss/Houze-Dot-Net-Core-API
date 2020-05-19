using System;
using AutoMapper;
using HouzeAPI.Entities;
using HouzeAPI.ViewModels;

namespace HouzeAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentViewModel>()
                .ForMember(dest => dest.PostTime,
                    act => act.MapFrom(src => src.TimeStamp));

            CreateMap<AppUser, UserViewModel>()
                .ForMember(dest => dest.UserId,
                    act => act.MapFrom(src => src.Id));

            CreateMap<House, HouseStats>()
                .ForMember(dest => dest.HouseType,
                    act => act.MapFrom(src => src.Type))
                .ForMember(dest => dest.NumberOfLikes,
                    act => act.MapFrom(src => src.Likes.Count));

        }
    }
}
