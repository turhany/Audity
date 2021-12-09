using System.Collections.Generic;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace Audity.Model
{
    public class AuditConfiguration
    {
        public string KeyPropertyName { get; set; }
        public bool IncludeEnvironmentData { get; set; }
        public List<string> ExcludeEntities { get; set; } = new List<string>();
        public List<string> MaskedProperties { get; set; } = new List<string>();
    }
}