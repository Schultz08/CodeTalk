using Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CodeExampleModels
{
    public class ExampleCreate
    {
        public int CodeExampleId { get; set; }

        public string ProfileId { get; set; }

        [Display(Name ="Category Type")]
        public int CategoryId { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Display(Name = "Show off your awsome code!")]
        public string ExampleCode { get; set; }
        [Display(Name = "Explain your code in your own words!")]
        public string ExampleDiscription { get; set; }

        public DateTimeOffset TimeStamp { get; set; }

        public DateTimeOffset Edited { get; set; }


    }
}
