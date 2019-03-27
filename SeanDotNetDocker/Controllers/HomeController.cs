using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using SeanDotNetDocker.DataAccess;
using SeanDotNetDocker.Models;

namespace SeanDotNetDocker.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBContext _db;

        private IConfiguration _config;
        private IHostingEnvironment _he;

        public HomeController(DBContext db, IHostingEnvironment he)
        {
            _db = db;
            _he = he;
        }

        public async Task<IActionResult> Index()
        {
            //var foo = await _db.WebSettings.Where(s => s.SettingKey.Equals("sean")).FirstOrDefaultAsync();
            //if (foo != null)
            //    ViewBag.msg = foo.Value;
            //else ViewBag.msg = "fuck you!";
            
            ViewBag.HE = _he.EnvironmentName;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var foo = await _db.WebSettings.Where(s => s.SettingKey.Equals("sean")).FirstOrDefaultAsync();

            return Content("Message from server => " + foo.Value);
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
