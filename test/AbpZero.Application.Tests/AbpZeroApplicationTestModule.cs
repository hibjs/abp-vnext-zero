using Volo.Abp.Modularity;

namespace AbpZero;

[DependsOn(
    typeof(AbpZeroApplicationModule),
    typeof(AbpZeroDomainTestModule)
)]
public class AbpZeroApplicationTestModule : AbpModule
{
}