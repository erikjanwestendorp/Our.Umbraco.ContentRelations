using Our.Umbraco.ContentRelations.Apps;
using Our.Umbraco.ContentRelations.Mappings;
using Our.Umbraco.ContentRelations.Notifications;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Notifications;

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

            // Add Mappings
            builder.WithCollectionBuilder<MapDefinitionCollectionBuilder>()
                .Add<RelationMappings>()
                .Add<ContentMappings>();

            return builder;
        }
    }
}
