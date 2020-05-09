using System;
using HouzeAPI.Entities;

namespace HouzeAPI.ViewModels
{
    public class CommentViewModel : Comment
    {
        public CommentViewModel()
        {
        }

        public string PostTime { get; set; }

        public string UserImage { get; set; }

        public string Name { get; set; }
    }
}
