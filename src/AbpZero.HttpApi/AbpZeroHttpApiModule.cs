using AbpZero.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace AbpZero;

[DependsOn(
    typeof(AbpZeroApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class AbpZeroHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder => { mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpZeroHttpApiModule).Assembly); });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AbpZeroResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}