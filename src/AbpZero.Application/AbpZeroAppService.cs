using AbpZero.Localization;
using Volo.Abp.Application.Services;

namespace AbpZero;

public abstract class AbpZeroAppService : ApplicationService
{
    protected AbpZeroAppService()
    {
        LocalizationResource = typeof(AbpZeroResource);
        ObjectMapperContext = typeof(AbpZeroApplicationModule);
    }
}