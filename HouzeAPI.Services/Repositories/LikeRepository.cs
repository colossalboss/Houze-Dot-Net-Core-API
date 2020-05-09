using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HouzeAPI.Data;
using HouzeAPI.Entities;
using HouzeAPI.Services.Interfaces;

namespace HouzeAPI.Services.Repositories
{
    public class LikeRepository : ILikes
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public LikeRepository(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public LikeDto AddLike(Like like, Guid userId)
        {
            Like existingLike = null;
            if (like.HouseId != 0)
            {
                existingLike = GetLike(like.HouseId, userId);
            }

            LikeDto likeDto = new LikeDto
            {
                UserId = like.UserId,
                HouseId = like.HouseId,

            };
            
            if (existingLike == null)
            {
                _db.Likes.Add(like);
                likeDto.Liked = true;

            } else
            {
                _db.Likes.Remove(existingLike);

                likeDto.Liked = false;

            }

            _db.SaveChanges();
            return likeDto;
        }

        public List<Like> GetHouseLikeCount(int id)
        {
            return _db.Likes.Where(l => l.HouseId == id).ToList();
        }

        private Like GetLike(int id, Guid user)
        {
            var like = _db.Likes.FirstOrDefault(l => l.HouseId == id && l.UserId == user);
            return like;
        }

        public void Unlike(int id)
        {
            var unliked = _db.Likes.FirstOrDefault(like => like.HouseId == id);
            _db.Likes.Remove(unliked);
            _db.SaveChanges();
        }
    }
}
