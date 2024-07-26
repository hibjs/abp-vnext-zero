using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace AbpZero.EntityFrameworkCore;

public static class AbpZeroDbContextModelCreatingExtensions
{
    public static void ConfigureAbpZero(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}