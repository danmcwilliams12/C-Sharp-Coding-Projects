using EntityCodeFirstChallenge.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;



namespace EntityCodeFirstChallenge.DAL
{
    public class CollectionContext : DbContext
    {
        public CollectionContext() : base("CollectionContext")
        {
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}