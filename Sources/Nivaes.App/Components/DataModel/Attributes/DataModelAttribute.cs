namespace Nivaes.App
{
    using System;

    /// <summary>Attribute for indicate ignore atribute in data model.</summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DataModelAttribute : Attribute
    {
    }
}
