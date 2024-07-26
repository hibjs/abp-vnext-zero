using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;

namespace AbpZero.EntityFrameworkCore;

[DependsOn(
    typeof(AbpZeroTestBaseModule),
    typeof(AbpZeroEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqliteModule)
)]
public class AbpZeroEntityFrameworkCoreTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var sqliteConnection = CreateDatabaseAndGetConnection();

        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure(abpDbContextConfigurationContext => { abpDbContextConfigurationContext.DbContextOptions.UseSqlite(sqliteConnection); });
        });
    }

    private static SqliteConnection CreateDatabaseAndGetConnection()
    {
        // Use sqlite in memory
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();
        new AbpZeroDbContext(new DbContextOptionsBuilder<AbpZeroDbContext>().UseSqlite(connection).Options).GetService<IRelationalDatabaseCreator>()
            .CreateTables();
        return connection;
    }
}