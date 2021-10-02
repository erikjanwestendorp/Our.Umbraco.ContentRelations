using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Our.Umbraco.ContentRelations.Services;
using Umbraco.Cms.Core.Services;

namespace Our.Umbraco.ContentRelations.Authorization
{
    public class CanDeleteHandler : AuthorizationHandler<IsAllowedToDeleteContentRelations>
    {
        private readonly IPermissionService _permissionService;
        private readonly IUserService _userService;
        public CanDeleteHandler(IPermissionService permissionService, IUserService userService)
        {
            _permissionService = permissionService;
            _userService = userService;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAllowedToDeleteContentRelations requirement)
        {
            var userName = context.User.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var user = _userService.GetByUsername(userName);

            if (user == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var permissions = _permissionService.GetPermissions();

            if (permissions?.Delete == null || !permissions.Delete.UserGroups.Any())
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var userUserGroups = user.Groups.Select(x => x.Alias).ToList();
            var permissionUserGroups = permissions.Delete.UserGroups;

            var inter = userUserGroups.Intersect(permissionUserGroups);
            if (userUserGroups.Intersect(permissionUserGroups).Any())
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
