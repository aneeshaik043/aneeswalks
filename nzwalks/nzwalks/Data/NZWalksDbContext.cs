using Microsoft.EntityFrameworkCore;
using nzwalks.models.domain;

namespace nzwalks.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options):base(options)
        {

        }

        public DbSet<Region> Regions { get; set; }

        public DbSet<walks> Walks { get; set; }

        public DbSet<walksdifficulty> walksDifficulty { get; set; }
    }
}
