using kol.DTOs;
using kol.Services;
using Microsoft.AspNetCore.Mvc;

namespace kol.Controllers;


[ApiController]
[Route("[controller]")] 
public class GalleriesController : ControllerBase {

    private readonly IKolService _kolService;

    public GalleriesController(IKolService kolService) {
        _kolService = kolService;
    }


    [HttpGet("{galleryId}/exhibitions")]
    public async Task<IActionResult> GetGalleriesAndExhibitions(int galleryId) {
        

        try {
            var galData = await _kolService.GetGalleryExhibition(galleryId);
            return Ok(galData);
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }

    }
    
}