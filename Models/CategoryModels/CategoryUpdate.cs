using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CategoryModels
{
    public class CategoryUpdate
    {
        public int CategoryId { get; set; }
       
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        
        [Display(Name = "Category Description")]
        public string CategoryDescription { get; set; }
    }
}
