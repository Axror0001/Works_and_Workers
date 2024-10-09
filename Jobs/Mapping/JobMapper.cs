using AutoMapper;
using Jobs.Dtos;
using Jobs.Models;
using Jobs.Profiles;

namespace Jobs.Mapping
{
    public static class JobMapper
    {
        private static readonly IMapper _mapper;
        static JobMapper()
        {
            _mapper = new MapperConfiguration(configProfile => configProfile.AddProfile<JobProfiles>()).CreateMapper();
        }
        public static Job ModelToDtos(this JobsDtos jobsDtos)
        {
            return _mapper.Map<JobsDtos, Job>(jobsDtos);
        }
        public static JobsDtos DtosToModel(this Job jobs)
        {
            return _mapper.Map<Job,  JobsDtos>(jobs);
        }
    }
}
