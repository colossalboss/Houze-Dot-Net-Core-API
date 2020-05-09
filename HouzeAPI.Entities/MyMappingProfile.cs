using System;
using AutoMapper;

namespace HouzeAPI.Entities
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<Like, LikeDto>()
                .ForMember(dest => dest.Liked,
                    act => act.MapFrom(src => false));

        }
    }
}
