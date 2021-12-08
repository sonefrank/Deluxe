using Deluxe.BLL;
using Deluxe.BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deluxe.con
{
    class Program
    {
        

        static void Main(string[] args)
        {
             string Choice = "y";
            do
            {
                Console.Clear();
                Console.WriteLine("-------------------------Create a Product-------------------------");
                Console.Write("Enter reference\t:");
                string reference = Console.ReadLine();
                Console.Write("Enter name\t:");
                string name = Console.ReadLine();
                Console.Write("Enter Unit price\t:");
                double price = double.Parse(Console.ReadLine());
                Console.Write("Enter tax\t:");
                float tax = float.Parse(Console.ReadLine());

                Product product = new Product(reference, name, price, tax);
                ProductBLO productBLO = new ProductBLO(ConfigurationManager.AppSettings["DbFolder"]);
                productBLO.CreateProduct(product);

                IEnumerable<Product> products = productBLO.GetAllProducts();
                foreach (Product p in products)
                {
                    Console.WriteLine($"{p.Reference}\t{p.Name}");
                }

                Console.WriteLine("Create another product ? [y/n]:");
                Choice = Console.ReadLine();
            }
            while (Choice.ToLower() != "n");
            Console.WriteLine("Program end !");
           
            Console.ReadKey();

        }
    }
}
