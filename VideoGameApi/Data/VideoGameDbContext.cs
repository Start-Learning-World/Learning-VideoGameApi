using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace VideoGameApi.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame
                {
                    Id = 1,
                    Title = "MARIO",
                    Platform = "PS5",
                    Developer = "RICHARD",
                    Publisher = "SAM"
                },
            new VideoGame
            {
                Id = 2,
                Title = "GTA",
                Platform = "PS5",
                Developer = "RYAN",
                Publisher = "ABRAHAM"
            },
            new VideoGame
            {
                Id = 3,
                Title = "NFS",
                Platform = "PS5",
                Developer = "RIORDAN",
                Publisher = "BRYAN"
            });
        }
    }

    
}


