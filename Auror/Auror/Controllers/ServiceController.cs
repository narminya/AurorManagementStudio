using Auror.Models.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Controllers
{
    public class ServiceController : Controller
    {
        private readonly AurorDataContext _dt;
        public ServiceController(AurorDataContext dt)
        {
            _dt = dt;
        }
        public async Task<IActionResult> Index()
        {
            var service = await _dt.Services.Where(o => !o.IsDeleted).ToListAsync();
            return View(service);
        }
    }
}
