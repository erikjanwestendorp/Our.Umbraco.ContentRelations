using Our.Umbraco.ContentRelations.ViewModels;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Models;

namespace Our.Umbraco.ContentRelations.Mappings
{
    public class RelationMappings : IMapDefinition
    {
        public void DefineMaps(IUmbracoMapper mapper)
        {
            mapper.Define<IRelation, RelationViewModel>((perm, context) => new RelationViewModel(), Map);
        }

        private static void Map(IRelation src, RelationViewModel vm, MapperContext arg3)
        {
            vm.Id = src.Id;
            vm.CreateDate = src.CreateDate;
            vm.ChildId = src.ChildId;
            vm.ChildObjectType = src.ChildObjectType;
            vm.Comment = src.Comment;
            vm.Content = null;
            vm.ParentId = src.ParentId;
            vm.ParentObjectGuid = src.ParentObjectType;
            vm.RelationType = src.RelationType;
            vm.RelationTypeId = src.RelationTypeId;
        }
    }
}
