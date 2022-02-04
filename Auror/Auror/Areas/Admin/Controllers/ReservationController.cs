using Auror.Areas.Admin.ViewModels;
using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "NonUser&Hotel")]
    public class ReservationController : Controller
    {
        private readonly AurorDataContext _dt;
        private readonly IAuthorizationService _authorizationService;
        public ReservationController(AurorDataContext dt, IAuthorizationService authorizationService)
        {
            _dt = dt;
            _authorizationService = authorizationService;
        }
        public async Task<IActionResult> Index(int? id)
        {
            var reservList = new List<ReservationViewModel>();

            if (!id.HasValue || id.Value == 0)
            {
                reservList = await _dt.Reservation.Include(s => s.ReservationStatus).Include(y => y.Hotel)
                  .Include(g => g.Guest).ThenInclude(u => u.User).Select(r =>
                  new ReservationViewModel
                  {
                      Name = r.Guest.Name,
                      Surname = r.Guest.Surname,
                      Username = r.Guest.User.UserName,
                      In = r.CheckIn,
                      Out = r.CheckOut,
                      Status = r.ReservationStatus.Status,
                      CreatedDate = r.CreatedDate,
                      Hotel = r.Hotel.Name,
                      TotalPrice = r.TotalPrice

                  }
                  ).ToListAsync();
            }
            else
            {
                var hotel = await _dt.Hotel.Where(t => t.Id == id).FirstOrDefaultAsync();
                var result = await _authorizationService.AuthorizeAsync(User, hotel, "HotelPermissionPolicy");
                if (!result.Succeeded)
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        return new ForbidResult();
                    }
                    else
                    {
                        return new ChallengeResult();
                    }
                }

                if (hotel == null)
                {
                    return NotFound();
                }



                reservList = await _dt.Reservation.Include(s => s.ReservationStatus)
                   .Include(g => g.Guest).ThenInclude(u => u.User).Where(c => c.HotelId == id).Select(r =>
                   new ReservationViewModel
                   {
                       Name = r.Guest.Name,
                       Surname = r.Guest.Surname,
                       Username = r.Guest.User.UserName,
                       In = r.CheckIn,
                       Out = r.CheckOut,
                       Status = r.ReservationStatus.Status,
                       CreatedDate = r.CreatedDate,
                       Hotel = hotel.Name,
                       TotalPrice = r.TotalPrice

                   }
               ).ToListAsync();
            }


            return View(reservList);
        }




    }
}
