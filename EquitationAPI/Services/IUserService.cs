using EquitationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquitationAPI.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void AddUser(User user);

        User DeleteUser(int id);
        void UpdateUser(User user);

        User LoginVerification(string login);
    }
}
