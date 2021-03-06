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
            var vm = new HomeViewModel();
            vm.Comments = await _dt.Comment.Where(o => !o.IsDeleted).OrderBy(c => c.CreatedDate)
                       .Include(h => h.Hotel).Include(u => u.User).Take(4).ToListAsync();
            vm.Rooms = await _dt.Room.Where(x => x.IsAvailable)
                            .Include(r => r.RoomImages.Where(i => i.IsMain)).Include(i => i.RoomType).Take(6).ToListAsync();

            return View(vm);
        }
    }
}
