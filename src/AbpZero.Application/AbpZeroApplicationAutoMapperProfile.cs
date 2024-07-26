using AbpZero.Samples.Dto;
using AutoMapper;

namespace AbpZero;

public class AbpZeroApplicationAutoMapperProfile : Profile
{
    public AbpZeroApplicationAutoMapperProfile()
    {
        CreateMap<Sample, SampleDto>();
    }
}