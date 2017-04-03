using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQA.NET
{
    public class Site
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "notes")]
        public String Notes { get; set; }

        [JsonProperty(PropertyName = "ownerId")]
        public int OwnerID { get; set; }

        [JsonProperty(PropertyName = "machineIds")]
        public List<int> MachineIds { get; set; }

        [JsonProperty(PropertyName = "userIds")]
        public List<int> UserIds { get; set; }
    }
}
