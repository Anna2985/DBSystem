using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Basic;

namespace HIS_DB_Lib
{
    public enum enum_updateVersion
    {
        GUID,
        program_name,
        version,
        filepath,
        update_time,
        enable,
    }

    public class updateVersionClass
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("program_name")]
        public string program_name { get; set; }
        [JsonPropertyName("version")]
        public string version { get; set; }
        [JsonPropertyName("filepath")]
        public string filepath { get; set; }
        [JsonPropertyName("update_time")]
        public string update_time { get; set; }
        [JsonPropertyName("enable")]
        public string enable { get; set; }
    }
}
