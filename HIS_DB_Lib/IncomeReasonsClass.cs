using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Basic;

namespace HIS_DB_Lib
{
    public enum enum_收支原因
    {
        GUID,
        類別,
        原因,
        新增時間
    }
    public class IncomeReasonsClass
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("TYPE")]
        public string 類別 { get; set; }
        [JsonPropertyName("RSN")]
        public string 原因 { get; set; }
        [JsonPropertyName("CT_TIME")]
        public string 新增時間 { get; set; }
      

    }
}
