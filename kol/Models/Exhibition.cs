using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kol.Models;

[Table("Exhibition")]
public class Exhibition {
    [Key]
    public int ExhibitionId { get; set; }

    [Required][MaxLength(100)]
    public string Title { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }

    [Required]
    public int NumberOfArtworks { get; set; }
    
    public virtual Gallery Gallery { get; set; }
    [ForeignKey(nameof(Gallery))] public int GalleryId { get; set; }

    public virtual ICollection<ExhibitionArtwork> ExhibitionArtworks { get; set; } = new List<ExhibitionArtwork>();

    public Exhibition() { }
}