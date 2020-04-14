using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProfileModels
{
    public class ProfileDetail
    {
        public string ProfileId { get; set; }
       
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }
        
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}
