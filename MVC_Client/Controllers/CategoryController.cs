using Microsoft.AspNetCore.Mvc;
using MVC_Client.APIFunction;
using MVC_Client.Model.Category;

namespace MVC_Client.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            List<CategoryVM> categories = APICategory.GetAllCategory();
            return View(categories);
        }

        [HttpPost]
        public IActionResult Index(string id)
        {
            List<CategoryVM> products = APICategory.GetCategory(Int32.Parse(id));
            return View(products);
        }

        public IActionResult Delete(int id)
        {
             APICategory.DeleteCategory(id);
            return RedirectToAction("Index");
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryVM category)
        {
            APICategory.AddNewCategory(category);
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            List<CategoryVM> categories = APICategory.GetCategory(id);
            ViewData["category"] = categories[0];
            return View("UpdateCategory");
        }

        [HttpPost]
        public IActionResult UpdateCategory(CategoryVM category)
        {
            APICategory.UpdateCategory(category);
            return RedirectToAction("Index");
        }

    }
}
