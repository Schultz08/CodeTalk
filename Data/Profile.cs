using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Profile
    {
        [Key]
        public string ProfileId
        {
            get
            {

                return User.Id;
            }
        }
        [Required]
        [Range(1, 50)]
        public string FirstName { get; set; }
        [Required]
        [Range(1, 50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Range(3, 15)]
        public string UserName { get; set; }

        public double AverageRating { get; set; }

        public virtual ICollection<CodeExample> UserRating { get; set; }

        [ForeignKey(nameof(User))]
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
