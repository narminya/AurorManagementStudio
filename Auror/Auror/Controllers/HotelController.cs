using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Auror.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _user;
        public HotelController(AurorDataContext dt, UserManager<User> user)
        {
            _dt = dt;
            _user = user;
        }
        public async Task<IActionResult> Index()
        {
            var hvm = new HotelViewModel()
            {
                Hotels = await _dt.Hotel.Where(h => !h.IsDeleted)
                .Include(c => c.HotelCategory)
                .Include(i=>i.Images.Where(i=>i.IsMain))
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


            TempData["Id"] = id;
            var hdvm = new HotelDetailViewModel()
            {
                Hotel = await _dt.Hotel.Where(f => f.Id == id).Include(c => c.HotelCategory)
                .Include(o => o.Images).Include(c=>c.Comments).ThenInclude(c=>c.User).FirstOrDefaultAsync(),
                Advantages = await _dt.HotelAdvantages.Where(i => i.HotelId == id).Select(x =>
                new Advantage
                {
                    Name = x.Advantage.Name,
                    Icon = x.Advantage.Icon

                }).ToListAsync(),
                RoomTypes = await _dt.Room.Where(c => c.HotelId == id)
                      .Select(r => new RoomExampleViewModel { TypeName = r.RoomType.Name, PeopleCount =r.PeopleCount, RoomSquare = r.RoomSquare})
                      .Distinct().ToListAsync()
            };

            return View(hdvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Detail(int id, RoomBookViewModel model)
        {
            model.HotelId = id;

            model.RoomTypes = await _dt.Room.Where(c => c.HotelId == model.HotelId)
                      .Select(r => new RoomType { Name = r.RoomType.Name })
                      .Distinct().ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction("Index","Room", model);

        }
        public async Task<PartialViewResult> Comment(string content,string rating)
        {
            var user = await _user.GetUserAsync(HttpContext.User);
            var comment = new Comment()
            {
                Content = content,
                HotelId = Convert.ToInt32(TempData["Id"]),
                Rating = Convert.ToInt32(rating),
                User = user
            };

            await _dt.Comment.AddAsync(comment);
            await _dt.SaveChangesAsync();
            return PartialView("_CommentPartial", comment);
        }




    }
}
