using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Model;
using System.Data.Entity.Migrations;

namespace Domain
{

    public class EFDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }


        public EFDbContext()
            : base("name=EFDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.CreateIfNotExists();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Car>().HasKey(x => x.Id);
            modelBuilder.Entity<Car>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Car>().Property(x => x.Model).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.Brand).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.CarType).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.ProductionYear).IsRequired();

            modelBuilder.Entity<Owner>().HasKey(x => x.Id);
            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Owner>().Property(x => x.FirstName).IsRequired();
            modelBuilder.Entity<Owner>().Property(x => x.LastName).IsRequired();
            modelBuilder.Entity<Owner>().Property(x => x.DrivingExperience).IsOptional();

            modelBuilder.Entity<Owner>()
            .HasMany(p => p.Cars)
            .WithMany(c => c.Owners)
            .Map(m =>
            {
                m.ToTable("CarOwners");
                m.MapLeftKey("OwnerId");
                m.MapRightKey("CarId");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
