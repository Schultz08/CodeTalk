using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CategoryModels
{
    public class CategoryCreate
    {
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        
        [Display(Name = "Category Discription")]
        public string CategoryDiscription { get; set; }
    }
}
