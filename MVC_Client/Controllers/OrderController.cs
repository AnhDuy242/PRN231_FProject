using Microsoft.AspNetCore.Mvc;
using MVC_Client.APIFunction;
using MVC_Client.Model;
using MVC_Client.Model.Order;

namespace MVC_Client.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<OrderVM> order = APIOrder.GetAllOrders();
            return View(order);
        }


        public IActionResult Delete(int id)
        {
            OrderVM order = APIOrder.DeleteProduct(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Index(string from, string to)
        {
            List<OrderVM> order = APIOrder.GetOrderByDate(from, to);
            return View(order);
        }

        public IActionResult Details(int id)
        {

            List<OrderDetailVm> orders = APIOrder.GetOrderDetailById(id);
            return View(orders);
        }

        public IActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrder(OrderAdd order)
        {
            APIOrder.AddNewOrder(order);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            List<OrderVM> products = APIOrder.GetOrderById(id);
            ViewData["order"] = products[0];
            return View("UpdateOrder");
        }

        [HttpPost]
        public IActionResult UpdateOrder(OrderVM order)
        {
            APIOrder.UpdateOrder(order);
            return RedirectToAction("Index");
        }


        
    }
}
