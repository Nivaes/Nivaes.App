namespace Nivaes.App
{
    using System;

    public class AppException
        : Exception
    {
        public AppException()
           : base()
        { }

        public AppException(string message)
            : base(message)
        { }

        public AppException(string messageFormat, params object?[] messageFormatArguments)
            : base(string.Format(messageFormat, messageFormatArguments))
        {
        }

        // the order of parameters here is slightly different to that normally expected in an exception
        // - but this order allows us to put string.Format in place
        public AppException(Exception innerException, string messageFormat, params object?[] formatArguments)
            : base(string.Format(messageFormat, formatArguments), innerException)
        {
        }

        public AppException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
