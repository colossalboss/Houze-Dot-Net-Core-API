using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HouzeAPI.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
        }

        public string Image { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

    }
}
