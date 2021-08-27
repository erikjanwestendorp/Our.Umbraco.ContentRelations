using System.Linq;
using Microsoft.Extensions.Logging;
using Our.Umbraco.ContentRelations.Services;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Our.Umbraco.ContentRelations.Notifications
{
    public class CannotDeleteContentNotification : INotificationHandler<ContentMovingToRecycleBinNotification>
    {
        private readonly ILogger<CannotDeleteContentNotification> _logger;
        private readonly IContentRelationsService _relationService;

        public CannotDeleteContentNotification(
            ILogger<CannotDeleteContentNotification> logger,
            IContentRelationsService relationService)
        {
            _logger = logger;
            _relationService = relationService;
        }

        public void Handle(ContentMovingToRecycleBinNotification notification)
        {

            foreach (var moveEventInfo in notification.MoveInfoCollection)
            {

                var relations = _relationService.GetRelationsByContentId(moveEventInfo.Entity.Id);
                if (relations.Any())
                {
                    // TODO Use localization
                    notification.CancelOperation(new EventMessage("Not allowed", "Content can not deleted because it's related to another content item", EventMessageType.Error));

                    // TODO LOG? 
                }
            }
        }
    }
}
