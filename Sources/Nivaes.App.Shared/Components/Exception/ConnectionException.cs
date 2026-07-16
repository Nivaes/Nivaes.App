namespace Nivaes.App
{
    using System;

    public class ConnectionException
        : AppException
    {
        public ConnectionException()
           : base()
        { }

        public ConnectionException(string message)
            : base(message)
        { }

        public ConnectionException(string messageFormat, params object?[] messageFormatArguments)
           : base(string.Format(messageFormat, messageFormatArguments))
        {
        }

        public ConnectionException(Exception innerException, string messageFormat, params object?[] formatArguments)
            : base(innerException, string.Format(messageFormat, formatArguments))
        {
        }

        public ConnectionException(Exception innerException, string message)
            : base(innerException, message)
        {
        }

        public static ConnectionException NotUrlDefined() => new ConnectionException(ConnectionExceptionLocalizationString.UrlNotDefined);
    }
}
