using EquitationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquitationAPI.Services
{
    public class ClientService : IClientService
    {
        public equimarocContext _equimarocContext { get; set; }

        public ClientService(equimarocContext equimarocCtx)
        {
            _equimarocContext = equimarocCtx;
        }
        public IEnumerable<Client> GetClients()
        {
            try
            {
                return _equimarocContext.Clients.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
