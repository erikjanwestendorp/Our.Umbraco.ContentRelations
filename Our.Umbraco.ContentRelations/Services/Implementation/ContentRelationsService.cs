using System.Collections.Generic;
using System.Linq;
using Our.Umbraco.ContentRelations.Static;
using Our.Umbraco.ContentRelations.ViewModels;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace Our.Umbraco.ContentRelations.Services.Implementation
{
    public class ContentRelationsService : IContentRelationsService
    {
        private readonly IRelationService _relationService;
        private readonly IUmbracoMapper _umbracoMapper;
        private readonly IContentService _contentService;

        public ContentRelationsService(
            IRelationService relationService,
            IUmbracoMapper umbracoMapper,
            IContentService contentService)
        {
            _relationService = relationService;
            _umbracoMapper = umbracoMapper;
            _contentService = contentService;
        }
        public IEnumerable<RelationViewModel> GetRelationsByContentId(int id)
        {

            var relations = _relationService.GetAllRelationsByRelationType(RelationType()).Where(x => x.ParentId == id || x.ChildId == id).ToList();

            var mapped = _umbracoMapper.MapEnumerable<IRelation, RelationViewModel>(relations);

            var result = new List<RelationViewModel>();
            foreach (var relationViewModel in mapped)
            {
                // Add Content 
                if (relationViewModel.ChildId == relationViewModel.ParentId)
                {
                    continue;
                }


                if (relationViewModel.ChildId == id)
                {
                    relationViewModel.Content = GetContent(relationViewModel.ParentId);
                }

                if (relationViewModel.ParentId == id)
                {
                    relationViewModel.Content = GetContent(relationViewModel.ChildId);

                }

                if (relationViewModel.Content != null)
                    result.Add(relationViewModel);

            }

            return result;
        }


        public RelationViewModel Save(RelationViewModel relation)
        {
            _relationService.Save(
                new Relation(relation.ParentId, relation.ChildId, RelationType())
                {
                    Comment = relation.Comment
                });

            var addedRelation = _relationService.GetAllRelations().FirstOrDefault(x => x.ChildId == relation.ChildId && x.ParentId == relation.ParentId);


            if (addedRelation != null)
            {
                var mapped = _umbracoMapper.Map<IRelation, RelationViewModel>(addedRelation);
                mapped.Content = GetContent(mapped.ChildId);

                return mapped;
            }
            
            // TODO Error handling
            return relation;

        }

        public bool Exists(RelationViewModel relation)
        {
            var allRelations = _relationService.GetAllRelationsByRelationType(RelationType());

            if (allRelations.Any(x => x.ChildId == relation.ChildId && x.ParentId == relation.ParentId))
                return true;

            return false;

        }

        public bool Delete(int id)
        {
            var r = _relationService.GetById(id);

            if (r == null)
                return false;

            _relationService.Delete(r);

            return true;
        }

        private IRelationType RelationType()
        {
            return _relationService.GetRelationTypeByAlias(Constants.RelationTypes.RelatedContent.Alias);

        }

        private ContentViewModel GetContent(int id)
        {
            var content = _contentService.GetById(id);

            return content != null ? _umbracoMapper.Map<IContent, ContentViewModel>(content) : null;
        }
    }
}
