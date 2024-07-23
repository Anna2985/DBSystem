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
    [EnumDescription("med_carInfo")]
    public enum enum_藥車資訊
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("姓名,VARCHAR,30,NONE")]
        姓名,
        [Description("住院號,VARCHAR,50,INDEX")]
        住院號,
        [Description("病歷號,VARCHAR,50,NONE")]
        病歷號,
        [Description("住院藥局,VARCHAR,10,NONE")]
        住院藥局,
        [Description("護理站,VARCHAR,10,NONE")]
        護理站,
        [Description("床號,VARCHAR,10,NONE")]
        床號,
        [Description("占床狀態,VARCHAR,10,NONE")]
        占床狀態,
        [Description("調劑狀態,VARCHAR,10,NONE")]
        調劑狀態
    }
    public class medCarInfoClass
    {
        [JsonPropertyName("GUID")]

        public string GUID { get; set; }
        [JsonPropertyName("pnamec")]

        public string 姓名 { get; set; }
        [JsonPropertyName("caseno")]
        public string 住院號 { get; set; }
        [JsonPropertyName("histno")]
        public string 病歷號 { get; set; }
        [JsonPropertyName("phar")]
        public string 住院藥局 { get; set; }
        [JsonPropertyName("hnursta")]
        public string 護理站 { get; set; }
        [JsonPropertyName("hbedno")]
        public string 床號 { get; set; }
        [JsonPropertyName("bed_status")]
        public string 占床狀態 { get; set; }
        [JsonPropertyName("dispens_status")]
        public string 調劑狀態 { get; set; }
    }
}
