using Audity.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization; 
using System.Linq;
using System.Reflection;

namespace Audity.Resolver
{
    internal class AudityContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (IsIgnored(member))
            {
                property.ShouldSerialize = i => false;
                property.Ignored = true;

                property.Readable = false;
                property.Writable = false;
            }

            return property;
        }

        private bool IsIgnored(MemberInfo member)
        {
            if (member == null || member.CustomAttributes  == null || !member.CustomAttributes.Any())
            {
                return false;
            }

            return member.CustomAttributes.Any(attr => attr.AttributeType == typeof(AudityIgnoreAttribute));
        }
    }
}
