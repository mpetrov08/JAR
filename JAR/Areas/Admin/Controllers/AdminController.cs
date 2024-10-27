using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static JAR.Infrastructure.Constants.AdministratorConstants;

namespace JAR.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminController : Controller
    {
    }
}
