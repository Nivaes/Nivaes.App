namespace Nivaes.App
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;

    [SuppressMessage("Design", "CA1032:Implement standard exception constructors", Justification = "Force message description")]
    [SuppressMessage("Design", "RCS1194:Implement exception constructors.", Justification = "Force message description")]
    public class CommunicationException
        : AppException
    {
        public string? CallerMemberName { get; }

        public HttpStatusCode? HttpStatusCode { get; private set; }

        public CommunicationException(string message, string callerMemberName)
            : base(message)
        {
            CallerMemberName = callerMemberName;
        }

        public CommunicationException(string message, Exception innerException)
           : base(message, innerException)
        {
        }

        public CommunicationException(string message, string callerMemberName, HttpStatusCode httpStatusCode)
            : base(message)
        {
            CallerMemberName = callerMemberName;
            HttpStatusCode = httpStatusCode;
        }

        public CommunicationException(string message, string callerMemberName, Exception innerException)
           : base(message, innerException)
        {
            CallerMemberName = callerMemberName;
        }

        public CommunicationException(string message, string callerMemberName, HttpStatusCode httpStatusCode, Exception innerException)
            : base(message, innerException)
        {
            CallerMemberName = callerMemberName;
            HttpStatusCode = httpStatusCode;
        }

        public override string ToString()
        {
            if (HttpStatusCode.HasValue)
                return $"{base.ToString()} \n Methods: {CallerMemberName} \n HttpStatusCode: {HttpStatusCode}";
            else
                return $"{base.ToString()} \n Methods: {CallerMemberName}";
        }
    }
}
