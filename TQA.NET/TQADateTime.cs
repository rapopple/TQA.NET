using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQA.NET
{
    public class TQADateTime
    {
        [JsonProperty(PropertyName = "date")]
        public String Date { get; set; }

        [JsonProperty(PropertyName = "timezone_type")]
        public int TimeZoneType { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public String TimeZone { get; set; }

    }
}
