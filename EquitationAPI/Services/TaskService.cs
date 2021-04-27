using EquitationAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = EquitationAPI.Models.Task;

namespace EquitationAPI.Services
{
    public class TaskService : ITaskService
    {
        public equimarocContext _equimarocContext { get; set; }

        public TaskService(equimarocContext equimarocCtx)
        {
            _equimarocContext = equimarocCtx;
        }

        public void AddTask(Models.Task task)
        {
            try
            {
                _equimarocContext.Tasks.Add(task);
                _equimarocContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Models.Task DeleteTask(int id)
        {
            try
            {
                Models.Task task = GetTask(id);
                _equimarocContext.Tasks.Remove(task);
                _equimarocContext.SaveChanges();
                return task;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Models.Task GetTask(int id)
        {
            try
            {
                return _equimarocContext.Tasks.Find((uint)id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Models.Task> GetTasks()
        {
            try
            {
                return _equimarocContext.Tasks.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateTask(Models.Task task)
        {
            try
            {
                _equimarocContext.Entry(task).State = EntityState.Modified;
                _equimarocContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
