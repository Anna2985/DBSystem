using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Basic;
using System.ComponentModel;

namespace ClassLibrary
{
    [EnumDescription("med_carList")]
    public enum enum_med_carList
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("藥局,VARCHAR,30,INDEX")]
        藥局,
        [Description("藥局名,VARCHAR,30,NONE")]
        藥局名,
        [Description("護理站,VARCHAR,30,INDEX")]
        護理站
    }
    public class medCarListClass
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("phar")]
        public string 藥局 { get; set; }
        [JsonPropertyName("phar_name")]
        public string 藥局名 { get; set; }
        [JsonPropertyName("hnursta")]
        public string 護理站 { get; set; }
    }
    public static class PharmacyData
    {
        public static Dictionary<string, string> PharmacyDictionary = new Dictionary<string, string>()
        {
            { "UB01", "中正樓總藥局" },
            { "UB18", "中正樓十三樓藥局" },
            { "UA05", "思源樓思源藥局" },
            { "ERS1", "中正樓急診藥局" },
            { "UBAA", "中正樓配方機藥局" },
            { "UATP", "中正樓TPN藥局" },
            { "EW01", "思源樓神經再生藥局" },
            { "UBTP", "中正樓臨床試驗藥局" },
            { "UC02", "長青樓長青樓藥局" },
        };
    }



}
