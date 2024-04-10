using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using starwars.Domain;

namespace starwars.DataAccess
{
    public class StarwarsContext : DbContext
    {
        public StarwarsContext() { }
        public StarwarsContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Character>? Characters { get; set; }

        public virtual DbSet<User>? Users { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string directory = Directory.GetCurrentDirectory();

                IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(directory)
         .AddJsonFile("appsettings.json")
         .Build();

                var connectionString = configuration.GetConnectionString(@"starwarsDB");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}

