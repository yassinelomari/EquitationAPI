using EquitationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquitationAPI.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetClients();
        Client GetClient(int id);
        void AddClient(Client client);

        Client DeleteClient(int id);
        void UpdateClient(Client client);

        Client LoginVerification(string login);
    }
}
