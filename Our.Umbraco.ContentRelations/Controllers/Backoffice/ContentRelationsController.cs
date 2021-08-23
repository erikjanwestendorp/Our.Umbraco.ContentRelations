using System;
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
            throw new NotImplementedException();
        }


    }
}
