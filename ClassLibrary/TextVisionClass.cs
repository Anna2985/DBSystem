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
        UI結果,
        [Description("批號,VARCHAR,100,NONE")]
        批號,
        [Description("單號,VARCHAR,100,NONE")]
        單號,
        [Description("藥名,VARCHAR,100,NONE")]
        藥名,
        [Description("中文名,VARCHAR,100,NONE")]
        中文名,
        [Description("數量,VARCHAR,100,NONE")]
        數量,
        [Description("效期,VARCHAR,100,NONE")]
        效期



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
        /// <summary>
        /// 批號
        /// </summary>
        [JsonPropertyName("batch_num")]
        public string 批號 { get; set; }
        /// <summary>
        /// 單號
        /// </summary>
        [JsonPropertyName("po_num")]
        public string 單號 { get; set; }
        /// <summary>
        /// 藥名
        /// </summary>
        [JsonPropertyName("name")]
        public string 藥名 { get; set; }
        /// <summary>
        /// 中文名
        /// </summary>
        [JsonPropertyName("cht_name")]
        public string 中文名 { get; set; }
        /// <summary>
        /// 數量
        /// </summary>
        [JsonPropertyName("qty")]
        public string 數量 { get; set; }
        /// <summary>
        /// 效期
        /// </summary>
        [JsonPropertyName("expirydate")]
        public string 效期 { get; set; }

    }
    /// <summary>
    /// UIresult資料
    /// </summary>
    public class UIresult
    {
        /// <summary>
        /// 唯一KEY
        /// </summary>
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 批號
        /// </summary>
        [JsonPropertyName("batch_num")]
        public string 批號 { get; set; }
        /// <summary>
        /// 操作者ID
        /// </summary>
        [JsonPropertyName("op_id")]
        public string 操作者ID { get; set; }
        /// <summary>
        /// 操作者姓名
        /// </summary>
        [JsonPropertyName("op_name")]
        public string 操作者姓名 { get; set; }
        /// <summary>
        /// 單號
        /// </summary>
        [JsonPropertyName("po_num")]
        public string 單號 { get; set; }
        /// <summary>
        /// 藥名
        /// </summary>
        [JsonPropertyName("name")]
        public string 藥名 { get; set; }
        /// <summary>
        /// 中文名
        /// </summary>
        [JsonPropertyName("cht_name")]
        public string 中文名 { get; set; }
        /// <summary>
        /// 數量
        /// </summary>
        [JsonPropertyName("qty")]
        public string 數量 { get; set; }
        /// <summary>
        /// 效期
        /// </summary>
        [JsonPropertyName("expirydate")]
        public string 效期 { get; set; }

    }


    public class GuidBase
    {
        public string GUID { get; set; }
        public string base64 { get; set; }
    }
    


}
