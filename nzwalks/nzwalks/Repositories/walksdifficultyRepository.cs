using Microsoft.EntityFrameworkCore;
using nzwalks.Data;
using nzwalks.models.domain;

namespace nzwalks.Repositories
{
    public class walksdifficultyRepository: IwalksdifficultyRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public walksdifficultyRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<IEnumerable<walksdifficulty>> GetAllAsync()
        {
            return await nZWalksDbContext.walksDifficulty.ToListAsync();
        }

        public async Task<walksdifficulty> GetAsync(Guid id)
        {
            return await nZWalksDbContext.walksDifficulty.FirstOrDefaultAsync(x => x.Id== id);
        }

        public async Task<walksdifficulty> AddAsync(walksdifficulty walksdifficulty)
        {
            walksdifficulty.Id = Guid.NewGuid();
            await nZWalksDbContext.walksDifficulty.AddAsync(walksdifficulty);
            await nZWalksDbContext.SaveChangesAsync();
            return walksdifficulty;
        }

        public async Task<walksdifficulty> DeleteAsync(Guid id)
        {
            var ewd = await nZWalksDbContext.walksDifficulty.FindAsync(id);
            if (ewd == null)
            {
                return null;
            }
            nZWalksDbContext.walksDifficulty.Remove(ewd);
            await nZWalksDbContext.SaveChangesAsync();
            return ewd;
        }

        public async Task<walksdifficulty> UpdateAsync(Guid id, walksdifficulty walksdifficulty)
        {
            var ewd = await nZWalksDbContext.walksDifficulty.FindAsync(id);
            if (ewd == null)
            {
                return null;
            }
            ewd.code = walksdifficulty.code;
            await nZWalksDbContext.SaveChangesAsync();
            return ewd;
        }
    }
}
