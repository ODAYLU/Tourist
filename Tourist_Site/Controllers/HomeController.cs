using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using Tourist_Site.Data;
using Tourist_Site.Models;

namespace Tourist_Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(string txtSearch)
        {
            var places = await _context.Users
                .Where(z => (z.TypeUser == TypeUserEnum.Resturant || z.TypeUser == TypeUserEnum.Hotel) &&
                string.IsNullOrEmpty(txtSearch) ? true : z.Title.Contains(txtSearch)).ToListAsync();
            return View(places);
        }
        [Authorize]
        public async Task<IActionResult> ViewReservationsForUser()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await _context.Reservations.Where(z => z.UserId == currentUserId).ToListAsync();
            return View(data);
        }
        [Authorize]
        public async Task<IActionResult> ViewReservationsForPlace()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await _context.Reservations.Where(z => z.ReservationId == currentUserId).ToListAsync();
            return View(data);
        }
        [Authorize]
        public IActionResult Book()
        {
            ViewBag.users = _context.Users.Where(z => z.TypeUser == TypeUserEnum.Resturant || z.TypeUser == TypeUserEnum.Hotel).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Book(Reservations model)
        {
            model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ModelState.Remove("User");
            ModelState.Remove("ReservationUser");
            if (!ModelState.IsValid)
            {
                return View();
            }
           await  _context.Reservations.AddAsync(model);
           await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ViewReservationsForUser));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}