using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestSearch.Data;
using TestSearch.Interfaces;
using Unity;

namespace TestSearch.Interfaces
{
    public class SearchEngineRepository : ISearchEngineRepository
    {
        [Dependency]
        public SearchDBEntities context { get; set; }

        public SearchEngine GetSearchEngineByID(int Id)
        {
            return context.SearchEngines.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<SearchEngine> GetSearchEngines() 
        { 
            return context.SearchEngines.ToList(); 
        }

        public int RegisterEngine(SearchEngine engine)
        {
            context.SearchEngines.Add(engine);
            return context.SaveChanges();
        }

        public int UpdateEngine(SearchEngine engine)
        {
            var objEngine = GetSearchEngineByID(engine.Id);
            objEngine.Name = engine.Name;
            objEngine.Url = engine.Url;
            return context.SaveChanges();
        }

        public int DeleteEngine(int Id)
        {
            var objEngine = GetSearchEngineByID(Id);
            context.SearchEngines.Remove(objEngine);
            return context.SaveChanges();
        }
    }
}