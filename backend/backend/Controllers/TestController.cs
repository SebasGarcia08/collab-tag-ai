// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using backend.Models;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
//
// namespace backend.Controllers
// {
//     [Microsoft.AspNetCore.Components.Route("api")]
//     [ApiController]
//     public class TestController
//     {
//
//         private readonly CollabtagContext _context;
//         private readonly ILogger<TestController> _logger;
//         
//         public TestController(CollabtagContext context, ILogger<TestController> logger)
//         {
//             _context = context;
//             _logger = logger;
//         }
//     
//         // GET: api/Test
//         [HttpGet("users")]
//         public ActionResult<List<CUser>> GetAllUsers()
//         {
//             _logger.LogInformation("\n \n \n THIS IS A TEST \n \n \n");
//             return _context.CUsers.ToList();
//         }
//         
//         [HttpGet("users/{id}")]
//         public ActionResult<CUser> GetUserById(int id)
//         {
//
//             try
//             {
//                 return _context.CUsers.Single(u => u.IdUser == id);
//             }
//             catch
//             {
//                 return new NotFoundResult();
//             }
//         }
//
//         // [HttpPost("user")]
//         // public async Task<ActionResult<CUser>> addUser(CUser user)
//         // {
//         //     _context.CUsers.Add(user);
//         //     await _context.SaveChangesAsync();
//         //
//         //     return CreatedAtActionResult(nameof(user), );
//         // }       
//     }
// }