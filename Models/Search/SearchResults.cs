using Models.CategoryModels;
using Models.CodeExampleModels;
using Models.ProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Search
{
    public class SearchResults
    {
        public ICollection<object> SearchResult { get; set; }
    }
}
