using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Basic;
namespace HIS_DB_Lib
{
    public enum enum_commonSpaceSetup
    {
        GUID,
        共用區名稱,
        共用區類型,
        是否共用,
        設置時間,
    }
    public class commonSpaceSetup
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("name")]
        public string 共用區名稱 { get; set; }
        [JsonPropertyName("type")]
        public string 共用區類型 { get; set; }
        [JsonPropertyName("enable")]
        public string 是否共用 { get; set; }
        [JsonPropertyName("setup_time")]
        public string 設置時間 { get; set; }
    }
}
