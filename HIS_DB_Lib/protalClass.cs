using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Basic;

namespace HIS_DB_Lib
{
    public class protal_check_Class
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("PRI_KEY")]
        public string PRI_KEY { get; set; }
        [JsonPropertyName("PHARM_CODE")]
        public string 藥局代碼 { get; set; }
        [JsonPropertyName("MED_BAG_SN")]
        public string 藥袋條碼 { get; set; }
        [JsonPropertyName("BRYPE")]
        public string 藥袋類型 { get; set; }
        [JsonPropertyName("CODE")]
        public string 藥品碼 { get; set; }
        [JsonPropertyName("NAME")]
        public string 藥品名稱 { get; set; }
        [JsonPropertyName("MED_BAG_NUM")]
        public string 領藥號 { get; set; }
        [JsonPropertyName("HCASENO")]
        public string 住院序號 { get; set; }
        [JsonPropertyName("UDORDSEQ")]
        public string 就醫序號 { get; set; }
        [JsonPropertyName("DOS")]
        public string 批序 { get; set; }
        [JsonPropertyName("SD")]
        public string 單次劑量 { get; set; }
        [JsonPropertyName("DUNIT")]
        public string 劑量單位 { get; set; }
        [JsonPropertyName("RROUTE")]
        public string 途徑 { get; set; }
        [JsonPropertyName("FREQ")]
        public string 頻次 { get; set; }
        [JsonPropertyName("CTYPE")]
        public string 費用別 { get; set; }
        [JsonPropertyName("WARD")]
        public string 病房 { get; set; }
        [JsonPropertyName("BEDNO")]
        public string 床號 { get; set; }
        [JsonPropertyName("PATNAME")]
        public string 病人姓名 { get; set; }
        [JsonPropertyName("PATCODE")]
        public string 病歷號 { get; set; }
        [JsonPropertyName("TXN_QTY")]
        public string 交易量 { get; set; }
        [JsonPropertyName("ORD_START")]
        public string 開方日期 { get; set; }
        [JsonPropertyName("ORD_END")]
        public string 結方日期 { get; set; }
        [JsonPropertyName("EXT_TIME")]
        public string 展藥時間 { get; set; }
        [JsonPropertyName("CT_TIME")]
        public string 產出時間 { get; set; }
        [JsonPropertyName("POST_TIME")]
        public string 過帳時間 { get; set; }
        [JsonPropertyName("PHARER_NAME")]
        public string 藥師姓名 { get; set; }
        [JsonPropertyName("PHARER_ID")]
        public string 藥師ID { get; set; }
        [JsonPropertyName("TAKER_NAME")]
        public string 領藥姓名 { get; set; }
        [JsonPropertyName("TAKER_ID")]
        public string 領藥ID { get; set; }
        [JsonPropertyName("STATE")]
        public string 狀態 { get; set; }
        [JsonPropertyName("NOTE")]
        public string 備註 { get; set; }
    }
}
