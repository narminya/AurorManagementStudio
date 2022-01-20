using Auror.Models.DataAccessLayer;
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

        public async Task<IActionResult> Detail(int id)
        {
            return View();
        }
    }
}
