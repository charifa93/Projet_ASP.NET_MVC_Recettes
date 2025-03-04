using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetTest.Models.User
{
    public class GetAllUsers
    {
        //pour met UserId en cacher
        [ScaffoldColumn(false)]
        public Guid UserId { get; set; }



        [DisplayName ("Nom d'utilisateur :")]
        public string UserName { get; set; }
    }
}
