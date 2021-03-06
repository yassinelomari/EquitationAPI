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
    public class TasksController : ControllerBase
    {
        public ITaskService _TaskService { get; set; }

        public TasksController(ITaskService TaskService)
        {
            _TaskService = TaskService;
        }
        // GET: api/<TasksController>
        [HttpGet]
        public IEnumerable<Models.Task> Get()
        {
            return _TaskService.GetTasks();
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public Models.Task Get(int id)
        {
            return _TaskService.GetTask(id);
        }

        // POST api/<TasksController>
        [DisableCors]
        [HttpPost]
        public IActionResult Post([FromBody] Models.Task task)
        {
            _TaskService.AddTask(task);
            return Content("{ \"status\":\"SUCCESS\" }", "application/json");
        }

        // PUT api/<TasksController>/5
        [DisableCors]
        [HttpPut]
        public void Put([FromBody] Models.Task task)
        {
            _TaskService.UpdateTask(task);
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public Models.Task Delete(int id)
        {
            return _TaskService.DeleteTask(id);
        }

        [HttpGet("{idUser}/{month}/{year}")]
        public IEnumerable<Models.Task> Get(int idUser, int month, int year)
        {
            return _TaskService.GetTaskByClientAndMonth((uint)idUser, month, year);
        }

        [HttpGet("{idUser}/{day}")]
        public IEnumerable<Models.Task> Get(int idUser, string day)
        {
            DateTime day2 = DateTime.Parse(day, null, System.Globalization.DateTimeStyles.RoundtripKind);
            return _TaskService.GetTaskByUserAndDay((uint)idUser, day2);
        }
    }
}
