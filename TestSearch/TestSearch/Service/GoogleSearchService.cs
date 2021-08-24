using Newtonsoft.Json;
using System.Collections.Generic;
using TestSearch.Helpers;
using TestSearch.Interfaces;
using TestSearch.Models;

namespace TestSearch.Service
{
    public class GoogleSearchService : IGoogleSearchService
    {
        /// <summary>
        /// Return list of Search results
        /// </summary>
        /// <param name="query">search text</param>
        /// <returns>List of search results</returns>
        public List<SearchResultModel> GetSearchResults(string query)
        {
            var url = WebClientHelper.FormGoogleSearchApiUrl(query);
            var jsonData = WebClientHelper.GenerateClient(url);
            dynamic objData = JsonConvert.DeserializeObject(jsonData);
            var results = new List<SearchResultModel>();

            foreach (var item in objData.items)
            {
                results.Add(new SearchResultModel
                {
                    Title = item.title,
                    Link = item.link,
                    Snippet = item.snippet
                });
            }

            return results;
        }
    }
}