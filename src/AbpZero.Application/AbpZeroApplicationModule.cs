using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace AbpZero;

[DependsOn(
    typeof(AbpZeroDomainModule),
    typeof(AbpZeroApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
)]
public class AbpZeroApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<AbpZeroApplicationModule>();
        Configure<AbpAutoMapperOptions>(options => { options.AddMaps<AbpZeroApplicationModule>(true); });
    }
}