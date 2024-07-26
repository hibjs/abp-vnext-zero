namespace AbpZero;

public static class AbpZeroDbProperties
{
    public const string ConnectionStringName = "Default";

    public static string DbTablePrefix { get; set; } = "";

    public static string DbSchema { get; set; } = null;
}