using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Basic;
using System.Text.Json.Serialization;

namespace ClassLibrary
{

    [EnumDescription("PCMPO")]
    public enum enum_textVision
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("操作者姓名,VARCHAR,250,INDEX")]
        操作者姓名,
        [Description("操作者ID,VARCHAR,250,INDEX")]
        操作者ID,
        [Description("圖片,LONGTEXT,10,NONE")]
        圖片,
        [Description("操作時間,VARCHAR,250,INDEX")]
        操作時間,
        [Description("測試結果,VARCHAR,5000,NONE")]
        測試結果,
        [Description("Log,VARCHAR,1000,NONE")]
        Log,
        [Description("PD座標,VARCHAR,500,NONE")]
        PD座標,
        [Description("PR座標,VARCHAR,500,NONE")]
        PR座標,
        [Description("Keyword,VARCHAR,1000,NONE")]
        keyword,



    }
    /// <summary>
    /// TextVision 資料
    /// </summary>
    public class textVisionClass
    {
        /// <summary>
        /// 唯一KEY
        /// </summary>
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// user_id
        /// </summary>
        [JsonPropertyName("op_name")]
        public string 操作者姓名 { get; set; }
        /// <summary>
        /// user_id
        /// </summary>
        [JsonPropertyName("op_id")]
        public string 操作者ID { get; set; }
        /// <summary>
        /// base64
        /// </summary>
        [JsonPropertyName("base64")]
        public string 圖片 { get; set; }
        /// <summary>
        /// 操作時間
        /// </summary>
        [JsonPropertyName("op_time")]
        public string 操作時間 { get; set; }
        /// <summary>
        /// 測試時間
        /// </summary>
        [JsonPropertyName("ocr_results")]
        public string 測試結果 { get; set; }
        /// <summary>
        /// Log
        /// </summary>
        [JsonPropertyName("logs")]
        public string Log { get; set; }
        /// <summary>
        /// PD座標
        /// </summary>
        [JsonPropertyName("product_coord")]
        public string PD座標 { get; set; }
        /// <summary>
        /// PR座標
        /// </summary>
        [JsonPropertyName("purReqs_coord")]
        public string PR座標 { get; set; }
        /// <summary>
        /// keyword
        /// </summary>
        [JsonPropertyName("keywords")]
        public string keyword { get; set; }
    }


    public class GuidBase
    {
        public string GUID { get; set; }
        public string base64 { get; set; }
    }


}
