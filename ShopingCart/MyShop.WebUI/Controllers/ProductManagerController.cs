using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.core.Models;
using MyShop.DataAccess;
using MyShop.DataAccess.InMemory;
namespace MyShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {

        ProductRepo context;

        public ProductManagerController()
        {
            context = new ProductRepo();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection() as List<Product>;
            return View(products);
        }

        

    }
}