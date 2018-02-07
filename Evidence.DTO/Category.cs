using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evidence.DTO
{
    public class Category:Entity
    {
        [Required(ErrorMessage = "Název kategorie je vyžadován.")]
        [MaxLength(15, ErrorMessage = "Maximální délka názvu kategorie je 15 znaků.")]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
    
}