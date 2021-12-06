using System.Collections.Generic;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable CollectionNeverQueried.Global

namespace Audity.Model
{
    public class AuditEntryResult
    {
        public EnvironmentData EnvironmentData { get; set; }
        public List<AuditLogEntry> AuditLogEntries { get; set; } = new List<AuditLogEntry>();
    }
}