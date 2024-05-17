using Microsoft.AspNetCore.Mvc;
using MVC_Client.APIFunction;
using MVC_Client.Model;

namespace MVC_Client.Controllers
{
    public class HomeController : Controller
    {

     
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Account a)
        {
            if (APIAuthen.Login(a))
            {
                HttpContext.Session.SetString("Key", a.Username);

                return RedirectToAction("Index", "Product");
            }
            else { return View(); }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("Key", "");
            return RedirectToAction("Login");
        }
    }
}
