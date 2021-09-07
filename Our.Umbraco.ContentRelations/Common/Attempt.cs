using Umbraco.Cms.Core.Events;

namespace Our.Umbraco.ContentRelations.Common
{
    public class Attempt
    {
        public bool Succeeded { get; set; }
        public EventMessage Message { get; set; }

        public static Attempt Success(string category, string message)
        {
            return new Attempt
            {
                Succeeded = true,
                Message = new EventMessage(category, message, EventMessageType.Success)
            };
        }

        public static Attempt Failed(string category, string message, EventMessageType type)
        {
            return new Attempt
            {
                Succeeded = false,
                Message = new EventMessage(category, message, type)
            };
        }

    }
}
