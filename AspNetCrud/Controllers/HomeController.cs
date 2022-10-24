using AspNetCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AspNetCrud.Controllers
{
    public class HomeController : Controller
    {
        public List<Product> list { set; get; }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            list = new List<Product>();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(list);
        }
        
        [HttpPost]
        public IActionResult Add(Product product)
        {
            product.Date = DateTime.Now;
            list.Add(product);
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Title}, {item.Price}, {item.Date}");

            }
            return View("List", list);
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
