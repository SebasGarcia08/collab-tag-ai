using System.Collections.Generic;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    
    [Microsoft.AspNetCore.Components.Route("")]
    [ApiController]
    public class ClassController
    {
        private readonly CollabtagContext _context;
        private readonly ILogger<ClassController> _logger;
        
        public ClassController(CollabtagContext context, ILogger<ClassController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost("api/classes")]
        public ActionResult<Class> addClass()
        {
            return new BadRequestResult(); // TODO
        }
        
        [HttpDelete("api/classes/{classId}")]
        public ActionResult<Class> addClass(long classId)
        {
            return new BadRequestResult(); // TODO
        }
        
    }
}