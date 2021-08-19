using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;

namespace Our.Umbraco.ContentRelations.Controllers.Backoffice
{

    public class ContentRelationsController : UmbracoAuthorizedApiController
    {
        private readonly IRelationService _relationService;
        private readonly IContentService _contentService;
        public ContentRelationsController(
            IRelationService relationService,
            IContentService contentService)
        {
            _relationService = relationService;
            _contentService = contentService;
        }

        [HttpGet]
        public IEnumerable<IRelation> GetRelationsByContentId(int id)
        {
            var childRelations = _relationService.GetByChildId(id).ToList();
            var parentRelations = _relationService.GetByParentId(id).ToList();

            
            var result = childRelations.Concat(parentRelations).ToList();

            return result.Any() ? result : Enumerable.Empty<IRelation>();

        }
    }
}
