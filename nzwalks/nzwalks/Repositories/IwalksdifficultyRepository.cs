using nzwalks.models.domain;

namespace nzwalks.Repositories
{
    public interface IwalksdifficultyRepository
    {
        Task<IEnumerable<walksdifficulty>> GetAllAsync();

        Task<walksdifficulty> GetAsync(Guid id);

        Task<walksdifficulty> AddAsync(walksdifficulty walksdifficulty);

        Task<walksdifficulty> UpdateAsync(Guid id, walksdifficulty walksdifficulty);

        Task<walksdifficulty> DeleteAsync(Guid id);
    }
}
