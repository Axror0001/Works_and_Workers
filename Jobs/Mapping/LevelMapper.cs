using AutoMapper;
using Jobs.Dtos;
using Jobs.Models;
using Jobs.Profiles;

namespace Jobs.Mapping
{
    public static class LevelMapper
    {
        private static readonly IMapper _mapper;
        static LevelMapper()
        {
            _mapper = new MapperConfiguration(configProfile => configProfile.AddProfile<LevelProfiles>()).CreateMapper();
        }
        public static Level ModelToDtos(this LevelsDtos levelsDtos)
        {
            return _mapper.Map<LevelsDtos, Level>(levelsDtos);
        }
        public static LevelsDtos DtosToModel(this Level levels)
        {
            return _mapper.Map<Level,  LevelsDtos>(levels);
        }
    }
}
