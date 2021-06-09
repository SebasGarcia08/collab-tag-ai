using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using backend.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    
    [Microsoft.AspNetCore.Components.Route("")]
    [ApiController]
    public class DataController
    {
        private readonly CollabtagContext _context;
        private readonly ILogger<DataController> _logger;
        
        public DataController(CollabtagContext context, ILogger<DataController> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        // GET TAGGED DATA OR UNTAGGED DATA
        [HttpGet("api/data/list/{projectId}")]
        public ActionResult<List<Datum>> getDataByProjectId(long projectId, [FromQuery]bool tagged)
        {
            List<Datum> dataItems = null;
            
            if (tagged)
            {
                // Only tagged data
                dataItems = _context.Data.Where(d => (d.IdProject == projectId && d.IdClass != null)).ToList();
            }
            else
            {
                // Only untagged data
                dataItems = _context.Data.Where(d => (d.IdProject == projectId && d.IdClass == null)).ToList();
            }
            
            return dataItems; // TODO
        }
        
        // GET ALL DATA BY A GIVEN PROJECT
        [HttpGet("api/data/list/all/{projectId}")]
        public ActionResult<List<Datum>> getAllDataByProjectId(long projectId)
        {
            List<Datum> dataItems = _context.Data.Where(d => (d.IdProject == projectId)).ToList();

            return dataItems; // TODO
        }
        
        // GET AN SPECIFIC DATA ITEM
        [HttpGet("api/data/{dataId}")]
        public ActionResult<List<Datum>> getDataByProjectId(long dataId)
        {
            var dataItems = _context.Data.Where(d => d.IdData == dataId).ToList();
            
            return dataItems; // TODO
        }
        
        
        [HttpPut("api/data/{dataId}/{classId}")]
        public ActionResult<Datum> postData(long dataId, long classId)
        {
            try
            {
                Datum data = _context.Data.Single(d => d.IdData.Equals(dataId));
                data.IdClass = classId;
                _context.SaveChanges();

                return new CreatedResult("api/data/" + data.IdData, data);
            }
            catch
            {
                return new BadRequestResult();
            }
        }
        

        [HttpPost("api/data")]
        public ActionResult<Datum> postData(Photo photo)
        {
            _logger.LogInformation("\n \n \n DATA ENTRY \n \n \n");
            
            try
            {
                Datum data = new Datum();
                data.Image =  Encoding.ASCII.GetBytes(photo.Image);;
                data.IdProject = photo.IdProject;
                data.IdUser = photo.IdUser;
                data.Date = photo.Date;
                //data.IdClass = photo.IdClass;
                
                var addedData = _context.Add<Datum>(data).Entity;
                _context.SaveChanges();
                
                return new CreatedResult("api/data/" + addedData.IdData, addedData);
            }
            catch
            {
                return new BadRequestResult();
            }
        }

    }
}