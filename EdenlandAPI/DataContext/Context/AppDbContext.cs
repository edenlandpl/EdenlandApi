using EdenlandAPI.Domain.Models;
using EdenlandAPI.Domain.Models.Beautician;
using Microsoft.EntityFrameworkCore;

namespace EdenlandAPI.DataContext.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<BeauticianModel> Beauticians { get; set; }
        public DbSet<TreatmentModel> Treatments { get; set; }

        public DbSet<BeauticiansTreatmentsModel> BeaticiansTreatments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {  }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<BeauticiansTreatmentsModel>(builder => builder.HasNoKey());

            builder.Entity<BeauticiansTreatmentsModel>()
                .HasOne(bt => bt.Beauticians)
                .WithMany(p => p.Treatments)
                .HasForeignKey(mbt => mbt.BeauticianId);

            builder.Entity<BeauticiansTreatmentsModel>()
                .HasOne(pt => pt.Treatments)
                .WithMany(t => t.Beauticians)
                .HasForeignKey(pt => pt.TreatmentId);  
            
            //base.OnModelCreating(builder);

            //builder.Entity<BeauticianModel>()
            //    .HasOne<TreatmentModel>(t => t.Beauticians).WithMany(b = b.Beauticians).Map(tb =>
            //    {
            //        tb.MapLeftKey("BeauticianRefId");
            //        tb.MapRightKey("TreatmentRefId");
            //        tb.ToTable("B_BeauticiansTreatments");
            //    });


            //// poprzednia wersja - z ręcznie dodana tabelą pośrednią
            //builder.Entity<BeauticianTreatmentsModel>()
            //    .HasOne(pt => pt.TreatmentId)
            //    .WithMany(p => p.BeauticiansTreatments)
            //    .HasForeignKey(pt => pt.BeauticianId);

            //builder.Entity<BeauticianTreatmentsModel>()
            //    .HasOne(pt => pt.BeauticianId)
            //    .WithMany(t => t.BeauticiansTreatments)
            //    .HasForeignKey(pt => pt.TreatmentId);
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<Category>().ToTable("Categories");
        //    builder.Entity<Category>().HasKey(p => p.Id);
        //    builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        //    builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        //    // relationship beetwen tables - one - to many (category(one) - has- products(many))
        //    builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId); 

        //    // default examples, ID manually setting, with real SQL database it is not neccessary
        //    builder.Entity<Category>().HasData
        //    (
        //        new Category { Id = 100, Name = "Owoce i warzywa" },
        //        new Category { Id = 101, Name = "Dziennik" }
        //    );

        //    builder.Entity<Product>().ToTable("Products");
        //    builder.Entity<Product>().HasKey(p => p.Id);
        //    builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        //    builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        //    builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
        //    builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();

        //    // examples products
        //    builder.Entity<Product>().HasData(
        //        new Product
        //        {
        //            Id = 100,
        //            Name = "Jabłko",
        //            QuantityInPackage = 1,
        //            UnitOfMeasurement = EUnitOfMeasurement.Unity,
        //            CategoryId = 100
        //        },
        //        new Product
        //        {
        //            Id = 101,
        //            Name = "Mleko",
        //            QuantityInPackage = 2,
        //            UnitOfMeasurement = EUnitOfMeasurement.Liter,
        //            CategoryId = 101,
        //        }
        //    );
        //}
    }
}
