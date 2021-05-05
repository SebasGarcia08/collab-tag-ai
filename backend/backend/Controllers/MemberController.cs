using System.Collections.Generic;
using System.Linq;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
 
    [Microsoft.AspNetCore.Components.Route("")]
    [ApiController]
    public class MemberController
    {
        private readonly CollabtagContext _context;
        private readonly ILogger<MemberController> _logger;
        
        public MemberController(CollabtagContext context, ILogger<MemberController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("/api/members")]
        public ActionResult<List<Member>> getMembers()
        {
            try
            {
                return _context.Members.ToList();
            }
            catch
            {
                return new NotFoundResult();
            }
        }

        [HttpGet("/api/members/{projectId}")]
        public ActionResult<List<Member>> getMembersByProjectId(long projectId)
        {
            var members = _context.Members.Where(m => m.IdProject == projectId).ToList();
            return members;
        }
        
        
        [HttpPost("/api/members")]
        public ActionResult<Member> postMember(Member member)
        {
            try
            {
                var addedMember = _context.Add<Member>(member).Entity;
                _context.SaveChanges();

                return new CreatedResult("/api/members/"+ addedMember.IdProject,
                    addedMember);

            }
            catch
            {
                return new BadRequestResult();
            }
        }
        
        
        
    }
}