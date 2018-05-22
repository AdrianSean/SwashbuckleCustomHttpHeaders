using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApplication1
{
    public class AuthenticationAttribute : AuthorizeAttribute
    {

        
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {            
            var sessionId = actionContext.Request.Headers.GetValues("SessionId");
            return true;
        }

       
    }
}