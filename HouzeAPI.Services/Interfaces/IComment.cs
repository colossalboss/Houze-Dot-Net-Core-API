using System;
using System.Collections.Generic;
using HouzeAPI.Entities;

namespace HouzeAPI.Services.Interfaces
{
    public interface IComment
    {
        Comment AddComment(Comment comment);

        List<Comment> GetCommentsByHouseId(int id);


    }
}
