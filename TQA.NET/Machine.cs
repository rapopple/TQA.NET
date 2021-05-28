using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQA.NET
{
    public class Machine
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "uid")]
        public String UID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "deviceType")]
        public DeviceType DeviceType { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "schedules")]
        public List<int> Schedules { get; set; }

        [JsonProperty(PropertyName = "siteId")]
        public int SiteId { get; set; }

        [JsonProperty(PropertyName = "phoneNumber")]
        public String PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "serialNumber")]
        public String SerialNumber { get; set; }

        [JsonProperty(PropertyName = "internalNumber")]
        public String InternalNumber { get; set; }

        [JsonProperty(PropertyName = "creationDate")]
        public TQADateTime CreationDate { get; set; }

        [JsonProperty(PropertyName = "source")]
        public List<int> Source { get; set; }

        [JsonProperty(PropertyName = "users")]
        public List<int> Users { get; set; }
    }
}
