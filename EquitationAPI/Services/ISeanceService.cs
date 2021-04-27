﻿using EquitationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquitationAPI.Services
{
    public interface ISeanceService
    {
        IEnumerable<Seance> GetSeances();
        Seance GetSeance(int id);
        void AddSeance(Seance seance);
        Seance DeleteSeance(int id);
        void UpdateSeance(Seance seance);
    }
}