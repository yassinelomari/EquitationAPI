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
    }
}
