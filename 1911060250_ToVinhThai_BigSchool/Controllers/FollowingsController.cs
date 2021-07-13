using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _1911060250_ToVinhThai_BigSchool.DTOs;
using _1911060250_ToVinhThai_BigSchool.Models;
using Microsoft.AspNet.Identity;

namespace _1911060250_ToVinhThai_BigSchool.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FollweeId))
                return BadRequest("Following already exists!");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FollweeId
            };

            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFollowing(string id)
        {
            var userId = User.Identity.GetUserId();
            var following = _dbContext.Followings
                .SingleOrDefault(a => a.FollowerId == userId && a.FolloweeId == id);
            if (following == null)
                return NotFound();
            _dbContext.Followings.Remove(following);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
