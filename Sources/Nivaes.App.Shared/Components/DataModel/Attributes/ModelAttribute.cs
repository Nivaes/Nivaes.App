namespace Nivaes.App
{
    using System;

    /// <summary>Attribute for indicate ignore atribute in model.</summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModelAttribute : Attribute
    {
    }
}
