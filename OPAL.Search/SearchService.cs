using OPAL.Application.Interfaces;
using OPAL.Domain.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPAL.Search
{
    public class SearchService : ISearchService
    {
        public IQueryable<BasicSearch> BasicSearch { get; set; }

        public SearchService()
        {
            var search = new List<BasicSearch>
            {
                new BasicSearch {
                    Id = 1,
                    Author = "Zia",
                    DocumentTitle = "Document 1",
                    DocumentDescription = "first result document",
                    CreateOn = DateTime.Now.AddDays(-5),
                    CreatedBy = "Zia",
                    UpdateOn = DateTime.Now.AddDays(-5),
                    UpdatedBy = "Zia"
                },
                new BasicSearch {
                    Id = 2,
                    Author = "Zia",
                    DocumentTitle = "Document 2",
                    DocumentDescription = "second result document",
                    CreateOn = DateTime.Now.AddDays(-4),
                    CreatedBy = "Zia",
                    UpdateOn = DateTime.Now.AddDays(-4),
                    UpdatedBy = "Zia"
                },
                new BasicSearch {
                    Id = 3,
                    Author = "Zia",
                    DocumentTitle = "Document 3",
                    DocumentDescription = "third result document",
                    CreateOn = DateTime.Now.AddDays(-3),
                    CreatedBy = "Zia",
                    UpdateOn = DateTime.Now.AddDays(-3),
                    UpdatedBy = "Zia"
                },
                new BasicSearch {
                    Id = 4,
                    Author = "Zia",
                    DocumentTitle = "Document 4",
                    DocumentDescription = "fourth result document",
                    CreateOn = DateTime.Now.AddDays(-2),
                    CreatedBy = "Zia",
                    UpdateOn = DateTime.Now.AddDays(-2),
                    UpdatedBy = "Zia"
                }
            };

            BasicSearch = search.AsQueryable();
        }
    }
}
