using AbpZero.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpZero;

public abstract class AbpZeroController : AbpControllerBase
{
    protected AbpZeroController()
    {
        LocalizationResource = typeof(AbpZeroResource);
    }
}