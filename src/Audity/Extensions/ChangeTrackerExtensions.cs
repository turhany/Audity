using Audity.Generator;
using Audity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Audity.Extensions
{
    public static class ChangeTrackerExtensions
    {
        public static AuditEntryResult GetAuditData(this ChangeTracker changeTracker, AuditConfiguration configuration)
        {
            return AuditGenerator.Generate(changeTracker, configuration);
        }
    }
}