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
    [EnumDescription("logger")]
    public enum enum_logger
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("網址,VARCHAR,250,NONE")]
        網址,
        [Description("項目,VARCHAR,100,INDEX")]
        項目,
        [Description("操作類型,VARCHAR,50,INDEX")]
        操作類型,
        [Description("操作者ID,VARCHAR,100,NONE")]
        操作者ID,
        [Description("操作者姓名,VARCHAR,100,INDEX")]
        操作者姓名,
        [Description("操作時間,DATETIME,50,INDEX")]
        操作時間,
        [Description("回傳結果,VARCHAR,500,NONE")]
        回傳結果
    }
    [EnumDescription("item")]
    public enum enum_item
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("項目中文,VARCHAR,250,INDEX")]
        項目中文,
        [Description("項目英文,VARCHAR,250,INDEX")]
        項目英文

    }
    /// <summary>
    /// logger 資料
    /// </summary>
    public class loggerClass
    {
        /// <summary>
        /// 唯一KEY
        /// </summary>
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 網址
        /// </summary>
        [JsonPropertyName("url")]
        public string 網址 { get; set; }
        /// <summary>
        /// 項目
        /// </summary>
        [JsonPropertyName("item")]
        public string 項目 { get; set; }
        /// <summary>
        /// 操作類型
        /// </summary>
        [JsonPropertyName("op_type")]
        public string 操作類型 { get; set; }
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
        /// 操作時間
        /// </summary>
        [JsonPropertyName("op_time")]
        public string 操作時間 { get; set; }
        /// <summary>
        /// 回傳結果
        /// </summary>
        [JsonPropertyName("result")]
        public string 回傳結果 { get; set; }
        public class ICP_By_OP_Time : IComparer<loggerClass>
        {
            //實作Compare方法
            //依Speed由小排到大。
            public int Compare(loggerClass x, loggerClass y)
            {
                return x.操作時間.CompareTo(y.操作時間);
            }
        }
    }
    public class itemClass
    {
        /// <summary>
        /// 唯一KEY
        /// </summary>
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 項目中文
        /// </summary>
        [JsonPropertyName("item_ch")]
        public string 項目中文 { get; set; }
        /// <summary>
        /// 項目英文
        /// </summary>
        [JsonPropertyName("item_eng")]
        public string 項目英文 { get; set; }
    }
}
