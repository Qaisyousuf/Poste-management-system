using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPMS.Models
{
    public class UserModel:EntityBase
    {
        public UserModel()
        {
            Roles = new List<RoleModel>();
        }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }

        public ICollection<RoleModel> Roles { get; set; }




     
      

    }
}
