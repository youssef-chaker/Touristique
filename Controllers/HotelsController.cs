using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TouristiqueDbContext.models;
using TouristiqueMvc.Models;

namespace TouristiqueMvc.Controllers
{
    public class HotelsController : Controller
    {

        private TouristiqueDbContext.TouristiqueDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public HotelsController(TouristiqueDbContext.TouristiqueDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
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
            Hotel hotel;
            try
            { 
                hotel = await _db.Hotels.Include(h => h.Comments).ThenInclude(c => c.User).Include(h => h.Chambres).Include(h => h.Restaurant).Include(h => h.Restaurant.Notes).Include(h => h.Location).Include(h => h.Notes).Where(h => h.Id == id)
                    .FirstAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
            if (hotel == null) return NotFound();
            return View("Hotel",new HotelViewModel{Hotel = hotel});
        }

        [HttpPost]
        public async Task<IActionResult> PostComment(int hotelId,string comment)
        {
            var c = new HotelComment {Comment = comment};
            c.Hotel = await _db.Hotels.FindAsync(hotelId);
            c.User = await _db.Users.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _db.HotelComments.AddAsync(c);
            await _db.SaveChangesAsync();
            return Redirect($"{hotelId}");
        }

        [HttpPost]
        public async Task<IActionResult> PostRating(int hotelId, int rating)
        {
            var r = new NoteHotel
            {
                Etoile = rating
            };
            r.Hotel = await _db.Hotels.FindAsync(hotelId);
            r.User = await _db.Users.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            await _db.NoteHotels.AddAsync(r);
            
            await _db.SaveChangesAsync();
            return Redirect($"{hotelId}");
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Hotel hotel)
        {
            if (!ModelState.IsValid) return BadRequest();
            var location = await _db.Locations.Where(l =>
                l.Adresse == hotel.Location.Adresse && l.Pays == hotel.Location.Pays &&
                l.Ville == hotel.Location.Ville).FirstOrDefaultAsync();
            if (location == null)
            {
                var newLocation = await _db.Locations.AddAsync(hotel.Location);
                hotel.Location = newLocation.Entity;
            }
            else hotel.Location = location;

            var result = await _db.Hotels.AddAsync(hotel);
            await _db.SaveChangesAsync();

            return Redirect($"{result.Entity.Id}");
        }

        [HttpPost]
        public async Task<IActionResult> AddChambre(Chambre chambre)
        {
            if (!ModelState.IsValid) return BadRequest();
            var hotel = await _db.Hotels.FindAsync(chambre.Hotel.Id);
            chambre.Hotel = hotel;
            await _db.Chambres.AddAsync(chambre);
            await _db.SaveChangesAsync();
            return Redirect($"{chambre.Hotel.Id}");
        }
        
    }
}