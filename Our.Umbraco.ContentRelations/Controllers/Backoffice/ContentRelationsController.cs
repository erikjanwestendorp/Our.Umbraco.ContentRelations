using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Our.Umbraco.ContentRelations.Services;
using Our.Umbraco.ContentRelations.ViewModels;
using Umbraco.Cms.Web.BackOffice.Controllers;

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
        public RelationViewModel AddRelation(RelationViewModel relation)
        {
            // TODO VALIDATION
            // TODO IS USER ADMIN
            // TODO IS relation valid
            // TODO RETURN ATTEMPT? 
            // TODO DOES RELATION ALREADY EXIST?

            return _relationService.Save(relation);
        }

        [HttpDelete] 
        public bool DeleteRelation(int id)
        {
            // TODO Only admins can delete
            return _relationService.Delete(id);
        }

    }
}
