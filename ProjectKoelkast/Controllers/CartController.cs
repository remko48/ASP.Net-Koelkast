using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectKoelkast.Models;
using ProjectKoelkast.Services;
using System.Data.SqlClient;

namespace ProjectKoelkast.Controllers
{
    public class CartController : Controller
    {
        ProductsService productsService = new ProductsService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buy(int id)
        {
           
            
       

            

            //ProductModel productModel = new ProductModel();
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = productsService.GetProduct(id), Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = productsService.GetProduct(id), Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Display_Products","Winkelmand");
        }

        public ActionResult Remove(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Display_Products", "Winkelmand");
        }

        private int isExist(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.Id.Equals(id))
                    return i;
            return -1;
        }
     
    }
}