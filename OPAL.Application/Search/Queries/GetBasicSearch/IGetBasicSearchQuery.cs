using System;
using System.Collections.Generic;
using System.Text;

namespace OPAL.Application.Search.Queries.GetBasicSearch
{
    public interface IGetBasicSearchQuery
    {
        IEnumerable<BasicSearchModel> Execute();
    }
}
