namespace MishMash.Data
{
    using Microsoft.EntityFrameworkCore;

    using MishMash.Models;

    public class MishMashContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserChannel> UsersChannels { get; set; }
        public DbSet<ChannelTag> ChannelsTags { get; set; }

        public MishMashContext() { }
        public MishMashContext(DbContextOptions options) 
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
            modelBuilder.Entity<UserChannel>()
                        .HasKey(pk => new
                        {
                            pk.UserId,
                            pk.ChannelId
                        });

            modelBuilder.Entity<ChannelTag>()
                      .HasKey(pk => new
                      {
                          pk.ChannelId,
                          pk.TagId
                      });
        }
    }
}