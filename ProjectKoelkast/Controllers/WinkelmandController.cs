using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.SqlClient;
using ProjectKoelkast.Models;
using ProjectKoelkast.DataContext;
using ProjectKoelkast.Services;

using System.Drawing;

namespace ProjectKoelkast.Controllers
{
    public class WinkelmandController : Controller
    {
        // GET: Winkelmand
        /*[Route("home/create")]*/

        ProductsService productsService = new ProductsService();
        public ActionResult Display_Products()
        {
            //ProductModel productModel = new ProductModel();
            //ViewBag.products = productModel.findAll();
            ViewBag.products = productsService.GetProducts();
            return View();
        }
        

    }
}