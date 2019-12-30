using System;
using System.Runtime.Serialization;

namespace DinosaursPark.Generation.Exceptions
{
    [Serializable]
    public class GenerationException : Exception
    {
        public GenerationException()
        {
        }

        public GenerationException(string message)
            : base(message)
        {
        }

        public GenerationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GenerationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
