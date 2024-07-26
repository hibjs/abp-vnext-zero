using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace AbpZero;

[DependsOn(
    typeof(AbpZeroApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class AbpZeroHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(AbpZeroApplicationContractsModule).Assembly,
            AbpZeroRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options => { options.FileSets.AddEmbedded<AbpZeroHttpApiClientModule>(); });
    }
}