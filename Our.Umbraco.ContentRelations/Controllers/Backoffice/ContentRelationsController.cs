using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Our.Umbraco.ContentRelations.Services;
using Our.Umbraco.ContentRelations.ViewModels;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Authorization;

namespace Our.Umbraco.ContentRelations.Controllers.Backoffice
{

    public class ContentRelationsController : UmbracoAuthorizedApiController
    {
        private readonly IContentRelationsService _relationService;


        public ContentRelationsController(
            IContentRelationsService relationService)
        {
            _relationService = relationService;

        }

        [HttpGet]
        public IEnumerable<RelationViewModel> GetRelationsByContentId(int id)
        {
            return _relationService.GetRelationsByContentId(id);
            
        }

        [HttpPost]
        [Authorize(Policy = AuthorizationPolicies.SectionAccessSettings)]
        public RelationViewModel AddRelation(RelationViewModel relation)
        {
            // TODO VALIDATION
            // TODO IS relation valid
            // TODO RETURN ATTEMPT? 


            if (_relationService.Exists(relation))
            {
                return relation;
            }
                

            return _relationService.Save(relation);
        }

        [HttpDelete]
        [Authorize(Policy = AuthorizationPolicies.SectionAccessSettings)]
        public bool DeleteRelation(int id)
        {
            return _relationService.Delete(id);
        }

    }
}
