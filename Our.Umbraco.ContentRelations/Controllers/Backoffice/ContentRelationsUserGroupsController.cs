using System;
using System.Collections.Generic;
using System.Linq;
using Our.Umbraco.ContentRelations.Common;
using Our.Umbraco.ContentRelations.ViewModels;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;

namespace Our.Umbraco.ContentRelations.Controllers.Backoffice
{
    public class ContentRelationsUserGroupsController : UmbracoAuthorizedApiController
    {
        private readonly IUserService _userService;
        private readonly IUmbracoMapper _umbracoMapper;
        private readonly IKeyValueService _keyValueService;

        private Guid _key = Guid.Parse("CFC88F56-CDAB-430B-8CB2-ED879C4ACA8C");

        public ContentRelationsUserGroupsController(
            IUserService userService, 
            IUmbracoMapper umbracoMapper,
            IKeyValueService keyValueService)
        {
            _userService = userService;
            _umbracoMapper = umbracoMapper;
            _keyValueService = keyValueService;
        }

        public ApiAttempt<IEnumerable<UserGroupViewModel>> GetUserGroups()
        {
            // Get al user groups except admin 
            var umbracoUserGroups = _userService.GetAllUserGroups().Where(x => x.Alias != Constants.Security.AdminGroupAlias).OrderBy(x => x.Name).ToList();

            if (!umbracoUserGroups.Any())  
                return ApiAttempt<IEnumerable<UserGroupViewModel>>.Failed("No user groups", "No user groups found", EventMessageType.Error);

            var userGroups = _umbracoMapper.MapEnumerable<IUserGroup,UserGroupViewModel>(umbracoUserGroups);
            

            return ApiAttempt<IEnumerable<UserGroupViewModel>>.Success(userGroups);
        }
    }
}
