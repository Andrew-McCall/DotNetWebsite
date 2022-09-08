using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using andrew_mccall.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace andrew_mccall.Controllers
{   

    [ApiController]
    public class APIController : Controller
    {
        private readonly ILogger<APIController> _logger;

        public APIController(ILogger<APIController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet("API/index/{id}")]
        public IActionResult Index(int id)
        {
            return Ok(id);
        }

        [HttpGet("API/ping")]
        public IActionResult ping()
        {
            return Ok("Pong!");
        }

    
    }
}
