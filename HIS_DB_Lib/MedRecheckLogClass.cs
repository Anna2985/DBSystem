using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Basic;

namespace HIS_DB_Lib
{
    public enum enum_MedRecheckLog_State
    {
        未排除,
        已排除
    }
    public enum enum_MedRecheckLog
    {
        GUID,
        藥碼,
        藥名,
        系統理論值,
        覆盤理論值,
        校正庫存值,
        批號,
        效期,    
        醫令_GUID,
        交易紀錄_GUID,
        操作人,
        發生時間,
        排除時間,
        狀態,
    }
    public class MedRecheckLogClass
    {
        
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("CODE")]
        public string 藥碼 { get; set; }
        [JsonPropertyName("NAME")]
        public string 藥名 { get; set; }
        [JsonPropertyName("SYS_QTY")]
        public string 系統理論值 { get; set; }
        [JsonPropertyName("RECHECK_QTY")]
        public string 覆盤理論值 { get; set; }
        [JsonPropertyName("UPDATE_QTY")]
        public string 校正庫存值 { get; set; }
        [JsonPropertyName("LOT")]
        public string 批號 { get; set; }
        [JsonPropertyName("VAL")]
        public string 效期 { get; set; }
        [JsonPropertyName("ORDER_GUID")]
        public string 醫令_GUID { get; set; }
        [JsonPropertyName("TRADING_GUID")]
        public string 交易紀錄_GUID { get; set; }
        [JsonPropertyName("CT")]
        public string 操作人 { get; set; }
        [JsonPropertyName("occurrence_time")]
        public string 發生時間 { get; set; }
        [JsonPropertyName("troubleshooting_time")]
        public string 排除時間 { get; set; }
        [JsonPropertyName("state")]
        public string 狀態 { get; set; }
    }
}
