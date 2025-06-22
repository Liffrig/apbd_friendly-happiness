using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kol.Models;

[Table("Gallery")]
public class Gallery {

    [Key]
    public int GalleryId { get; set; }
    
    [Required][MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    public DateTime EstablishedDate { get; set; }

    public virtual ICollection<Exhibition> Exhibitions { get; set; } = new List<Exhibition>();

    public Gallery() { }

}