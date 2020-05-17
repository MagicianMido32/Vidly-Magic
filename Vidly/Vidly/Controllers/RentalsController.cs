using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using System.Linq;

namespace Vidly.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }


        public ActionResult PastRentals()
        {
            var rentals = _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie)
                .Where(r => r.DateReturned != null)
                .ToList();
            return View(rentals);
        }
        public ActionResult Index()
        {
            var rentals = _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie)
                .Where(r => r.DateReturned == null)
                .ToList();
            return View(rentals);
        }

        public ActionResult ReturnRental()
        {
            return View();
        }
    }
}