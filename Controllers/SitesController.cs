using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TouristiqueMvc.Controllers
{
    public class SitesController : Controller
    {
        private TouristiqueDbContext.TouristiqueDbContext _db;

        public SitesController(TouristiqueDbContext.TouristiqueDbContext db)
        {
            _db = db;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var sites = await _db.Sites.ToListAsync();
            return View(sites);
        }

        [HttpGet("[controller]/{id}")]
        public async Task<IActionResult> Site(int id)
        {
            var site = await _db.Sites.FindAsync(id);
            return View("Site", site);
        }
    }
}