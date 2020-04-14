using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CodeExampleModels
{
    public class ExampleList
    {
        public int CodeExampleId { get; set; }

        public string ProfileId { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }

        public string UserName { get; set; }

        public string ExampleDescription { get; set; }
    }
}
