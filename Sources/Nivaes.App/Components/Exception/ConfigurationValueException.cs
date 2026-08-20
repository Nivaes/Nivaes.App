namespace Nivaes.App
{
    public class ConfigurationValueException
        : AppException
    {
        public ConfigurationValueException()
           : base()
        {
        }

        public ConfigurationValueException(string? message)
           : base($"Configuration error in: '{message}'")
        {
        }

        public ConfigurationValueException(string message, Exception? innerException)
            : base(message, innerException)
        {
        }

        public ConfigurationValueException(string messageFormat, params object?[] messageFormatArguments)
            : base(messageFormat, messageFormatArguments)
        {
        }

        public ConfigurationValueException(Exception innerException, string messageFormat, params object?[] formatArguments)
            : base(innerException, messageFormat, formatArguments)
        {
        }
    }
}
