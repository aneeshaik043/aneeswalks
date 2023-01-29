﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Region> GetRegion(Guid id)
        {
            return await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await nZWalksDbContext.AddAsync(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> deleteRegionAsync(Guid id)
        {
            var deletingRegion = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (deletingRegion == null)
            {
                return null;
            }
            nZWalksDbContext.Regions.Remove(deletingRegion);
            await nZWalksDbContext.SaveChangesAsync();
            return deletingRegion;
        }

        public async Task<Region> updateRegionAsync(Guid id,Region region)
        {
            var existingRegion = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.lat= region.lat;
            existingRegion.Code = region.Code;
            existingRegion.lon= region.lon;
            existingRegion.Area= region.Area;
            existingRegion.Code= region.Code;
            existingRegion.Name= region.Name;
            return existingRegion;
        }
    }
}
