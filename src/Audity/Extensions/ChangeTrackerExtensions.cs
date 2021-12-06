using Audity.Generator;
using Audity.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Audity.Extensions
{
    public static class ChangeTrackerExtensions
    {
        public static AuditEntryResult GetAuditData(this ChangeTracker item, AuditConfigurations configurations)
        {
            return AuditGenerator.Generate(item, configurations);
        }
    }
}