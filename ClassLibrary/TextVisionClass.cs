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
        [Description("Log,LONGTEXT,10,NONE")]
        Log,
        [Description("座標,VARCHAR,500,NONE")]
        座標,
        [Description("keyword,VARCHAR,500,NONE")]
        keyword,
        [Description("UI結果,VARCHAR,1000,NONE")]
        UI結果



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
        /// 操作者姓名
        /// </summary>
        [JsonPropertyName("op_name")]
        public string 操作者姓名 { get; set; }
        /// <summary>
        /// 操作者ID
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
        /// Log
        /// </summary>
        [JsonPropertyName("logs")]
        public object Log { get; set; }
        /// <summary>
        /// 座標
        /// </summary>
        [JsonPropertyName("roi")]
        public object 座標 { get; set; }
        /// <summary>
        /// keyword
        /// </summary>
        [JsonPropertyName("keywords")]
        public object keyword { get; set; }
        /// <summary>
        /// UI結果
        /// </summary>
        [JsonPropertyName("UI_result")]
        public object UI結果 { get; set; }
    }


    public class GuidBase
    {
        public string GUID { get; set; }
        public string base64 { get; set; }
    }


}
