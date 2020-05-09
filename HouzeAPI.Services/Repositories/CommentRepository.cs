using System;
using System.Collections.Generic;
using System.Linq;
using HouzeAPI.Data;
using HouzeAPI.Entities;
using HouzeAPI.Services.Interfaces;

namespace HouzeAPI.Services.Repositories
{
    public class CommentRepository : IComment
    {
        private readonly AppDbContext _db;

        public CommentRepository(AppDbContext db)
        {
            _db = db;
        }

        public Comment AddComment(Comment comment)
        {
            _db.Comments.Add(comment);
            _db.SaveChanges();
            return comment;
        }

        public List<Comment> GetCommentsByHouseId(int id)
        {
            return _db.Comments.Where(c => c.HouseId == id).ToList();
        }
    }
}
