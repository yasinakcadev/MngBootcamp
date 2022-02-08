using Domain.Entities;
using Domain.Entities.Abstarct;
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

        public DbSet<Model> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<FindexScore> FindexScores { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
        public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Damage> Damages { get; set; }

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
            modelBuilder.Entity<Model>(b =>
            {
                b.ToTable("Models").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
                b.Property(p => p.TransmissionId).HasColumnName("TransmissionId");
                b.Property(p => p.FuelId).HasColumnName("FuelId");
                b.Property(p => p.BrandId).HasColumnName("BrandId");
                b.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
                b.HasOne(p => p.Fuel);
                b.HasOne(p => p.Transmission);
                b.HasOne(p => p.Brand);
                //b.HasMany(p => p.Cars);
            });

            modelBuilder.Entity<Car>(b =>
            {
                b.ToTable("Cars").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.ModelYear).HasColumnName("ModelYear");
                b.Property(p => p.Plate).HasColumnName("Plate");
                b.Property(p => p.ColorId).HasColumnName("ColorId");
                b.Property(p => p.ModelId).HasColumnName("ModelId");
                b.Property(p => p.CarState).HasColumnName("State");
                b.HasOne(p => p.Color);
                b.HasOne(p => p.Model);
                b.HasOne(p => p.City);
            });

            modelBuilder.Entity<Transmission>(b =>
            {
                b.ToTable("Tranmissions").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.HasMany(p => p.Models);
            });
            modelBuilder.Entity<FindexScore>(b =>
            {
                b.ToTable("FindexScores").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.CustomerId).HasColumnName("CustomerId");
                b.Property(p => p.Score).HasColumnName("Score");
                b.HasOne(p => p.Customer);
            });

            modelBuilder.Entity<Fuel>(b =>
            {
                b.ToTable("Fuels").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.HasMany(p => p.Models);
            });

            modelBuilder.Entity<Color>(b =>
            {
                b.ToTable("Colors").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.HasMany(p => p.Cars);
            });

            modelBuilder.Entity<City>(b =>
            {
                b.ToTable("Cities").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.HasMany(p => p.Cars);
            });

            modelBuilder.Entity<Brand>(b =>
            {
                b.ToTable("Brand").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.HasMany(p => p.Models);
            });

            modelBuilder.Entity<Customer>(c =>
            {
                c.ToTable("Customer").HasKey(k => k.Id);
                c.Property(p => p.Id).HasColumnName("Id");
                c.Property(p => p.Email).HasColumnName("Email");
            });

            modelBuilder.Entity<IndividualCustomer>(c =>
            {
                c.ToTable("IndividualCustomer");
                c.Property(p => p.FirstName).HasColumnName("FirstName");
                c.Property(p => p.Lastname).HasColumnName("Lastname");
                c.Property(p => p.NationalId).HasColumnName("NationalId");
            });

            modelBuilder.Entity<CorporateCustomer>(c =>
            {
                c.ToTable("CorporateCustomer");
                c.Property(p => p.CompanyName).HasColumnName("CompanyName");
                c.Property(p => p.TaxNumber).HasColumnName("TaxNumber");
            });

            modelBuilder.Entity<Invoice>(c =>
            {
                c.ToTable("Invoice").HasKey(i => i.Id);
                c.Property(p => p.CreationDate).HasColumnName("CreationDate");
                c.Property(p => p.RentStartDate).HasColumnName("RentStartDate");
                c.Property(p => p.RentEndDate).HasColumnName("RentEndDate");
                c.Property(p => p.TotalRentDay).HasColumnName("TotalRentDay");
                c.Property(p => p.TotalRentAmount).HasColumnName("TotalRentAmount");
                c.Property(p => p.CustomerId).HasColumnName("CustomerId");
                c.HasOne(p => p.Customer);
                c.HasMany(p => p.Cars);
            });

            modelBuilder.Entity<Rent>(r =>
            {
                r.ToTable("Rent").HasKey(i => i.Id);
                r.HasOne(x => x.GivingCity);
                r.HasOne(x => x.TakingCity);
                r.HasOne(x => x.Invoice);
                r.HasOne(r => r.Car);
            });

            modelBuilder.Entity<Damage>(r =>
            {
                r.ToTable("Damage").HasKey(i => i.Id);
                r.Property(r => r.CarId).HasColumnName("CarId");
                r.Property(r => r.DamageDetail).HasColumnName("DamageDetail");
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

            modelBuilder.Entity<Car>().HasData(new Car(1,1,1,"06ABC06",1,2018,CarState.Available,100));
            modelBuilder.Entity<Car>().HasData(new Car(2,2,2,"34ABC34",1,2018,CarState.Available,10));
        }
    }
}