using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api_login.Entities;
using api_login.Services;

namespace api_login.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserServices _service;
        public UserController(ILogger<UserController> logger, IUserServices services)
        {
            _logger = logger;
            _service = services;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            IEnumerable<User> list = _service.GetUsers();
            if (list != null)
            {
                return Ok(list);
            }
            else
                return BadRequest();
        }

        [HttpGet("{Username}/username", Name = "GetUser")]
        public IActionResult GetUserByName(string Username)
        {
            User obj = _service.GetUserByName(Username);
            if (obj != null)
                return Ok(obj);
            return BadRequest();
        }

        [HttpPost]
        public IActionResult CreateUser(User m)
        {
            _service.CreateUser(m);
            // might need to add code to return if successful
            return NoContent();
        }

        [HttpGet("{u}/uname/{p}/pwd")]
        public IActionResult Login(string u, string p)
        {
            User obj = _service.Login(u, p);
            if (obj != null)
            {
                return Ok(obj);
            }
            return BadRequest();
        }

        [HttpPut("{Username}/updateUname")]
        public IActionResult UpdateUsername(string Username, User userIn)
        {
            _service.UpdateUsername(Username, userIn);
            return NoContent();
        }

        [HttpPut("{Id}/{Password}/{Username}")]
        public IActionResult UpdatePassword(string Id, string Password, User pwdIn)
        {
            _service.UpdatePassword(Id, Password, pwdIn);
            return NoContent();
        }

        [HttpDelete("{Username}")]
        public IActionResult DeleteUser(string Username)
        {
            _service.DeleteUser(Username);
            return NoContent();
        }
    }
}