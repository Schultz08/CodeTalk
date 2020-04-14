using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CodeExampleModels
{
    public class ExampleDetail
    {
        public int CodeExampleId { get; set; }
       
        public string ProfileId { get; set; }
        
        public int CategoryId { get; set; }
        
        [Display(Name = "Code Category")]
        public string CategoryName { get; set; }

        public string Title { get; set; }
        
        [Display(Name = "Posted By")]
        public string UserName { get; set; }
        
        [Display(Name = "Snipet of Code")]
        public string ExampleCode { get; set; }
        
        [Display(Name = "Code Description")]
        public string ExampleDescription { get; set; }
        
        [Display(Name = "Initial Post Date")]
        public DateTimeOffset InitialPost { get; set; }

        [Display(Name = "Last Modified")]
        public DateTimeOffset? EditedPost { get; set; }

    }
}
