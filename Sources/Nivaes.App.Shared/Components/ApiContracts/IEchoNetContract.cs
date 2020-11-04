namespace Nivaes.App.Contracts
{
    using System.ServiceModel;
    using System.Threading.Tasks;
    using ProtoBuf.Grpc;

    [ServiceContract(Name = "echo")]
    public interface IEchoNetContract
    {
        [OperationContract(Name = "anonymous")]
        ValueTask<string> EchoAnonymous(string echo, CallContext context = default);

        [OperationContract(Name = "exception")]
        ValueTask<string> EchoException(string echo, CallContext context = default);

        [OperationContract(Name = "clientAccount")]
        ValueTask<string> EchoClientAccount(string echo, CallContext context = default);

        [OperationContract(Name = "account")]
        ValueTask<string> EchoAccount(string echo, CallContext context = default);
    }
}
