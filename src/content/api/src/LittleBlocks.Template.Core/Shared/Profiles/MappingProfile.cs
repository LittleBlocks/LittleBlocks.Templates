using AutoMapper;
using LittleBlocks.Template.Common;
using LittleBlocks.Template.Core.Shared.Domain;

namespace LittleBlocks.Template.Core.Shared.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Sample, SampleDto>();
        }
    }
}
