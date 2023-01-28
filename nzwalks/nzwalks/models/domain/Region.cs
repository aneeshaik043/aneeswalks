namespace nzwalks.models.domain
{
    public class Region
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public double lat { get; set; }

        public double lon { get; set; }

        public double Area { get; set; }

        public long Population { get; set; }

        //navigation property

        public IEnumerable<walks> walk { get; set; }

    }
}
