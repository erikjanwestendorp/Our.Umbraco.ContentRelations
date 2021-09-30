using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Our.Umbraco.ContentRelations.Common;
using Our.Umbraco.ContentRelations.Services;
using Our.Umbraco.ContentRelations.ViewModels;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;

namespace Our.Umbraco.ContentRelations.Controllers.Backoffice
{
    [PluginController(Static.Constants.Package.PluginName)]
    public class UserGroupsController : UmbracoAuthorizedApiController
    {
        private readonly IUserService _userService;
        private readonly IUmbracoMapper _umbracoMapper;
        private readonly IPermissionService _permissionService;


        public UserGroupsController(
            IUserService userService, 
            IUmbracoMapper umbracoMapper,
            IPermissionService permissionService)
        {
            _userService = userService; 
            _umbracoMapper = umbracoMapper;
            _permissionService = permissionService;
        }

        [HttpGet]
        public ApiAttempt<IEnumerable<UserGroupViewModel>> GetUserGroups()
        {
            // Get al user groups except admin 
            var umbracoUserGroups = _userService.GetAllUserGroups().Where(x => x.Alias != Constants.Security.AdminGroupAlias).OrderBy(x => x.Name).ToList();

            if (!umbracoUserGroups.Any())  
                return ApiAttempt<IEnumerable<UserGroupViewModel>>.Failed("No user groups", "No user groups found", EventMessageType.Error);

            var userGroups = _umbracoMapper.MapEnumerable<IUserGroup,UserGroupViewModel>(umbracoUserGroups);
            

            return ApiAttempt<IEnumerable<UserGroupViewModel>>.Success(userGroups);
        }

        [HttpGet]
        public ApiAttempt<PermissionsViewModel> GetConfiguration()
        {
            return ApiAttempt<PermissionsViewModel>.Success(_permissionService.GetPermissions());
        }

        [HttpPost]
        public ApiAttempt<PermissionsViewModel> SaveConfiguration(PermissionsViewModel permissions)
        {
            var saveAttempt = _permissionService.SavePermissionViewModel(permissions);


            //TODO Validate PermissionsViewModel
            if (saveAttempt.Success)
                return ApiAttempt<PermissionsViewModel>.Success(saveAttempt.Result);

            return ApiAttempt<PermissionsViewModel>.Failed("Configuration", "Cannot save configuration", EventMessageType.Error);
        }
    }
}
