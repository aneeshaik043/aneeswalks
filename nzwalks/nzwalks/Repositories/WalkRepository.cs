using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nzwalks.Data;
using nzwalks.models.domain;

namespace nzwalks.Repositories
{
    public class WalkRepository: IWalksRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<IEnumerable<walks>> GetAllWalksAsync()
        {
            return await nZWalksDbContext.Walks
                .Include(x =>x.Region)
                .Include(x =>x.walkdifficulty)
                .ToListAsync();
        }

        public async Task<walks> GetWalkBYIdAsync(Guid id)
        {
            return await nZWalksDbContext.Walks
                .Include(x =>x.Region)
                .Include(x =>x.walkdifficulty)
                .FirstOrDefaultAsync(x =>x.Id == id);
        }

        public async Task<walks> AddWalkAsync(walks walk)
        {
            walk.Id = Guid.NewGuid();
            await nZWalksDbContext.Walks.AddAsync(walk);
            await nZWalksDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<walks> UpdateWalkAsync(Guid id, walks walk)
        {
            var existingwalk = await nZWalksDbContext.Walks.FindAsync(id);
            if (existingwalk == null)
            {
                return null;
            }
            existingwalk.Length = walk.Length;
            existingwalk.walkdifficulty = walk.walkdifficulty;
            existingwalk.Name = walk.Name;
            existingwalk.RegionId = walk.RegionId;
            await nZWalksDbContext.SaveChangesAsync();
            return existingwalk;

        }

        public async Task<walks> deleteWalkAsync(Guid id)
        {
            var existingwalk = await nZWalksDbContext.Walks.FindAsync(id);
            if (existingwalk == null)
            {
                return null;
            }
             nZWalksDbContext.Walks.Remove(existingwalk);
            await nZWalksDbContext.SaveChangesAsync() ;
            return existingwalk;
        }

    }
}
