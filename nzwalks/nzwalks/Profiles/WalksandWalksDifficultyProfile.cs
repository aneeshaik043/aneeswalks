using AutoMapper;

namespace nzwalks.Profiles
{
    public class WalksandWalksDifficultyProfile: Profile
    {
        public WalksandWalksDifficultyProfile()
        {
            CreateMap<models.domain.walks, models.DTOS.WalksDTO>()
                 .ReverseMap();
            CreateMap<models.domain.walksdifficulty, models.DTOS.WalksDifficultyDTO>()
                .ReverseMap();
        }
    }
}
