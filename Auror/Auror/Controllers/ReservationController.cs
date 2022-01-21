using Auror.Models.ViewModels;
using Auror.Models.ViewModels.Reservation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Controllers
{
    public class ReservationController : Controller
    {

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reservation(ReservationCreateViewModel rvm)
        {
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Reservation(ReservationViewModel rsv)
        {
            return View();
        }

        public async Task<PartialViewResult> GetAvailableRooms()
        {

            return PartialView("_AvailableRoomsPartial");
        }
    }
}
