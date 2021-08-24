using System.Collections.Generic;
using TestSearch.Data;

namespace TestSearch.Interfaces
{
    public interface ISearchEngineRepository
    {
        IEnumerable<SearchEngine> GetSearchEngines();
        SearchEngine GetSearchEngineByID(int Id);
        int RegisterEngine(SearchEngine engine);
        int DeleteEngine(int Id);
        int UpdateEngine(SearchEngine engine);
    }
}
