using System;
using System.ComponentModel.DataAnnotations;

namespace HouzeAPI.Entities
{
    public class Like
    {
        public Like()
        {
        }

        public int Id { get; set; }

        public int AppUserId { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public int HouseId { get; set; }
    }
}
