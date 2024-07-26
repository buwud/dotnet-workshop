using Microsoft.AspNetCore.Mvc;

namespace dotnet_workshop_deneme.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
