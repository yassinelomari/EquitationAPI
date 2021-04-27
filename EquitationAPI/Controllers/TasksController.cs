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
        [HttpPost]
        public void Post([FromBody] Models.Task task)
        {
            _TaskService.AddTask(task);
        }

        // PUT api/<TasksController>/5
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
    }
}
