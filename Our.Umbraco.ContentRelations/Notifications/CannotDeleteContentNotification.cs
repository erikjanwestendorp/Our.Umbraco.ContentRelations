using System.Linq;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services;

namespace Our.Umbraco.ContentRelations.Notifications
{
    public class CannotDeleteContentNotification : INotificationHandler<ContentMovingToRecycleBinNotification>
    {
        private readonly ILogger<CannotDeleteContentNotification> _logger;
        private readonly IRelationService _relationService;

        public CannotDeleteContentNotification(
            ILogger<CannotDeleteContentNotification> logger, 
            IRelationService relationService)
        {
            _logger = logger;
            _relationService = relationService;
        }

        public void Handle(ContentMovingToRecycleBinNotification notification)
        {

            foreach (var moveEventInfo in notification.MoveInfoCollection)
            {
                // TODO Create a service or helper to avoid duplicate code
                var childRelations = _relationService.GetByChildId(moveEventInfo.Entity.Id).ToList();
                var parentRelations = _relationService.GetByParentId(moveEventInfo.Entity.Id).ToList();

                if (childRelations.Any() || parentRelations.Any())
                {
                    // TODO Use localization
                    notification.CancelOperation(new EventMessage("Not allowed", "Content can not deleted because it's related to another content item", EventMessageType.Warning));
                }


            }


            _logger.LogInformation("CannotDeleteContentNotification raised");
        }

    }
}
