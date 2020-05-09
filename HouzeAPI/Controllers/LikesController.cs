using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HouzeAPI.Entities;
using HouzeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HouzeAPI.Controllers
{
    [Route("api/[controller]")]
    public class LikesController : Controller
    {
        private readonly ILikes _likesRepo;
        private readonly IHouse _houseRepo;

        public LikesController(ILikes likes, IHouse house)
        {
            _likesRepo = likes;
            _houseRepo = house;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_likesRepo.GetHouseLikeCount(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Like like)
        {
            if (like == null)
                return BadRequest();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();

            var house = _houseRepo.GetHouseById(like.HouseId);
            if (house == null)
                return NotFound();

            like.UserId = Guid.Parse(userId);

            var savedLike = _likesRepo.AddLike(like, Guid.Parse(userId));
            return CreatedAtAction(nameof(GetById), new { Id = savedLike.Id }, savedLike);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
