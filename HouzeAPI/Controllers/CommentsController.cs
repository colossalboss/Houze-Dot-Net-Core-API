using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using HouzeAPI.Entities;
using HouzeAPI.Services.Interfaces;
using HouzeAPI.ViewModels;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HouzeAPI.Controllers
{
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private readonly IComment _commentRepo;
        private readonly IMapper _mapper;
        private readonly IManager _managerRepo;

        public CommentsController(IComment comment, IMapper mapper, IManager manager)
        {
            _commentRepo = comment;
            _mapper = mapper;
            _managerRepo = manager;
        }

        // GET: api/values
        [HttpGet]
        public void Get()
        {
            //var comments = _commentRepo.GetComments();
            //var commentsViewModel = _mapper.Map < List<CommentViewModel>>(comments);
            //foreach(var comment in commentsViewModel)
            //{
            //    comment.PostTime = DateTime.Parse(comment.PostTime).Humanize();
            //    comment.Name = _managerRepo.GetUserName(comment.Owner);
            //    comment.UserImage = _managerRepo.GetUserImage(comment.Owner);
            //}
            //return Ok(commentsViewModel);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var comments = _commentRepo.GetCommentsByHouseId(id);
            var commentsViewModel = _mapper.Map<List<CommentViewModel>>(comments);
            foreach (var comment in commentsViewModel)
            {
                comment.PostTime = DateTime.Parse(comment.PostTime).Humanize();
                comment.Name = _managerRepo.GetUserName(comment.Owner);
                comment.UserImage = _managerRepo.GetUserImage(comment.Owner);
            }
            return Ok(commentsViewModel);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Comment comment)
        {
            if (comment == null)
                return BadRequest();

            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (user == null)
                return Unauthorized();

            comment.Owner = Guid.Parse(user);
            comment.TimeStamp = DateTime.Now;

            var savedComment = _commentRepo.AddComment(comment);
            return CreatedAtAction(nameof(GetById), new { Id = savedComment.Id }, savedComment);
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
