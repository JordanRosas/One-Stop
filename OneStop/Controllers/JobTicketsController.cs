using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OneStop.Data;
using OneStop.Models;

namespace OneStop.Controllers
{
    public class JobTicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobTicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobTickets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JobTickets.Include(j => j.Company).Include(j => j.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: JobTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobTicket = await _context.JobTickets
                .Include(j => j.Company)
                .Include(j => j.User)
                .FirstOrDefaultAsync(m => m.JobTicketId == id);
            if (jobTicket == null)
            {
                return NotFound();
            }

            return View(jobTicket);
        }

        // GET: JobTickets/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: JobTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobTicketId,UserId,CompanyId,Position,DateCreated,StatusId")] JobTicket jobTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", jobTicket.CompanyId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", jobTicket.UserId);
            return View(jobTicket);
        }

        // GET: JobTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobTicket = await _context.JobTickets.FindAsync(id);
            if (jobTicket == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", jobTicket.CompanyId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", jobTicket.UserId);
            return View(jobTicket);
        }

        // POST: JobTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobTicketId,UserId,CompanyId,Position,DateCreated,StatusId")] JobTicket jobTicket)
        {
            if (id != jobTicket.JobTicketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobTicketExists(jobTicket.JobTicketId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", jobTicket.CompanyId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", jobTicket.UserId);
            return View(jobTicket);
        }

        // GET: JobTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobTicket = await _context.JobTickets
                .Include(j => j.Company)
                .Include(j => j.User)
                .FirstOrDefaultAsync(m => m.JobTicketId == id);
            if (jobTicket == null)
            {
                return NotFound();
            }

            return View(jobTicket);
        }

        // POST: JobTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobTicket = await _context.JobTickets.FindAsync(id);
            _context.JobTickets.Remove(jobTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobTicketExists(int id)
        {
            return _context.JobTickets.Any(e => e.JobTicketId == id);
        }
    }
}
