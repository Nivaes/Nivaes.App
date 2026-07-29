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
    }
}
