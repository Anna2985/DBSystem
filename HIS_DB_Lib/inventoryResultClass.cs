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
    [EnumDescription("inventoryResult")]
    public enum enum_inventoryResult
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("庫別,VARCHAR,50,None")]
        庫別,
        [Description("庫名,VARCHAR,50,None")]
        庫名,
        [Description("盤點切帳時間,DATETIME,50,None")]
        盤點切帳時間,
        [Description("加入時間,DATETIME,50,None")]
        加入時間,
    }

    [EnumDescription("inventoryResult_content")]
    public enum enum_inventoryResult_content
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("Master_GUID,VARCHAR,50,INDEX")]
        Master_GUID,
        [Description("藥碼,VARCHAR,15,INDEX")]
        藥碼,
        [Description("藥名,VARCHAR,300,None")]
        藥名,
        [Description("盤點日庫存,VARCHAR,15,None")]
        盤點日庫存,
        [Description("盤點量,VARCHAR,15,None")]
        盤點量,
        [Description("異動量,VARCHAR,15,None")]
        異動量,
        [Description("效期及批號,VARCHAR,300,None")]
        效期及批號,
        [Description("加入時間,DATETIME,50,INDEX")]
        加入時間,
    }
    public class inventoryResultClass
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }   
        [JsonPropertyName("store_type")]
        public string 庫別 { get; set; }
        [JsonPropertyName("store_name")]
        public string 庫名 { get; set; }
        [JsonPropertyName("inventory_cut_off_time")]
        public string 盤點切帳時間 { get; set; }
        [JsonPropertyName("add_time")]
        public string 加入時間 { get; set; }
        [JsonPropertyName("contents")]
        public List<inventoryResult_content> Contents { get => contents; set => contents = value; }
        private List<inventoryResult_content> contents = new List<inventoryResult_content>();

        public void AddContent(string 藥碼,string 藥名,int 盤點日庫存,int 盤點量, ValidityClass validityClass)
        {
            List<inventoryResult_content> inventoryResult_Contents = (from temp in contents
                                                                      where temp.藥碼 == 藥碼
                                                                      select temp).ToList();

            inventoryResult_content inventoryResult_Content = new inventoryResult_content();
            if(inventoryResult_Contents.Count > 0)
            {
                inventoryResult_Content = inventoryResult_Contents[0];
            }
            inventoryResult_Content.藥碼 = 藥碼;
            inventoryResult_Content.藥名 = 藥名;
            inventoryResult_Content.盤點日庫存 = 盤點日庫存.ToString();
            inventoryResult_Content.盤點量 = 盤點量.ToString();
            inventoryResult_Content.效期及批號 = validityClass.ToString();
            contents.Add(inventoryResult_Content);

        }

        public inventoryResult_content this[string code]
        {
            get
            {
                return contents.FirstOrDefault(temp => temp.藥碼 == code);
            }
        }
        static public void add_inventoryResult(string API_Server, string ServerName, string ServerType, inventoryResultClass inventoryResultClass)
        {
            string url = $"{API_Server}/api/inventoryResult/add_inventoryResult";
            returnData returnData = new returnData();
            returnData.ServerName = ServerName;
            returnData.ServerType = ServerType;
            returnData.Data = inventoryResultClass;

            string json_in = returnData.JsonSerializationt();
            string json_out = Basic.Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();
            if (returnData == null) return;
            if (returnData.Code != 200)
            {
                Console.WriteLine($"-----------------------------------------------");
                Console.WriteLine($"url : {url}");
                Console.WriteLine($"Result : {returnData.Result}");
                Console.WriteLine($"-----------------------------------------------");
                return;
            }
        }
        static public List<inventoryResultClass> get_inventoryResult_by_st_end_time(string API_Server, string ServerName, string ServerType,DateTime dateTime_st,DateTime dateTime_end)
        {
            string url = $"{API_Server}/api/inventoryResult/get_inventoryResult_by_st_end_time";
            returnData returnData = new returnData();
            returnData.ServerName = ServerName;
            returnData.ServerType = ServerType;
            returnData.ValueAry.Add(dateTime_st.GetStartDate().ToDateTimeString());
            returnData.ValueAry.Add(dateTime_end.GetEndDate().ToDateTimeString());

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

            List<inventoryResultClass> inventoryResultClasses = returnData.Data.ObjToClass<List<inventoryResultClass>>();
            return inventoryResultClasses;

        }
        static public void delete_inventoryResult_by_GUID(string API_Server, string ServerName, string ServerType, string GUID)
        {
            string url = $"{API_Server}/api/inventoryResult/delete_inventoryResult_by_GUID";
            returnData returnData = new returnData();
            returnData.ServerName = ServerName;
            returnData.ServerType = ServerType;
            returnData.ValueAry.Add(GUID);

            string json_in = returnData.JsonSerializationt();
            string json_out = Basic.Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();
            if (returnData == null) return;
            if (returnData.Code != 200)
            {
                Console.WriteLine($"-----------------------------------------------");
                Console.WriteLine($"url : {url}");
                Console.WriteLine($"Result : {returnData.Result}");
                Console.WriteLine($"-----------------------------------------------");
                return;
            }

        }

    }

    public class inventoryResult_content
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
        public string 盤點日庫存 { get; set; }
        [JsonPropertyName("inv_qty")]
        public string 盤點量 { get; set; }
        [JsonPropertyName("change_qty")]
        public string 異動量 { get; set; }
        [JsonPropertyName("exp_batch_no")]
        public string 效期及批號 { get; set; }
        [JsonPropertyName("add_time")]
        public string 加入時間 { get; set; }

    }
}
