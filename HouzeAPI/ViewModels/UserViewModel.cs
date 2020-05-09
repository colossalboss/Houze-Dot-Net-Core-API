using System;
namespace HouzeAPI.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
        }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Image { get; set; }

        public string Address { get; set; }

    }
}
