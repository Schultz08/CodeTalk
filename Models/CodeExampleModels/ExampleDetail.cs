﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CodeExampleModels
{
    public class ExampleDetail
    {
        public int CodeExampleId { get; set; }
        public string ProfileId { get; set; }
        public int CategoryId { get; set; }
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }
        public string UserName { get; set; }
        
        public string ExampleCode { get; set; }

        public string ExampleDiscription { get; set; }

        public double AverageRating { get; set; }
        
        public DateTimeOffset InitialPost { get; set; }

        public DateTimeOffset? EditedPost { get; set; }

    }
}
