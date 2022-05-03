using Capacitacion.Test.Avs.Business.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capacitacion.Test.Avs.Business.Data;
using System.Data.SqlClient;

namespace Capacitacion.Test.Avs.Infraesctuture.Data
{
    public class UserData : IUserData
    {
        private readonly SqlConnection _conn;
        public UserData()
        {
            string connectionString = "Data Source=DESKTOP-19TGFI2;Database=homework;Integrated Security=true;";
            _conn = new SqlConnection(connectionString);
        }
        public User Create(User user)
        {
            User userResult = null;
            string commandText = $"INSERT INTO USUARIOS VALUES({user.TypeDocument}, {user.DocumentNumber}, '{user.Name}', '{user.LastName}')";
            using (SqlCommand cmd = new SqlCommand(commandText, _conn))
            {
                _conn.Open();
                cmd.ExecuteNonQuery();
                _conn.Close();
            }
            commandText = "SELECT TOP(1) * FROM USUARIOS ORDER BY id DESC";
            using (SqlCommand cmd = new SqlCommand(commandText, _conn))
            {
                _conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userResult = new User()
                        {
                            Id = reader.GetInt32(0),
                            TypeDocument = reader.GetInt32(1),
                            DocumentNumber = reader.GetInt32(2),
                            Name = reader.GetString(3),
                            LastName = reader.GetString(4)
                        };
                    }
                }
                _conn.Close();
            }
            return userResult;
        }

        public void Delete(int id)
        {
            string commandText = $"DELETE FROM USUARIOS WHERE id={id}";
            using (SqlCommand cmd = new SqlCommand(commandText, _conn))
            {
                _conn.Open();
                cmd.ExecuteNonQuery();
                _conn.Close();
            }
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            string commandText = "SELECT * FROM USUARIOS ORDER BY id DESC";
            using (SqlCommand cmd = new SqlCommand(commandText, _conn))
            {
                _conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User userData = new User()
                        {
                            Id = reader.GetInt32(0),
                            TypeDocument = reader.GetInt32(1),
                            DocumentNumber = reader.GetInt32(2),
                            Name = reader.GetString(3),
                            LastName = reader.GetString(4)
                        };
                        users.Add(userData);
                    }
                }
                _conn.Close();
            }
            return users;
        }

        public User GetUserById(int id)
        {
            User userResult = null;
            string commandText = $"SELECT * FROM USUARIOS WHERE id={id}";
            using (SqlCommand cmd = new SqlCommand(commandText, _conn))
            {
                _conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userResult = new User();
                        userResult.Id = reader.GetInt32(0);
                        userResult.TypeDocument = reader.GetInt32(1);
                        userResult.DocumentNumber = reader.GetInt32(2);
                        userResult.Name = reader.GetString(3);
                        userResult.LastName = reader.GetString(4);
                    }
                }
                _conn.Close();
            }
            return userResult;
        }

        public User Update(User user)
        {
            User userResult = null;
            string commandText = $"UPDATE USUARIOS SET tipo_cedula={user.TypeDocument}, name='{user.Name}', last_name='{user.LastName}', cedula={user.DocumentNumber} WHERE id={user.Id}";
            using (SqlCommand cmd = new SqlCommand(commandText, _conn))
            {
                _conn.Open();
                cmd.ExecuteNonQuery();
                _conn.Close();
            }
            commandText = $"SELECT * FROM USUARIOS WHERE id={user.Id}";
            using (SqlCommand cmd = new SqlCommand(commandText, _conn))
            {
                _conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userResult = new User();
                        userResult.Id = reader.GetInt32(0);
                        userResult.TypeDocument = reader.GetInt32(1);
                        userResult.DocumentNumber = reader.GetInt32(2);
                        userResult.Name = reader.GetString(3);
                        userResult.LastName = reader.GetString(4);
                    }
                }
                _conn.Close();
            }
            return userResult;
        }
    }
}
