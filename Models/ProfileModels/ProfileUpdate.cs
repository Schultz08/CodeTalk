using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProfileModels
{
    public class ProfileUpdate
    {
        public string ProfileId { get; set; }
        [MinLength(1)]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MinLength(1)]
        [MaxLength(50)]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(1)]
        [MaxLength(50)]
        public string UserName { get; set; }
    }
}
