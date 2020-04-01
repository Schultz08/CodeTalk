using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RateModels
{
    public class RateUpdate
    {
        public int RateId { get; set; }

        public int CodeExampleId { get; set; }

        public string ProfileId { get; set; }
        
        public string Review { get; set; }

    }
}
