using Core.Security.Entities;
using Domain.Entities;
using Domain.Enums;
using Domain.FindexScore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistence
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<FindexScore> FindexScores { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
        public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Damage> Damages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if(!optionsBuilder.IsConfigured)
            //{
            //    base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("RentACarConnectionString")));
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Model>(m =>
            {
                m.ToTable("Models").HasKey(k => k.Id);
                m.Property(p => p.Id).HasColumnName("Id");
                m.Property(p => p.Name).HasColumnName("Name");
                m.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
                m.Property(p => p.TransmissionId).HasColumnName("TransmissionId");
                m.Property(p => p.FuelId).HasColumnName("FuelId");
                m.Property(p => p.BrandId).HasColumnName("BrandId");
                m.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
                m.HasOne(p => p.Fuel);
                m.HasOne(p => p.Transmission);
                m.HasOne(p => p.Brand);
                m.HasMany(p => p.Cars);
            });

            modelBuilder.Entity<Car>(c =>
            {
                c.ToTable("Cars").HasKey(k => k.Id);
                c.Property(p => p.Id).HasColumnName("Id");
                c.Property(p => p.ModelYear).HasColumnName("ModelYear");
                c.Property(p => p.Plate).HasColumnName("Plate");
                c.Property(p => p.ColorId).HasColumnName("ColorId");
                c.Property(p => p.ModelId).HasColumnName("ModelId");
                c.Property(p => p.CarState).HasColumnName("State");
                c.HasOne(p => p.Color);
                c.HasOne(p => p.Model);
                c.HasOne(p => p.City);
            });

            modelBuilder.Entity<Transmission>(t =>
            {
                t.ToTable("Tranmissions").HasKey(k => k.Id);
                t.Property(p => p.Id).HasColumnName("Id");
                t.Property(p => p.Name).HasColumnName("Name");
                t.HasMany(p => p.Models);
            });
            modelBuilder.Entity<FindexScore>(f =>
            {
                f.ToTable("FindexScores").HasKey(k => k.Id);
                f.Property(p => p.Id).HasColumnName("Id");
                f.Property(p => p.UserId).HasColumnName("UserId");
                f.Property(p => p.Score).HasColumnName("Score");
                f.HasOne(p => p.User);
            });

            modelBuilder.Entity<Fuel>(f =>
            {
                f.ToTable("Fuels").HasKey(k => k.Id);
                f.Property(p => p.Id).HasColumnName("Id");
                f.Property(p => p.Name).HasColumnName("Name");
                f.HasMany(p => p.Models);
            });

            modelBuilder.Entity<Color>(c =>
            {
                c.ToTable("Colors").HasKey(k => k.Id);
                c.Property(p => p.Id).HasColumnName("Id");
                c.Property(p => p.Name).HasColumnName("Name");
                c.HasMany(p => p.Cars);
            });

            modelBuilder.Entity<City>(c =>
            {
                c.ToTable("Cities").HasKey(k => k.Id);
                c.Property(p => p.Id).HasColumnName("Id");
                c.Property(p => p.Name).HasColumnName("Name");
                c.HasMany(p => p.Cars);
            });

            modelBuilder.Entity<Brand>(b =>
            {
                b.ToTable("Brands").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.HasMany(p => p.Models);
            });

            //modelBuilder.Entity<Customer>(c =>
            //{
            //    c.ToTable("Customers").HasKey(k => k.Id);
            //    c.Property(p => p.Id).HasColumnName("Id");
            //    c.Property(p => p.Email).HasColumnName("Email");
            
            //});

            modelBuilder.Entity<IndividualCustomer>(ic =>
            {
                ic.ToTable("IndividualCustomers");
                ic.Property(p => p.FirstName).HasColumnName("FirstName");
                ic.Property(p => p.LastName).HasColumnName("LastName");
                ic.Property(p => p.NationalId).HasColumnName("NationalId");
            });

            modelBuilder.Entity<CorporateCustomer>(cc =>
            {
                cc.ToTable("CorporateCustomers");
                cc.Property(p => p.CompanyName).HasColumnName("CompanyName");
                cc.Property(p => p.TaxNumber).HasColumnName("TaxNumber");
            });

            modelBuilder.Entity<Invoice>(i =>
            {
                i.ToTable("Invoices").HasKey(i => i.Id);
                i.Property(p => p.CreationDate).HasColumnName("CreationDate");
                i.Property(p => p.RentStartDate).HasColumnName("RentStartDate");
                i.Property(p => p.RentEndDate).HasColumnName("RentEndDate");
                i.Property(p => p.TotalRentDay).HasColumnName("TotalRentDay");
                i.Property(p => p.TotalRentAmount).HasColumnName("TotalRentAmount");
                i.Property(p => p.AdditionalRentAmount).HasColumnName("AdditionalRentAmount");
                i.Property(p => p.UserId).HasColumnName("UserId");
                i.HasOne(p => p.User);
                i.HasMany(p => p.Cars);
            });

            modelBuilder.Entity<Rent>(r =>
            {
                r.ToTable("Rents").HasKey(i => i.Id);
                r.HasOne(x => x.GivingCity);
                r.HasOne(x => x.TakingCity);
                r.HasOne(x => x.Invoice);
                r.HasOne(r => r.Car);
                r.HasMany(x => x.AdditionalServices);
            });

            modelBuilder.Entity<AdditionalService>(a =>
            {
                a.ToTable("AdditionalServices").HasKey(i => i.Id);
                a.Property(x => x.Name).HasColumnName("Name");
                a.Property(x => x.DailyPrice).HasColumnName("DailyPrice");
                a.HasMany(x => x.Rents);
            });

            modelBuilder.Entity<Damage>(d =>
            {
                d.ToTable("Damages").HasKey(i => i.Id);
                d.Property(r => r.CarId).HasColumnName("CarId");
                d.Property(r => r.DamageDetail).HasColumnName("DamageDetail");
                d.HasOne(r => r.Car);
            });

            modelBuilder.Entity<User>(r =>
            {
                r.ToTable("Users").HasKey(i => i.Id);
                //r.Property(r => r.FirstName).HasColumnName("FirstName");
                //r.Property(r => r.LastName).HasColumnName("LastName");
                r.Property(r => r.Email).HasColumnName("Email");
                r.Property(r => r.PasswordHash).HasColumnName("PasswordHash");
                r.Property(r => r.PasswordSalt).HasColumnName("PasswordSalt");
                r.Property(r => r.Status).HasColumnName("Status");
            });

            modelBuilder.Entity<OperationClaim>(r =>
            {
                r.ToTable("OperationClaims").HasKey(i => i.Id);
                r.Property(r => r.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(r =>
            {
                r.ToTable("UserOperationClaims").HasKey(i => i.Id);
                r.Property(r => r.UserId).HasColumnName("UserId");
                r.Property(r => r.OperationClaimId).HasColumnName("OperationClaimId");
            });

            //Data Seeding
            var brand1 = new Brand(1,"BMW");
            var brand2 = new Brand(2,"Mercedes");
            modelBuilder.Entity<Brand>().HasData(brand1,brand2);

            var color1 = new Color(1,"Red");
            var color2 = new Color(2,"Blue");
            modelBuilder.Entity<Color>().HasData(color1, color2);

            var city1 = new City(1,"istanbul");
            var city2 = new City(2,"ankara");
            var city3 = new City(3,"izmir");
            modelBuilder.Entity<City>().HasData(city1, city2,city3);

            var transmission1 = new Transmission(1,"Manuel");
            var transmission2 = new Transmission(2,"Automatic");
            modelBuilder.Entity<Transmission>().HasData(transmission1, transmission2);

            var fuel1 = new Fuel(1, "Diesel");
            var fuel2 = new Fuel(2, "Electric");
            modelBuilder.Entity<Fuel>().HasData(fuel1, fuel2);

            var model1 = new Model(1,"418i",1000,2,1,1,"");
            var model2 = new Model(2,"CLA 180D",600,2,1,2,"");
            modelBuilder.Entity<Model>().HasData(model1, model2);

            var operationClaim1 = new OperationClaim(1, "Admin");
            var operationClaim2 = new OperationClaim(2, "Member");
          
            modelBuilder.Entity<OperationClaim>().HasData(operationClaim1, operationClaim2);

            modelBuilder.Entity<Car>().HasData(new Car(1,1,1,"06ABC06",1,2018,CarState.Available,100,300));
            modelBuilder.Entity<Car>().HasData(new Car(2,2,2,"34ABC34",1,2018,CarState.Available,10,500));
        }
    }
}