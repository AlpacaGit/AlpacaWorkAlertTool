using Alpaca.Web.CoreAlertTool.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Alpaca.Web.CoreAlertTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新規作成ページ
        /// </summary>
        /// <returns></returns>
        public IActionResult New()
        {
            return View();
        }

        
        /// <summary>
        /// 新規作成「登録」操作
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create()
        {
            //なんやかんや登録のロジックを書きたい。

            return View();
        }

        /// <summary>
        /// プライバシーポリシーページ
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// エラー発生時のページ
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}