namespace IRunes.Data
{
    using IRunes.Models;

    using Microsoft.EntityFrameworkCore;

    public class IRunesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<TrackAlbum> TracksAlbums { get; set; }

        //public IRunesContext() { }
        //public IRunesContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
                builder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrackAlbum>()
                        .HasKey(pk => new
                        {
                            pk.TrackId,
                            pk.AlbumId
                        });
        }
    }
}