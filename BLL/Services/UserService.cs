using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Mappers;
using BLL.Entities;
using Common.Repositories;
using DAL.Entities;

namespace BLL.Services
{
    public class UserService : IUserRepository<BLL.Entities.User>
    {
        private IUserRepository<DAL.Entities.User> _userService;

        public UserService(IUserRepository<DAL.Entities.User> userService)
        {
            _userService = userService;
        }


        public IEnumerable<BLL.Entities.User> Get()
        {
            return _userService.Get().Select(dal => dal.ToBLL());
        }

        public BLL.Entities.User Get(Guid userId)
        {
            return _userService.Get(userId).ToBLL();
            // user.SetCocktails(_cocktailService.GetFromUser(user_id).Select(dal => dal.ToBLL()));
           
        }

        public Guid Insert(BLL.Entities.User user)
        {

            if (user is null) throw new ArgumentNullException(nameof(user));
            return _userService.Insert(user.ToDAL());
        }
        public void Update(Guid userId, BLL.Entities.User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            _userService.Update(userId, user.ToDAL());
        }
        public Guid ChangePassword(Guid UserId, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Le mot de passe ne peut pas être vide.", nameof(password));

            return _userService.ChangePassword(UserId, password);
        }

        public Guid CheckPassword(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("L'email ne peut pas être vide.", nameof(email));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Le mot de passe ne peut pas être vide.", nameof(password));

            return _userService.CheckPassword(email, password);
        }
        public void Delete(Guid userId)
        {
            _userService.Delete(userId);
        }
    }
}
