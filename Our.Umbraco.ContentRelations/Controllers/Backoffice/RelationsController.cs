using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Our.Umbraco.ContentRelations.Common;
using Our.Umbraco.ContentRelations.Services;
using Our.Umbraco.ContentRelations.Static;
using Our.Umbraco.ContentRelations.ViewModels;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;
using Umbraco.Cms.Web.Common.Authorization;

namespace Our.Umbraco.ContentRelations.Controllers.Backoffice
{
    [PluginController(Constants.Package.PluginName)]
    public class RelationsController : UmbracoAuthorizedApiController
    {
        private readonly IContentRelationsService _relationService;
        private readonly ILogger<RelationsController> _logger;


        public RelationsController(
            IContentRelationsService relationService,
            ILogger<RelationsController> logger)
        {
            _relationService = relationService;
            _logger = logger;

        }

        [HttpGet]
        public IEnumerable<RelationViewModel> GetRelationsByContentId(int id)
        {
            return _relationService.GetRelationsByContentId(id);
            
        }

        [HttpPost]
        [Authorize(Policy = AuthorizationPolicies.SectionAccessSettings)]
        public ApiAttempt<RelationViewModel> AddRelation(RelationViewModel relation)
        {
            // TODO VALIDATION
            // TODO IS relation valid
            
            if (_relationService.Exists(relation))
            {
                _logger.LogInformation("Cannot add relation because a relation between these nodes already exists. {childId}, {parentId}", relation.ChildId, relation.ParentId);
                return ApiAttempt<RelationViewModel>.Failed(relation, "Not allowed", "This relation already exists", EventMessageType.Error);
            }
                

            return ApiAttempt<RelationViewModel>.Success(_relationService.Save(relation),"Succeeded", "The relation has been added successfully");
        }

        [HttpDelete]
        [Authorize(Policy = AuthorizationPolicies.SectionAccessSettings)]
        public bool DeleteRelation(int id)
        {
            return _relationService.Delete(id);
        }

    }
}
