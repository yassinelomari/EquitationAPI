using EquitationAPI.Models;
using EquitationAPI.Services;
using ImageMagick;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private IClientService _clientSvc;
        [Obsolete]
        private IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public ClientsController(IClientService clientService, IHostingEnvironment hostingEnvironment)
        {
            _clientSvc = clientService;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/<ClientsController>
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return _clientSvc.GetClients();
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public Client Get(int id)
        {
            return _clientSvc.GetClient(id);
        }

        // POST api/<ClientsController>
        [DisableCors]
        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            string fileName = client.FName + "_" + client.LName + DateTime.Now.ToString("MM_dd_HH_mm_ss") + ".jpg";
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);
            System.IO.File.WriteAllBytes(path, Convert.FromBase64String(client.Photo));
            client.Passwd = BC.HashPassword(client.Passwd);
            client.Photo = fileName;
            _clientSvc.AddClient(client);
            string status = "SUCCESS";
            return Content("{ \"status\":\"SUCCESS\" }", "application/json");
        }

        // PUT api/<ClientsController>/5
        [HttpPut]
        public IActionResult Put(Client client)
        {
            _clientSvc.UpdateClient(client);
            return Content("{ \"status\":\"SUCCESS\" }", "application/json");
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public Client Delete(int id)
        {
            Client client = _clientSvc.DeleteClient(id);
            //string photoName = client.Photo.Replace("jpeg", "jpg");
            if (client.Photo != "default.jpg")
            {
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", client.Photo);
                System.IO.File.Delete(path);
            }
            return client;
        }

        [HttpGet("photo/{name}")]
        public IActionResult GetImg(string name)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", name);
            var image = System.IO.File.OpenRead(path);
            return File(image, "image/jpeg");
        }

        [HttpGet("photoById/{id}")]
        public IActionResult GetImgById(int id)
        {
            Client client = _clientSvc.GetClient(id);
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", client.Photo);
            var image = new FileInfo(path);
            var optimizer = new ImageOptimizer();
            optimizer.Compress(image);
            return File(image.OpenRead(), "image/jpeg");
        }

        [DisableCors]
        [HttpPut("photo/")]
        public IActionResult ChangeImg([FromBody] Image image)
        {
            Client client = _clientSvc.GetClient(image.UserId);
            string fileName = client.FName + "_" + client.LName + DateTime.Now.ToString("MM_dd_HH_mm_ss") + ".jpg";
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);
            System.IO.File.WriteAllBytes(path, Convert.FromBase64String(image.ImageBase64));
            string OldPhoto = client.Photo;
            client.Photo = fileName;
            _clientSvc.UpdateClient(client);
            if (client.Photo != "default.jpg")
            {
                var path1 = Path.Combine(_hostingEnvironment.WebRootPath, "images", OldPhoto);
                System.IO.File.Delete(path1);
            }
            return Content("{ \"status\":\"SUCCESS\" }", "application/json");
        }

        [HttpGet("disable/{id}")]
        public IActionResult Disable(int id)
        {
            Client client = _clientSvc.GetClient(id);
            client.IsActive = false;
            _clientSvc.UpdateClient(client);
            return Content("{ \"status\":\"SUCCESS\" }", "application/json");
        }

        [HttpGet("enable/{id}")]
        public IActionResult Enable(int id)
        {
            Client client = _clientSvc.GetClient(id);
            client.IsActive = true;
            _clientSvc.UpdateClient(client);
            return Content("{ \"status\":\"SUCCESS\" }", "application/json");
        }

        [HttpGet("rating/{id}/{rate}")]
        public IActionResult rating(int id, string rate)
        {
            Client client = _clientSvc.GetClient(id);
            client.Notes = rate;
            _clientSvc.UpdateClient(client);
            return Content("{ \"status\":\"SUCCESS\" }", "application/json");
        }



    }
}
