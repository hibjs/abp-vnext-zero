using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace AbpZero;

[DependsOn(
    typeof(AbpZeroDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
)]
public class AbpZeroApplicationContractsModule : AbpModule
{
}