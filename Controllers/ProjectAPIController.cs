using System;
using System.Collections.Generic;
using System.Configuration;
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


        /// Public ///
        [HttpGet("Projects/GetAll")]
        public IActionResult GetAll(){
            return Ok(projectDAO.GetAll());
        }

        [HttpGet("Projects/GetOne")]
        public IActionResult GetOne(String id){
            if (string.IsNullOrEmpty(id)){
                return BadRequest("Id missing (Url Paramater)");
            }
            
            return Ok(projectDAO.GetOne(id));
        }
        

        /// Protected ///
        [HttpPut("Projects/Create")]
        public IActionResult Create(String key, [FromBody] Project project){

            if (!key.Equals(ConfigurationManager.AppSettings["API_MASTER_KEY"])){
                return Unauthorized("You must provide the key to create!");
            }

            if (project == null || project.Title == null || project.Description == null || project.Link == null || project.Image == null){
                return BadRequest(project);
            }

            return Ok(projectDAO.Create(project));
        }

        [HttpPost("Projects/Update")]
        public IActionResult Update(String key, [FromBody] Project project){

            if (!key.Equals(ConfigurationManager.AppSettings["API_MASTER_KEY"])){
                return Unauthorized("You must provide the key to update!");
            }

            if (project == null || project.Title == null || project.Description == null || project.Link == null || project.Image == null ){
                return BadRequest(project);
            }

            return Ok(projectDAO.Update(project));
        }

        [HttpDelete("Projects/Delete")]
        public IActionResult Delete(String key, String id){

            if (!key.Equals(ConfigurationManager.AppSettings["API_MASTER_KEY"])){
                return Unauthorized("You must provide the key to update!");
            }

            if (string.IsNullOrEmpty(id)){
                return BadRequest("Id missing (Url Paramater)");
            }

            return Ok(projectDAO.Delete(id));
        }

    }
}