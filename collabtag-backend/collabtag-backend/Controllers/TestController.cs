using System.Collections.Generic;
using System.Linq;
using collabtag_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using postgres_connection.Models;

namespace postgres_connection.Controllers
{   
    [Route("api")]
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