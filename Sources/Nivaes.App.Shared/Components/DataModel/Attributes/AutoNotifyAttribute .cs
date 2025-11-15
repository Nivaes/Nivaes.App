namespace Nivaes.App
{
    using System;

    [AttributeUsage(System.AttributeTargets.Field)]
    public sealed class AutoNotifyAttribute : Attribute
    {
        public AutoNotifyAttribute() { }

        public AutoNotifyAttribute(string propertyName) => PropertyName = propertyName;

        public string? PropertyName { get; set; }
    }
}
