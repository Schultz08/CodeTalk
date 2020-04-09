using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Search
{
    public class SearchFilter
    {
        [Display(Name = "Profiles")]
        public bool SearchProfile { get; set; }
        [Display(Name = "Categories")]
        public bool SearchCategory { get; set; }
        [Display(Name = "Example Code Titles")]
        public bool SearchCodeExample { get; set; }
        [Display(Name = "Search")]
        public string SearchRequest { get; set; }
    }
}
