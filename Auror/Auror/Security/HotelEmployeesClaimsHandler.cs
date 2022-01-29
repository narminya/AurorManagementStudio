using Auror.Constants;
using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auror.Security
{
  public class HotelEmployeesClaimsHandler   :AuthorizationHandler<SecurityRequirements>
    {
        private readonly AurorDataContext _dt;
        private readonly UserManager<User> _userManager;
        public HotelEmployeesClaimsHandler(AurorDataContext dt, UserManager<User> userManager)
        {
            _dt = dt;
            _userManager = userManager;
        }



        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SecurityRequirements requirement)
        {
            var authFilterContext = context.Resource as AuthorizationFilterContext;
            if (authFilterContext == null)
            {
                return Task.CompletedTask;
            }

            var hotelClaims = context.User.FindFirst(c => c.Type == ClaimTypes.Sid).Value;
            if (hotelClaims is null)
            {
                return Task.CompletedTask;
            }
            int hotelId = Convert.ToInt32(authFilterContext.HttpContext.Request.RouteValues["id"]);
            var hotel = _dt.Hotel.Find(hotelId);

            if (context.User.IsInRole(RoleConstants.Hotel) && 
                context.User.HasClaim(claim=>claim.Type==ClaimTypes.Sid && claim.Value == hotel.Name))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
