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
                
                var addedProject = _context.Add<Project>(project).Entity;
                _context.SaveChanges();
        
                return new CreatedResult("api/projects/" + addedProject.IdProject, addedProject);
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

        [HttpGet("api/project/{userId}")]
        public ActionResult<List<Project>> getProjectsByUserId(long userId)
        {
            var projects = _context.Projects.Where(p => p.IdUser == userId).ToList();
            return projects;
        }
            
        // [HttpGet("api/projects/{projectId}/classes")]
        // public ActionResult<List<Class>> getProjectClasses(long projectId)
        // {
        //     var project = _context.Projects
        //         .Include(project => project.Classes)
        //         .FirstOrDefault(project => project.IdProject == projectId);
        //     
        //     
        //     return project == null ? new NotFoundResult() : project.Classes.ToList();
        // }
        
    }
}