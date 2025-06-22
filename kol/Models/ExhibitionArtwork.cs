using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kol.Models;

[Table("Exhibition_Artwork")]
[PrimaryKey(nameof(ExhibitionId), nameof(ArtworkId))]
public class ExhibitionArtwork {

    
    [Required][Column(TypeName = "decimal(10,2)")]
    public double InsuranceValue { get; set; }
    
    public virtual Exhibition Exhibition { get; set; }
    [ForeignKey(nameof(Exhibition))] public int ExhibitionId { get; set; }
        
    public virtual Artwork Artwork { get; set; }
    [ForeignKey(nameof(Artwork))] public int ArtworkId { get; set; }

    public ExhibitionArtwork() {
        
    }

}