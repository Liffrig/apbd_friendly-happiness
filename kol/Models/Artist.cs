using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kol.Models;

[Table("Artist")]
public class Artist {

    [Key]
    public int ArtistId { get; set; }

    [Required][MaxLength(100)]
    public string FirstName { get; set; }
    
    [Required][MaxLength(100)]
    public string LastName { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }
    
    public virtual ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();

    public Artist() {
        
    }
}