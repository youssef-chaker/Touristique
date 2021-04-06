using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Index()
        {
            var hotels = await _db.Hotels.ToListAsync();
            return View(hotels);
        }

        [HttpGet("[controller]/{id}")]
        public async Task<IActionResult> Hotel(int id)
        {
            var hotel = await _db.Hotels.FindAsync(id);
            return View("Hotel",hotel);
        }
    }
}