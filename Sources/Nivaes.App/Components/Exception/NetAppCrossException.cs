namespace Nivaes.App
{
    public class NetAppCrossException : AppException
    {
        public NetAppCrossException()
           : base()
        { }

        public NetAppCrossException(string message)
            : base(message)
        { }

        public NetAppCrossException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NetAppCrossException(string messageFormat, params object?[] messageFormatArguments)
            : base(messageFormat, messageFormatArguments)
        {
        }

        public NetAppCrossException(Exception innerException, string messageFormat, params object?[] formatArguments)
            : base(innerException, messageFormat, formatArguments)
        {
        }
    }
}
