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
    [EnumDescription("medPrice")]
    public enum enum_medPrice
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("藥品碼,VARCHAR,50,INDEX")]
        藥品碼,
        [Description("售價,VARCHAR,15,NONE")]
        售價,
        [Description("成本價,VARCHAR,15,NONE")]
        成本價,
        [Description("最近一次售價,VARCHAR,15,NONE")]
        最近一次售價,
        [Description("最近一次成本價,VARCHAR,15,NONE")]
        最近一次成本價,
        [Description("健保價,VARCHAR,15,NONE")]
        健保價,
        [Description("ATC,VARCHAR,20,NONE")]
        ATC,
        [Description("加入時間,DATETIME,20,NONE")]
        加入時間,
    }
    public class medPriceClass
    {
        /// <summary>
        /// GUID
        /// </summary>
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 藥品碼
        /// </summary>
        [JsonPropertyName("Code")]
        public string 藥品碼 { get; set; }
        /// <summary>
        /// 售價
        /// </summary>
        [JsonPropertyName("SalePrice")]
        public string 售價 { get; set; }
        /// <summary>
        /// 成本價
        /// </summary>
        [JsonPropertyName("CostPrice")]
        public string 成本價 { get; set; }
        /// <summary>
        /// 最近一次售價
        /// </summary>
        [JsonPropertyName("RecentSalePrice")]
        public string 最近一次售價 { get; set; }
        /// <summary>
        /// 最近一次成本價
        /// </summary>
        [JsonPropertyName("RecentCostPrice")]
        public string 最近一次成本價 { get; set; }
        /// <summary>
        /// 健保價
        /// </summary>
        [JsonPropertyName("HealthInsurancePrice")]
        public string 健保價 { get; set; }
        /// <summary>
        /// ATC
        /// </summary>
        [JsonPropertyName("ATC")]
        public string ATC { get; set; }
        /// <summary>
        /// 加入時間
        /// </summary>
        [JsonPropertyName("add_time")]
        public string 加入時間 { get; set; }
    }
}
