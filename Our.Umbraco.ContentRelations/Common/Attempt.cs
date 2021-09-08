using Umbraco.Cms.Core.Events;

namespace Our.Umbraco.ContentRelations.Common
{

    public class Attempt<T> : Attempt
        where T : class
    {
        public T Content { get; set; }

        public new static Attempt Success(string category, string message)
        {
            return new Attempt<T>
            {
                Succeeded = true,
                Content = default,
                Message = new EventMessage(category, message)
            };
        }

        public static Attempt<T> Success(T content, string category, string message)
        {
            return new Attempt<T>
            {
                Succeeded = true,
                Content = content,
                Message = new EventMessage(category, message, EventMessageType.Success)
            };
        }

        public new static Attempt<T> Failed(string category, string message, EventMessageType type)
        {
            return new Attempt<T>
            {
                Succeeded = false,
                Content = default,
                Message = new EventMessage(category, message, type)
            };
        }

        public static Attempt<T> Failed(T content, string category, string message, EventMessageType type)
        {
            return new Attempt<T>
            {
                Succeeded = false,
                Content = content,
                Message = new EventMessage(category, message, type)

            };
        }

    }

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
