using Microsoft.AspNetCore.Mvc;
using MVC_Client.APIFunction;
using MVC_Client.Model.Supplier;

namespace MVC_Client.Controllers
{
    public class SupplierController : Controller
    {
        public IActionResult Index()
        {
            List<SupplierVM> suppliers = APISupplierFunc.GetAllSuppliers();

            return View(suppliers);
        }


        public IActionResult Details(int id)
        {
            List<SupplierVM> suppliers = APISupplierFunc.GetSupplierById(id);
            return View(suppliers);
        }

        [HttpGet]
        public IActionResult AddSupplier()
        {

            return View();
        }
        [HttpPost]
        
        public IActionResult AddSupplier(SupplierAdd supplier)
        {
             APISupplierFunc.AddSupplier(supplier);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            APISupplierFunc.DeleteSupplier(id);
            
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            List<SupplierVM> suppliers = APISupplierFunc.GetSupplierById(id);
            ViewData["supplier"] = suppliers[0];
            return View("UpdateSupplier");
        }

        [HttpPost]
        public IActionResult UpdateSupplier(SupplierVM supplier)
        {
            APISupplierFunc.UpdateSupplier(supplier);
            return RedirectToAction("Index");
        }
    }
}
