using Audity.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace Audity.Resolver
{
    internal class AudityContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);

            if (type != null && properties != null && properties.Any())
            {
                return properties.Where(p =>
                {
                    var propInfo = type.GetProperty(p.UnderlyingName);
                    return propInfo == null || !propInfo.IsDefined(typeof(AudityIgnoreAttribute), true);
                }).ToList(); 
            } 

            return properties;
        }
    }
}
