using AutoMapper;
using Jobs.Dtos;
using Jobs.Models;

namespace Jobs.Profiles
{
    public class JobProfiles : Profile
    {
        public JobProfiles()
        {
            CreateMap<Job, JobsDtos>().ReverseMap();
            CreateMap<JobsDtos, Job>().ReverseMap();
        }
    }
}
