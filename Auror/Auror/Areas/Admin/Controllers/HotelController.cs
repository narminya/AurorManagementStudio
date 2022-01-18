using Auror.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            return View();
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
