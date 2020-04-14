using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CodeExampleModels
{
    public class ExampleDelete
    {
        public int CodeExampleId { get; set; }

        public string ProfileId { get; set; }

        public int CategoryId { get; set; }
        [Display(Name = "Code Category")]
        public string CategoryName { get; set; }
        
        public string Title { get; set; }

        public string UserName { get; set; }
       
        [Display(Name = "Code Example")]
        public string ExampleCode { get; set; }
       
        [Display(Name = "Discription")]
        public string ExampleDiscription { get; set; }
       
        [Display(Name = "Initial Post")]
        public DateTimeOffset InitialPost { get; set; }
      
        [Display(Name = "Last Modified")]
        public DateTimeOffset? EditedPost { get; set; }
    }
}
