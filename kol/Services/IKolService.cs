using kol.DTOs;

namespace kol.Services;

public interface IKolService {
    public Task<GalleryExhibitionDto> GetGalleryExhibition(int galleryId);
}