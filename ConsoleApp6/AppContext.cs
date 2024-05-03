using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class AppContext : DbContext
    {
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<EthnicGroup> EthnicGroups { get; set; }
        public DbSet<Religion> Religions { get; set; }

        public AppContext() : base("dbModel") { }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Country>()
        //        .HasRequired(c => c.Continents)
        //        .WithMany(cont => cont.Countries)
        //        .HasForeignKey(c => c.ContinentId);
        //}
    }
}
