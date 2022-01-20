using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HotelController : Controller
    {
        private readonly AurorDataContext _dt;
        public HotelController(AurorDataContext dt)
        {
            _dt = dt;
        }
        public async Task<IActionResult> Index()
        {
            var hotels = await _dt.Hotel.Where(h => !h.IsDeleted).Include(c=>c.HotelCategory).OrderBy(r => r.Rating).ToListAsync();
            return View(hotels);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (!id.HasValue || id.Value == 0)
            {
                return NotFound();
            }
            var hotel = await _dt.Hotel.Where(t=>t.Id == id).Include(c=>c.Advantages)
                .Include(r=>r.Reservations)
                .Include(r => r.Images)
                .Include(r => r.Rooms)
                .FirstOrDefaultAsync();
            if (hotel == null)
            {
                return NotFound();
            }

            
            return View(hotel);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hotel hotel)
        {
            return View();
        }
      
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Hotel hotel,int id)
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
