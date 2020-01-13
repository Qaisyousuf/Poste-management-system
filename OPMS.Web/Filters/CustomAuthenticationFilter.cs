using OPMS.Services.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace OPMS.Web.Filters
{
    public class CustomAuthenticationFilter : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            HttpCookie myCookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (myCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(myCookie.Value);

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                CustomPricipalSerialize serialize = serializer.Deserialize<CustomPricipalSerialize>(authTicket.UserData);

                CustomPrincipal currentUser = new CustomPrincipal(authTicket.Name)
                {
                    Id = serialize.Id,
                    UserName = serialize.UserName,
                    PhoneNumber=serialize.PhoneNumber,
                    Email = serialize.Email,
                    Roles = serialize.Roles
                };

                filterContext.HttpContext.User = currentUser;

            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            
        }
    }
}