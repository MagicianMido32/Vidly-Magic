using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [AllowAnonymous] // to make it available to anonymous users , because we applied authorize in the global filter config
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        // [OutputCache(Duration = 50,Location = OutputCacheLocation.Server,VaryByParam = "genre")]//s
        //for each different param of type Genre make a unique cache , put * means for each different param
        //however only use these stuff when there are really performance problems
        public ActionResult Index()
        {
            var movies = _context.Movies
                 .Include(m => m.Genre) //no need to eager load genres
                .ToList();
            var viewModel = new HomePageViewModel()
            {
                Movies = movies
            };
            return View(viewModel);
        }

        // [OutputCache(Duration = 0,VaryByParam = "*",NoStore = true)] disabling cache by setting duration to 0, for each param
    }
}