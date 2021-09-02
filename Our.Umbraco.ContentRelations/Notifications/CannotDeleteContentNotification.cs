using System.Globalization;
using System.Linq;
using Microsoft.Extensions.Logging;
using Our.Umbraco.ContentRelations.Services;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services;


namespace Our.Umbraco.ContentRelations.Notifications
{
    public class CannotDeleteContentNotification : INotificationHandler<ContentMovingToRecycleBinNotification>
    {
        private readonly ILogger<CannotDeleteContentNotification> _logger;
        private readonly IContentRelationsService _relationService;
        private readonly ILocalizedTextService _localizedTextService;

        public CannotDeleteContentNotification(
            ILogger<CannotDeleteContentNotification> logger,
            IContentRelationsService relationService,
            ILocalizedTextService localizedTextService)
        {
            _logger = logger;
            _relationService = relationService;
            _localizedTextService = localizedTextService;
        }

        public void Handle(ContentMovingToRecycleBinNotification notification)
        {

            foreach (var moveEventInfo in notification.MoveInfoCollection)
            {

                var relations = _relationService.GetRelationsByContentId(moveEventInfo.Entity.Id);
                if (relations.Any())
                {
                    const string area = Static.Constants.Text.Notifications.Area;
                    var category = _localizedTextService.Localize(area, Static.Constants.Text.Notifications.DeleteNotAllowedCategory, CultureInfo.CurrentCulture);
                    var message = _localizedTextService.Localize(area, Static.Constants.Text.Notifications.DeleteNotAllowedMessage, CultureInfo.CurrentCulture);

                    notification.CancelOperation(new EventMessage(category, message, EventMessageType.Error));

                    // TODO LOG? 
                }
            }
        }
    }
}
