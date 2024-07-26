using Volo.Abp.Reflection;

namespace AbpZero.Permissions;

public class AbpZeroPermissions
{
    public const string GroupName = "AbpZero";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(AbpZeroPermissions));
    }
}