using Our.Umbraco.ContentRelations.ViewModels;
using Umbraco.Cms.Core;

namespace Our.Umbraco.ContentRelations.Services
{
    public interface IPermissionService
    {
        PermissionsViewModel GetPermissions();
        Attempt<PermissionsViewModel> SavePermissionViewModel(PermissionsViewModel permissionViewModel);
    }
}
