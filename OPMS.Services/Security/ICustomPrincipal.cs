using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;


namespace OPMS.Services.Security
{
    interface ICustomPrincipal:IPrincipal
    {
        int Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string[] Roles { get; set; }
    }
}
