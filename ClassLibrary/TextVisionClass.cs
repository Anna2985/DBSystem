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

    [EnumDescription("textVision")]
    public enum enum_textVision
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("圖片,VARCHAR,250,NONE")]
        圖片,
        [Description("操作者ID,VARCHAR,250,INDEX")]
        操作者ID,
        [Description("操作時間,VARCHAR,250,INDEX")]
        操作時間,
        [Description("產品資料,VARCHAR,250,NONE")]
        產品資料,
        [Description("PCMPO,VARCHAR,500,NONE")]
        PCMPO

    }
    public class TextVisionClass
    {
        /// <summary>
        /// 唯一KEY
        /// </summary>
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// base64
        /// </summary>
        [JsonPropertyName("base64")]
        public string 圖片 { get; set; }
        /// <summary>
        /// user_id
        /// </summary>
        [JsonPropertyName("op_id")]
        public string 操作者ID { get; set; }
        /// <summary>
        /// 操作時間
        /// </summary>
        [JsonPropertyName("op_time")]
        public string 操作時間 { get; set; }
        /// <summary>
        /// 產品資料
        /// </summary>
        [JsonPropertyName("pd_data")]
        public string 產品資料 { get; set; }
        /// <summary>
        /// PCMPO
        /// </summary>
        [JsonPropertyName("pcmpo")]
        public string PCMPO { get; set; }
    }
}
