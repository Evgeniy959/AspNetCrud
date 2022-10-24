﻿using AspNetCrud.Models;
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
        //public ObservableCollection<Product> list { set; get; }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            list = new List<Product>();
            //list = new ObservableCollection<Product>();
        }
        [HttpGet]
        public IActionResult Add()
        {
            //ModelState.AddModelError("Title", "99999");
            return View();
        }
        [HttpGet]
        //public IActionResult Index()
        //{
            /*Product product = new Product();
            product.Date = DateTime.Now;
            list.Add(product);
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Title}, {item.Price}, {item.Date}");

            }*/
            //var serializer = new XmlSerializer(typeof(List<Product>));
            //using var reader = new FileStream(@$"wwwroot/content/list.xml", FileMode.OpenOrCreate);
            
            /*for (int i = 0; i < reader.Length; i++)
            {
                var li = StreamReader.(reader);
                var li = (Product)serializer.Deserialize(reader);
            }*/
            //var li = (List<Product>)serializer.Deserialize(reader);
            //List<Product>? li = serializer.Deserialize(reader) as List<Product>;
            //return li;
            /*return View(li.ToList());
        }*/
        public async Task<IActionResult> Index()
        {
            /*var serializer = new XmlSerializer(typeof(List<Product>));
            using var reader = new FileStream(@$"wwwroot/content/list.xml", FileMode.OpenOrCreate);
            List<Product> li = (List<Product>)serializer.Deserialize(reader);
            //List<Product> li = serializer.Deserialize(reader) as List<Product>;
            //return li;*/
            using (StreamReader reader = new StreamReader(@$"wwwroot/content/list.xml"))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    Console.WriteLine(line);
                    
                }
                var list1 = line.ToList();
            }
            
            return View(list1);
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            product.Date = DateTime.Now;
            list.Add(product);
            var serializer = new XmlSerializer(typeof(List<Product>));
            using var writer = new FileStream(@$"wwwroot/content/list.xml", FileMode.Append);
            //using var writer = new StreamWriter(@$"wwwroot/content/list.xml", false);
            serializer.Serialize(writer, list);
            /*foreach (var item in list)
            {
                Console.WriteLine($"{item.Title}, {item.Price}, {item.Date}");

            }*/
            return RedirectToAction("Index");
            //return View();
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
