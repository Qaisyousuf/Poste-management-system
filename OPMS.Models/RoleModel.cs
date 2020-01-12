using System.Collections.Generic;

namespace OPMS.Models
{
    public class RoleModel:EntityBase
    {
        public RoleModel()
        {
            Users = new List<UserModel>();
        }
        public string Name { get; set; }

        public ICollection<UserModel> Users { get; set; }
    }
}
