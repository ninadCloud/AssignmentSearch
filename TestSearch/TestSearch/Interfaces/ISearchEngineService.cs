using System.Collections.Generic;
using TestSearch.Models;

namespace TestSearch.Interfaces
{
    public interface ISearchEngineService
    {
        List<SearchEngineModel> GetAllSearchEngines();

        bool AddSearchEngine(SearchEngineModel searchEngineModel);

        bool EditSearchEngine(SearchEngineModel searchEngineModel);

        bool DeleteSearchEngineById(int Id);

        bool IsEngineAlreadyPresent(string name);

        SearchEngineModel GetSearchEngineByID(int Id);
    }
}
