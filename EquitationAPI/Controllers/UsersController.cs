using EquitationAPI.Models;
using EquitationAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EquitationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUserService _userService { get; set; }

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetUsers();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userService.GetUser(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userService.AddUser(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public void Put([FromBody] User user)
        {
            _userService.UpdateUser(user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public User Delete(int id)
        {
            return _userService.DeleteUser(id);
        }
    }
}
