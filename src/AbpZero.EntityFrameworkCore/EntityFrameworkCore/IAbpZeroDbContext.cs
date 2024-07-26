using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AbpZero.EntityFrameworkCore;

[ConnectionStringName(AbpZeroDbProperties.ConnectionStringName)]
public interface IAbpZeroDbContext : IEfCoreDbContext
{
}