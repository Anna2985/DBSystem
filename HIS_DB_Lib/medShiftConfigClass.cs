using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Basic;
using System.ComponentModel;
using System.Reflection;
namespace HIS_DB_Lib
{
    public enum enum_交班藥品設定
    {
        GUID,
        藥品碼,
        是否交班,
    }
    [EnumDescription("medShiftList")]
    public enum enum_medShiftList
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("藥碼,VARCHAR,20,INDEX")]
        藥碼,
        [Description("藥名,VARCHAR,300,NONE")]
        藥名,
        [Description("現有庫存,VARCHAR,20,NONE")]
        現有庫存,
        [Description("處方支出,VARCHAR,20,NONE")]
        處方支出,
        [Description("處方數量,VARCHAR,20,NONE")]
        處方數量,
        [Description("實際庫存,VARCHAR,20,NONE")]
        實際庫存,
        [Description("起始時間,DATETIME,50,None")]
        起始時間,
        [Description("結束時間,DATETIME,50,None")]
        結束時間,
        [Description("管制級別,VARCHAR,10,NONE")]
        管制級別,
    }
    public class medShiftConfigClass
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("CODE")]
        public string 藥品碼 { get; set; }
        [JsonPropertyName("IS_SHIFT")]
        public string 是否交班 { get; set; }
    }


    public class medShiftListClass
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("CODE")]
        public string 藥碼 { get; set; }
        [JsonPropertyName("NAME")]
        public string 藥名 { get; set; }
        [JsonPropertyName("TOTAL_VALUE")]
        public string 現有庫存 { get; set; }
        [JsonPropertyName("PRESC_COST")]
        public string 處方支出 { get; set; }
        [JsonPropertyName("PRESC_NUM")]
        public string 處方數量 { get; set; }
        [JsonPropertyName("CURRENT__VALUE")]
        public string 實際庫存 { get; set; }
        [JsonPropertyName("ST_TIME")]
        public string 起始時間 { get; set; }
        [JsonPropertyName("END_TIME")]
        public string 結束時間 { get; set; }
        [JsonPropertyName("DRUGKIND")]
        public string 管制級別 { get; set; }
    }
}
