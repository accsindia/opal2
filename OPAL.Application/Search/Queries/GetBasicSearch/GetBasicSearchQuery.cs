using OPAL.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OPAL.Application.Search.Queries.GetBasicSearch
{
    public class GetBasicSearchQuery : IGetBasicSearchQuery
    {
        ISearchService _search;
        public GetBasicSearchQuery(ISearchService search)
        {
            _search = search;
        }
        public IEnumerable<BasicSearchModel> Execute()
        {
            return  _search.BasicSearch.
                Select(x => new BasicSearchModel {
                    Id = x.Id,
                    Author = x.Author,
                    DocumentTitle = x.DocumentTitle,
                    DocumentDescription = x.DocumentDescription,
                    CreateOn = x.CreateOn,
                    CreatedBy = x.CreatedBy,
                    UpdateOn = x.UpdateOn,
                    UpdatedBy = x.UpdatedBy
                });
        }
    }
}
