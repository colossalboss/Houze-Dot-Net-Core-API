using System;
using System.Collections.Generic;
using HouzeAPI.Entities;

namespace HouzeAPI.Services.Interfaces
{
    public interface IHouse
    {
        House AddHouse(House house);
        House GetHouseById(int id);
        House UpdateHouse(House house);
        List<House> GetHouses();
        List<House> GetUserHouses(Guid id);
    }
}
