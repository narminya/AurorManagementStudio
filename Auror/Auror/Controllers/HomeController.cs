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
    public class HomeController : Controller
    {
        private readonly AurorDataContext _dt;
        public HomeController(AurorDataContext dt)
        {
            _dt = dt;
        }
        public async Task<IActionResult> Index()
        {
            var hvm = new HomeViewModel()
            {
                Rooms = await _dt.Room.Where(x => x.IsAvailable)
                .Include(r=>r.RoomImages.Where(i=>i.IsMain)).Include(i=>i.RoomType).Take(6).ToListAsync(),

                Comments = await _dt.Comment.Where(o=>!o.IsDeleted)
                .Include(h => h.Hotel).Include(u=>u.User).ToListAsync()
                
            };
            return View(hvm);
        }
    }
}
