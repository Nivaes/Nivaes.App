namespace Nivaes.App.Shared.UnitTest
{
    using System;

    public sealed class ProtoBufRegisterFixture
        : IDisposable
    {
        public ProtoBufRegisterFixture()
        {
            Nivaes.App.Shared.Runtime.CompilerServices.ProtoBufRegisterHelper.RegisterProtoBufTypes();
            Nivaes.App.Shared.Test.Runtime.CompilerServices.ProtoBufRegisterHelper.RegisterProtoBufTypes();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
