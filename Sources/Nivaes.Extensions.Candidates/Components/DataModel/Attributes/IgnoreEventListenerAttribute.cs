namespace Nivaes.App
{
    /// <summary>Attribute for indicate ignore atribute in data view.</summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IgnoreEventListenerAttribute : Attribute
    {
    }
}
