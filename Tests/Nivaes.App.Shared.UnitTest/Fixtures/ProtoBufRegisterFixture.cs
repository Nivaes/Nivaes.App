namespace Nivaes.App.Shared.UnitTest
{
    using System;

    public sealed class ProtoBufRegisterFixture
        : IDisposable
    {
        public ProtoBufRegisterFixture()
        {
            Nivaes.App.Shared.Helpers.ProtoBufRegisterHelper.RegisterProtoBufTypes();
            Nivaes.App.Shared.Test.Helpers.ProtoBufRegisterHelper.RegisterProtoBufTypes();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
