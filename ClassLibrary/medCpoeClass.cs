using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basic;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    //病床處方
    //Computerized Physician Order Entry
    [EnumDescription("med_cpoe")]
    public enum enum_病床處方
    {
        床號,
        姓名,
        護理站,
        住院號,
        序號,
        病歷號,
        狀態,
        開始日期,
        開始時間,
        結束日期,
        結束時間,
        藥碼,
        頻次代碼,
        頻次屬性,
        藥品名,
        途徑,
        數量,
        劑量,
        單位,
        期限,
        自動包藥機,
        化癌分類,
        自購,
        血液製劑註記,
        處方醫師,
        處方醫師姓名,
        操作人員,
        藥局代碼,
        大瓶點滴,
        LKFLAG,
        排序,
        判讀藥師代碼,
        判讀FLAG,
        勿磨,
        抗生素等級,
        重複用藥,
        配藥天數,
        交互作用,
        交互作用等級
    }
    public class medCpoeClass
    {
        [JsonPropertyName("hbedno")]
        public string 床號 { get; set; }
        [JsonPropertyName("pnamec")]
        public string 姓名 { get; set; }
        [JsonPropertyName("hnursta")]
        public string 護理站 { get; set; }
        [JsonPropertyName("caseno")]
        public string 住院號 { get; set; }
        [JsonPropertyName("ordseq")]
        public string 序號 { get; set; }
        [JsonPropertyName("histno")]
        public string 病歷號 { get; set; }
        [JsonPropertyName("status")]
        public string 狀態 { get; set; }
        [JsonPropertyName("bgndt2")]
        public string 開始日期 { get; set; }
        [JsonPropertyName("bgntm")]
        public string 開始時間 { get; set; }
        [JsonPropertyName("enddt2")]
        public string 結束日期 { get; set; }
        [JsonPropertyName("endtm")]
        public string 結束時間 { get; set; }
        [JsonPropertyName("drgno")]
        public string 藥碼 { get; set; }
        [JsonPropertyName("freqn")]
        public string 頻次代碼 { get; set; }
        [JsonPropertyName("frqatr")]
        public string 頻次屬性 { get; set; }
        [JsonPropertyName("drgnam")]
        public string 藥品名 { get; set; }
        [JsonPropertyName("route")]
        public string 途徑 { get; set; }
        [JsonPropertyName("lqnty")]
        public string 數量 { get; set; }
        [JsonPropertyName("dosage")]
        public string 劑量 { get; set; }
        [JsonPropertyName("dunit")]
        public string 單位 { get; set; }
        [JsonPropertyName("durat")]
        public string 期限 { get; set; }
        [JsonPropertyName("dspmf")]
        public string 自動包藥機 { get; set; }
        [JsonPropertyName("chemo")]
        public string 化癌分類 { get; set; }
        [JsonPropertyName("self")]
        public string 自購 { get; set; }
        [JsonPropertyName("albumi")]
        public string 血液製劑註記 { get; set; }
        [JsonPropertyName("orsign")]
        public string 處方醫師 { get; set; }
        [JsonPropertyName("signam")]
        public string 處方醫師姓名 { get; set; }
        [JsonPropertyName("luser")]
        public string 操作人員 { get; set; }
        [JsonPropertyName("lrxid")]
        public string 藥局代碼 { get; set; }
        [JsonPropertyName("cnt02")]
        public string 大瓶點滴 { get; set; }
        [JsonPropertyName("brfnm")]
        public string LKFLAG { get; set; }
        [JsonPropertyName("rank")]
        public string 排序 { get; set; }
        [JsonPropertyName("pharnum")]
        public string 判讀藥師代碼 { get; set; }
        [JsonPropertyName("flag")]
        public string 判讀FLAG { get; set; }
        [JsonPropertyName("udngt")]
        public string 勿磨 { get; set; }
        [JsonPropertyName("anticg")]
        public string 抗生素等級 { get; set; }
        [JsonPropertyName("samedg")]
        public string 重複用藥 { get; set; }
        [JsonPropertyName("dspdy")]
        public string 配藥天數 { get; set; }
        [JsonPropertyName("ddi")]
        public string 交互作用 { get; set; }
        [JsonPropertyName("ddic")]
        public string 交互作用等級 { get; set; }

    }
}
