using ButterfliesShop.Models;
using ButterfliesShop.Services;
using ButterfliesShop.ViewModels.Butterfly;
using Microsoft.AspNetCore.Mvc;

namespace ButterfliesShop.Controllers
{
    public class ButterflyController : Controller
    {
        private readonly IDataService DataService;
        private readonly IButterfliesQuantityService ButterfliesQuantityService;

        public ButterflyController(
            IDataService dataService,
            IButterfliesQuantityService butterfliesQuantityService)
        {
            DataService = dataService;
            ButterfliesQuantityService = butterfliesQuantityService;
            InitializeButterfliesData();
        }

        public IActionResult Index() => View(new IndexViewModel { Butterflies = DataService.ButterfliesList });

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Butterfly butterfly)
        {
            if (!ModelState.IsValid || !DataService.AddButterfly(butterfly)) return View(butterfly);
            return RedirectToAction("Index");
        }

        public IActionResult GetImage(int id)
        {
            var butterfly = DataService.GetButterflyById(id);
            if (butterfly == null || string.IsNullOrEmpty(butterfly.ImageName) 
                || string.IsNullOrEmpty(butterfly.ImageMimeType)) return null;

            return File($@"\images\{butterfly.ImageName}", butterfly.ImageMimeType);
        }

        private void InitializeButterfliesData()
        {
            if (DataService.ButterfliesList != null) return;
            var butterflies = DataService.ButterfliesInitializeData();
            foreach (var butterfly in butterflies) ButterfliesQuantityService.AddButterfliesQuantityData(butterfly);
        }
    }
}