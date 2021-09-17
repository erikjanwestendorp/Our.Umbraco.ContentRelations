using System.Collections.Generic;
using System.Linq;
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

        public ContentRelationsUserGroupsController(
            IUserService userService, 
            IUmbracoMapper umbracoMapper)
        {
            _userService = userService;
            _umbracoMapper = umbracoMapper;
        }

        public Common.Attempt<IEnumerable<UserGroupViewModel>> GetUserGroups()
        {
            // Get al user groups except admin 
            var umbracoUserGroups = _userService.GetAllUserGroups().Where(x => x.Alias != Constants.Security.AdminGroupAlias).OrderBy(x => x.Name).ToList();

            if (!umbracoUserGroups.Any())  
                return Common.Attempt<IEnumerable<UserGroupViewModel>>.Failed("No user groups", "No user groups found", EventMessageType.Error);

            var userGroups = _umbracoMapper.MapEnumerable<IUserGroup,UserGroupViewModel>(umbracoUserGroups);
            

            return Common.Attempt<IEnumerable<UserGroupViewModel>>.Success(userGroups);

        }

        
    }
}
