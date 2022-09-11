using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using andrew_mccall.DAO;
using andrew_mccall.Entites;

namespace andrew_mccall.Controllers
{
    public class ProjectAPIController : Controller
    {
        private readonly ILogger<ProjectAPIController> _logger;
        private ProjectDAO projectDAO = new ProjectDAO();

        public ProjectAPIController(ILogger<ProjectAPIController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Projects/GetAll")]
        public IActionResult GetAll(){
            projectDAO.GetAll();
            return Ok("lol");
        }

    }
}