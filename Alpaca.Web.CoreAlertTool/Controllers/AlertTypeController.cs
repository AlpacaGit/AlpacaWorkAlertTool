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
    public class AlertTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlertTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AlertType
        public async Task<IActionResult> Index()
        {
              return View(await _context.AlertType.ToListAsync());
        }

        // GET: AlertType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AlertType == null)
            {
                return NotFound();
            }

            var alertType = await _context.AlertType
                .FirstOrDefaultAsync(m => m.AlertTypeId == id);
            if (alertType == null)
            {
                return NotFound();
            }

            return View(alertType);
        }

        // GET: AlertType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlertType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlertTypeId,AlertTypeName")] AlertType alertType)
        {
            if (ModelState.IsValid)
            {
                var lastData = _context.AlertType.OrderByDescending(x => x.AlertTypeId).FirstOrDefault();
                int nextId = 1;
                if (lastData != null)
                {
                    nextId = lastData.AlertTypeId + 1;
                }
                alertType.AlertTypeId = nextId;
                _context.Add(alertType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alertType);
        }

        // GET: AlertType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AlertType == null)
            {
                return NotFound();
            }

            var alertType = await _context.AlertType.FindAsync(id);
            if (alertType == null)
            {
                return NotFound();
            }
            return View(alertType);
        }

        // POST: AlertType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlertTypeId,AlertTypeName")] AlertType alertType)
        {
            if (id != alertType.AlertTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alertType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlertTypeExists(alertType.AlertTypeId))
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
            return View(alertType);
        }

        // GET: AlertType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AlertType == null)
            {
                return NotFound();
            }

            var alertType = await _context.AlertType
                .FirstOrDefaultAsync(m => m.AlertTypeId == id);
            if (alertType == null)
            {
                return NotFound();
            }

            return View(alertType);
        }

        // POST: AlertType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AlertType == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AlertType'  is null.");
            }
            var alertType = await _context.AlertType.FindAsync(id);
            if (alertType != null)
            {
                _context.AlertType.Remove(alertType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlertTypeExists(int id)
        {
          return _context.AlertType.Any(e => e.AlertTypeId == id);
        }
    }
}
