using System.Collections.Generic;
using System.Linq;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<Datum>> getDataByProjectId(long projectId)
        {
            var dataItems = _context.Data.Where(d => d.IdProject == projectId).ToList();
            return dataItems; // TODO
        }

        


        }
}