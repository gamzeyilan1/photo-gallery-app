using System.ComponentModel.DataAnnotations;

namespace PhotosApi.Models
{
    public class ImageModel
    {
        [Key] public int Id { get; set; }

        public string CreatorName { get; set; }

        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
    }
}