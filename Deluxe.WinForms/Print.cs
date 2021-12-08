using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deluxe.WinForms
{
    public class Print
    {
        public string Reference { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public Print(string reference , string name, double price)
        {
            Reference = reference;
            Name = name;
            Price = price;
        }
    }
}
