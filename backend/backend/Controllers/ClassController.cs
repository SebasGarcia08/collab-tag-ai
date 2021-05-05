using System.Collections.Generic;
using System.Linq;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        public ActionResult<Class> addClass(Class c)
        {
            try
            {
                var addedClass = _context.Add<Class>(c).Entity;
                _context.SaveChanges();

                return new CreatedResult("/api/classes/" + addedClass.IdClass, addedClass);
            }
            catch
            {
                return new BadRequestResult();
            }
        }
        
        [HttpDelete("api/classes/{classId}")]
        public ActionResult<Class> addClass(long classId)
        {
            return new BadRequestResult(); // TODO
        }

        [HttpGet("api/classes/{projectId}")]
        public ActionResult<List<Class>> getClassesByProjectId(long projectId)
        {
            var classes = _context.Classes.Where(c => c.IdProject == projectId).ToList();
            return classes;

        }
    }
}