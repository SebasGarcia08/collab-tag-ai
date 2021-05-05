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
    public class ProjectsController
    {
        private readonly CollabtagContext _context;
        private readonly ILogger<ProjectsController> _logger;
        
        public ProjectsController(CollabtagContext context, ILogger<ProjectsController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpGet("api/projects")]
        public ActionResult<List<Project>> getProjects()
        {
            try
            {
                return _context.Projects.ToList();
            }
            catch
            {
                return new NotFoundResult();
            }
        }

        [HttpGet("api/projects/{projectId}")]
        public ActionResult<Project> getProjectsById(long projectId)
        {
            try
            {
                return _context.Projects.SingleOrDefault(p => p.IdProject == projectId);
            }
            catch
            {
                return new NotFoundResult();
            }
        } 
        
        [HttpPost("api/projects")]
        public ActionResult<Project> postProject(Project project)
        {
            try
            {
                // long userId = project.IdUser;
                // CUser user = _context.CUsers.SingleOrDefault(u => u.IdUser == userId);
                //
                // project.IdUserNavigation = user;
                
                EntityEntry<Project> addedProject = _context.Add<Project>(project);
                _context.SaveChanges();
        
                return new CreatedResult("api/projects/" + addedProject.Entity.IdProject, addedProject.Entity);
            }
            catch
            {
                return new BadRequestResult(); // TODO
            }
        }
        
        [HttpDelete("api/projects/{projectId}")]
        public ActionResult<Project> deleteProject(long projectId)
        {
            var project = _context.Projects.Find(projectId);
            if (project == null)
            {
                return new NotFoundResult();
            }
            
            _context.Projects.Remove(project);
            _context.SaveChanges();

            return project;
        }

        // [HttpGet("api/projects/{projectId}/classes")]
        // public ActionResult<Class> getProjectClasses(long projectId)
        // {
        //     var project = _context.Projects
        //         .Include(project => project.Classes)
        //         .FirstOrDefault(project => project.IdProject == projectId);
        //
        //     _logger.LogInformation(project.Classes.GetType().ToString());
        //
        //
        //     return new NotFoundResult();
        //     //return project == null ? new NotFoundResult() : project.Classes;
        // }
        //
    }
}