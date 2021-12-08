using Deluxe.BO;
using Deluxe.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deluxe.BLL
{
    public class ProductBLO
    {
        ProductDAO productRepo;
        public ProductBLO(string dbFolder)
        {
            productRepo = new ProductDAO(dbFolder);
        }
        public void CreateProduct(Product product)
        {
            productRepo.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            productRepo.Remove(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productRepo.Find();
        }
        public IEnumerable<Product> GetBy(Func<Product, bool> predicate )
        {
            return productRepo.Find(predicate);
        }

        public void EditProduct(Product oldProduct, Product newProduct)
        {
            productRepo.Set(oldProduct, newProduct);
        }
    }
}
