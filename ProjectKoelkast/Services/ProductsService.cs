using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjectKoelkast.DataContext;
using ProjectKoelkast.Models;

namespace ProjectKoelkast.Services
{
    public class ProductsService
    {
        private readonly IdentityDb _context = new IdentityDb();

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }

        public void SaveProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}