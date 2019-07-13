using Best.BusinessLayer.Abstract;
using Best.Entities.Entities;
using Best.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Best.PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: Home
        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAllProducts()
            };
            return View(model);
        }

    }
}