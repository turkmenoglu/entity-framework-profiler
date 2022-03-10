using System.Linq;
using System.Web.Mvc;
using EFProfilerTest.Models;

namespace EFProfilerTest.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LazyLoadingEnabledProductListResult()
        {
            EFProfilerTestContainer container = new EFProfilerTestContainer();
            container.Configuration.LazyLoadingEnabled = true;

            var productList = container.Products.ToList();

            return View(productList);
        }

        public ActionResult EagerLoadingEnabledProductListResult()
        {
            EFProfilerTestContainer container = new EFProfilerTestContainer();

            var productList = container.Products.Include("Brand").ToList();

            return View(productList);
        }
    }
}