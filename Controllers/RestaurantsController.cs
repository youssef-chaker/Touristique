using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Index()
        {
            var restaurants = await _db.Restaurants.ToListAsync();
            return View(restaurants);
        }

        [HttpGet("[controller]/{id}")]
        public async Task<IActionResult> Restaurant(int id)
        {
            var restaurant = await _db.Restaurants.FindAsync(id);
            return View("Restaurant", restaurant);
        }

    }
}