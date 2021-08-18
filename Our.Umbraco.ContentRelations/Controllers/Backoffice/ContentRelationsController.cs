using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;

namespace Our.Umbraco.ContentRelations.Controllers.Backoffice
{

    public class ContentRelationsController : UmbracoAuthorizedApiController
    {
        private readonly IRelationService _relationService;
        public ContentRelationsController(
            IRelationService relationService)
        {
            _relationService = relationService;
        }

        public IEnumerable<IRelation> GetRelationsByContentId(int id)
        {

            var childRelations = _relationService.GetByChildId(id);
            var parentRelations = _relationService.GetByParentId(id);
            
            var result = childRelations.Concat(parentRelations).ToList();

            return result.Any() ? result : Enumerable.Empty<IRelation>();

        }
    }
}
