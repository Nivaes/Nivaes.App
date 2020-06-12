namespace Nivaes.Contracts
{
    using System.ServiceModel;
    using System.Threading.Tasks;
    using ProtoBuf.Grpc;

    [ServiceContract(Name = "user.echo")]
    public interface IUserEchoNetContract
    {
        [OperationContract(Name = "anonymous")]
        ValueTask<string> UserEchoAnonymous(string echo, CallContext context = default);

        [OperationContract(Name = "clientAccount")]
        ValueTask<string> UserEchoClientAccount(string echo, CallContext context = default);

        [OperationContract(Name = "account")]
        ValueTask<string> UserEchoAccount(string echo, CallContext context = default);
    }
}
