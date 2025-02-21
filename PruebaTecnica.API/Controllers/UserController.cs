using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnica.API.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
