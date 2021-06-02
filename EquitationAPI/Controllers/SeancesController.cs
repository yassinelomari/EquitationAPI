using EquitationAPI.Models;
using EquitationAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EquitationAPI.Controllers
{
    [EnableCors("MyPolicy")]
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
        [DisableCors]
        [HttpPost]
        public IActionResult Post([FromBody] Seance seance)
        {
            _SeanceService.AddSeance(seance);
            string status = "SUCCESS";
            return Content("{ \"status\":\"SUCCESS\" }", "application/json");
        }

        // PUT api/<SeancesController>/5
        [DisableCors]
        [HttpPut]
        public IActionResult Put([FromBody] Seance seance)
        {
            _SeanceService.UpdateSeance(seance);
            string status = "SUCCESS";
            return Content("{ \"status\":\"SUCCESS\" }", "application/json");
        }

        // DELETE api/<SeancesController>/5
        [HttpDelete("{id}")]
        public Seance Delete(int id)
        {
            return _SeanceService.DeleteSeance(id);
        }

        [HttpGet("groups/")]
        public IEnumerable<Group> GetGroups()
        {
            return _SeanceService.GetDistinctGrp();
        }

        [HttpGet("groupIdMax/")]
        public IActionResult GetGroupIdMax()
        {
            int maxId = _SeanceService.GetMaxGrp();
            return Content("{ \"id\":\""+ maxId + "\" }", "application/json");
        }

        [HttpGet("{idClient}/{month}/{year}")]
        public IEnumerable<Seance> Get(int idClient, int month, int year)
        {
            return _SeanceService.GetSeanceByClientAndMonth((uint)idClient, month, year);
        }
    }
}
