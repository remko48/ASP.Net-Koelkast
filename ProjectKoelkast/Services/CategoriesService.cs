using ProjectKoelkast.DataContext;
using ProjectKoelkast.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProjectKoelkast.Services
{
    public class CategoriesService : IDisposable
    {
        private readonly IdentityDb _context = new IdentityDb();

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int? id)
        {
            return _context.Categories.Find(id);
        }

        public void SaveCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Deleted;
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}