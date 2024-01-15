using Microsoft.AspNetCore.Mvc;

namespace Business.P_1.Areas.admin.Controllers
{
    public class Dashboard : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
