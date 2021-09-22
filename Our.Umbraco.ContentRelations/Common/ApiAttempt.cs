using Umbraco.Cms.Core.Events;

namespace Our.Umbraco.ContentRelations.Common
{

    public class ApiAttempt<T> : ApiAttempt
        where T : class
    {
        public T Content { get; set; }

        public new static ApiAttempt Success(string category, string message)
        {
            return new ApiAttempt<T>
            {
                Succeeded = true,
                Content = default,
                Message = new EventMessage(category, message)
            };
        }

        public static ApiAttempt<T> Success(T content, string category, string message)
        {
            return new ApiAttempt<T>
            {
                Succeeded = true,
                Content = content,
                Message = new EventMessage(category, message, EventMessageType.Success)
            };
        }

        public static ApiAttempt<T> Success(T content)
        {
            return new ApiAttempt<T>
            {
                Content = content,
                Succeeded = true,
                Message = new EventMessage(string.Empty, string.Empty)
            };

        }

        public new static ApiAttempt<T> Failed(string category, string message, EventMessageType type)
        {
            return new ApiAttempt<T>
            {
                Succeeded = false,
                Content = default,
                Message = new EventMessage(category, message, type)
            };
        }

        public static ApiAttempt<T> Failed(T content, string category, string message, EventMessageType type)
        {
            return new ApiAttempt<T>
            {
                Succeeded = false,
                Content = content,
                Message = new EventMessage(category, message, type)

            };
        }

    }

    public class ApiAttempt
    {
        public bool Succeeded { get; set; }
        public EventMessage Message { get; set; }

        public static ApiAttempt Success(string category, string message)
        {
            return new ApiAttempt
            {
                Succeeded = true,
                Message = new EventMessage(category, message, EventMessageType.Success)
            };
        }

        public static ApiAttempt Failed(string category, string message, EventMessageType type)
        {
            return new ApiAttempt
            {
                Succeeded = false,
                Message = new EventMessage(category, message, type)
            };
        }

    }
}
