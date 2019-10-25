using System;
using System.Collections.Generic;
using System.Text;

namespace OPAL.Application.Search.Queries.GetBasicSearch
{
    public class BasicSearchModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentDescription { get; set; }
        public DateTime CreateOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdateOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
