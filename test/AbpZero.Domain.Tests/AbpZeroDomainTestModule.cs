using AbpZero.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpZero;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(AbpZeroEntityFrameworkCoreTestModule)
)]
public class AbpZeroDomainTestModule : AbpModule
{
}