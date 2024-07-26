using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AbpZero.EntityFrameworkCore;

[ConnectionStringName(AbpZeroDbProperties.ConnectionStringName)]
public class AbpZeroDbContext : AbpDbContext<AbpZeroDbContext>, IAbpZeroDbContext
{
    public AbpZeroDbContext(DbContextOptions<AbpZeroDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureAbpZero();
    }
}