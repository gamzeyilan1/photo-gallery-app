using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;

namespace PhotosApi.Models
{
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
        
        public DbSet<ImageModel> ImageModels { get; set; }
    }
}