using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderDbContext :DbContext{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=your database name ;User Id= SA;Password=your password;TrustServerCertificate=True");
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderConfigurations());
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Order> Orders{get;set;}

    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(o=>o.Address, a=>{
                a.Property<int>("OrderId");
                a.WithOwner();
            });
        }
    }
}