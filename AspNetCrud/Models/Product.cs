using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCrud.Models
{
    public class Product
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}
