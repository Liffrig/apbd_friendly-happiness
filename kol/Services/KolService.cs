using System.ComponentModel.DataAnnotations;
using kol.Data;
using kol.DTOs;
using kol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kol.Services;

public class KolService : IKolService {
    private readonly KolDbContext _context;

    public KolService(KolDbContext context) {
        _context = context;
    }



    public async Task<GalleryExhibitionDto> GetGalleryExhibition(int galleryId) {
        
        var gallery = await _context.Gallery.FirstOrDefaultAsync(g => g.GalleryId == galleryId);
        if (gallery == null) {
            throw new Exception("Gallery not found");
        }

        var retGallery = new GalleryDto {
            GalleryId = gallery.GalleryId,
            Name = gallery.Name,
            EstablishedDate = gallery.EstablishedDate.ToShortDateString(),
        };
        
        var mainRes = _context.Exhibition
            .Include(e => e.ExhibitionArtworks)
            .ThenInclude(ea => ea.Artwork)
            .ThenInclude(a => a.Artist)
            .Where(e => e.GalleryId == galleryId)
            .ToListAsync();


        var exhibitionList = new List<ExhibitionDto>();
        
        foreach (var el in mainRes.Result) {

            var exhibition = new ExhibitionDto {
                Title = el.Title,
                StartDate = el.StartDate.ToShortDateString(),
                EndDate = el.EndDate.ToString(),
                NumberOfArtworks = el.NumberOfArtworks
            };
            
            exhibitionList.Add(exhibition);
        }

        return new GalleryExhibitionDto {
            Gallery = retGallery,
            Exhibitions = exhibitionList
        };

        

    }
    
}

