namespace nzwalks.models.DTOS
{
    public class AddRegionRequestDTO
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public double lat { get; set; }

        public double lon { get; set; }

        public double Area { get; set; }

        public long Population { get; set; }
    }
}
