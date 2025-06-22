using System;

namespace Audity.Model
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class AudityIgnoreAttribute : Attribute
    { 

    }
}
