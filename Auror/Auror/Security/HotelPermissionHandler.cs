using Auror.Constants;
using Auror.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Security
{
    public class HotelPermissionHandler : AuthorizationHandler<HotelRequirement, Hotel>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                      HotelRequirement requirement,
                                                      Hotel resource)
        {
            if (context.User.HasClaim("HotelId", resource.Id.ToString()))
            {
                context.Succeed(requirement);
            }
            else if(context.User.IsInRole(RoleConstants.SuperAdmin))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

