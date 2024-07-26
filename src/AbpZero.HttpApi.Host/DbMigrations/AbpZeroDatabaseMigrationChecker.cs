using System;
using AbpZero.DbMigrations.EfCore;
using AbpZero.EntityFrameworkCore;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace AbpZero.DbMigrations;

public class AbpZeroDatabaseMigrationChecker : PendingEfCoreMigrationsChecker<AbpZeroDbContext>
{
    public AbpZeroDatabaseMigrationChecker(IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider, ICurrentTenant currentTenant,
        IDistributedEventBus distributedEventBus,
        IAbpDistributedLock abpDistributedLock, string databaseName) :
        base(unitOfWorkManager,
            serviceProvider,
            currentTenant,
            distributedEventBus,
            abpDistributedLock,
            databaseName)
    {
    }
}