using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;

namespace PhotosApi.Models
{
    /* DbContext to acknowledge and return the db model */
    public class ImageDbContext: DbContext
    {

        public ImageDbContext(DbContextOptions<ImageDbContext> options):base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

          
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
         /* The project has only one model, ImageModel, and returns a bunch of ImageModels with: */
        public DbSet<ImageModel> ImageModels { get; set; }
    }
}