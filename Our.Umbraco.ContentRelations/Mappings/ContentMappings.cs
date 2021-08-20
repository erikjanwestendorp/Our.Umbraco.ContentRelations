using Our.Umbraco.ContentRelations.ViewModels;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Models;

namespace Our.Umbraco.ContentRelations.Mappings
{

    public class ContentMappings : IMapDefinition
    {
        public void DefineMaps(IUmbracoMapper mapper)
        {
            mapper.Define<IContent, ContentViewModel>((perm, context) => new ContentViewModel(), Map);
        }
        private void Map(IContent src, ContentViewModel vm, MapperContext arg3)
        {
            vm.Id = src.Id;
            vm.Name = src.Name;
        }
    }

}
