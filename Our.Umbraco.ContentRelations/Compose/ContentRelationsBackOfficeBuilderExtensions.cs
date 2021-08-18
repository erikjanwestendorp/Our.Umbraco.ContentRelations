using Our.Umbraco.ContentRelations.Apps;
using Umbraco.Cms.Core.DependencyInjection;

namespace Our.Umbraco.ContentRelations.Compose
{
    public static class ContentRelationsBackOfficeBuilderExtensions
    {
        public static IUmbracoBuilder AddContentRelations(this IUmbracoBuilder builder)
        {
            // Add Content App
            builder.ContentApps().Append<ContentRelationsContentApp>();

            return builder;
        }
    }
}
