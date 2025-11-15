namespace Nivaes.App
{
    using System;

    [AttributeUsage(System.AttributeTargets.Field)]
    public sealed class AutoNotifyAttribute : Attribute
    {
        public string? PropertyName { get; set; }
    }
}
