using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string ProfileId { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(3)]
        [MaxLength(15)]
        public string UserName { get; set; }

        public virtual ICollection<CodeExample> UserTotalLike { get; set; }

        [ForeignKey(nameof(User))]
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
