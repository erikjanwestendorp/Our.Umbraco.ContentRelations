using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Our.Umbraco.ContentRelations.Compose
{
    public class ContentRelationsComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.AddContentRelations();
        }
    }
}
