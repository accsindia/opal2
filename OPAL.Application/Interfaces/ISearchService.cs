using OPAL.Domain.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPAL.Application.Interfaces
{
    public interface ISearchService
    {
        IQueryable<BasicSearch> BasicSearch { get; set; }
    }
}
