using System;
using System.Collections.Generic;
using HouzeAPI.Entities;

namespace HouzeAPI.Services.Interfaces
{
    public interface ILikes
    {
        LikeDto AddLike(Like like, Guid userId);

        void Unlike(int id);

        List<Like> GetHouseLikeCount(int id);

    }
}
