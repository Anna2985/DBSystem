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
    [EnumDescription("stockRecord")]
    public enum enum_stockRecord
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("庫別,VARCHAR,50,None")]
        庫別,
        [Description("庫名,VARCHAR,50,None")]
        庫名,
        [Description("加入時間,DATETIME,50,None")]
        加入時間,
    }

    [EnumDescription("stockRecord_content")]
    public enum enum_stockRecord_content
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("Master_GUID,VARCHAR,50,INDEX")]
        Master_GUID,
        [Description("藥碼,VARCHAR,15,INDEX")]
        藥碼,
        [Description("藥名,VARCHAR,300,None")]
        藥名,
        [Description("庫存,VARCHAR,15,None")]
        庫存,
        [Description("加入時間,DATETIME,50,INDEX")]
        加入時間,

    }
    public class stockRecord
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("add_time")]
        public string 加入時間 { get; set; }
        [JsonPropertyName("store_type")]
        public string 庫別 { get; set; }
        [JsonPropertyName("store_name")]
        public string 庫名 { get; set; }
        [JsonPropertyName("contents")]
        public List<stockRecord_content> Contents { get => contents; set => contents = value; }
        private List<stockRecord_content> contents = new List<stockRecord_content>();

        public stockRecord_content this[string code]
        {
            get
            {
                return contents.FirstOrDefault(temp => temp.藥碼 == code);
            }
        }

        static public List<stockRecord> POST_get_all_record(string API_Server)
        {
            return POST_get_all_record(API_Server, "ds01", "藥庫");
        }
        static public List<stockRecord> POST_get_all_record(string API_Server, string ServerName, string ServerType)
        {
            string url = $"{API_Server}/api/stockRecord/get_all_record";
            returnData returnData = new returnData();
            returnData.ServerName = ServerName;
            returnData.ServerType = ServerType;
            string json_in = returnData.JsonSerializationt();
            string json_out = Basic.Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();
            if (returnData == null) return null;
            if (returnData.Code != 200)
            {
                Console.WriteLine($"-----------------------------------------------");
                Console.WriteLine($"url : {url}");
                Console.WriteLine($"Result : {returnData.Result}");
                Console.WriteLine($"-----------------------------------------------");
                return null;
            }
            List<stockRecord> stockRecords = returnData.Data.ObjToClass<List<stockRecord>>();
            if (stockRecords == null) return null;
            if (stockRecords.Count == 0) return null;
            return stockRecords;
        }
        static public List<stockRecord> POST_get_all_record_simple(string API_Server)
        {
            return POST_get_all_record_simple(API_Server, "ds01", "藥庫");
        }
        static public List<stockRecord> POST_get_all_record_simple(string API_Server, string ServerName, string ServerType)
        {
            string url = $"{API_Server}/api/stockRecord/get_all_record_simple";
            returnData returnData = new returnData();
            returnData.ServerName = ServerName;
            returnData.ServerType = ServerType;
            string json_in = returnData.JsonSerializationt();
            string json_out = Basic.Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();
            if (returnData == null) return null;
            if (returnData.Code != 200)
            {
                Console.WriteLine($"-----------------------------------------------");
                Console.WriteLine($"url : {url}");
                Console.WriteLine($"Result : {returnData.Result}");
                Console.WriteLine($"-----------------------------------------------");
                return null;
            }
            List<stockRecord> stockRecords = returnData.Data.ObjToClass<List<stockRecord>>();
            if (stockRecords == null) return null;
            if (stockRecords.Count == 0) return null;
            return stockRecords;
        }

        static public stockRecord POST_get_record_by_guid(string API_Server, string GUID)
        {
            return POST_get_record_by_guid(API_Server, GUID, "ds01", "藥庫");
        }
        static public stockRecord POST_get_record_by_guid(string API_Server, string GUID, string ServerName, string ServerType)
        {
            string url = $"{API_Server}/api/stockRecord/get_record_by_guid";
            returnData returnData = new returnData();
            returnData.ServerName = ServerName;
            returnData.ServerType = ServerType;
            returnData.ValueAry.Add(GUID);
            string json_in = returnData.JsonSerializationt();
            string json_out = Basic.Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();
            if (returnData == null) return null;
            if (returnData.Code != 200)
            {
                Console.WriteLine($"-----------------------------------------------");
                Console.WriteLine($"url : {url}");
                Console.WriteLine($"Result : {returnData.Result}");
                Console.WriteLine($"-----------------------------------------------");
                return null;
            }
            stockRecord stockRecord = returnData.Data.ObjToClass<stockRecord>();
            if (stockRecord == null) return null;
            return stockRecord;
        }


    }

    public class stockRecord_content
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("Master_GUID")]
        public string Master_GUID { get; set; }
        [JsonPropertyName("code")]
        public string 藥碼 { get; set; }
        [JsonPropertyName("name")]
        public string 藥名 { get; set; }
        [JsonPropertyName("stock_qty")]
        public string 庫存 { get; set; }
        [JsonPropertyName("add_time")]
        public string 加入時間 { get; set; }

    }

}
