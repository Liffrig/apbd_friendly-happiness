using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kol.Models;

[Table("Artwork")]
public class Artwork {

    [Key]
    public int ArtworkId { get; set; }
    [Required][MaxLength(100)] public string Title { get; set; }
    [Required] public int YearCreated { get; set; }
    
    public Artist Artist { get; set; }
    [ForeignKey(nameof(Artist))] public int ArtistId { get; set; }
    
    public virtual ICollection<ExhibitionArtwork> ExhibitionArtworks { get; set; } = new List<ExhibitionArtwork>();

    public Artwork() {
        
    }
}