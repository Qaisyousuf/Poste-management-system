using System.Security.Principal;


namespace OPMS.Services.Security
{
    interface ICustomPrincipal:IPrincipal
    {
        int Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string[] Roles { get; set; }
    }
}
