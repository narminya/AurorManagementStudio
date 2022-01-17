using Auror.Models.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
