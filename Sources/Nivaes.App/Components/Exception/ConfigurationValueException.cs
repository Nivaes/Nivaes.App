namespace Nivaes.App
{
    public class ConfigurationValueException
        : Exception
    {
        public ConfigurationValueException()
           : base()
        {
        }

        public ConfigurationValueException(string? message)
           : base($"Configuration error in: '{message}'")
        {
        }

        public ConfigurationValueException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
