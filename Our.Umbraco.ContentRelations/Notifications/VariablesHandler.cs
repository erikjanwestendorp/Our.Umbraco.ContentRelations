using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
using Our.Umbraco.ContentRelations.Controllers.Backoffice;
using Our.Umbraco.ContentRelations.Static;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Extensions;

namespace Our.Umbraco.ContentRelations.Notifications
{
    public class VariablesHandler : INotificationHandler<ServerVariablesParsingNotification>
    {
        private readonly LinkGenerator _linkGenerator;

        public VariablesHandler(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public void Handle(ServerVariablesParsingNotification notification)
        {
            notification.ServerVariables.Add(Constants.Package.Alias, new Dictionary<string, object>
            {
                { Constants.ApiPaths.ContentRelationsController, _linkGenerator.GetUmbracoApiServiceBaseUrl<ContentRelationsController>(controller => controller.GetRelationsByContentId(0))},
                { Constants.ApiPaths.UserGroupsController, _linkGenerator.GetUmbracoApiServiceBaseUrl<UserGroupsController>(controller => controller.GetUserGroups())},
                { Constants.ApiPaths.PackageController, _linkGenerator.GetUmbracoApiServiceBaseUrl<PackageController>(controller => controller.GetInformation())}
            });
        }
    }
}
