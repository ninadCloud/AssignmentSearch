using System.Collections.Generic;
using TestSearch.Models;

namespace TestSearch.Interfaces
{
    public interface IGoogleSearchService
    {
        List<SearchResultModel> GetSearchResults(string query);
    }
}
