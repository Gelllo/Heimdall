using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace Heimdall.Infrastracture.Database
{
    public class DataContext: DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options): base(options) {}
        public DbSet<GlucoseRecord?> GlucoseRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
                var connString = configuration.GetConnectionString("HeimdallConnection");
                optionsBuilder.UseSqlServer(connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<GlucoseRecord>().ToTable("GlucoseRecords").HasKey(x=>x.Id);
        }
    }
}
