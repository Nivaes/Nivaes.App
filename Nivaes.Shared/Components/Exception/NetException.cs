namespace Nivaes
{
    using System;

    public class NetException : Exception
    {
        public NetException()
           : base()
        { }

        public NetException(string message)
            : base(message)
        { }

        public NetException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
