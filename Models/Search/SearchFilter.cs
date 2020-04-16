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
        [Display(Name = "UserNames")]
        public bool SearchProfile { get; set; }
        [Display(Name = "Category Name")]
        public bool SearchCategory { get; set; }
        [Display(Name = "Example Titles")]
        public bool SearchCodeExample { get; set; }
        [Display(Name = "Search")]
        public string SearchRequest { get; set; }
    }
}
