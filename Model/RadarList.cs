using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RadarList
    {
        [JsonProperty("radar")]
        public List<Radar> Radars { get; set; }
    }
}

