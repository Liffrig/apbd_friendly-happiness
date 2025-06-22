using kol.Models;

namespace kol.DTOs;

public class GalleryExhibitionDto {
    public GalleryDto Gallery { get; set; }
    public List<ExhibitionDto> Exhibitions { get; set; }
    
}


public class GalleryDto {
    public int GalleryId { get; set; }
    public string Name { get; set; }
    public string EstablishedDate { get; set; }
 
}
public class ExhibitionDto {
        
    public string Title { get; set; }
    public string StartDate { get; set; }
    public string? EndDate { get; set; }
        public int NumberOfArtworks { get; set; }
        public List<ArtworkDto> Artworks { get; set; }
}

public class ArtworkDto {
    
    public string Title { get; set; }
    public int YearCreated { get; set; }
    public double InsuranceValue { get; set; }
    public ArtistDto Artist { get; set; }
}

public class ArtistDto {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
}






