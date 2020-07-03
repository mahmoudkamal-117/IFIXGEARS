using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Gears.Models;
using Gears.Data;
using Gears.ViewModels;

namespace Gears.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger,DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var viewmodel = new HomeViewModel
            {
                HomeContent = _context.HomeContents.First(),
                HomeSlider = _context.HomeSliders.ToList(),
                AboutUs = _context.AboutUs.First(),
                AboutWork = _context.AboutWork.ToList(),
                OurWork = _context.OurWork.ToList(),
                VideoContent = _context.VideoContents.First(),
                CustomerOpinion = _context.CustomerOpinion.ToList(),
                ContactUs=_context.ContactUs.First()
            };
            
            return View(viewmodel);
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
