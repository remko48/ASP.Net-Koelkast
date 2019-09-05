using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProjectKoelkast.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public double Price { get; set; }
        public byte[] ImageUrl { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Recipes> Recipes { get; set; }
    }
}
