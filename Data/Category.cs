using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Category
    {
        [Key]
        public string CategoryId { get; set; }
        [Required]
        [Range(3, 50)]
        public string CategoryName { get; set; }
        [Required]
        [Range(3, 50)]
        public string CategoryDiscription { get; set; }

    }
}
