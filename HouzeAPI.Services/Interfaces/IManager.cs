using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HouzeAPI.Entities;

namespace HouzeAPI.Services.Interfaces
{
    public interface IManager
    {
        string GetUserImage(Guid id);

        string GetUserName(Guid id);

        Task<AppUser> GetUser(Guid id);

    }
}
