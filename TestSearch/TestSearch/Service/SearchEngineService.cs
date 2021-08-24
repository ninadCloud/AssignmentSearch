using System;
using System.Collections.Generic;
using System.Linq;
using TestSearch.Models;
using TestSearch.Interfaces;
using AutoMapper;
using TestSearch.Data;

namespace TestSearch.Service
{
    public class SearchEngineService : ISearchEngineService
    {
        private readonly ISearchEngineRepository _repository;
        private readonly IMapper _mapper;

        public SearchEngineService(ISearchEngineRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<SearchEngineModel> GetAllSearchEngines()
        {
            var engines = new List<SearchEngineModel>();
            var engineList = _repository.GetSearchEngines();

            if (engineList.Any())
            {
                foreach (var engine in engineList)
                {
                    engines.Add(new SearchEngineModel { 
                    Id = engine.Id,
                    Name = engine.Name,
                    Url = engine.Url
                    });
                }
            }

            return engines;
        }

        public bool AddSearchEngine(SearchEngineModel searchEngineModel)
        {
            int rowAffected = _repository.RegisterEngine(new SearchEngine { Id = searchEngineModel.Id, Name = searchEngineModel.Name, Url = searchEngineModel.Url});
            return rowAffected > 0;
        }

        public bool EditSearchEngine(SearchEngineModel searchEngineModel)
        {
            int rowAffected = _repository.UpdateEngine(new SearchEngine { Id = searchEngineModel.Id, Name = searchEngineModel.Name, Url = searchEngineModel.Url });
            return rowAffected > 0;
        }

        public bool IsEngineAlreadyPresent(string name)
        {
            var engines = GetAllSearchEngines();
            return engines.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public SearchEngineModel GetSearchEngineByID(int Id)
        {
            return GetAllSearchEngines().FirstOrDefault(x => x.Id == Id);
        }

        public bool DeleteSearchEngineById(int Id)
        {
            var rowAffected = _repository.DeleteEngine(Id);
            return rowAffected > 0;
        }
    }
}