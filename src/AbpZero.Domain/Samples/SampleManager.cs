using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace AbpZero;

public class SampleManager : DomainService
{
    private readonly IRepository<Sample, long> _repository;

    public SampleManager(IRepository<Sample, long> repository)
    {
        _repository = repository;
    }
}