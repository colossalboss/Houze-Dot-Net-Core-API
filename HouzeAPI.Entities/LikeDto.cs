using System;
using HouzeAPI.Entities;

namespace HouzeAPI.Entities
{
    public class LikeDto : Like
    {
        public LikeDto()
        {
        }

        public bool Liked { get; set; }
    }
}
