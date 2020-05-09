using System;
using System.ComponentModel.DataAnnotations;

namespace HouzeAPI.Entities
{
    public class Comment
    {
        public Comment()
        {
        }

        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        public int AppUserId { get; set; }

        public DateTime TimeStamp { get; set; }

        public Guid Owner { get; set; }

        [Required]
        public int HouseId { get; set; }
    }
}
