using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace SimpleChatSite.Filters
{
    public class DenyAuthentificatedAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AuthorizeAttribute), true))
                return;
            if (filterContext.Principal.Identity.IsAuthenticated)
                filterContext.Result = new ViewResult() {ViewName = "DeniedForAuthentificated"};
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        { }
    }
}