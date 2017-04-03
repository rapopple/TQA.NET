using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQA.NET
{
    public class Schedule
    {
        [JsonProperty(PropertyName = "id")]
        public String Id { get; set; }

        [JsonProperty(PropertyName = "machineId")]
        public String MachineId { get; set; }

        [JsonProperty(PropertyName = "templateId")]
        public String TemplateId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }
    }
}
