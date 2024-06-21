using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Basic;
using System.ComponentModel;
namespace HIS_DB_Lib
{
    [EnumDescription("inv_combinelist")]
    public enum enum_合併總單
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("合併單名稱,VARCHAR,200,None")]
        合併單名稱,
        [Description("合併單號,VARCHAR,30,INDEX")]
        合併單號,
        [Description("StockRecord_GUID,VARCHAR,50,None")]
        StockRecord_GUID,
        [Description("StockRecord_ServerName,VARCHAR,30,None")]
        StockRecord_ServerName,
        [Description("StockRecord_ServerType,VARCHAR,30,None")]
        StockRecord_ServerType,
        [Description("建表人,VARCHAR,30,None")]
        建表人,
        [Description("建表時間,DATETIME,50,INDEX")]
        建表時間,
        [Description("消耗量起始時間,DATETIME,50,None")]
        消耗量起始時間,
        [Description("消耗量結束時間,DATETIME,50,None")]
        消耗量結束時間,
        [Description("備註,VARCHAR,200,None")]
        備註,
    }
    [EnumDescription("inv_sub_combinelist")]
    public enum enum_合併單明細
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("Master_GUID,VARCHAR,50,INDEX")]
        Master_GUID,
        [Description("合併單號,VARCHAR,30,INDEX")]
        合併單號,
        [Description("單號,VARCHAR,30,INDEX")]
        單號,
        [Description("類型,VARCHAR,50,None")]
        類型,
        [Description("新增時間,DATETIME,200,None")]
        新增時間,
        [Description("備註,VARCHAR,200,None")]
        備註,
    }
    /// <summary>
    /// 合併總單
    /// </summary>
    public class inv_combinelistClass
    {
        /// <summary>
        /// 唯一KEY
        /// </summary>
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 合併單名稱
        /// </summary>
        [JsonPropertyName("INV_NAME")]
        public string 合併單名稱 { get; set; }
        /// <summary>
        /// 合併單號
        /// </summary>
        [JsonPropertyName("INV_SN")]
        public string 合併單號 { get; set; }
        /// <summary>
        /// 建表人
        /// </summary>
        [JsonPropertyName("CT")]
        public string 建表人 { get; set; }
        /// <summary>
        /// 建表時間
        /// </summary>
        [JsonPropertyName("CT_TIME")]
        public string 建表時間 { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        [JsonPropertyName("NOTE")]
        public string 備註 { get; set; }
        /// <summary>
        /// StockRecord_GUID
        /// </summary>
        [JsonPropertyName("StockRecord_GUID")]
        public string StockRecord_GUID { get; set; }
        /// <summary>
        /// StockRecord_ServerName
        /// </summary>
        [JsonPropertyName("StockRecord_ServerName")]
        public string StockRecord_ServerName { get; set; }
        /// <summary>
        /// StockRecord_ServerType
        /// </summary>
        [JsonPropertyName("StockRecord_ServerType")]
        public string StockRecord_ServerType { get; set; }
        /// <summary>
        /// 消耗量起始時間
        /// </summary>
        [JsonPropertyName("consumption_startTime")]
        public string 消耗量起始時間 { get; set; }
        /// <summary>
        /// 消耗量起始時間
        /// </summary>
        [JsonPropertyName("consumption_endTime")]
        public string 消耗量結束時間 { get; set; }

        /// <summary>
        /// 合併單明細
        /// </summary>
        [JsonPropertyName("records_Ary")]
        public List<inv_records_Class> Records_Ary { get => records_Ary; set => records_Ary = value; }
        private List<inv_records_Class> records_Ary = new List<inv_records_Class>();

        public void AddRecord(inventoryClass.creat creat)
        {
   
            List<inv_records_Class> records_Ary_buf = (from temp in records_Ary
                                                       where temp.單號 == creat.盤點單號
                                                       select temp).ToList();
            if(records_Ary_buf.Count == 0)
            {
                inv_records_Class inv_Records_Class = new inv_records_Class();
                inv_Records_Class.GUID = Guid.NewGuid().ToString();
                inv_Records_Class.名稱 = creat.盤點名稱;
                inv_Records_Class.單號 = creat.盤點單號;
                inv_Records_Class.類型 = "盤點單";
                records_Ary.Add(inv_Records_Class);
            }
        }
        public void DeleteRecord(string SN)
        {
            List<inv_records_Class> records_Ary_buf = (from temp in records_Ary
                                                       where temp.單號 != SN
                                                       select temp).ToList();
            records_Ary = records_Ary_buf;
        }

        static public List<inv_records_Class> get_all_records(string API_Server)
        {
            string url = $"{API_Server}/api/inv_combinelist/get_all_records";
            returnData returnData = new returnData();
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
            List<inv_records_Class> inv_Records_Classes = returnData.Data.ObjToClass<List<inv_records_Class>>();
            if (inv_Records_Classes == null) return null;
            if (inv_Records_Classes.Count == 0) return null;
            return inv_Records_Classes;
        }
        static public inv_combinelistClass get_all_inv(string API_Server, string SN)
        {
            List<inv_combinelistClass> inv_CombinelistClasses = get_all_inv(API_Server);
            inv_CombinelistClasses = (from temp in inv_CombinelistClasses
                                      where temp.合併單號 == SN
                                      select temp).ToList();
            if (inv_CombinelistClasses.Count == 0) return null;
            return inv_CombinelistClasses[0];
        }
        static public List<inv_combinelistClass> get_all_inv(string API_Server, DateTime dateTime_st, DateTime dateTime_end)
        {
            List<inv_combinelistClass> inv_CombinelistClasses = get_all_inv(API_Server);
            inv_CombinelistClasses = (from temp in inv_CombinelistClasses
                                      where (temp.建表時間.StringToDateTime() >= dateTime_st) && temp.建表時間.StringToDateTime() <= dateTime_end
                                      select temp).ToList();
            return inv_CombinelistClasses;
        }
        static public List<inv_combinelistClass> get_all_inv(string API_Server)
        {
            string url = $"{API_Server}/api/inv_combinelist/get_all_inv";
            returnData returnData = new returnData();
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
            List<inv_combinelistClass> inv_CombinelistClasses = returnData.Data.ObjToClass<List<inv_combinelistClass>>();
            if (inv_CombinelistClasses == null) return null;
            if (inv_CombinelistClasses.Count == 0) return null;
            return inv_CombinelistClasses;
        }
        static public inv_combinelistClass inv_creat_update(string API_Server, inv_combinelistClass inv_CombinelistClass)
        {
            string url = $"{API_Server}/api/inv_combinelist/inv_creat_update";
            returnData returnData = new returnData();
            returnData.Data = inv_CombinelistClass;
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
            inv_CombinelistClass = returnData.Data.ObjToClass<inv_combinelistClass>();
            if (inv_CombinelistClass == null) return null;
            return inv_CombinelistClass;
        }
        static public List<inventoryClass.content> get_full_inv_by_SN(string API_Server , string SN)
        {
            string url = $"{API_Server}/api/inv_combinelist/get_full_inv_by_SN";
            returnData returnData = new returnData();
            returnData.Value = SN;
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
            List<inventoryClass.content> contents = returnData.Data.ObjToClass<List<inventoryClass.content>>();
            if (contents == null) return null;
            if (contents.Count == 0) return null;
            return contents;
        }
        static public byte[] get_full_inv_Excel_by_SN(string API_Server, string SN , params string[] remove_col_name)
        {
            string url = $"{API_Server}/api/inv_combinelist/get_full_inv_Excel_by_SN";
            returnData returnData = new returnData();
            returnData.Value = SN;
            if(remove_col_name != null) returnData.ValueAry = remove_col_name.ToList();
            string json_in = returnData.JsonSerializationt();
            byte[] bytes = Basic.Net.WEBApiPostDownloaFile(url, json_in);
            return bytes;
        }
        static public void inv_stockrecord_update_by_GUID(string API_Server, string GUID, string StockRecord_GUID, string StockRecord_ServerName, string StockRecord_ServerType)
        {
            string url = $"{API_Server}/api/inv_combinelist/inv_stockrecord_update_by_GUID";
            returnData returnData = new returnData();
            returnData.ValueAry.Add(GUID);
            returnData.ValueAry.Add(StockRecord_GUID);
            returnData.ValueAry.Add(StockRecord_ServerName);
            returnData.ValueAry.Add(StockRecord_ServerType);

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
        static public void inv_consumption_time_update_by_GUID(string API_Server, string GUID, DateTime dateTime_start , DateTime dateTime_end)
        {
            string url = $"{API_Server}/api/inv_combinelist/inv_consumption_time_update_by_GUID";
            returnData returnData = new returnData();
            returnData.ValueAry.Add(GUID);
            returnData.ValueAry.Add(dateTime_start.ToDateTimeString_6());
            returnData.ValueAry.Add(dateTime_end.ToDateTimeString_6());

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
        static public void inv_delete_by_SN(string API_Server, string SN)
        {
            string url = $"{API_Server}/api/inv_combinelist/inv_delete_by_SN";
            returnData returnData = new returnData();
            returnData.Value = $"{SN}";

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

  
    /// <summary>
    /// 合併單明細
    /// </summary>
    public class inv_records_Class
    {
        /// <summary>
        /// 唯一KEY
        /// </summary>
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 單號
        /// </summary>
        [JsonPropertyName("SN")]
        public string 單號 { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        [JsonPropertyName("NAME")]
        public string 名稱 { get; set; }
        /// <summary>
        /// 類型
        /// </summary>
        [JsonPropertyName("TYPE")]
        public string 類型 { get; set; }
    }
}
