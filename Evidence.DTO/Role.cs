using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evidence.DTO
{
    public partial class Role:Entity
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
