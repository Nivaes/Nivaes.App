namespace Nivaes.App
{
    using System;
    using System.Runtime.Serialization;

    public class AppException
        : Exception
    {
        public AppException()
           : base()
        { }

        public AppException(string message)
            : base(message)
        { }

        public AppException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected AppException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
