using ProductView_v_4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

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
            ProductRepository.UpdateProducts(product);
            return Redirect("/Home/Index");
        }

        public IActionResult Add(Product product)
        {
            ProductRepository.AddProducts(product);
            return Redirect("/Home/NewProduct");
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
