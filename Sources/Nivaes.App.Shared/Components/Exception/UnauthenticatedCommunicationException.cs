namespace Nivaes.App
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("Design", "CA1032:Implement standard exception constructors", Justification = "callerMemberName is required.")]
    [SuppressMessage("Design", "RCS1194:Implement exception constructors.", Justification = "Force message description")]
    public class UnauthenticatedCommunicationException
        : CommunicationException
    {
        [DebuggerStepThrough]
        public UnauthenticatedCommunicationException(string message, string callerMemberName)
            : base(message, callerMemberName)
        { }

        [DebuggerStepThrough]
        public UnauthenticatedCommunicationException(string message, string callerMemberName, Exception innerException)
            : base(message, callerMemberName, innerException)
        { }
    }
}
