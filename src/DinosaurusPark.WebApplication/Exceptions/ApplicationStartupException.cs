using System;
using System.Runtime.Serialization;

namespace DinosaurusPark.WebApplication.Exceptions
{
    [Serializable]
    public class ApplicationStartupException : Exception
    {
        public ApplicationStartupException()
        {
        }

        public ApplicationStartupException(string message)
            : base(message)
        {
        }

        public ApplicationStartupException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ApplicationStartupException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
