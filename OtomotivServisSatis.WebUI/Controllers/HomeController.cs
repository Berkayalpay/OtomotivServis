using Microsoft.AspNetCore.Mvc;
using OtomotivServisSatis.Entities;
using OtomotivServisSatis.Service.Abstract;
using OtomotivServisSatis.WebUI.Models;
using System.Diagnostics;

namespace OtomotivServisSatis.WebUI.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IService<Slider> _service;
        private readonly ICarService _serviceArac;

        public HomeController(IService<Slider> service, ICarService serviceArac)
        {
            _service = service;
            _serviceArac = serviceArac;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = new HomePageViewModel() //Sayfaya Yolladıgımız model değişti.
            {
                Sliders = await _service.GetAllAsync(),
                Araclar = await _serviceArac.GetCustomCarList(a=>a.Anasayfa)
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
