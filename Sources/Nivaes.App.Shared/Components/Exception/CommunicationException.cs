namespace Nivaes
{
    using System;

    public class CommunicationException
        : Exception
    {
        public CommunicationException()
           : base()
        { }

        public CommunicationException(string message)
            : base(message)
        { }

        public CommunicationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
