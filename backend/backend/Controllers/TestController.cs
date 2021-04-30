using System.Collections.Generic;
using System.Linq;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api")]
    [ApiController]
    public class TestController
    {

        private readonly CollabtagContext _context;
        private readonly ILogger<TestController> _logger;
        
        public TestController(CollabtagContext context, ILogger<TestController> logger)
        {
            _context = context;
            _logger = logger;
        }
    
        // GET: api/Test
        [HttpGet("users")]
        public ActionResult<List<CUser>> GetAllUsers()
        {
            _logger.LogInformation("\n \n \n THIS IS A TEST \n \n \n");
            return _context.CUsers.ToList();
        }
        
        [HttpGet("users/{id}")]
        public ActionResult<List<CUser>> GetUserById()
        {
            _logger.LogInformation("\n \n \n THIS IS A TEST \n \n \n");
            return _context.CUsers.ToList();
        }
    }
}