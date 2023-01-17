using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Alpaca.Web.CoreAlertTool.Data;
using Alpaca.Web.CoreAlertTool.Models;

namespace Alpaca.Web.CoreAlertTool.Controllers
{
    public class AlertInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlertInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AlertInfoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.AlertInfo.ToListAsync());
        }

        // GET: AlertInfoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.AlertInfo == null)
            {
                return NotFound();
            }

            var alertInfo = await _context.AlertInfo
                .FirstOrDefaultAsync(m => m.AlertId == id);
            if (alertInfo == null)
            {
                return NotFound();
            }

            return View(alertInfo);
        }

        // GET: AlertInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlertInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlertId,AlertTime,AlertName,AlertType")] AlertInfo alertInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alertInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alertInfo);
        }

        // GET: AlertInfoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.AlertInfo == null)
            {
                return NotFound();
            }

            var alertInfo = await _context.AlertInfo.FindAsync(id);
            if (alertInfo == null)
            {
                return NotFound();
            }
            return View(alertInfo);
        }

        // POST: AlertInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AlertId,AlertTime,AlertName,AlertType")] AlertInfo alertInfo)
        {
            if (id != alertInfo.AlertId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alertInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlertInfoExists(alertInfo.AlertId))
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
            return View(alertInfo);
        }

        // GET: AlertInfoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.AlertInfo == null)
            {
                return NotFound();
            }

            var alertInfo = await _context.AlertInfo
                .FirstOrDefaultAsync(m => m.AlertId == id);
            if (alertInfo == null)
            {
                return NotFound();
            }

            return View(alertInfo);
        }

        // POST: AlertInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.AlertInfo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AlertInfo'  is null.");
            }
            var alertInfo = await _context.AlertInfo.FindAsync(id);
            if (alertInfo != null)
            {
                _context.AlertInfo.Remove(alertInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlertInfoExists(string id)
        {
          return _context.AlertInfo.Any(e => e.AlertId == id);
        }
    }
}
