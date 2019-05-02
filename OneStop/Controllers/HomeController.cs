using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OneStop.Data;
using OneStop.Models;
using OneStop.Models.ViewModels;

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
            var applicationContext = await _context.JobTickets
                .Include(j => j.Company)
                .Include(j => j.User)
                .Where(j => j.UserId == userId)
                .ToListAsync();
            return View(applicationContext);
        }

        // GET: JobTickets/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "CompanyName");
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: JobTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobTicketId,UserId,CompanyId,Position,DateCreated,StatusId")] JobTicket jobTicket, Company company)
        {
            ModelState.Remove("jobTicket.User");
            ModelState.Remove("jobTicket.UserId");


            ApplicationUser user = await GetCurrentUserAsync();

            jobTicket.User = user;
            jobTicket.UserId = user.Id;

            if (ModelState.IsValid)
            {
                _context.Add(jobTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "CompanyName", jobTicket.CompanyId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", jobTicket.UserId);
            return View(jobTicket);
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
