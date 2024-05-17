using Microsoft.AspNetCore.Mvc;
using MVC_Client.APIFunction;
using MVC_Client.Model.Product;

namespace MVC_Client.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<ProductVM> products = APIProduct.GetAllProducts();
            return View(products);
        }

        
        public IActionResult Delete(int id)
        {
            ProductVM order = APIProduct.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Index(string id)
        {
            List<ProductVM> products = APIProduct.GetProductById(Int32.Parse(id));
            return View(products);
        }

        //public IActionResult CategorySearch(string id)
        //{
        //    List<ProductVM> products = APIFunc.GetProductByCatId(Int32.Parse(id));
        //    return redir
        //}


        public IActionResult Details(int id)
        {
            List<ProductDetail> productDetails = APIProduct.GetProductDetail(id);
            return View(productDetails);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductAdd product)
        {
            APIProduct.AddProduct(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            List<ProductDetail> products = APIProduct.GetProductDetail(id);
           ViewData["product"] = products[0];
            return View("UpdateProduct");
        }

        [HttpPost]
        public IActionResult UpdateProduct(ProductDetail products)
        {
         APIProduct.UpdateProduct(products);
            return RedirectToAction("Index");
        }



    }
}
