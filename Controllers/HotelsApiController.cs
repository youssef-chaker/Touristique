using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TouristiqueMvc.Models;

namespace TouristiqueMvc.Controllers
{
    [ApiController]
    [Route("/api/hotels")]
    public class HotelsApiController : ControllerBase
    {
        private TouristiqueDbContext.TouristiqueDbContext _db;

        public HotelsApiController(TouristiqueDbContext.TouristiqueDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index(string ville = null,string pays=null)
        {
            var hotels = _db.Hotels.AsQueryable();
            if (pays != null) hotels = hotels.Where(h => h.Location.Pays == pays);
            if (ville != null) hotels = hotels.Where(h => h.Location.Ville == ville);
            var result =  await hotels.Include(h => h.Notes).Include(h => h.Location).ToListAsync();
            return Ok(result);
        }
    }
}