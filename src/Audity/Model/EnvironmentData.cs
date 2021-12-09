// ReSharper disable InconsistentNaming
// ReSharper disable UnusedAutoPropertyAccessor.Global

using System;

namespace Audity.Model
{
    [Serializable]
    public class EnvironmentData
    {
        public string MachineName { get; set; }
        public string OSVersion { get; set; }
        public string UserDomainName { get; set; }
        public string UserName { get; set; }
        public string Version { get; set; }
    }
}