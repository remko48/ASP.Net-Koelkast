using System.Web.Mvc;
using ProjectKoelkast.DataContext;
using ProjectKoelkast.Models;
using ProjectKoelkast.Services;
using System.Linq;
using System.Web;

using System.Web.Routing;
using System.Data.SqlClient;

using System.IO;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace ProjectKoelkast.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ProductsService _productsService = new ProductsService();
        private readonly CategoriesService _categoriesService = new CategoriesService();
                private readonly IdentityDb _db = new IdentityDb();


        // GET: Products
        [AllowAnonymous]
        public ActionResult Index()
        {

            var products = _productsService.GetProducts();

            return View(products);
        }

        // GET: Products/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var categories = _categoriesService.GetCategories();

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                string filename = "";
                byte[] bytes;
                int BytestoRead;
                int numBytesRead;
                if (file != null)

                {

                    filename = Path.GetFileName(file.FileName);

                    bytes = new byte[file.ContentLength];

                    BytestoRead = (int)file.ContentLength;

                    numBytesRead = 0;

                    while (BytestoRead > 0)

                    {

                        int n = file.InputStream.Read(bytes, numBytesRead, BytestoRead);

                        if (n == 0) break;

                        numBytesRead += n;

                        BytestoRead -= n;

                    }

                    product.ImageUrl = bytes;

                }
                _productsService.SaveProduct(product);


                return RedirectToAction("Index", "Products");
            }
            return View();
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productsService.UpdateProduct(product);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
