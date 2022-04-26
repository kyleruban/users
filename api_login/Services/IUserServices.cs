using System.Collections.Generic;
using api_login.Entities;
using System.Collections;
using api_login.Repository;

namespace api_login.Services
{
    public interface IUserServices
    {
        public IEnumerable<User> GetUsers();
        public User GetUserByName(string name);
        public User GetUserByID(int id);
        public User Login(string u, string p);
        public void CreateUser(User p);
        public void UpdateUsername(string name, User p);
        public void UpdatePassword(string id, string pwd, User p);
        public void DeleteUser(string name);

    }

}