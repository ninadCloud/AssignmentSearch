using System;
using System.Linq;
using System.Web.Mvc;
using TestSearch.Interfaces;

namespace TestSearch.Controllers
{
    [HandleError]
    public class SearchController : Controller
    {
        private readonly ISearchEngineService _searchEngineService;
        private readonly IGoogleSearchService _googleSearchService;
        public SearchController(ISearchEngineService searchEngineService, IGoogleSearchService googleSearchService)
        {
            _searchEngineService = searchEngineService;
            _googleSearchService = googleSearchService;
        }

        public ActionResult Index()
        {
            try
            {
                var engines = _searchEngineService.GetAllSearchEngines();
                ViewBag.ddlData = engines;
                return View(engines);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        [HttpPost]
        public ActionResult SearchResults()
        {
            try
            {
                string searchQuery = Request["google"];
                if (!string.IsNullOrWhiteSpace(searchQuery))
                {
                    var searchResult = _googleSearchService.GetSearchResults(searchQuery);
                    return View(searchResult.ToList());
                }
            }
            catch (Exception ex)
            {

            }

            return View();
        }
    }
}