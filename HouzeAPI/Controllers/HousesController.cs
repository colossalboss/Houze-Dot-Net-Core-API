using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HouzeAPI.Entities;
using HouzeAPI.Services.Interfaces;
using HouzeAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HouzeAPI.Controllers
{
    [Route("api/[controller]")]
    public class HousesController : Controller
    {
        private readonly IHouse _houseRepo;
        private readonly IMapper _mapper;

        public HousesController(IHouse house, IMapper mapper)
        {
            _houseRepo = house;
            _mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_houseRepo.GetHouses());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id == 0)
                return NotFound();

            var house = _houseRepo.GetHouseById(id);

            if (house == null)
                return BadRequest();

            return Ok(house);
        }

        // GET api/values/5
        [HttpGet("stats")]
        public IActionResult GetById()
        {
            var houses = _houseRepo.GetHouseStats();
            var housesStats = _mapper.Map<List<HouseStats>>(houses);



            var targetList = new List<HouseStats>();


            foreach (var house in houses)
            {
                var existing = targetList.FirstOrDefault(h => h.HouseType.ToLower() == house.Type.ToLower());

                if (existing == null)
                {
                    var count = houses.Select(h => h.Likes.Count).Sum();
                    var stats = new HouseStats
                    {
                        NumberOfLikes = count,
                        HouseType = house.Type
                    };
                    targetList.Add(stats);
                }

            }

            return Ok(targetList);
        }

        // POST api/values
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody]HouseViewModel house)
        {
            var userId = HttpContext.User.Claims.First().Value;
            house.AppUserId = Guid.Parse(userId);
            var savedHouse = _houseRepo.AddHouse(house);
            //return Ok(savedHouse);
            return CreatedAtAction(nameof(GetById), new { id = savedHouse.Id }, savedHouse);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]House house)
        {

            if (id == house.Id)
            {
                var houseToUpdate = _houseRepo.GetHouseById(id);
                if (houseToUpdate != null)
                {
                    _houseRepo.UpdateHouse(house);
                }
            }
                

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
