using EquitationAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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

        public Client GetClient(int id)
        {
            try
            {
                return _equimarocContext.Clients.Find((uint) id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddClient(Client client)
        {
            try
            {
                _equimarocContext.Clients.Add(client);
                _equimarocContext.SaveChanges();

            }
            catch (Exception ex)
            {
                /*var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", client.Photo);
                File.Delete(path);*/
                throw new Exception(ex.Message);
            }
        }

        public Client DeleteClient(int id)
        {
            try
            {
                Client client = GetClient(id);
                _equimarocContext.Clients.Remove(client);
                _equimarocContext.SaveChanges();
                return client;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateClient(Client client)
        {
            try
            {
                _equimarocContext.Entry(client).State = EntityState.Modified;
                _equimarocContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
