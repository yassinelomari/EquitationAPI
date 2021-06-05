using EquitationAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquitationAPI.Services
{
    public class SeanceService : ISeanceService
    {
        public equimarocContext _equimarocContext { get; set; }

        public SeanceService(equimarocContext equimarocCtx)
        {
            _equimarocContext = equimarocCtx;
        }
        public void AddSeance(Seance seance)
        {
            try
            {
                _equimarocContext.Seances.Add(seance);
                _equimarocContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Seance DeleteSeance(int id)
        {
            try
            {
                Seance seance = GetSeance(id);
                _equimarocContext.Seances.Remove(seance);
                _equimarocContext.SaveChanges();
                return seance;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Seance GetSeance(int id)
        {
            try
            {
                return _equimarocContext.Seances.Find((uint)id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Seance> GetSeances()
        {
            try
            {
                return _equimarocContext.Seances.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateSeance(Seance seance)
        {
            try
            {
                _equimarocContext.Entry(seance).State = EntityState.Modified;
                _equimarocContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Group> GetDistinctGrp()
        {
            //return _equimarocContext.Seances.Select(m => m.SeanceGrpId).Distinct();
            return _equimarocContext.Seances
                .Join(
                    _equimarocContext.User,
                    entryPoint => entryPoint.MonitorId,
                    entry => entry.UserId,
                    (entryPoint, entry) => new { entryPoint, entry }
                ).GroupBy(g => g.entryPoint.SeanceGrpId)
                .Select(m => new Group(m.Key, m.Max(row => row.entryPoint.StartDate),
                    m.Max(r => r.entry.UserFname + " " + r.entry.UserLname + "|" + r.entry.UserId)));
        }

        public int GetMaxGrp()
        {
            return (int)_equimarocContext.Seances.Select(m => m.SeanceGrpId).Max();
        }

        public IEnumerable<Seance> GetSeanceByClientAndMonth(uint idClient, int month, int year)
        {
            return _equimarocContext.Seances
                .Where(s => s.StartDate.Month == month && s.ClientId == idClient && s.StartDate.Year == year)
                .ToList();
        }

        public IEnumerable<Seance> GetSeanceByMonitorAndMonth(uint idMonitor, int month, int year)
        {
            return _equimarocContext.Seances
                .Where(s => s.StartDate.Month == month && s.MonitorId == idMonitor && s.StartDate.Year == year)
                .ToList();
        }

        public IEnumerable<Seance> GetSeanceByMonitorAndDay(uint idMonitor, DateTime day)
        {
            return _equimarocContext.Seances
                .Where(s => s.StartDate.Month == day.Month && s.MonitorId == idMonitor 
                    && s.StartDate.Year == day.Year && s.StartDate.Day == day.Day)
                .ToList();
        }
    }
}
