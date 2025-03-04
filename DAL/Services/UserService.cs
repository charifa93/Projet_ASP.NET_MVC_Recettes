using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories;
using DAL.Entities;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DAL.Services
{
    public class UserService : BaseService, IUserRepository<DAL.Entities.User>
    {
        public UserService(IConfiguration config) : base(config, "Main-DB") { }



        public IEnumerable<User> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Get_All_Users";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToUser();
                        }
                    }
                }
            }
        }


        public User Get(Guid UserId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Get_User_By_Id";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(UserId), UserId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToUser();
                        }
                        else throw new ArgumentOutOfRangeException(nameof(UserId));
                    }
                }
            }
        }

        public Guid Insert(User User)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Create_User";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(User.Username), User.Username);
                    command.Parameters.AddWithValue(nameof(User.Email), User.Email);
                    command.Parameters.AddWithValue(nameof(User.Password), User.Password);
                    connection.Open();
                    return (Guid)command.ExecuteScalar();

                }
            }
        }

        public void Update(Guid UserId, User User)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Update_User";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(User.UserId), UserId);
                    command.Parameters.AddWithValue(nameof(User.Username), User.Username);
                    command.Parameters.AddWithValue(nameof(User.Email), User.Email);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public Guid ChangePassword(Guid UserId, string Password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Change_Passwors_User";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(UserId), UserId);
                    command.Parameters.AddWithValue(nameof(Password), Password);

                    // Paramètre de sortie pour récupérer le nouveau Salt
                    SqlParameter newSaltParam = new SqlParameter("@NewSalt", SqlDbType.UniqueIdentifier)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(newSaltParam);
                    connection.Open();
                    command.ExecuteNonQuery();
                    // Retourner le Salt généré
                    return (Guid)newSaltParam.Value;
                }
            }
        }

        public Guid CheckPassword(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Check_Password_User";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(email), email);
                    command.Parameters.AddWithValue(nameof(password), password);
                    connection.Open();
                    return (Guid)command.ExecuteScalar();


                }
            }
        }

        public void Delete(Guid UserId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Delete_User";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(UserId), UserId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}