using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HouzeAPI.Data;
using HouzeAPI.Entities;
using HouzeAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HouzeAPI.Services.Repositories
{
    public class HouseRepository : IHouse
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public HouseRepository(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public House AddHouse(House house)
        {
            _db.Houses.Add(house);
            _db.SaveChanges();
            return house;
        }

        public House GetHouseById(int id)
        {
            return _db.Houses.FirstOrDefault(h => h.Id == id);
        }

        public List<House> GetHouses()
        {
            return _db.Houses.ToList();
        }

        public List<House> GetHouseStats()
        {
            var houses = _db.Houses.Include(h => h.Likes).ToList();
            return houses;
        }

        public List<House> GetUserHouses(Guid id)
        {
            return _db.Houses.Where(h => h.AppUserId == id).ToList();
        }

        public House UpdateHouse(House house)
        {
            var houseToUpdate = _db.Houses.FirstOrDefault(h => h.Id == house.Id);
            houseToUpdate.Address = house.Address;
            houseToUpdate.Image = house.Image;
            houseToUpdate.Phone = house.Phone;
            houseToUpdate.Description = house.Description;
            houseToUpdate.School = house.School;
            houseToUpdate.Type = house.Type;

            _db.Houses.Update(houseToUpdate);
            _db.SaveChanges();
            return house;
        }
    }
}
