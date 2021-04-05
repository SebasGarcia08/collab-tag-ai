using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using capstone.Models;
using Microsoft.AspNetCore.Http;

namespace capstone.Controllers
{
    [Produces("application/json")]
    [Route("api/Person")]
    public class PersonController : Controller
    {
        [HttpGet]
        public Person Get()
        {
            Person p = new Person() {Name = "Hello from the backeeeeeend"};
            return p;
        }
    }
}