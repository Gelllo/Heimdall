using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Domain.GlucoseRecordDomain;
using Heimdall.Domain.UsersDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace Heimdall.Infrastracture.Database
{
    public class DataContext: DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options): base(options) {}
        public DbSet<User> Users { get; set; }
        public DbSet<GlucoseRecord> GlucoseRecords { get; set; }


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
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().HasAlternateKey(u => u.UserID);

            modelBuilder.Entity<GlucoseRecord>().ToTable("GlucoseRecords")
                .HasOne(gr=> gr.User)
                .WithMany(u => u.GlucoseRecords)
                .HasForeignKey(gr => gr.UserId)
                .HasPrincipalKey(u=>u.UserID)
                .IsRequired();
        }
    }
}
