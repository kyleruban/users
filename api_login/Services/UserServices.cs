using System.Collections.Generic;
using api_login.Entities;
using System.Collections;
using api_login.Repository;

namespace api_login.Services
{
    public class UserService : IUserServices
    {
        private IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> myList = _repo.GetAll();
            //sort list 
            return myList;
        }

        public User GetUserByName(string name)
        {
            return _repo.GetUserByName(name);
        }

        public User GetUserByID(int id)
        {
            IEnumerable<User> mylist = _repo.GetAll();
            foreach (User m in mylist)
            {
                if (m.Id == id)
                    return m;
            }
            return null;
        }
        public User Login(string u, string p)
        {
            return _repo.Login(u, p);
        }
        public void CreateUser(User m)
        {
            _repo.InsertUser(m);
        }
        public void UpdateUsername(string name, User m)
        {
            _repo.UpdateUsername(name, m);
        }
        public void UpdatePassword(string id, string pwd, User m)
        {
            _repo.UpdatePassword(id, pwd, m);
        }
        public void DeleteUser(string name)
        {
            _repo.DeleteUser(name);
        }



    }



}