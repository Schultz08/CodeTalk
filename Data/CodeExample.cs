using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CodeExample
    {
        [Key]
        public int CodeExampleId { get; set; }
        [Required]
     //   [Column(TypeName ="VARBINARY")]
        public string ExampleCode { get; set; }
        [Required]
        public string ExampleDiscription { get; set; }

        public DateTimeOffset InitialPost { get; set; }

        public DateTimeOffset EditedPost { get; set; }

        public double AverageRating { get; set; }

        public virtual ICollection<Rate> Rating { get; set; }


        [ForeignKey(nameof(Profile))]
        public string ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
