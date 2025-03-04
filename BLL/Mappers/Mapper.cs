using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  B = BLL.Entities;
using D = DAL.Entities;

namespace BLL.Mappers
{
    internal static class Mapper
    {
        public static B.User ToBLL( this D.User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new B.User(
                        user.UserId,
                        user.Username,
                        user.Email,
                        user.Password,
                        user.CreatedAt,
                        user.RoleName);
        }
        public static D.User ToDAL( this B.User user)
        {
            if(user is null) throw new ArgumentNullException(nameof(user));
            return new D.User()
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
                RoleName = user.RoleName.ToString()
            };
        }
    }
}
