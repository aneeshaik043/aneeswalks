using nzwalks.models.domain;

namespace nzwalks.models.DTOS
{
    public class AddWalkRequestDTO
    {
        public Guid RegionId { get; set; }

        public Guid walkdifficultyId { get; set; }

        public string Name { get; set; }

        public double Length { get; set; }

    }
}
