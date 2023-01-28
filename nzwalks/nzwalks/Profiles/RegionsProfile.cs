using AutoMapper;

namespace nzwalks.Profiles
{
    public class RegionsProfile: Profile
    {
        public RegionsProfile()
        {
            CreateMap<models.domain.Region, models.DTOS.RegionsDTO>()
                .ReverseMap();
        }
    }
}
