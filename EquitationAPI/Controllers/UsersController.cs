using EquitationAPI.Models;
using EquitationAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EquitationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUserService _userService { get; set; }

        public IClientService _clientService { get; set; }
        [Obsolete]
        private IHostingEnvironment _hostingEnvironment;

        public UsersController(IUserService userService, IHostingEnvironment hostingEnvironment,
                            IClientService clientService)
        {
            _userService = userService;
            _clientService = clientService;
            _hostingEnvironment = hostingEnvironment;
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
        public IActionResult Post([FromBody] User user)
        {
            string fileName = user.UserFname + "_" + user.UserLname + DateTime.Now.ToString("MM_dd_HH_mm_ss") + ".jpg";
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);
            System.IO.File.WriteAllBytes(path, Convert.FromBase64String(user.Userphoto));
            user.UserPasswd = BC.HashPassword(user.UserPasswd);
            user.Userphoto = fileName;
            _userService.AddUser(user);
            return Content("{ \"status\":\"SUCCESS\", \"photo\":\""+ fileName + "\"}", "application/json");
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            _userService.UpdateUser(user);
            return Content("{ \"status\":\"SUCCESS\" }", "application/json");
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public User Delete(int id)
        {
            User user = _userService.DeleteUser(id);
            if(user.Userphoto != "default.jpg")
            {
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", user.Userphoto);
                System.IO.File.Delete(path);
            }
            
            return user;
        }

        [HttpGet("disable/{id}")]
        public IActionResult Disable(int id)
        {
            User user = _userService.GetUser(id);
            user.IsActive = false;
            _userService.UpdateUser(user);
            return Content("{ \"status\":\"SUCCESS\" }", "application/json");
        }

        [DisableCors]
        [HttpPut("photo/")]
        public IActionResult ChangeImg([FromBody] Image image)
        {
            User user = _userService.GetUser(image.UserId);
            string fileName = user.UserFname + "_" + user.UserLname + DateTime.Now.ToString("MM_dd_HH_mm_ss") + ".jpg";
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);
            System.IO.File.WriteAllBytes(path, Convert.FromBase64String(image.ImageBase64));
            string OldPhoto = user.Userphoto;
            user.Userphoto = fileName;
            _userService.UpdateUser(user);
            if (user.Userphoto != "default.jpg")
            {
                var path1 = Path.Combine(_hostingEnvironment.WebRootPath, "images", OldPhoto);
                System.IO.File.Delete(path1);
            }
            return Content("{ \"status\":\"SUCCESS\" }", "application/json");
        }

        [HttpGet("enable/{id}")]
        public IActionResult Enable(int id)
        {
            User user = _userService.GetUser(id);
            user.IsActive = true;
            _userService.UpdateUser(user);
            return Content("{ \"status\":\"SUCCESS\" }", "application/json");
        }

        [HttpGet("login/{login}/{pwd}")]
        public IActionResult Login(string login, string pwd)
        {
            Client client = _clientService.LoginVerification(login);
            if (client == null || !BC.Verify(pwd, client.Passwd))
            {
                User user = _userService.LoginVerification(login);
                if (user == null || !BC.Verify(pwd, user.UserPasswd))
                {
                    // authentication failed
                    return Content("{ \"status\":\"FAIL\" }", "application/json");
                }
                else
                {
                    return Content("{ \"status\":\"SUCCESS\", \"role\":\""+ user.UserType +"\", \"id\":" + user.UserId + " }", "application/json");
                }
            } 
            else
            {
                // authentication successful
                return Content("{ \"status\":\"SUCCESS\", \"role\":\"CLIENT\", \"id\":" + client.ClientId + " }", "application/json");
            }
        }
    }
}
