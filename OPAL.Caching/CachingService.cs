using OPAL.Application.Interfaces;
using OPAL.Domain.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Redis;


namespace OPAL.Caching
{
    public class CachingService : ISearchService
    {
        const string _basicSearchKey = "BasicSearch";
        ISearchService _searchService;
        IRedisClient _client;
        public CachingService(ISearchService searchService, IRedisClient client)
        {
            _searchService = searchService;
            _client = client;
        }

        public IEnumerable<BasicSearch> BasicSearch
        {
            get
            {
                var cachedResult = _client.Get<IEnumerable<BasicSearch>>(_basicSearchKey);
                if (cachedResult == null)
                {
                    cachedResult = _searchService.BasicSearch;
                    _client.Set(_basicSearchKey, cachedResult);
                }

                return cachedResult;
            }
        }
    }
}
