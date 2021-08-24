using System;
using System.Web.Mvc;
using TestSearch.Models;
using TestSearch.Interfaces;

namespace TestSearch.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly ISearchEngineService _service;
        public HomeController(ISearchEngineService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var data = _service.GetAllSearchEngines();
                return View(data);
            }
            catch (Exception ex)
            {

            }

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new SearchEngineModel());
        }

        [HttpPost]
        public ActionResult Create(SearchEngineModel engineModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_service.IsEngineAlreadyPresent(engineModel.Name))
                    {
                        if (_service.AddSearchEngine(engineModel))
                        {
                            return RedirectToAction(nameof(Index));
                        }

                        ViewBag.Message = "Failed to Register engine! Please try again!";

                        return View(engineModel);
                    }

                    ModelState.AddModelError("Name", "Search engine name already present");

                    return View(engineModel);
                }
            }
            catch (Exception ex)
            {

            }

            return View(engineModel);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            try
            {
                var engine = _service.GetSearchEngineByID(Id);

                if (engine != null)
                {
                    return View(engine);
                }
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Edit(SearchEngineModel engineModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_service.IsEngineAlreadyPresent(engineModel.Name))
                    {
                        ModelState.AddModelError("Name", "Search engine name already present");

                        return View(engineModel);
                    }

                    if (_service.EditSearchEngine(engineModel))
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    ViewBag.Message = "Failed to update. Please try again.";

                    return View(engineModel);
                }
            }
            catch (Exception ex)
            {

            }

            return View(engineModel);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            try
            {
                var engine = _service.GetSearchEngineByID(Id);

                if (engine != null)
                {
                    return View(engine);
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Delete(SearchEngineModel engineModel)
        {
            try
            {
                if (_service.DeleteSearchEngineById(engineModel.Id))
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Message = "Failed to delete. Please try again.";
            }
            catch (Exception ex)
            {

            }
            return View(engineModel);
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            try
            {
                var engine = _service.GetSearchEngineByID(Id);
                if (engine != null)
                {
                    return View(engine);
                }
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction(nameof(Index));
        }
    }
}