using System;
namespace HouzeAPI.ViewModels
{
    public class HouseStats
    {
        public HouseStats()
        {
        }

        public int Id { get; set; }

        public string HouseType { get; set; }

        public int NumberOfLikes { get; set; }
    }
}
