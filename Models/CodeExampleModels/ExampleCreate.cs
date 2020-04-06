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

        public int CategoryId { get; set; }
        //  public List<CategoryList> Category { get; set; } = new List<CategoryList>(); 

        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }

        public string ExampleCode { get; set; }

        public string ExampleDiscription { get; set; }

        public DateTimeOffset TimeStamp { get; set; }

        public DateTimeOffset Edited { get; set; }


    }
}
