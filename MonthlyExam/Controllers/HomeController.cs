using Microsoft.AspNetCore.Mvc;

namespace MonthlyExam.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
