using NTier.Model.Entities;
using NTier.Service.Option;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTier.UI.Attributes
{

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorize : AuthorizeAttribute
    {
        
        private string[] UserProfilesRequired { get; set; }

        public CustomAuthorize(params object[] userProfilesRequired)
        {
            if (userProfilesRequired.Any(p => p.GetType().BaseType != typeof(Enum)))
                throw new ArgumentException("userProfilesRequired");

            this.UserProfilesRequired = userProfilesRequired.Select(p => Enum.GetName(p.GetType(), p)).ToArray();
        }

        public override void OnAuthorization(AuthorizationContext context)
        {
            bool authorized = false;

            
            AppUserLoginInfoService service = new AppUserLoginInfoService();

            AppUserLoginInfo user = service.FindByUsername(HttpContext.Current.User.Identity.Name);
            string userRole = Enum.GetName(typeof(Role), user.Role);

           
            foreach (var role in UserProfilesRequired)
                if (userRole == role)
                {
                    authorized = true;
                    break;
                }

            
            if (!authorized)
            {
                var url = new UrlHelper(context.RequestContext);
                var logonUrl = url.Action("Index", "Home", new { Id = 302, Area = "" });
                context.Result = new RedirectResult(logonUrl);

                return;
            }
        }
    }
}