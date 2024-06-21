using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Basic;
namespace HIS_DB_Lib
{
    public enum enum_人員資料
    {
        GUID,
        ID,
        姓名,
        性別,
        密碼,
        單位,
        藥師證字號,
        權限等級,
        顏色,
        卡號,
        一維條碼,
        識別圖案,
        指紋辨識,
        指紋ID,
        開門權限
    }
    public class personPageClass
    {
        /// <summary>
        /// 唯一KEY
        /// </summary>
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        [JsonPropertyName("ID")]
        public string ID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [JsonPropertyName("name")]
        public string 姓名 { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        [JsonPropertyName("gender")]
        public string 性別 { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        [JsonPropertyName("password")]
        public string 密碼 { get; set; }
        /// <summary>
        /// 單位
        /// </summary>
        [JsonPropertyName("employer")]
        public string 單位 { get; set; }
        /// <summary>
        /// 藥師證字號
        /// </summary>
        [JsonPropertyName("license")]
        public string 藥師證字號 { get; set; }
        /// <summary>
        /// 權限等級
        /// </summary>
        [JsonPropertyName("level")]
        public string 權限等級 { get; set; }
        /// <summary>
        /// 顏色
        /// </summary>
        [JsonPropertyName("color")]
        public string 顏色 { get; set; }
        /// <summary>
        /// 卡號
        /// </summary>
        [JsonPropertyName("UID")]
        public string 卡號 { get; set; }
        /// <summary>
        /// 一維條碼
        /// </summary>
        [JsonPropertyName("barcode")]
        public string 一維條碼 { get; set; }
        /// <summary>
        /// 識別圖案
        /// </summary>
        [JsonPropertyName("face_image")]
        public string 識別圖案 { get; set; }
        /// <summary>
        /// 指紋辨識
        /// </summary>
        [JsonPropertyName("finger_feature")]
        public string 指紋辨識 { get; set; }
        /// <summary>
        /// 指紋ID
        /// </summary>
        [JsonPropertyName("finger_ID")]
        public string 指紋ID { get; set; }
        /// <summary>
        /// 開門權限
        /// </summary>
        [JsonPropertyName("open_access")]
        public string 開門權限 { get; set; }

        static public List<personPageClass> get_all(string API_Server)
        {
            string url = $"{API_Server}/api/person_page/get_all";
            string str_serverNames = "";
            string str_serverTypes = "";

            returnData returnData = new returnData();
            returnData.ServerName = "";
            returnData.ServerType = "";
            returnData.Data = null;


            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData returnData_out = json_out.JsonDeserializet<returnData>();

            if (returnData_out == null)
            {
                return null;
            }
            if (returnData_out.Data == null)
            {
                return null;
            }
            List<personPageClass> personPageClasses = returnData_out.Data.ObjToClass<List<personPageClass>>();

            Console.WriteLine($"[{returnData_out.Method}]:{returnData_out.Result}");
            return personPageClasses;
        }
        static public personPageClass serch_by_id(string API_Server , string ID)
        {
            string url = $"{API_Server}/api/person_page/serch_by_id";
            string str_serverNames = "";
            string str_serverTypes = "";

            returnData returnData = new returnData();
            returnData.ServerName = "";
            returnData.ServerType = "";
            returnData.Data = null;
            returnData.Value = ID;
            if (ID.StringIsEmpty()) return null;
            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData returnData_out = json_out.JsonDeserializet<returnData>();

            if (returnData_out == null)
            {
                return null;
            }
            if (returnData_out.Data == null)
            {
                return null;
            }
            if (returnData_out.Code != 200) return null;
            personPageClass personPageClass = returnData_out.Data.ObjToClass<personPageClass>();

            Console.WriteLine($"[{returnData_out.Method}]:{returnData_out.Result}");
            return personPageClass;
        }

        static public SQLUI.Table Init(string API_Server)
        {
            string url = $"{API_Server}/api/person_page/init";

            returnData returnData = new returnData();
            returnData.ServerName = "";
            returnData.ServerType = "";

            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            SQLUI.Table table = json_out.JsonDeserializet<SQLUI.Table>();
            return table;
        }
    }
}
