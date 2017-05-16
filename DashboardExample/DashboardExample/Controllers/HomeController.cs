using Microsoft.AspNetCore.Mvc;

namespace DashboardExample.DashboardExample.Controllers
{
	public class HomeController : Controller
    {
		[NamespaceConstraint]
		public IActionResult Index()
        {
            return this.View();
        }
    }
}
