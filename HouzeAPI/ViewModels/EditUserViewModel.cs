using System;
namespace HouzeAPI.ViewModels
{
    public class EditUserViewModel : UserViewModel
    {
        public EditUserViewModel()
        {
        }

        public string Password { get; set; }
    }
}
