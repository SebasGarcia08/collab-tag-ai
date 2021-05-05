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
    public class DataController
    {
        private readonly CollabtagContext _context;
        private readonly ILogger<DataController> _logger;
        
        public DataController(CollabtagContext context, ILogger<DataController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("api/data/{projectId}")]
        public ActionResult<List<Datum>> getDataByProjectId(long projectId, [FromQuery]bool tagged)
        {
            var dataItems = _context.Data.Where(d => d.IdProject == projectId).ToList();

            if (tagged)
            {
                // TODO make query for untagged data
            }
            
            return dataItems; // TODO
        }

        [HttpPost("api/data")]
        public ActionResult<Datum> postData(Datum data)
        {
            try
            {
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