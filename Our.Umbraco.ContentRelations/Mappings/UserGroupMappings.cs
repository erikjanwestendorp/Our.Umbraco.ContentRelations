using Our.Umbraco.ContentRelations.ViewModels;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Models.Membership;

namespace Our.Umbraco.ContentRelations.Mappings
{
    public class UserGroupMappings : IMapDefinition
    {
        public void DefineMaps(IUmbracoMapper mapper)
        {
            mapper.Define<IUserGroup, UserGroupViewModel>((perm, context) => new UserGroupViewModel(), Map);
        }
        private void Map(IUserGroup src, UserGroupViewModel vm, MapperContext arg3)
        {
            vm.Alias = src.Alias;
            vm.Name = src.Name;
        }
    }
}
