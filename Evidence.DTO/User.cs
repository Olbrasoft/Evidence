using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evidence.DTO
{
    public partial class User:Entity
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string SurName { get; set; }
        
        public virtual ICollection<Role> Roles { get; set; }
    }
}
