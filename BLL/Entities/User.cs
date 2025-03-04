using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Entities
{
    public enum UserRole { User , Admin }
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserRole RoleName {  get; set; }

        public User(Guid userId, string username, string email, string password, DateTime createdAt, string roleName) : this(username, email)
        {
            UserId = userId;
            CreatedAt = createdAt;
            RoleName = Enum.Parse<UserRole>(roleName);
        }
        public User(string username, string email, string password) : this(username, email)
        {
            Password = password;
        }
        public User(string username, string email)
        {
            Username = username;
            Email = email;
        }
        //public User(string username, string email, string password):this(username, email) 
        //{
        //    Password = password;

        //}

    }
}
