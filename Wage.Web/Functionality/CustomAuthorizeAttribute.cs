using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Wage.Core.Enums;
using Wage.Web.Extensions;
using Wage.Web.Models;

namespace Wage.Web.Functionality
{
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute(params string[] claim) : base(typeof(CustomAuthorizeAttributeFilter))
        {
            Arguments = new object[] { claim };
        }
    }

    public class CustomAuthorizeAttributeFilter : IAuthorizationFilter
    {
        readonly string[] _claim;

        public CustomAuthorizeAttributeFilter(params string[] claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {          
            
            //check if entered url mean path url ===>path=/controller/action has AllowAnonymousAttribute or not 
            //if yes is valid and dont ckeck other validations
            bool hasAllowAnonymous = context.ActionDescriptor.EndpointMetadata.Any(em => em.GetType() == typeof(AllowAnonymousAttribute));
            if (hasAllowAnonymous) return;

            var IsAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
            //var claimsIndentity = context.HttpContext.User.Identity as ClaimsIdentity;
            //var wantendUrl = $"{context.HttpContext.Request.Scheme}://{context.HttpContext.Request.Host}{context.HttpContext.Request.Path}";


            if (IsAuthenticated)
            {
                bool isValid = false;
                var roleIDs = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value?.Split(',').ToArray();
                IEnumerable<AccessUrlViewModel> userAccessUrls =
                    context.HttpContext.Session.GetComplexData<IEnumerable<AccessUrlViewModel>>("UserAccessUrls");
                if (roleIDs.Length > 0)
                {
                    if (roleIDs.First().Equals(EnumRole.ADMIN.ToString()))
                    {
                        isValid = true;
                    }
                    else
                    {
                        if (context.HttpContext.Request.Path.HasValue && context.HttpContext.Request.Path != "/")
                        {
                            if (userAccessUrls.Count() > 0 && userAccessUrls.Any(a => a.Link.ToLower().Equals(context.HttpContext.Request.Path.Value.ToLower())))
                            {
                                isValid = true;
                            }
                            else
                            {
                                context.Result = new RedirectResult("~/Home/AccessDeny");
                            }
                        }
                        else
                        {
                            context.Result = new RedirectResult("~/Home/Index");
                        }
                    }
                }

            }
            else
            {                
                context.Result = new RedirectResult("~/Account/Login");
            }
            return;
        }
    }
}
