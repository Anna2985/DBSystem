using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Basic;

namespace HIS_DB_Lib
{
    public enum enum_udphnoph
    {
        GUID,
        通知時間,
        序號,
        病房,
        床號,
        病人姓名,
        病歷號,
        就醫類別,
        就醫序號,
        年齡,
        性別,
        身分,
        發藥醫師,
        加入時間,
    }
    public class udphnoph
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("sysdttm")]
        public string 通知時間 { get; set; }
        [JsonPropertyName("udserno")]
        public string 序號 { get; set; }
        [JsonPropertyName("hnursta")]
        public string 病房 { get; set; }
        [JsonPropertyName("hbed")]
        public string 床號 { get; set; }
        [JsonPropertyName("hnamec")]
        public string 病人姓名 { get; set; }
        [JsonPropertyName("hhisnum")]
        public string 病歷號 { get; set; }
        [JsonPropertyName("hcasetyp")]
        public string 就醫類別 { get; set; }
        [JsonPropertyName("hcaseno")]
        public string 就醫序號 { get; set; }
        [JsonPropertyName("hage")]
        public string 年齡 { get; set; }
        [JsonPropertyName("hsexc")]
        public string 性別 { get; set; }
        [JsonPropertyName("hfindesc")]
        public string 身分 { get; set; }
        [JsonPropertyName("phname")]
        public string 發藥醫師 { get; set; }
        [JsonPropertyName("orders")]
        public List<udphnoph_ordersClass> ordersAry { get; set; }
        public string 加入時間 { get; set; }


    }
    public enum enum_udphnoph_orders
    {
        GUID,
        Master_GUID,
        藥囑序號1,
        藥碼1,
        藥名1,
        使用劑量1,
        單位1,
        途徑1,
        頻次1,
        數量1,
        醫囑1,
        藥囑序號2,
        藥碼2,
        藥名2,
        使用劑量2,
        單位2,
        途徑2,
        頻次2,
        數量2,
        醫囑2,


    }
    public class udphnoph_ordersClass
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("ordseq1")]
        public string 藥囑序號1 { get; set; }
        [JsonPropertyName("drgno1")]
        public string 藥碼1 { get; set; }
        [JsonPropertyName("dgname1")]
        public string 藥名1 { get; set; }
        [JsonPropertyName("dosage1")]
        public string 使用劑量1 { get; set; }
        [JsonPropertyName("dosuni1")]
        public string 單位1 { get; set; }
        [JsonPropertyName("route1")]
        public string 途徑1 { get; set; }
        [JsonPropertyName("freqn1")]
        public string 頻次1 { get; set; }
        [JsonPropertyName("rlqnty1")]
        public string 數量1 { get; set; }
        [JsonPropertyName("words")]
        public string 醫囑1 { get; set; }
        [JsonPropertyName("ordseq2")]
        public string 藥囑序號2 { get; set; }
        [JsonPropertyName("drgno2")]
        public string 藥碼2 { get; set; }
        [JsonPropertyName("dgname2")]
        public string 藥名2 { get; set; }
        [JsonPropertyName("dosage2")]
        public string 使用劑量2 { get; set; }
        [JsonPropertyName("dosuni2")]
        public string 單位2 { get; set; }
        [JsonPropertyName("route2")]
        public string 途徑2 { get; set; }
        [JsonPropertyName("freqn2")]
        public string 頻次2 { get; set; }
        [JsonPropertyName("rlqnty2")]
        public string 數量2 { get; set; }
        [JsonPropertyName("ctdate")]
        public string 加入時間 { get; set; }
    }
}
