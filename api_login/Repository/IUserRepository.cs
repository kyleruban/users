using System.Collections.Generic;
using api_login.Entities;

namespace api_login.Repository
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
        public User GetUserByName(string name);
        public User Login(string u, string p);
        public void InsertUser(User u);
        public void UpdateUsername(string name, User u);
        public void UpdatePassword(string id, string pwd, User u);
        public void DeleteUser(string name);

    }

}