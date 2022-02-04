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
    public class CommentController : Controller
    {
        private readonly AurorDataContext _dt;
        private readonly IAuthorizationService _authorizationService;
        public CommentController(AurorDataContext dt, IAuthorizationService authorizationService)
        {
            _dt = dt;
            _authorizationService = authorizationService;
        }
        public async Task<IActionResult> Index(int? id)
        {
            var comments = new List<Comment>();
            if (!id.HasValue || id.Value == 0)
            {
                comments = await _dt.Comment.Include(c => c.Hotel).Include(t => t.User).ToListAsync();
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
                comments = await _dt.Comment.Include(c => c.Hotel).Include(t => t.User).Where(c => c.HotelId == id).ToListAsync();
                TempData["Id"] = id;
            }
            return View(comments);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _dt.Comment.FindAsync(id);
            _dt.Comment.Remove(comment);
            await _dt.SaveChangesAsync();
            return RedirectToAction("Index", "Comment", new { id = comment.HotelId });
        }
    }
}
