using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;

namespace AbpZero.EntityFrameworkCore;

[DependsOn(
    typeof(AbpZeroDomainModule),
    typeof(AbpEntityFrameworkCoreMySQLModule)
)]
public class AbpZeroEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<AbpZeroDbContext>(options => { options.AddDefaultRepositories(true); });
        context.Services.Configure<AbpDbContextOptions>(options => options.UseMySQL());
    }
}