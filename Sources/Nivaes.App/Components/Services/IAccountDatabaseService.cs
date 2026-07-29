namespace Nivaes.App
{
    public interface IAccountDatabaseService
    {
        ValueTask<AccountDataModel> LoadAccount(Guid idAccount);

        ValueTask SaveAccount(AccountDataModel account);
    }
}
