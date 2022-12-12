using Products.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserDbRepository : IDbRepository<User, int>
    {
   

        public User Login(User entity)
        {
            DbConnection conn = DbConnectionFactory.Instance.GetDbConnection();
            SqlCommand command = conn.CreateCommand($"SELECT * FROM [User] WHERE Username LIKE @username AND Password LIKE @password");
            command.Parameters.AddWithValue("@username", entity.Username);
            command.Parameters.AddWithValue("@password", entity.Password);
            using (SqlDataReader reader = command.ExecuteReader()) { 
                if (reader.Read())
                {
                    User user = new User();
                    user.Id = reader.GetInt32(0);
                    user.FirstName = reader.GetString(1);
                    user.LastName = reader.GetString(2);
                    user.Username = reader.GetString(3);
                    user.Password = reader.GetString(4);
                    return user;
                }
            }
            throw new Exception("User doesn't exist!");
        }
        public void Add(User entity)
        {
            throw new NotImplementedException();
        }


        public void Close()
        {
            DbConnectionFactory.Instance.GetDbConnection().Close();
        }

        public void Commit()
        {
            DbConnectionFactory.Instance.GetDbConnection().Commit();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public User Get(int key)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            DbConnectionFactory.Instance.GetDbConnection().Rollback();
        }

        public List<User> Search(string criteria)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

    }
}
