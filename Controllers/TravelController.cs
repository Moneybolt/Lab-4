using Laboratorium_nr3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_nr3.Controllers
{
    public class TravelController : Controller
    {
        private readonly ITravelService _travelservice;
        public TravelController(ITravelService travelService)
        {
            _travelservice = travelService;
        }
        public IActionResult Index()
        {
            return View(_travelservice.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Travel model)
        {
            if (ModelState.IsValid)
            {
                _travelservice.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_travelservice.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Travel model)
        {
            if (ModelState.IsValid)
            {
                _travelservice.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var travelToDelete = _travelservice.FindById(id);
            if (travelToDelete == null)
            {
                return NotFound();
            }

            return View(travelToDelete);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var travelToDelete = _travelservice.FindById(id);
            if (travelToDelete == null)
            {
                return NotFound();
            }

            _travelservice.DeleteById(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var travelDetails = _travelservice.FindById(id);
            if (travelDetails == null)
            {
                return NotFound();
            }

            return View(travelDetails);
        }
    }
}
