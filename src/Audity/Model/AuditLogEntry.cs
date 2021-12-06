// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Audity.Model
{
    public class AuditLogEntry
    {
        public string KeyPropertyValue { get; set; }
        public string EntityName { get; set; }
        public AuditLogOperationType AuditLogOperationType { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}