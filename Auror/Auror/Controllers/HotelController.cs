using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Auror.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Controllers
{
    public class HotelController : Controller
    {
        private readonly AurorDataContext _dt;
        public HotelController(AurorDataContext dt)
        {
            _dt = dt;
        }
        public async Task<IActionResult> Index()
        {
            var hvm = new HotelViewModel()
            {
                Hotels = await _dt.Hotel.Where(h => !h.IsDeleted)
                .Include(c => c.HotelCategory)
                .OrderBy(r => r.Rating)
                .ToListAsync(),

                Categories = await _dt.HotelCategory.ToListAsync()
            };
            return View(hvm);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (!id.HasValue && id.Value == 0)
            {
                return BadRequest();
            }
            if ((await _dt.Hotel.FindAsync(id)) == null)
            {
                return NotFound();
            }



            var hdvm = new HotelDetailViewModel()
            {
                Hotel = await _dt.Hotel.Where(f => f.Id == id).Include(c => c.HotelCategory)
                .Include(o => o.Images).FirstOrDefaultAsync(),
                Advantages = await _dt.HotelAdvantages.Where(i => i.HotelId == id).Select(x =>
                new Advantage
                {
                    Name = x.Advantage.Name,
                    Icon = x.Advantage.Icon

                }).ToListAsync(),
                Rooms = await _dt.Room.Where(f => f.HotelId == id && f.IsAvailable == true).Include(r => r.RoomType).ToListAsync()
            };

            return View(hdvm);
        }
      


     
    }
}
