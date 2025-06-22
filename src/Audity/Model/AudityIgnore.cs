using Newtonsoft.Json;

namespace Audity.Model
{ 
    public class AudityIgnore : JsonExtensionDataAttribute
    {
        public AudityIgnore()
        {
            this.WriteData = false;
            this.ReadData = false;
        }
    }
}
