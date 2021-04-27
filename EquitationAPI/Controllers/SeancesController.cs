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
    public class SeancesController : ControllerBase
    {
        public ISeanceService _SeanceService { get; set; }

        public SeancesController(ISeanceService SeanceService)
        {
            _SeanceService = SeanceService;
        }

        // GET: api/<SeancesController>
        [HttpGet]
        public IEnumerable<Seance> Get()
        {
            return _SeanceService.GetSeances();
        }

        // GET api/<SeancesController>/5
        [HttpGet("{id}")]
        public Seance Get(int id)
        {
            return _SeanceService.GetSeance(id);
        }

        // POST api/<SeancesController>
        [HttpPost]
        public void Post([FromBody] Seance seance)
        {
            _SeanceService.AddSeance(seance);
        }

        // PUT api/<SeancesController>/5
        [HttpPut]
        public void Put([FromBody] Seance seance)
        {
            _SeanceService.UpdateSeance(seance);
        }

        // DELETE api/<SeancesController>/5
        [HttpDelete("{id}")]
        public Seance Delete(int id)
        {
            return _SeanceService.DeleteSeance(id);
        }
    }
}
