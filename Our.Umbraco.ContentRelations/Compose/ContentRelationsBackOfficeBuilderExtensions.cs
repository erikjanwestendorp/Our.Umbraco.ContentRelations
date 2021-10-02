using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Our.Umbraco.ContentRelations.Apps;
using Our.Umbraco.ContentRelations.Authorization;
using Our.Umbraco.ContentRelations.Mappings;
using Our.Umbraco.ContentRelations.Notifications;
using Our.Umbraco.ContentRelations.Services;
using Our.Umbraco.ContentRelations.Services.Implementation;
using Our.Umbraco.ContentRelations.Static;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Extensions;

namespace Our.Umbraco.ContentRelations.Compose
{
    public static class ContentRelationsBackOfficeBuilderExtensions
    {
        public static IUmbracoBuilder AddContentRelations(this IUmbracoBuilder builder)
        {
            // Add Content App
            builder.ContentApps().Append<ContentRelationsContentApp>();

            // Add Notifications
            builder.AddNotificationHandler<ServerVariablesParsingNotification, VariablesHandler>();
            builder.AddNotificationHandler<ContentMovingToRecycleBinNotification, CannotDeleteContentNotification>();

            // Add Mappings
            builder.WithCollectionBuilder<MapDefinitionCollectionBuilder>()
                .Add<RelationMappings>()
                .Add<ContentMappings>()
                .Add<UserGroupMappings>();

            // Add Components 
            builder.Components()
                .Append<SetupRelationTypesComponent>();

            // Add Services 
            builder.Services.AddUnique<IContentRelationsService, ContentRelationsService>();
            builder.Services.AddUnique<IPermissionService, PermissionService>();

            // Add Authorization
            builder.Services.AddSingleton<IAuthorizationHandler, CanDeleteHandler>();
            builder.Services.AddAuthorization(options => options.AddPolicy(Constants.AuthorizationPolicies.CanDeleteContentRelationsPolicy,
                policyBuilder =>
                    policyBuilder.AddRequirements(
                        new IsAllowedToDeleteContentRelations()
                    )
            ));


            return builder;
        }
    }
}
