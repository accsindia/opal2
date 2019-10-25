using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OPAL.Application.Search.Queries.GetBasicSearch;
using OPAL.Presentation.Search.Models;

namespace OPAL.Presentation.Search
{
    public class SearchController : Controller
    {
        readonly IGetBasicSearchQuery _basicSearchQuery;
        public SearchController(IGetBasicSearchQuery basicSearchQuery)
        {
            _basicSearchQuery = basicSearchQuery;
        }

        public IActionResult BasicSearch()
        {
            var results = _basicSearchQuery.Execute();

            var resultsVM = from result in results
                select new BasicSearchViewModel {
                    Id = result.Id,
                    Author = result.Author,
                    DocumentTitle = result.DocumentTitle,
                    DocumentDescription = result.DocumentDescription,
                    CreateOn = result.CreateOn,
                    CreatedBy = result.CreatedBy,
                    UpdateOn = result.UpdateOn,
                    UpdatedBy = result.UpdatedBy
                };

            return View(resultsVM);
        }
    }
}
