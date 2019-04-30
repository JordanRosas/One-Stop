using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneStop.Data;
using OneStop.Models;

namespace OneStop.Controllers
{
    public class HomeController : Controller
    {
        //setting private reference to the I.D.F usermanager
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContext _context;

        //Getting the current user in the system (whoever is logged in)
        public Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public HomeController(ApplicationDbContext context,
                                  UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var userId = user.Id;             
            return View(await _context.Companies.Where(c => c.Creator.Id == userId).ToListAsync());
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
