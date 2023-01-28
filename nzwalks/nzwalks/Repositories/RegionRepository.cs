using Microsoft.EntityFrameworkCore;
using nzwalks.Data;
using nzwalks.models.domain;

namespace nzwalks.Repositories
{
    public class RegionRepository : IRegionRepository
    {

        private readonly NZWalksDbContext nZWalksDbContext;

        public RegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await nZWalksDbContext.Regions.ToListAsync();
        }
    }
}
