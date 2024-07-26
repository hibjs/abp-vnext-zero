using AbpZero.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpZero.Permissions;

public class AbpZeroPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpZeroPermissions.GroupName, L("Permission:AbpZero"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpZeroResource>(name);
    }
}