using AutoMapper;
using Jobs.Dtos;
using Jobs.Models;

namespace Jobs.Profiles
{
    public class LevelProfiles : Profile
    {
        public LevelProfiles()
        {
            CreateMap<Level, LevelsDtos>().ReverseMap();
            CreateMap<LevelsDtos, Level>().ReverseMap();
        }
    }
}
