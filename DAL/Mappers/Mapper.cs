using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Mappers
{
    public static class Mapper
    {
        public static User ToUser (this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException (nameof (record));
            return new User()
            {
                UserId = (Guid)record[nameof(User.UserId)],
                Username = (string)record[nameof(User.Username)],
                Email = (string)record[nameof(User.Email)],
                Password = (string)record[nameof(User.Password)],
                CreatedAt = (DateTime)record[nameof(User.CreatedAt)],
                RoleName = (string)record[nameof(User.RoleName)]
            };
        }

    }
}
