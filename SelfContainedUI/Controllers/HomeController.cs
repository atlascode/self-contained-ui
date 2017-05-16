using Microsoft.AspNetCore.Mvc;

namespace ParentSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
