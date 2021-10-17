using ProductView_v_4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProductView_v_4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() => View(new IndexModel());

        public IActionResult NewProduct() => View();

        public IActionResult Del(int id)
        {
            ProductRepository.Delete(id);
            return Redirect("/Home/Index");
        }
        public IActionResult EditView(int id) => View(ProductRepository.GetProducts().Find(i => i.id == id));

        public IActionResult EditProduct(Product product)
        {
            if (CheckProduct(product))
                ProductRepository.UpdateProducts(product);
            return Redirect("/Home/Index");
        }

        public IActionResult Add(Product product)
        {
            if (CheckProduct(product))
                ProductRepository.AddProducts(product);

            return Redirect("/Home/NewProduct");
        }

        private bool CheckProduct(Product product)
        {
            bool rez = false;
            if (product.model != null && product.model != string.Empty)
                if (product.product != null && product.product != string.Empty)
                    if (product.salesman != null && product.salesman != string.Empty)
                        if (product.category != null && product.category != string.Empty)
                            if (product.description != null && product.description != string.Empty)
                                if (product.price != null)
                                    if (product.img != null && product.img != string.Empty && IsImg(product.img))
                                        rez = true;
            return rez;
        }

        private bool IsImg(string path)
        {
            bool rez;
            if (path.EndsWith(".png") || path.EndsWith(".jpg"))
                rez = true;
            else
                rez = false;
            return rez;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
