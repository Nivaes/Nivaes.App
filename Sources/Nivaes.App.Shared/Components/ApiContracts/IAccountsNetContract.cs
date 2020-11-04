namespace Nivaes.App.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.Threading.Tasks;
    using ProtoBuf;
    using ProtoBuf.Grpc;

    [ServiceContract(Name = "accounts")]
    public interface IAccountsNetContract
    {
        [OperationContract(Name = "exists/account/name")]
        ValueTask<ExistsAccountResult> ExistsAccountName(string name, CallContext context = default);

        [OperationContract(Name = "existsaccountemail")]
        ValueTask<ExistsAccountResult> ExistsAccountEMail(string eMail);

        [OperationContract(Name = "create")]
        ValueTask<CreateAccountResult> CreateAccount(NewAccountModel newAccount);

        [OperationContract(Name = "current")]
        ValueTask<GetAccountResult> GetAccount(CallContext context = default);

        [OperationContract(Name = "account.id")]
        ValueTask<GetAccountResult> GetAccount(GetAccountRequest request, CallContext context = default);

        [OperationContract(Name = "update.account")]
        ValueTask<UpdateAccountResult> UpdateAccount(AccountDataModel account);

        [OperationContract(Name = "validate.password")]
        ValueTask<ValidatePasswordResult> ValidatePassword(PasswordRequest request);

        ValueTask<IEnumerable<ErrorResponse>> ValidatorNewAccount(AccountDataModel account);
    }

    [ProtoContract(Name = "ExistsAccountResult", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None, SkipConstructor = true)]
    public class ExistsAccountResult
        : Result, IDataModelProtobuf
    {
        [ProtoMember(1, Name = "ExistsAccount")]
        public bool ExistsAccount { get; set; }
    }

    [ProtoContract(Name = "CreateAccountResult", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None, SkipConstructor = true)]
    public class CreateAccountResult
        : Result, IDataModelProtobuf
    {
        [ProtoMember(1, Name = "IdAccount")]
        public Guid IdAccount { get; set; }

        [ProtoMember(2, Name = "AccountCreated")]
        public bool AccountCreated { get; set; }

        [ProtoMember(3, Name = "Errors")]
        public IEnumerable<ErrorResponse> Errors { get; set; } = Array.Empty<ErrorResponse>();
    }

    [ProtoContract(Name = "GetAccountResult", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None, SkipConstructor = true)]
    public class GetAccountResult
        : Result, IDataModelProtobuf
    {
        public GetAccountResult()
        { }

        [ProtoMember(1, Name = "Account")]
        public AccountDataModel? Account { get; set; }
    }

    [ProtoContract(Name = "GetAccountRequest", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None, SkipConstructor = true)]
    public class GetAccountRequest
        : Request, IDataModelProtobuf
    {
        public GetAccountRequest()
        { }

        [ProtoMember(1, Name = "IdAccount")]
        public Guid IdAccount { get; set; }
    }

    [ProtoContract(Name = "UpdateAccountResult", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None, SkipConstructor = true)]
    public class UpdateAccountResult
        : Request, IDataModelProtobuf
    {
        public UpdateAccountResult()
        { }

        [ProtoMember(1, Name = "IdAccount")]
        public Guid IdAccount { get; set; }

        [ProtoMember(2, Name = "AccountUpdate")]
        public bool AccountUpdate { get; set; }

        [ProtoMember(3, Name = "Errors")]
        public IEnumerable<ErrorResponse> Errors { get; set; } = Array.Empty<ErrorResponse>();
    }

    [ProtoContract(Name = "ValidatePassword", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None, SkipConstructor = true)]
    public class ValidatePasswordResult
        : Result, IDataModelProtobuf
    {
        [ProtoMember(1, Name = "IsValid")]
        public bool IsValid { get; set; }

        [ProtoMember(2, Name = "Errors")]
        public IEnumerable<ErrorResponse> Errors { get; set; } = Array.Empty<ErrorResponse>();
    }

    [ProtoContract(Name = "PasswordRequest", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None, SkipConstructor = true)]
    public class PasswordRequest
        : Request, IDataModelProtobuf
    {
        [ProtoMember(1, Name = "Password")]
        public string Password { get; set; } = string.Empty;
    }
}
