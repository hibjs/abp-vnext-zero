using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace AbpZero.DbMigrations;

public class AbpZeroDataSeeder : IDataSeedContributor, ITransientDependency
{
    public Task SeedAsync(DataSeedContext context)
    {
        // INFO seed data here.
        throw new NotImplementedException();
    }
}