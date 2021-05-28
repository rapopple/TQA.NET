using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQA.NET
{
    public class Template
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public String Description { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool IsActive { get; set; }

        [JsonProperty(PropertyName = "owner")]
        public String Owner { get; set; }

        [JsonProperty(PropertyName = "tests")]
        public Test[] Tests { get; set; }

        [JsonProperty(PropertyName = "deviceTypes")]
        public DeviceType[] DeviceTypes { get; set; }

        [JsonProperty(PropertyName = "allowDeviceTypeOther")]
        public bool AllowDeviceTypeOther { get; set; }
    }
}
