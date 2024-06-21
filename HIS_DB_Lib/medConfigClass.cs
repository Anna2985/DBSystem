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
    [EnumDescription("med_config")]
    public enum enum_藥品設定表
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("藥碼,VARCHAR,50,INDEX")]
        藥碼,
        [Description("效期管理,VARCHAR,15,NONE")]
        效期管理,
        [Description("盲盤,VARCHAR,15,NONE")]
        盲盤,
        [Description("複盤,VARCHAR,15,NONE")]
        複盤,
        [Description("結存報表,VARCHAR,15,NONE")]
        結存報表,
        [Description("雙人覆核,VARCHAR,15,NONE")]
        雙人覆核,
        [Description("麻醉藥品,VARCHAR,15,NONE")]
        麻醉藥品,
        [Description("形狀相似,VARCHAR,15,NONE")]
        形狀相似,
        [Description("發音相似,VARCHAR,15,NONE")]
        發音相似,
        [Description("自定義,VARCHAR,15,NONE")]
        自定義,
    }

    public class medConfigClass
    {
        /// <summary>
        /// 唯一KEY
        /// </summary>
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 藥碼
        /// </summary>
        [JsonPropertyName("CODE")]
        public string 藥碼 { get; set; }
        /// <summary>
        /// 效期管理
        /// </summary>
        [JsonPropertyName("expiry")]
        public string 效期管理 { get; set; }
        /// <summary>
        /// 盲盤
        /// </summary>
        [JsonPropertyName("blind")]
        public string 盲盤 { get; set; }
        /// <summary>
        /// 複盤
        /// </summary>
        [JsonPropertyName("recheck")]
        public string 複盤 { get; set; }
        /// <summary>
        /// 結存報表
        /// </summary>
        [JsonPropertyName("inventoryReport")]
        public string 結存報表 { get; set; }
        /// <summary>
        /// 雙人覆核
        /// </summary>
        [JsonPropertyName("dual_verification")]
        public string 雙人覆核 { get; set; }
        /// <summary>
        /// 麻醉藥品
        /// </summary>
        [JsonPropertyName("isAnesthetic")]
        public string 麻醉藥品 { get; set; }
        /// <summary>
        /// 形狀相似
        /// </summary>
        [JsonPropertyName("isShapeSimilar")]
        public string 形狀相似 { get; set; }
        /// <summary>
        /// 發音相似
        /// </summary>
        [JsonPropertyName("isSoundSimilar")]
        public string 發音相似 { get; set; }
        /// <summary>
        /// 自定義
        /// </summary>
        [JsonPropertyName("customVar")]
        public string 自定義 { get; set; }


        static public SQLUI.Table init(string API_Server)
        {
            string url = $"{API_Server}/api/medconfig/init";

            returnData returnData = new returnData();
            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            List<SQLUI.Table> tables = json_out.JsonDeserializet<List<SQLUI.Table>>();
            SQLUI.Table table = SQLUI.TableMethod.GetTable(tables, new enum_藥品設定表());
            return table;
        }
    }


}
