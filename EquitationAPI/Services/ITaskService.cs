using System;
using EquitationAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquitationAPI.Services
{
    public interface ITaskService
    {
        IEnumerable<Models.Task> GetTasks();
        Models.Task GetTask(int id);
        void AddTask(Models.Task task);
        Models.Task DeleteTask(int id);
        void UpdateTask(Models.Task task);
    }
}
