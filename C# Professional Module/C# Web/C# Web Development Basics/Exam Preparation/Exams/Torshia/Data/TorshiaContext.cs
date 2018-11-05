namespace Torshia.Data
{
    using Microsoft.EntityFrameworkCore;

    using Torshia.Models;

    public class TorshiaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<TaskSector> TasksSectors { get; set; }

        public TorshiaContext() { }
        public TorshiaContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString)
                       .UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskSector>()
                        .HasKey(pk => new
                        {
                            pk.TaskId,
                            pk.SectorId
                        });
        }
    }
}