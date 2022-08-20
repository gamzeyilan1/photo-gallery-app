using System.ComponentModel.DataAnnotations;

namespace PhotosApi.Models
{

 /* This project is very simple and holds only the photo model. The model has a url so that it can
  show the photo on the front end, and then some detail like the creator of that photo and the name given
  by the creator. */
    public class ImageModel
    {
        [Key] public int Id { get; set; }

        public string CreatorName { get; set; }

        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
    }
}