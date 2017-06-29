using System.Data.Entity;
using Services.Entity;


namespace Services.DataHandler
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<Person> Persons { get; set; }
    } 
}
