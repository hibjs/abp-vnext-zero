using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AbpZero.EntityFrameworkCore;

public class AbpZeroMigrationsDbContextFactory : IDesignTimeDbContextFactory<AbpZeroDbContext>
{
    public AbpZeroDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AbpZeroDbContext>()
            .UseMySql("Server=******;Port=3306;Database=***;Uid=root;Pwd=youStrongPassword;", new MySqlServerVersion(new Version("8.0.27")));

        return new AbpZeroDbContext(builder.Options);
    }
}