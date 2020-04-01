using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RateModels
{
    public class RateCreate
    {
        public int RateId { get; set; }

        public string ProfileId { get; set; }
        
        public int CodeExampleId { get; set; }
        [Range(0, 5)]
        public double MyRating { get; set; }
        [Range(1, 500)]
        public string Review { get; set; }

       
    }
}
