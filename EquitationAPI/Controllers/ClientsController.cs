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
    public class ClientsController : ControllerBase
    {
        public IClientService _clientSvc { get; set; }

        public ClientsController(IClientService clientService)
        {
            _clientSvc = clientService;

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
        public void Post([FromBody] Client client)
        {
            _clientSvc.AddClient(client);
        }

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
            return _clientSvc.DeleteClient(id);
        }
    }
}
