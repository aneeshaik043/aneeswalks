using nzwalks.models.domain;

namespace nzwalks.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();

        Task<Region> GetRegion(Guid id);

        Task<Region> AddRegionAsync(Region region);

        Task<Region> deleteRegionAsync(Guid id);

        Task<Region> updateRegionAsync(Guid id, Region region);



    }
}
