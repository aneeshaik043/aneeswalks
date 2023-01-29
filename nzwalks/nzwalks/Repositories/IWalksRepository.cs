using nzwalks.models.domain;

namespace nzwalks.Repositories
{
    public interface IWalksRepository
    {
        Task<IEnumerable<walks>> GetAllWalksAsync();

        Task<walks> GetWalkBYIdAsync(Guid id);

        Task<walks> AddWalkAsync(walks walk);

        Task<walks> deleteWalkAsync(Guid id);

        Task<walks> UpdateWalkAsync(Guid id,walks walk);
    }
}
