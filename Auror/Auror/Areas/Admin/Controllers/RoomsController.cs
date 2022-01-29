using Auror.Areas.Admin.ViewModels;
using Auror.Constants;
using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
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
    public class RoomsController : Controller
    {
        private readonly AurorDataContext _dt;
        public RoomsController(AurorDataContext dt)
        {
            _dt = dt;
        }
        public async Task<IActionResult> Index(int? id)
        {
            var rooms = await _dt.Room.Include(h => h.Hotel).Include(i => i.RoomImages).Include(t => t.RoomType).ToListAsync();
            return View(rooms);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (!id.HasValue || id.Value == 0)
            {
                return NotFound();
            }
            var room = await _dt.Room.Where(i => i.Id == id).Include(p => p.RoomImages).Include(p => p.RoomType).Include(t => t.Hotel).FirstOrDefaultAsync();

            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        public async Task<IActionResult> Create(int? id)
        {
            if (!id.HasValue || id.Value ==0)
            {
                return BadRequest();
            }
            TempData["Hotel"] = id;
            var rcv = new RoomCreateViewModel()
            {
                RoomType = await _dt.RoomType.Where(a => !a.IsDeleted).ToListAsync(),
                HotelId = id
            };
            return View(rcv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomCreateViewModel rcv)
        {
            rcv.RoomType = await _dt.RoomType.ToListAsync();
           // rcv.Hotels = await _dt.Hotel.ToListAsync();

            if (!ModelState.IsValid)
            {
                return View(rcv);
            }

            var hotel = TempData["Id"];

            List<RoomImage> images = new List<RoomImage>();
            foreach (var item in rcv.file)
            {
                if (item == null)
                {
                    ModelState.AddModelError(nameof(RoomCreateViewModel.file), "Please upload an image");
                    return View(rcv);
                }
                if (!item.IsContains())
                {
                    ModelState.AddModelError(nameof(RoomCreateViewModel.file), "Uploaded image is not supported");
                    return View(rcv);
                }

                var picture = FileUtil.FileCreate(item, FileConstant.ImagePath, "rooms");
                images.Add(new RoomImage { Path = picture });
            }

            images[rcv.fileSelectedIndex].IsMain = true;

            var room = new Room()
            {
                Name = rcv.Number,
                BedCount = rcv.BedCount,
                HotelId = (int)hotel,
                CurrentPrice = rcv.CurrentPrice,
                IsAvailable = rcv.IsAvailable,
                PeopleCount = rcv.PeopleCount,
                RoomSquare = rcv.RoomSquare,
                RoomTypeId = rcv.RoomTypeId,
                RoomImages = images
            };
            await _dt.AddAsync(room);
            await _dt.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue || id.Value < 1)
            {
                return BadRequest();
            }
            var room = await _dt.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            var rcv = new RoomCreateViewModel()
            {
                RoomType = await _dt.RoomType.Where(a => !a.IsDeleted).ToListAsync(),
                //  Hotels = await _dt.Hotel.Where(a => !a.IsDeleted).ToListAsync(),
                Number = room.Name,
                BedCount = room.BedCount,
                HotelId = room.HotelId,
                IsAvailable = room.IsAvailable,
                PeopleCount = room.PeopleCount,
                RoomSquare = room.RoomSquare,
                RoomTypeId = room.RoomTypeId
            };

            return View(rcv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(RoomCreateViewModel rcv,int? id)
        {

            rcv.RoomType = await _dt.RoomType.Where(a => !a.IsDeleted).ToListAsync();
          //  rcv.Hotels = await _dt.Hotel.Where(a => !a.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View(rcv);
            }

            var foundRoom = await _dt.Room.Where(r => r.Id == id).Include(p => p.RoomImages)
                .FirstOrDefaultAsync();
            var previousImages = foundRoom.RoomImages.ToList();

            List<RoomImage> roomImages = new List<RoomImage>();
            foreach (var item in rcv.file)
            {
                if (item == null)
                {
                    ModelState.AddModelError(nameof(RoomCreateViewModel.file), "Please upload an image");
                    return View(rcv);
                }
                if (!item.IsContains())
                {
                    ModelState.AddModelError(nameof(RoomCreateViewModel.file), "Uploaded image is not supported");
                    return View(rcv);
                }

                var picture = FileUtil.FileCreate(item, FileConstant.ImagePath, "rooms");

                roomImages.Add(new RoomImage { Path = picture });
            }

            roomImages[rcv.fileSelectedIndex].IsMain = true;

            foundRoom.BedCount = rcv.BedCount;
            foundRoom.IsAvailable = rcv.IsAvailable;
            foundRoom.Name = rcv.Number;
            foundRoom.RoomSquare = rcv.RoomSquare;
            foundRoom.RoomTypeId = rcv.RoomTypeId;
            foundRoom.PeopleCount = rcv.PeopleCount;
            foundRoom.RoomImages = roomImages;


            _dt.Room.Update(foundRoom);

            await _dt.SaveChangesAsync();


            foreach (var item in previousImages)
            {
                string path = Path.Combine(FileConstant.ImagePath, "rooms", item.Path);

                FileUtil.FileDelete(path);
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var room = await _dt.Room.FindAsync(id);
            room.IsDeleted = true;
            _dt.Room.Update(room);
            await _dt.SaveChangesAsync();
            return Json(room);
        }

    }
}
