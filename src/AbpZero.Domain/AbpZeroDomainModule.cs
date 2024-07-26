using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace AbpZero;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpZeroDomainSharedModule)
)]
public class AbpZeroDomainModule : AbpModule
{
}