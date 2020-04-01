using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Rate
    {
        [Key]
        public int RateId { get; set; }
        [Required]
        [Range(1, 5)]
        public double MyRating { get; set; }
        [Range(1, 500)]
        public string Review { get; set; }

        [ForeignKey(nameof(CodeExample))]
        public int CodeExampleId { get; set; }
        public virtual CodeExample CodeExample { get; set; }

        [ForeignKey(nameof(Profile))]
        public string ProfileId { get; set; }
        public virtual Profile Profile{ get; set; }

    }
}
