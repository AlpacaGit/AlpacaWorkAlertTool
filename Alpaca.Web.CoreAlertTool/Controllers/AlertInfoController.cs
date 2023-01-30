using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Alpaca.Web.CoreAlertTool.Data;
using Alpaca.Web.CoreAlertTool.Models;
using Alpaca.Web.CoreAlertTool.Common;

namespace Alpaca.Web.CoreAlertTool.Controllers
{
    public class AlertInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlertInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AlertInfoes
        public async Task<IActionResult> Index()
        {
            Models.ViewModel.V_AlertList v_Alert = new Models.ViewModel.V_AlertList();
            v_Alert.AlertInfoList = _context.AlertInfo.OrderBy(x => x.AlertTime).ToList();
            v_Alert.AlertTypeList = _context.AlertType.ToList();
            Util.WriteLog(_context, HttpContext,ConstInfo.PageId.AlertList);
            return View(v_Alert);
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
            Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertDetail);
            return View(alertInfo);
        }

        // GET: AlertInfoes/Create
        public IActionResult Create()
        {
            Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertCreate);
            return View();
        }

        // POST: AlertInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlertId,AlertTime,AlertName,AlertType")] AlertInfo alertInfo)
        {
            Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertCreate,"通知定義の登録を開始");
            if(_context.AlertInfo.Where( x=>x.AlertId == alertInfo.AlertId).Any())
            {
                ModelState.AddModelError("AlertId",  String.Format(Common.Messages.DATA_ALREADY_FOUND,"アラート定義"));
                return View(alertInfo);
            }

            if (!Common.Util.IsTimeStr(alertInfo))
            {
                ModelState.AddModelError("AlertTime", "時刻は HHmm、もしくはHH:mm の時刻形式である必要があります。");
                return View(alertInfo);
            }

            if (ModelState.IsValid)
            {
                try
                {

                _context.Add(alertInfo);
                await _context.SaveChangesAsync();

                Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertCreate,"登録完了");
                return RedirectToAction(nameof(Index));
                }
                catch(Exception e)
                {
                    Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertCreate, "登録失敗");
                }
            }

            Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertCreate,"登録失敗");
            return View(alertInfo);
        }

        // GET: AlertInfoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.AlertInfo == null)
            {
                Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertEdit, "指定された通知定義は存在しませんでした。");
                return NotFound();
            }

            var alertInfo = await _context.AlertInfo.FindAsync(id);
            if (alertInfo == null)
            {
                Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertEdit, "指定された通知定義は存在しませんでした。");
                return NotFound();
            }
            Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertEdit, "ID:"+ id.ToString() + "を表示");
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
                Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertEdit, "指定された通知定義は存在しませんでした。");
                return NotFound();
            }

            if (!Common.Util.IsTimeStr(alertInfo))
            {
                ModelState.AddModelError("AlertTime", "時刻は HHmm、もしくはHH:mm の時刻形式である必要があります。");
                return View(alertInfo);
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
                        Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertEdit, "指定された通知定義は存在しませんでした。");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertEdit, "修正に失敗しました");
            return View(alertInfo);
        }

        // GET: AlertInfoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertDelete, "ID:" + id.ToString() + "の削除確認");
            if (id == null || _context.AlertInfo == null)
            {
                Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertDelete, "指定された通知定義は存在しませんでした。");
                return NotFound();
            }

            var alertInfo = await _context.AlertInfo
                .FirstOrDefaultAsync(m => m.AlertId == id);
            if (alertInfo == null)
            {
                Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertDelete, "指定された通知定義は存在しませんでした。");
                return NotFound();
            }

            return View(alertInfo);
        }

        // POST: AlertInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertDetail, "ID:" + id.ToString() + "の削除を開始");
            if (_context.AlertInfo == null)
            {
                Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertDelete, "指定された通知定義は存在しませんでした。");
                return Problem("Entity set 'ApplicationDbContext.AlertInfo'  is null.");
            }
            var alertInfo = await _context.AlertInfo.FindAsync(id);
            if (alertInfo != null)
            {
                _context.AlertInfo.Remove(alertInfo);
            }
            
            await _context.SaveChangesAsync();
            Util.WriteLog(_context, HttpContext, ConstInfo.PageId.AlertDelete, "ID:" + id.ToString() + "の削除を完了");
            return RedirectToAction(nameof(Index));
        }

        private bool AlertInfoExists(string id)
        {
          return _context.AlertInfo.Any(e => e.AlertId == id);
        }


        public bool WriteLog()
        {
            bool ret = false;

            Alpaca.Web.CoreAlertTool.Models.ControlLog controlLog = new Models.ControlLog();

            int logCount = _context.ControlLog.Count() + 1;
            controlLog.ControlDateTime = DateTime.Now;
            controlLog.SessionID = HttpContext.Connection.Id;
            controlLog.LogType = 1;
            controlLog.PageID = (int)Common.ConstInfo.PageId.None;
            controlLog.LogDetail = "";
            _context.Add(controlLog);
            _context.SaveChanges();
            return ret; ;
        }

    }
}
