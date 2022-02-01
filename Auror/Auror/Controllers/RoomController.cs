using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Auror.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Controllers
{
    public class RoomController : Controller
    {
        private readonly AurorDataContext _dt;
        private readonly UserManager<User> _userManager;

        public RoomController(AurorDataContext dt, UserManager<User> userManager)
        {
            _dt = dt;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(RoomBookViewModel model)
        {


            ReservationViewModel reservation;

            var reservJson = Request.Cookies["reserv"];

            if (string.IsNullOrWhiteSpace(reservJson))
            {
                reservation = new ReservationViewModel();
            }
            else
            {
                reservation = JsonConvert.DeserializeObject<ReservationViewModel>(reservJson);
            }
            reservation.CheckIn = (System.DateTime)model.CheckIn;
            reservation.CheckOut = (System.DateTime)model.CheckOut;
            reservation.PeopleCount = model.Adults + model.Kids;

            Response.Cookies.Append("reserv", JsonConvert.SerializeObject(reservation));



            var reservations = _dt.Reservation.Include(r => r.Room)
               .Where(r => (r.HotelId == model.HotelId) && (r.ReservationStatus.Status=="Active") && (
               (model.CheckIn >= r.CheckIn && model.CheckOut <= r.CheckOut) ||
               (model.CheckOut >= r.CheckIn && model.CheckOut < r.CheckOut)) ||
              ((model.CheckIn <= r.CheckIn) && (model.CheckOut >= r.CheckIn) && (model.CheckOut <= r.CheckOut)) ||
              ((model.CheckIn >= r.CheckIn) && (model.CheckIn <= r.CheckOut) && (model.CheckOut >= r.CheckOut)) ||
              ((model.CheckIn <= r.CheckIn) && (model.CheckOut >= r.CheckOut))
               ).Select(r => new Room
               {
                   Name = r.Room.Name,
                   Id = r.Room.Id

               });


            var rooms = _dt.Room
                .Where(r => r.HotelId == model.HotelId && !reservations.Any(b => b.Id == r.Id) && model.Kids + model.Adults <= r.PeopleCount);

            model.Rooms = await rooms.Include(c => c.RoomImages).Include(c => c.RoomType).ToListAsync();

            model.RoomTypes = await rooms.Select(r => new RoomType { Name = r.RoomType.Name })
                                  .Distinct().ToListAsync();


            return View(model);
        }

        public async Task<IActionResult> ReserveRoom(int? id)
        {
            if (!id.HasValue || id.Value == 0)
            {
                return BadRequest();
            }


            ReservationViewModel reservation = new ReservationViewModel();

            var reservJson = Request.Cookies["reserv"];

            if (!string.IsNullOrWhiteSpace(reservJson))
            {
                reservation = JsonConvert.DeserializeObject<ReservationViewModel>(reservJson);
            }

            TempData["Room"] = id;

            var rvm = new ReservationViewModel()
            {
                Gender = await _dt.Gender.ToListAsync(),
                CheckIn = reservation.CheckIn,
                CheckOut = reservation.CheckOut,
                PeopleCount = reservation.PeopleCount,
                RoomId = id,
                TotalPrice = (await _dt.Room.Where(a => a.Id == id).FirstOrDefaultAsync()).CurrentPrice

            };
            return View(rvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReserveRoom(ReservationViewModel rsvm)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            rsvm.Gender = await _dt.Gender.ToListAsync();

            ReservationViewModel reservation = new ReservationViewModel();

            var reservJson = Request.Cookies["reserv"];

            if (!string.IsNullOrWhiteSpace(reservJson))
            {
                reservation = JsonConvert.DeserializeObject<ReservationViewModel>(reservJson);
            }
            rsvm.CheckIn = reservation.CheckIn;
            rsvm.CheckOut = reservation.CheckOut;
            rsvm.PeopleCount = reservation.PeopleCount;


            if (!ModelState.IsValid)
            {
                return View(rsvm);
            }

            var id = (int)TempData["Room"];

            var room = await _dt.Room.Where(c => c.Id == id).FirstOrDefaultAsync();
            var hotel = await _dt.Hotel.Where(c => c.Id == room.HotelId).FirstOrDefaultAsync();
            var guest = new Guest()
            {
                Name = rsvm.Name,
                Surname = rsvm.Surname,
                Email = rsvm.Email,
                GenderId = rsvm.GenderId,
                Phone = rsvm.Phone,
                User = user

            };


            var reserv = new Reservation()
            {
                CheckIn = rsvm.CheckIn,
                CheckOut = rsvm.CheckOut,
                Guest = guest,
                Hotel = hotel,
                Room = room,
                PeopleCount = rsvm.PeopleCount,
                ReservationStatusId = 1,
                TotalPrice = (rsvm.CheckOut-rsvm.CheckOut).Days * room.CurrentPrice,
                RoomId = id
            };

            await _dt.Reservation.AddAsync(reserv);
            await _dt.SaveChangesAsync();

            Utilities.SendEmail.EmailSender(rsvm.Email, "Reservation", "Reservation qebul olundu.Teshekkurler");

            foreach (var cookie in HttpContext.Request.Cookies)
            {
                Response.Cookies.Delete("reserv");
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
