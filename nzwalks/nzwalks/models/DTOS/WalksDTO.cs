using nzwalks.models.domain;

namespace nzwalks.models.DTOS
{
    public class WalksDTO
    {
        public Guid Id { get; set; }

        public Guid RegionId { get; set; }

        public Guid walkdifficultyId { get; set; }

        public string Name { get; set; }

        public double Length { get; set; }

        //Navigation Properties

        public Region Region { get; set; }

        public walksdifficulty walkdifficulty { get; set; }
    }
}
