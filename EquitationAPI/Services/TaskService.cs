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

        public IEnumerable<Task> GetTaskByClientAndMonth(uint idUser, int month, int year)
        {
            return _equimarocContext.Tasks
                .Where(t => t.StartDate.Month == month && t.User_Fk == idUser && t.StartDate.Year == year)
                .ToList();
        }

        public IEnumerable<Task> GetTaskByUserAndDay(uint idUser, DateTime day)
        {
            return _equimarocContext.Tasks
                .Where(t => t.StartDate.Month == day.Month && t.User_Fk == idUser && t.StartDate.Year == day.Year 
                && t.StartDate.Day == day.Day)
                .ToList();
        }
    }
}
