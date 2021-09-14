using Our.Umbraco.ContentRelations.Apps;
using Our.Umbraco.ContentRelations.Mappings;
using Our.Umbraco.ContentRelations.Notifications;
using Our.Umbraco.ContentRelations.Services;
using Our.Umbraco.ContentRelations.Services.Implementation;
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
            
            return builder;
        }
    }
}
