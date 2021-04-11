using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wage.Web.Functionality
{
    public class UnAuthorizedAttribute : TypeFilterAttribute
    {
        public UnAuthorizedAttribute() : base(typeof(UnauthorizedFilter))
        {
            //Empty constructor
        }
    }

    /// <summary>
    /// user can only global page in app when controller decorated by this 
    /// action are decorated by Authorized filter
    /// </summary>
    public class UnauthorizedFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool IsAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
            if (!IsAuthenticated)
            {
                context.Result = new RedirectResult("~/Home/Index");
            }
        }
    }
}
