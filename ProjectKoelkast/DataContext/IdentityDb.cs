using Microsoft.AspNet.Identity.EntityFramework;
using ProjectKoelkast.Models;
using MySql.Data.Entity;
using System.Data.Entity;


namespace ProjectKoelkast.DataContext
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb()
            : base("DefaultConnection")
        {
        }

        public static IdentityDb Create()
        {
            return new IdentityDb();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipes> Recipes { get; set; }
        
    }
}