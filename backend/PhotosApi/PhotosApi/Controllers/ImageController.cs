using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotosApi.Models;

namespace PhotosApi.Controllers
{
    [Route("api/[controller]")]
    public class ImageController: ControllerBase
    {
        private readonly ImageDbContext _context;

        public ImageController(ImageDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageModel>>> GetImages()
        {
            return await _context.ImageModels.ToListAsync();
        }

    }
}

