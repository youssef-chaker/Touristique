using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TouristiqueDbContext.models;
using TouristiqueMvc.Models;

namespace TouristiqueMvc.Controllers
{
    public class HotelsController : Controller
    {

        private TouristiqueDbContext.TouristiqueDbContext _db;

        public HotelsController(TouristiqueDbContext.TouristiqueDbContext db)
        {
            _db = db;
        }

        // GET
        public async Task<IActionResult> Index(string ville = null,string pays=null)
        {
            var hotels = _db.Hotels.AsQueryable();
            if (pays != null) hotels = hotels.Where(h => h.Location.Pays == pays);
            if (ville != null) hotels = hotels.Where(h => h.Location.Ville == ville);
            var hvm = new HotelViewModel();
            hvm.Hotels = await hotels.Include(h => h.Notes).Include(h => h.Location).ToListAsync();
            hvm.Ville = ville;
            hvm.Pays = pays;
            return View(hvm);
        }

        [HttpGet("[controller]/{id}")]
        public async Task<IActionResult> Hotel(int id)
        {
            Hotel hotel = null;
            try
            { 
                hotel = await _db.Hotels.Include(h => h.Chambres).Include(h => h.Restaurant).Include(h => h.Restaurant.Notes).Include(h => h.Location).Include(h => h.Notes).Where(h => h.Id == id)
                    .FirstAsync();
            }
            catch
            {
                return NotFound();
            }
            if (hotel == null) return NotFound();
            return View("Hotel",hotel);
        }
    }
}