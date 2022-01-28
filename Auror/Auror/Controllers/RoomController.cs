using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Auror.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Controllers
{
    public class RoomController : Controller
    {
        private readonly AurorDataContext _dt;
        public RoomController(AurorDataContext dt)
        {
            _dt = dt;
        }
        //public async Task<IActionResult> Index(RoomBookViewModel model)
        //{

        //    model.RoomTypes = await _dt.Room.Where(c => c.HotelId == model.HotelId)
        //                          .Select(r => new RoomType { Name = r.RoomType.Name })
        //                          .Distinct().ToListAsync();


        //    var rooms = await _dt.Room
        //       .Where(r => r.HotelId == model.HotelId).ToListAsync();



        //    foreach (var item in rooms)
        //    {
        //        var reserved = await _dt.ReservationRooms.Include(r => r.Reservation).Where(c => c.RoomId == item.Id).ToListAsync();
        //        item.Reserved = reserved;
        //    }

        //    //   var query = _dt.Reservation.Where(c => c.HotelId == model.HotelId).SelectMany(c => c.Reserved).ToList();

         
        //    return Json();
        //}


    }
}
