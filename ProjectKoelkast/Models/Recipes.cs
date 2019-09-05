
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProjectKoelkast.Models
{

    public class Recipes
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public string Keuken { get; set; }
        public string Gang { get; set; }
        public int AantalPersonen { get; set; }
        public int Tijd { get; set; }
        public string Voedingswaarden { get; set; }
        [Required]
        public int ProductId { get; set; }
       
        public string Bereidwijze { get; set; }
        public byte[] ImageUrl { get; set; }
        public IEnumerable<int> Product_IDs { get; set; }
        public virtual Product Product { get; set; }


    }
   
    public enum Course
    {
        Voorgerecht,
        Hoofdgerecht,
        Nagerecht
    }


}