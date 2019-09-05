using System.Data.Entity;
using MySql.Data.Entity;
using ProjectKoelkast.Models;

namespace ProjectKoelkast.DataContext
{
    

    /*
     * Used to create entities in context for the 'Koelkast' database by accessing a DbSet on a context object.
     * Inherits from DbContext.
     */
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class KoelkastContext : DbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }

        public KoelkastContext() : base("KoelkastConnection")
        {
            
        }
    }
}