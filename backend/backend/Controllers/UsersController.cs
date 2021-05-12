using System;
using System.Collections.Generic;
using System.Linq;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    
    [Microsoft.AspNetCore.Components.Route("")]
    [ApiController]
    public class UsersController
    {
        private readonly CollabtagContext _context;
        private readonly ILogger<UsersController> _logger;
        
        public UsersController(CollabtagContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("api/users")]
        public ActionResult<List<CUser>> getUsers()
        {
            try
            {
                return _context.CUsers.ToList();
            }
            catch
            {
                return new NotFoundResult();
            }
        }
        
        [HttpGet("api/users/{userId}")]
        public ActionResult<CUser> GetUserById(string userId)
        {
            try
            {
                // return _context.CUsers
                //     .Include(user => user.Projects)
                //     .Where(u => u.IdUser == userId)
                //     .FirstOrDefault();
                return _context.CUsers.Single(u => u.IdUser.Equals(userId));
            }
            catch
            {
                return new NotFoundResult();
            }
        }

        [HttpPost("api/users")]
        public ActionResult<CUser> addUser(CUser user)
        {
            try
            {
                var addedUser = _context.Add<CUser>(user).Entity;
                _context.SaveChanges();
                
                return new CreatedResult("api/users/" + addedUser.IdUser, addedUser);
            }
            catch
            {
                return new BadRequestResult();
            }
            
        }

        [HttpDelete("api/users/{userId}")]
        public ActionResult<CUser> deleteUser(long userId)
        {
            var user = _context.CUsers.Find(userId);

            if (user == null)
            {
                return new NotFoundResult();
            }

            _context.CUsers.Remove(user);
            _context.SaveChanges();
            
            return user;
        }

    }
}