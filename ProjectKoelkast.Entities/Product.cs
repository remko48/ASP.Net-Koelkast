using System.ComponentModel.DataAnnotations;



namespace ProjectKoelkast.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }
        
        public virtual Category Category { get; set; }

    }
}
