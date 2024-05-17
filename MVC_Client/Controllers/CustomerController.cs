using Microsoft.AspNetCore.Mvc;
using MVC_Client.APIFunction;
using MVC_Client.Model.Customer;

namespace MVC_Client.Controllers
{
    public class CustomerController : Controller
    {

        public IActionResult Index()
        {
            List<CustomerVM> customers = APICustomer.GetAllCustomer();
            return View(customers);
        }


        public IActionResult Delete(string CustomerId)
        {
            APICustomer.DeleteCustomer(CustomerId);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Index(string id)
        {
            List<CustomerVM> products = APICustomer.GetCustomerById(id.ToLower());
            return View(products);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(CustomerVM customer)
        {
            APICustomer.AddCustomer(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Update(string id)
        {
            List<CustomerVM> customer = APICustomer.GetCustomerById(id);
            ViewData["customer"] = customer[0];
            return View("UpdateCustomer");
        }
        
        public IActionResult Details(string id)
        {
            List<CustomerVM> customersdetail = APICustomer.GetCustomerById(id);
            return View(customersdetail);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(CustomerVM customer)
        {
            APICustomer.UpdateCustomer(customer);
            return RedirectToAction("Index");
        }

    }
}
