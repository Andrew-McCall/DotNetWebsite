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
using andrew_mccall.DAO;
using andrew_mccall.Entites;

namespace andrew_mccall.Controllers
{   

    [ApiController]
    public class APIController : Controller
    {
        private readonly ILogger<APIController> _logger;
        private CatPictureDAO catPictureDAO = new CatPictureDAO();

        public APIController(ILogger<APIController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet("API/cat")]
        public IActionResult Cat()
        {
            return Ok(catPictureDAO.getRandom());
        }

        // [HttpGet("API/createCat/{url}")]
        // public IActionResult Cat(String url)
        // {
        //     catPictureDAO.Create(new CatPicture(url));
        //     return Ok(url);
        // }

        [HttpGet("API/ping")]
        public IActionResult Ping()
        {
            return Ok("Pong!");
        }

    
    }
}
