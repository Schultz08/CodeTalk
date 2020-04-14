using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        [ForeignKey(nameof(CodeExample))]
        public int CodeExampleId { get; set; }
        public virtual CodeExample CodeExample { get; set; }

        [ForeignKey(nameof(Profile))]
        public string ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
