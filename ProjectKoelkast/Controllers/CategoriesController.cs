using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using ProjectKoelkast.DataContext;
using ProjectKoelkast.Models;
using ProjectKoelkast.Services;

namespace ProjectKoelkast.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        readonly CategoriesService _categoriesService = new CategoriesService();

        // GET: Categories
        [AllowAnonymous]
        public ActionResult Index()
        {
            var products = _categoriesService.GetCategories();

            return View(products);
        }

        // GET: Categories/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = _categoriesService.GetCategory(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
      
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                // Retrieve information from form and save into the db context
                _categoriesService.SaveCategory(category);

                return RedirectToAction("Index", "Categories");
              
            }

            return View();
        }

        // GET: Categories/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var category = _categoriesService.GetCategory(id);

            return View(category);
        }

        // POST: Categories/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                _categoriesService.UpdateCategory(category);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = _categoriesService.GetCategory(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            try
            {
                _categoriesService.RemoveCategory(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
