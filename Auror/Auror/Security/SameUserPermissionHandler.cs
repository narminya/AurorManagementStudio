using Auror.Constants;
using Auror.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Security
{
    public class SameUserPermissionHandler : AuthorizationHandler<SameUserRequirement, User>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                      SameUserRequirement requirement,
                                                      User resource)
        {
            if (context.User.HasClaim("UserHimself", resource.Id))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
