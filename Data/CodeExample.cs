using Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string ExampleCode { get; set; }
        [Required]
        public string ExampleDiscription { get; set; }

        public DateTimeOffset InitialPost { get; set; }

        public DateTimeOffset? EditedPost { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();


        [ForeignKey(nameof(Profile))]
        public string ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
