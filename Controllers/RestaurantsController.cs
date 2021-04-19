using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TouristiqueDbContext.models;
using TouristiqueMvc.Models;

namespace TouristiqueMvc.Controllers
{
    public class RestaurantsController : Controller
    {
        private TouristiqueDbContext.TouristiqueDbContext _db;

        public RestaurantsController(TouristiqueDbContext.TouristiqueDbContext db)
        {
            _db = db;
        }

        // GET
        public async Task<IActionResult> Index(string ville = null,string pays=null)
        {
            var restaurants = _db.Restaurants.AsQueryable();
            if (pays != null) restaurants = restaurants.Where(h => h.Location.Pays == pays);
            if (ville != null) restaurants = restaurants.Where(h => h.Location.Ville == ville);
            var rvm = new RestaurantViewModel();
            rvm.Restaurants = await restaurants.Include(h => h.Notes).Include(h => h.Location).ToListAsync();
            rvm.Ville = ville;
            rvm.Pays = pays;
            return View(rvm);
        }

        [HttpGet("[controller]/{id}")]
        public async Task<IActionResult> Restaurant(int id)
        {
            Restaurant restaurant;
            try
            { 
                restaurant = await _db.Restaurants.Include(h => h.Comments).ThenInclude(c => c.User).Include(h => h.Location).Include(h => h.Notes).Where(h => h.Id == id)
                    .FirstAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
            if (restaurant == null) return NotFound();
            return View("restaurant",new RestaurantViewModel(){Restaurant =  restaurant});
        }
        
        
        [HttpPost]
        public async Task<IActionResult> PostComment(int restaurantId,string comment)
        {
            var c = new RestaurantComment() {Comment = comment};
            c.Restaurant = await _db.Restaurants.FindAsync(restaurantId);
            c.User = await _db.Users.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _db.RestaurantComments.AddAsync(c);
            await _db.SaveChangesAsync();
            return Redirect($"{restaurantId}");
        }

        [HttpPost]
        public async Task<IActionResult> PostRating(int restaurantId, int rating)
        {
            Console.WriteLine("post rating");
            var r = new NoteRestaurant()
            {
                Etoile = rating
            };
            r.Restaurant = await _db.Restaurants.FindAsync(restaurantId);
            r.User = await _db.Users.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            await _db.NoteRestaurants.AddAsync(r);
            
            await _db.SaveChangesAsync();
            return Redirect($"{restaurantId}");
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(Restaurant restaurant)
        {
            if (!ModelState.IsValid) return BadRequest();
            var location = await _db.Locations.Where(l =>
                l.Adresse == restaurant.Location.Adresse && l.Pays == restaurant.Location.Pays &&
                l.Ville == restaurant.Location.Ville).FirstOrDefaultAsync();
            if (location == null)
            {
                var newLocation = await _db.Locations.AddAsync(restaurant.Location);
                restaurant.Location = newLocation.Entity;
            }
            else restaurant.Location = location;

            var result = await _db.Restaurants.AddAsync(restaurant);
            await _db.SaveChangesAsync();

            return Redirect($"{result.Entity.Id}");
        }
    }
}