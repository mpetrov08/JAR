using Microsoft.AspNetCore.Mvc;

namespace JAR.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public IActionResult Index() => View();
    }
}
