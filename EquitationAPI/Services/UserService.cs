﻿using EquitationAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquitationAPI.Services
{
    public class UserService : IUserService
    {
        public equimarocContext _equimarocContext { get; set; }

        public UserService(equimarocContext equimarocCtx)
        {
            _equimarocContext = equimarocCtx;
        }
        public void AddUser(User user)
        {
            try
            {
                _equimarocContext.Users.Add(user);
                _equimarocContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User DeleteUser(int id)
        {
            try
            {
                User user = GetUser(id);
                _equimarocContext.Users.Remove(user);
                _equimarocContext.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public User GetUser(int id)
        {
            try
            {
                return _equimarocContext.Users.Find((uint)id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<User> GetUsers()
        {
            try
            {
                return _equimarocContext.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                _equimarocContext.Entry(user).State = EntityState.Modified;
                _equimarocContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
