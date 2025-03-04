using BLL.Entities;
using ProjetTest.Models.User;

namespace ProjetTest.Mappers
{
    internal static class Mapper
    {
        public static GetAllUsers ToListItem(this User user)
        {
            if(user is null) throw new ArgumentNullException(nameof(user));
            return new GetAllUsers()
            {
                UserId = user.UserId,
                UserName = user.Username
            };
        }
    }
}
