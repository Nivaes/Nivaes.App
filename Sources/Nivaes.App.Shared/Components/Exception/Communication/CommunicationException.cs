namespace Nivaes.App
{
    public class CommunicationException
        : AppException
    {
        public string? CallerMemberName { get; }

        //public StatusCode? StatusCode { get; private set; }

        public CommunicationException(string message, string callerMemberName)
            : base(message)
        {
            CallerMemberName = callerMemberName;
        }

        public CommunicationException(string message, Exception innerException)
           : base(message, innerException)
        {
        }

        //public CommunicationException(string message, string callerMemberName, StatusCode statusCode)
        //    : base(message)
        //{
        //    CallerMemberName = callerMemberName;
        //    StatusCode = statusCode;
        //}

        public CommunicationException(string message, string callerMemberName, Exception innerException)
           : base(message, innerException)
        {
            CallerMemberName = callerMemberName;
        }

        //public CommunicationException(string message, string callerMemberName, StatusCode statusCode, Exception innerException)
        //    : base(message, innerException)
        //{
        //    CallerMemberName = callerMemberName;
        //    StatusCode = statusCode;
        //}

        public override string ToString()
        {
            //if (StatusCode.HasValue)
            //    return $"{base.ToString()} \n Methods: {CallerMemberName} \n HttpStatusCode: {StatusCode}";
            //else
                return $"{base.ToString()} \n Methods: {CallerMemberName}";
        }
    }
}
