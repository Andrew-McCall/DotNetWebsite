using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using andrew_mccall.Entites;
using andrew_mccall.DAO;


namespace andrew_mccall.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private LoginDAO loginDAO = new LoginDAO();

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

         [HttpGet("Login/getToken")]
        public IActionResult GetToken([FromBody] Login login){

            if (string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password)){
                return BadRequest("Missing Username or Password");
            }
            
            login.hashPassword();

            if (loginDAO.CheckCredentials(login)){
                return Ok(login.GenerateSession());
            }

            return BadRequest("Incorrect Username or Password");
        }

    }
}
