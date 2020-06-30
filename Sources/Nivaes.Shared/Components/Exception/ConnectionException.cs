namespace Nivaes
{
    using System;

    public class ConnectionException
        : Exception
    {
        public ConnectionException()
           : base()
        { }

        public ConnectionException(string message)
            : base(message)
        { }

        public ConnectionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public static ConnectionException NotUrlDefined() => new ConnectionException(ConnectionExceptionLocalizationString.UrlNotDefined);
    }
}
