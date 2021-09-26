using Our.Umbraco.ContentRelations.ViewModels;

namespace Our.Umbraco.ContentRelations.Services
{
    public interface IPermissionService
    {
        PermissionsViewModel GetPermissions();
        PermissionsViewModel SavePermissionViewModel(PermissionsViewModel permissionViewModel);
    }
}
