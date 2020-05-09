using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouzeAPI.Entities
{
    public class House
    {
        public House()
        {
        }

        public int Id { get; set; }

        [Required]
        public string Image { get; set; }

        public string School { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public Guid AppUserId { get; set; }

        public List<Like> Likes { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
