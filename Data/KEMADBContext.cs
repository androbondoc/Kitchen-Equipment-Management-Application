using Microsoft.EntityFrameworkCore;

namespace KEMA.Data
{
    public class KEMADbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<RegisteredEquipment> RegisteredEquipments { get; set; }

        public KEMADbContext()
            : this(new DbContextOptionsBuilder<KEMADbContext>().UseSqlServer("Data Source=ABONDOC\\ABSQLSERVER;Initial Catalog=KEMA_DB;Integrated Security=True;TrustServerCertificate=True").Options)
        { }

        public KEMADbContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("user");
            builder.Entity<Equipment>().ToTable("equipment");
            builder.Entity<Site>().ToTable("site");
            builder.Entity<RegisteredEquipment>().ToTable("registered_equipment");
        }
    }
}
