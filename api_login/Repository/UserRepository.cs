using System.Collections.Generic;
using api_login.Entities;
using MySql.Data.MySqlClient;
using System;

namespace api_login.Repository
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> Users2 = new List<User>(10)
        {
            //new Movie{Name = "Citizen Kane",Genre = "Drama," ,Year = 1941},
            //new Movie{Name = "The Wizard of Oz",Genre = "Drama,",Year =  1939},
            //new Movie{Name = "The Godfather",Genre = "Crime",Year =  1972}
        };

        private MySqlConnection _connection;
        public UserRepository()
        {
            string connectionString = "server=localhost;userid=root;password=kyleruban;database=website_database";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }
        ~UserRepository()
        {
            _connection.Close();
        }

        public IEnumerable<User> GetAll()
        {
            var statement = "Select * from Users";
            var command = new MySqlCommand(statement, _connection);
            var results = command.ExecuteReader();

            List<User> newList = new List<User>(1000);
            while (results.Read())
            {
                User m = new User
                {
                    Id = (int)results[0],
                    Username = (string)results[1],
                    Password = (string)results[2]
                };
                newList.Add(m);

            }
            results.Close();
            return newList;

            //return movies;
        }

        public User GetUserByName(string name)
        {
            //need statement and command
            var statement = "Select * from Users where Username = @newName ";
            var command = new MySqlCommand(statement, _connection); //always takes statement and connection
            command.Parameters.AddWithValue("@newName", name);

            var results = command.ExecuteReader();
            User m = null;
            if (results.Read())
            {
                m = new User
                {
                    Id = (int)results[0],
                    Username = (string)results[1],
                    Password = (string)results[2]
                };
            }
            results.Close();
            return m;
        }

        public void InsertUser(User m)
        {
            var statement = "Insert into Users (Username, Password) Values(@n,@p)";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@n", m.Username);
            command.Parameters.AddWithValue("@p", m.Password);

            int result = command.ExecuteNonQuery();

            Console.WriteLine(result);

        }

        public User Login(string username, string password)
        {
            var statement = "SELECT * FROM Users WHERE Password = @enteredPassword && Username = @enteredUsername";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@enteredUsername", username);
            command.Parameters.AddWithValue("@enteredPassword", password);

            var results = command.ExecuteReader();
            User m = null;
            if (results.Read())
            {
                m = new User
                {
                    Id = (int)results[0],
                    Username = (string)results[1],
                    Password = (string)results[2]
                };
            }
            results.Close();
            return m;
        }

        public void UpdateUsername(string name, User userIn)
        {
            var statement = "Update Users Set Username=@newName, Password=@newPassword Where user_id=@userid";

            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@newName", userIn.Username);
            command.Parameters.AddWithValue("@updateName", name);

            int result = command.ExecuteNonQuery();
        }

        public void UpdatePassword(string id, string pwd, User dataIn)
        {
            var statement = "Update Users Set Username=@newName, Password=@newPassword Where user_id=@userid";

            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@newPassword", dataIn.Password);
            command.Parameters.AddWithValue("@newName", dataIn.Username);
            command.Parameters.AddWithValue("@userid", dataIn.Id);
            command.Parameters.AddWithValue("@updatePwd", pwd);

            int result = command.ExecuteNonQuery();
        }

        public void DeleteUser(string name)

        {
            var statement = "DELETE FROM Users Where Username=@deleteName";

            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@deleteName", name);

            int result = command.ExecuteNonQuery();

        }

    }


}