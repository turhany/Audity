using System;

namespace Audity.Model
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class AudityIgnoreAttribute : Attribute
    { 

    }
}
