using System.ComponentModel.DataAnnotations;

namespace Evidence.DTO
{
    public class Product:Entity
    {

        [Required(ErrorMessage = "Název produktu je vyžadován.")]
        [MaxLength(100, ErrorMessage = "Maximální délka názvu produktu je 100 znaků.")]
        public string Name { get; set; }
        [MaxLength(100, ErrorMessage = "Maximální délka názvu produktu je 100 znaků.")]
        public string Author { get; set; }
        public string Description { get; set; }
        
        public int CategoryId { get; set; }
        
        public virtual Category Category { get; set; }
    }
}
