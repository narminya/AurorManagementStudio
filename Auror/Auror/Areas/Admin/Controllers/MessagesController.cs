using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace Auror.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AreaAdmin")]
    public class MessagesController : Controller
    {
        private readonly AurorDataContext _dt;
        private readonly UserManager<User> _userManager;
        public MessagesController(AurorDataContext dt, UserManager<User> userManager)
        {
            _dt = dt;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _dt.Message.Where(i => !i.IsDeleted).Include(u=>u.User).ToListAsync();
            return View(result);
        }
        public async Task<IActionResult> Answer(int? id)
        {
            var message = await _dt.Message.FindAsync(id);
            return View(message);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Answer(Message message,int id)
        {
            var messages = await _dt.Message.FindAsync(id);
            if (!ModelState.IsValid)
            {
                return View(message);
            }
            SendEmail.EmailSender(messages.Email, "Answering your message.", message.Answer);

            messages.IsAnswered = true;
            messages.Answer = message.Answer;
            messages.AnsweredDate = DateTime.Now;
            messages.User = await _userManager.GetUserAsync(HttpContext.User);
            
            _dt.Message.Update(messages);

            await _dt.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
