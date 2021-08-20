using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Our.Umbraco.ContentRelations.ViewModels;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;

namespace Our.Umbraco.ContentRelations.Controllers.Backoffice
{

    public class ContentRelationsController : UmbracoAuthorizedApiController
    {
        private readonly IRelationService _relationService;
        private readonly IContentService _contentService;
        private readonly IUmbracoMapper _umbracoMapper;

        public ContentRelationsController(
            IRelationService relationService,
            IContentService contentService, 
            IUmbracoMapper umbracoMapper)
        {
            _relationService = relationService;
            _contentService = contentService;
            _umbracoMapper = umbracoMapper;
        }

        [HttpGet]
        public IEnumerable<RelationViewModel> GetRelationsByContentId(int id)
        {
            var childRelations = _relationService.GetByChildId(id).ToList();
            var parentRelations = _relationService.GetByParentId(id).ToList();

            // TODO Make a service 
            
            var concatenated = childRelations.Concat(parentRelations).ToList();
            var mapped = _umbracoMapper.MapEnumerable<IRelation, RelationViewModel>(concatenated);

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
                    var cont = _contentService.GetById(relationViewModel.ParentId);

                    if (cont != null)
                    {
                        relationViewModel.Content = _umbracoMapper.Map<IContent, ContentViewModel>(cont);
                        result.Add(relationViewModel);

                    }
                        
                }

                if (relationViewModel.ParentId == id)
                {
                    var cont = _contentService.GetById(relationViewModel.ChildId);

                    if (cont != null)
                    {
                        relationViewModel.Content = _umbracoMapper.Map<IContent, ContentViewModel>(cont);
                        result.Add(relationViewModel);
                    }
                }

                

            }

            return result.Any() ? result : Enumerable.Empty<RelationViewModel>();

        }
    }
}
