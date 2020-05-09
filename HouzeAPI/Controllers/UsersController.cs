using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using HouzeAPI.Entities;
using HouzeAPI.Services.Interfaces;
using HouzeAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HouzeAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IManager _managerRepo;
        private readonly IHouse _houseRepo;
        private readonly UserManager<AppUser> userManager;

        public UsersController(IMapper mapper, IManager manager, IHouse house, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _managerRepo = manager;
            _houseRepo = house;
            this.userManager = userManager;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _managerRepo.GetUser(Guid.Parse(userId));
            return Ok(user);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = _managerRepo.GetUser(id).Result;
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return Ok(user);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpGet("userhouses/{id}")]
        public async Task<IActionResult> GetUserHouses(Guid id)
        {
            if (id == null)
                return BadRequest();

            var user = await userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound();

            var userHouses = _houseRepo.GetUserHouses(id);
            return Ok(userHouses);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]EditUserViewModel model)
        {
            if (model.UserId == null)
                return BadRequest();

            var user = await userManager.FindByIdAsync(model.UserId.ToString());
            if (user == null)
                return NotFound();

            user.Email = model.Email;
            user.Name = model.Name;
            user.Address = model.Address;
            model.Image = model.Image;

            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
                return NoContent();
            return BadRequest();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
