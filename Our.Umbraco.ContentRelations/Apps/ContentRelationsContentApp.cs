using System.Collections.Generic;
using Our.Umbraco.ContentRelations.Static;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.ContentEditing;
using Umbraco.Cms.Core.Models.Membership;

namespace Our.Umbraco.ContentRelations.Apps
{
    public class ContentRelationsContentApp : IContentAppFactory
    {
        public ContentApp GetContentAppFor(object source, IEnumerable<IReadOnlyUserGroup> userGroups)
        {
            if (!(source is IContent content) || content.Id <= 0) 
                return null;
            
            
            var relationsContentApp = new ContentApp
            {
                Alias = Constants.Apps.RelationsContentApp.Alias,
                Name = Constants.Apps.RelationsContentApp.Name,
                Icon = Constants.Apps.RelationsContentApp.Icon,
                View = Constants.Apps.RelationsContentApp.View,
                Weight = Constants.Apps.RelationsContentApp.Weight
            };

            return relationsContentApp;

        }
    }
}
