using kol.Models;
using Microsoft.EntityFrameworkCore;
using kol.Models;
namespace kol.Data;

public class KolDbContext : DbContext {
    
    public DbSet<Artwork> Artwork { get; set; }
    public DbSet<Artist> Artist { get; set; }
    public DbSet<ExhibitionArtwork> ExhibitionArtwork { get; set; }
    public DbSet<Exhibition> Exhibition { get; set; }
    public DbSet<Gallery> Gallery { get; set; }
    
    
    protected KolDbContext() { }
    public KolDbContext(DbContextOptions options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        
        // Seed

        modelBuilder.Entity<Gallery>().HasData(
            new Gallery {
                Name = "sadja",
                GalleryId = 1,
                EstablishedDate = DateTime.Today
            });
        
        modelBuilder.Entity<Exhibition>().HasData(
            new Exhibition {
                ExhibitionId = 1,
                GalleryId = 1,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today,
                NumberOfArtworks = 2,
                Title = "20th Century Giants"
            });

        modelBuilder.Entity<ExhibitionArtwork>().HasData(
            new ExhibitionArtwork {
                ExhibitionId = 1,
                ArtworkId = 1,
                InsuranceValue = 103.20d
            });

        modelBuilder.Entity<Artwork>().HasData(
            new Artwork {
                ArtworkId = 1,
                Title = "ABCFD",
                ArtistId = 1,
                YearCreated = 2020
            });

        modelBuilder.Entity<Artist>().HasData(
            new Artist {
                ArtistId = 1,
                FirstName = "John",
                LastName = "Doe",
                BirthDate = DateTime.Today
            });

    }
}



