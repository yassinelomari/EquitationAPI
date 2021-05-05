using EquitationAPI.Models;
using EquitationAPI.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EquitationAPI.Controllers
{
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
        [HttpPost]
        public void Post([FromForm] Client client, IFormFile image)
        {
            var fileName = DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + image.FileName;
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);
            var stream = new FileStream(path, FileMode.Append);
            image.CopyTo(stream);
            client.Photo = fileName;
            _clientSvc.AddClient(client);
        }
        //[HttpPost]
        //public void Post([FromBody] Client client)
        //{
        //    _clientSvc.AddClient(client);
        //}

        // PUT api/<ClientsController>/5
        [HttpPut]
        public void Put(Client client)
        {
            _clientSvc.UpdateClient(client);
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public Client Delete(int id)
        {
            Client client = _clientSvc.DeleteClient(id);
            //string photoName = client.Photo.Replace("jpeg", "jpg");
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", client.Photo);
            System.IO.File.Delete(path);
            return client;
        }

        [HttpGet("photo/{name}")]
        public IActionResult GetImg(string name)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", name);
            var image = System.IO.File.OpenRead(path);
            return File(image, "image/jpeg");
        }
    }
}
