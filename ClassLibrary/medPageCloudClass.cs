﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basic;
using System.Text.Json.Serialization;
using System.ComponentModel;


namespace ClassLibrary
{
    [EnumDescription("medicine_page_cloud")]
    public enum enum_medPageCloud
    {
        GUID,
        藥品碼,
        中文名稱,
        藥品名稱,
        藥品學名,
        健保碼,
        包裝單位,
        包裝數量,
        最小包裝單位,
        最小包裝數量,
        藥品條碼1,
        藥品條碼2
    }

    [EnumDescription("search_medCODE")]
    public enum enum_search_medCODE
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("藥名,VARCHAR,50,NONE")]
        藥名,
        [Description("藥品碼,VARCHAR,50,INDEX")]
        藥品碼,
        [Description("操作時間,VARCHAR,50,INDEX")]
        操作時間

    }

    public class searchMedCODEClass
    {
        /// <summary>
        /// 唯一KEY
        /// </summary>
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 中文名
        /// </summary>
        [JsonPropertyName("name")]
        public string 藥名 { get; set; }
        /// <summary>
        /// 藥品碼
        /// </summary>
        [JsonPropertyName("CODE")]
        public string 藥品碼 { get; set; }
        /// <summary>
        /// 操作時間
        /// </summary>
        [JsonPropertyName("op_time")]
        public string 操作時間 { get; set; }
    }


}
