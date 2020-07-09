using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarketSENA.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace MarketSENA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public FileStreamResult Pdf()
        {
            string FilePath = Path.Combine(_env.WebRootPath, "download/", "solucion.pdf");
            string FilePath404 = Path.Combine(_env.WebRootPath, "download/", "no.pdf");
            if (System.IO.File.Exists(FilePath))
            {
                FileStream fs = new FileStream(FilePath, FileMode.Open);
                return File(fs, "application/pdf");
            }
            else
            {
                FileStream fs = new FileStream(FilePath404, FileMode.Open);
                return File(fs, "application/pdf");
            }
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
