using Auror.Areas.Admin.ViewModels;
using Auror.Constants;
using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace Auror.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HotelController : Controller
    {
        private readonly AurorDataContext _dt;
        private readonly IWebHostEnvironment _env;
        public HotelController(AurorDataContext dt, IWebHostEnvironment env)
        {
            _dt = dt;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var hotels = await _dt.Hotel.Include(c => c.HotelCategory).OrderBy(r => r.Rating).ToListAsync();
            return View(hotels);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (!id.HasValue || id.Value == 0)
            {
                return NotFound();
            }
            var hotel = await _dt.Hotel.Where(t => t.Id == id).Include(c => c.Advantages)
                .Include(r => r.Reservations)
                .Include(r => r.Images)
                .Include(r => r.Rooms)
                .FirstOrDefaultAsync();
            if (hotel == null)
            {
                return NotFound();
            }


            return View(hotel);
        }

        [Authorize(Policy = "AreaAdmin")]
        public async Task<IActionResult> Create()
        {
            var category = await _dt.HotelCategory.Where(i => !i.IsDeleted).ToListAsync();
            var advantage = await _dt.Advantages.Where(a => !a.IsDeleted).ToListAsync();
            var hcvm = new HotelCreateViewModel()
            {
                Category = category,
                Advantage = advantage
            };
            return View(hcvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HotelCreateViewModel hcvm)
        {
            var category = await _dt.HotelCategory.Where(i => !i.IsDeleted).ToListAsync();
            var advantage = await _dt.Advantages.Where(a => !a.IsDeleted).ToListAsync();
            hcvm.Category = category;
            hcvm.Advantage = advantage;
            if (!ModelState.IsValid)
            {
                return View(hcvm);
            }

            var hotelCategory = await _dt.HotelCategory.FindAsync(hcvm.HotelCategoryId);
            if (hotelCategory == null)
            {
                ModelState.AddModelError(nameof(HotelCreateViewModel.HotelCategoryId), "Please choose valid category");
                return View(hcvm);
            }


            List<HotelImage> hotelImages = new List<HotelImage>();
            foreach (var item in hcvm.file)
            {
                if (item == null)
                {
                    ModelState.AddModelError(nameof(HotelCreateViewModel.file), "Please upload an image");
                    return View(hcvm);
                }
                if (!item.IsContains())
                {
                    ModelState.AddModelError(nameof(HotelCreateViewModel.file), "Uploaded image is not supported");
                    return View(hcvm);
                }

                var picture = FileUtil.FileCreate(item, FileConstant.ImagePath, "HOTEL");

                hotelImages.Add(new HotelImage { Path = picture });
            }

            hotelImages[hcvm.fileSelectedIndex].IsMain = true;


            var hotel = new Hotel()
            {
                Name = hcvm.Name,
                Location = hcvm.Location,
                Email = hcvm.Email,
                Phone = hcvm.Phone,
                Images = hotelImages,
                Description = hcvm.Description,
                HotelCategoryId = hcvm.HotelCategoryId,
                
            };
            var hotelAdvantages = new List<HotelAdvantages>();
            foreach (var adv in hcvm.AdvantageId)
            {
                hotelAdvantages.Add(new HotelAdvantages { AdvantageId = adv, HotelId = hotel.Id });
            }
            hotel.Advantages = hotelAdvantages;

            await _dt.AddAsync(hotel);
            await _dt.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue || id.Value < 1)
            {
                return BadRequest();
            }
            var hotel = await _dt.Hotel.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            var category = await _dt.HotelCategory.Where(i => !i.IsDeleted).ToListAsync();


            var hotelUpdate = new HotelCreateViewModel()
            {
                Description = hotel.Description,
                Email = hotel.Email,
                HotelCategoryId = hotel.HotelCategoryId,
                Location = hotel.Location,
                Name = hotel.Name,
                Phone = hotel.Phone,
                Category = category

            };

            return View(hotelUpdate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(HotelCreateViewModel hotel, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(hotel);
            }
            var foundHotel = await _dt.Hotel.Where(i => i.Id == id).Include(p => p.Images).FirstOrDefaultAsync();
            var previousImages = foundHotel.Images.ToList();

            List<HotelImage> hotelImages = new List<HotelImage>();
            foreach (var item in hotel.file)
            {
                if (item == null)
                {
                    ModelState.AddModelError(nameof(HotelCreateViewModel.file), "Please upload an image");
                    return View(hotel);
                }
                if (!item.IsContains())
                {
                    ModelState.AddModelError(nameof(HotelCreateViewModel.file), "Uploaded image is not supported");
                    return View(hotel);
                }

                var picture = FileUtil.FileCreate(item, FileConstant.ImagePath, "HOTEL");

                hotelImages.Add(new HotelImage { Path = picture });
            }


            hotelImages[hotel.fileSelectedIndex].IsMain = true;


            foundHotel.Description = hotel.Description;
            foundHotel.Email = hotel.Email;
            foundHotel.HotelCategoryId = hotel.HotelCategoryId;
            foundHotel.Location = hotel.Location;
            foundHotel.Name = hotel.Name;
            foundHotel.Phone = hotel.Phone;
            foundHotel.Images = hotelImages;


            _dt.Hotel.Update(foundHotel);
            await _dt.SaveChangesAsync();


            foreach (var item in previousImages)
            {
                string path = Path.Combine(FileConstant.ImagePath, "HOTEL", item.Path);

                FileUtil.FileDelete(path);
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var hotel = await _dt.Hotel.FindAsync(id);
            hotel.IsDeleted = true;
            _dt.Hotel.Update(hotel);
            await _dt.SaveChangesAsync();
            return Json(hotel);
        }

       
    }
}
