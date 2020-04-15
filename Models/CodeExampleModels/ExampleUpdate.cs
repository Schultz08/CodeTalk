using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CodeExampleModels
{
    public class ExampleUpdate
    {
        public int CodeExampleId { get; set; }

        public string ProfileId { get; set; }

        public int CategoryId { get; set; }
        [Display(Name = "Category Type")]

        public string CategoryName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }

        public string UserName { get; set; }

        [Required]
        [Display(Name = "Edit your Example Code")]
        public string ExampleCode { get; set; }
        [Required]
        [Display(Name = "Describ what your code is doing and What you changed")]
        public string ExampleDescription { get; set; }

        public DateTimeOffset? EditedPost { get; set; }


    }
}
