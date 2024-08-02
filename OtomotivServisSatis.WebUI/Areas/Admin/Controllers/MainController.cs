using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OtomotivServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")] //Bu Controller bir area içerisinde çalışıcak ve çalısıcagı area ismi Admin.
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
