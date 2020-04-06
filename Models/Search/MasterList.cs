using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Search
{
    public class MasterList
    {
        public string ProfileId { get; set; }
       
        public int CodeExampleId { get; set; }

        public int CategoryId { get; set; }
        
        public string UserName { get; set; }
        public int PostCount { get; set; }

        public string ExampleTitle { get; set; }

        public string ExampleDiscription { get; set; }

        public DateTimeOffset InitialPost { get; set; }

        public DateTimeOffset? EditedPost { get; set; }

        public string CategoryName { get; set; }
      
        public string CategoryDiscription { get; set; }
    }
}
