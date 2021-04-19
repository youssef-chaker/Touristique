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
    public class SitesController : Controller
    {
        private TouristiqueDbContext.TouristiqueDbContext _db;

        public SitesController(TouristiqueDbContext.TouristiqueDbContext db)
        {
            _db = db;
        }

        // GET
        public async Task<IActionResult> Index(string ville = null,string pays=null)
        {
            var sites = _db.Sites.AsQueryable();
            if (pays != null) sites = sites.Where(h => h.Location.Pays == pays);
            if (ville != null) sites = sites.Where(h => h.Location.Ville == ville);
            var svm = new SiteViewModel();
            svm.Sites = await sites.Include(h => h.Notes).Include(h => h.Location).ToListAsync();
            svm.Ville = ville;
            svm.Pays = pays;
            return View(svm);
        }

        [HttpGet("[controller]/{id}")]
        public async Task<IActionResult> Site(int id)
        {
            Site site;
            try
            { 
                site = await _db.Sites.Include(h => h.Comments).ThenInclude(c => c.User).Include(h => h.Location).Include(h => h.Notes).Where(h => h.Id == id)
                    .FirstAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
            if (site == null) return NotFound();
            return View("site",new SiteViewModel(){Site =  site});
        }
        
        
        [HttpPost]
        public async Task<IActionResult> PostComment(int siteId,string comment)
        {
            var c = new SiteComment() {Comment = comment};
            c.Site = await _db.Sites.FindAsync(siteId);
            c.User = await _db.Users.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _db.SiteComments.AddAsync(c);
            await _db.SaveChangesAsync();
            return Redirect($"{siteId}");
        }

        [HttpPost]
        public async Task<IActionResult> PostRating(int siteId, int rating)
        {
            var r = new NoteSite()
            {
                Etoile = rating
            };
            r.Site = await _db.Sites.FindAsync(siteId);
            r.User = await _db.Users.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            await _db.NoteSites.AddAsync(r);
            
            await _db.SaveChangesAsync();
            return Redirect($"{siteId}");
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(Site site)
        {
            if (!ModelState.IsValid) return BadRequest();
            var location = await _db.Locations.Where(l =>
                l.Adresse == site.Location.Adresse && l.Pays == site.Location.Pays &&
                l.Ville == site.Location.Ville).FirstOrDefaultAsync();
            if (location == null)
            {
                var newLocation = await _db.Locations.AddAsync(site.Location);
                site.Location = newLocation.Entity;
            }
            else site.Location = location;

            var result = await _db.Sites.AddAsync(site);
            await _db.SaveChangesAsync();

            return Redirect($"{result.Entity.Id}");
        }
    }
}