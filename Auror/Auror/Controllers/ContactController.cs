using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Auror.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace Auror.Controllers
{
    public class ContactController : Controller
    {
        private readonly AurorDataContext _dt;
        public ContactController(AurorDataContext dt)
        {
            _dt = dt;
        }
        public async Task<IActionResult> Index()
        {


            var vcm = new ContactViewModel()
            {
                Contacts = await _dt.Contacts.Where(e => !e.IsDeleted).ToListAsync()
            };
            return View(vcm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactViewModel cvm)
        {

            if (!ModelState.IsValid)
            {
                return View(cvm);
            }

            var message = new Message()
            {
                Name = cvm.Name,
                Content = cvm.Content,
                Email = cvm.Email
            };

            await _dt.Message.AddAsync(message);
            await _dt.SaveChangesAsync();
            SendEmail.EmailSender(message.Email, "We received you message!", "We will answer your question as soon as possible!");

            cvm.Contacts = await _dt.Contacts.Where(e => !e.IsDeleted).ToListAsync();
            cvm.Message = "Gondэrildi";


            return View(cvm);
        }
    }
}
