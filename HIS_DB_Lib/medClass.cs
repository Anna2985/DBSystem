using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Basic;
using System.Text.Json;
using H_Pannel_lib;
namespace HIS_DB_Lib
{

    public class medClassBasic
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("Master_GUID")]
        public string Master_GUID { get; set; }
        [JsonPropertyName("CODE")]
        public string 藥品碼 { get; set; }
        [JsonPropertyName("SKDIACODE")]
        public string 料號 { get; set; }
        [JsonPropertyName("CHT_NAME")]
        public string 中文名稱 { get; set; }
        [JsonPropertyName("NAME")]
        public string 藥品名稱 { get; set; }
        [JsonPropertyName("DIANAME")]
        public string 藥品學名 { get; set; }
        [JsonPropertyName("GROUP")]
        public string 藥品群組 { get; set; }
        [JsonPropertyName("HI_CODE")]
        public string 健保碼 { get; set; }
        [JsonPropertyName("PAKAGE")]
        public string 包裝單位 { get; set; }
        [JsonPropertyName("PAKAGE_VAL")]
        public string 包裝數量 { get; set; }
        [JsonPropertyName("MIN_PAKAGE")]
        public string 最小包裝單位 { get; set; }
        [JsonPropertyName("MIN_PAKAGE_VAL")]
        public string 最小包裝數量 { get; set; }
        [JsonPropertyName("BARCODE1")]
        public string 藥品條碼1 { get; set; }
        [JsonPropertyName("BARCODE2")]
        public string 藥品條碼2 { get; set; }
        [JsonPropertyName("IS_WARRING")]
        public string 警訊藥品 { get; set; }
        [JsonPropertyName("IS_H_COST")]
        public string 高價藥品 { get; set; }
        [JsonPropertyName("IS_BIO")]
        public string 生物製劑 { get; set; }
        [JsonPropertyName("PHAR_QTY")]
        public string 藥局庫存 { get; set; }
        [JsonPropertyName("DRUG_QTY")]
        public string 藥庫庫存 { get; set; }
        [JsonPropertyName("DRUGKIND")]
        public string 管制級別 { get; set; }
        [JsonPropertyName("TOLTAL_QTY")]
        public string 總庫存 { get; set; }
        [JsonPropertyName("QTY")]
        public string 庫存 { get; set; }
        [JsonPropertyName("REF_QTY")]
        public string 基準量 { get; set; }
        [JsonPropertyName("SAFE_QTY")]
        public string 安全庫存 { get; set; }
        [JsonPropertyName("BRD")]
        public string 廠牌 { get; set; }
        [JsonPropertyName("LICENSE")]
        public string 藥品許可證號 { get; set; }
        [JsonPropertyName("TYPE")]
        public string 類別 { get; set; }
        [JsonPropertyName("FILE_STATUS")]
        public string 開檔狀態 { get; set; }


        [JsonPropertyName("DeviceBasics")]
        public List<DeviceBasic> DeviceBasics { get => deviceBasics; set => deviceBasics = value; }
        private List<DeviceBasic> deviceBasics = new List<DeviceBasic>();
    }

  
    public class medClass : medClassBasic
    {
        public enum StoreType
        {
            藥庫,
            藥局,
            調劑台,
        }
        public enum SerchType
        {
            模糊,
            前綴,
        }
 
        [JsonIgnore]
        private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
          // PropertyNameCaseInsensitive = true,
        };
        [JsonPropertyName("BARCODE")]
        public List<string> Barcode
        {
            get
            {
                if (藥品條碼2.StringIsEmpty()) return new List<string>(); ;
                List<string> temp = JsonSerializer.Deserialize<List<string>>(藥品條碼2, jsonSerializerOptions);


                List<string> temp_buf = new List<string>();
                for (int i = 0; i < temp.Count; i++)
                {
                    if (!string.IsNullOrWhiteSpace(temp[i]))
                    {
                        temp_buf.Add(temp[i]);
                    }
                }
                return temp_buf;
            }
            set
            {
                藥品條碼2 = JsonSerializer.Serialize(value, jsonSerializerOptions);
            }
        }
        public void Add_BarCode(string barcode)
        {
            List<string> barcodes = 藥品條碼2.JsonDeserializet<List<string>>();
            if (barcodes == null) barcodes = new List<string>();
            barcodes.Add(barcode);
            Barcode = barcodes;
        }
        public void Delete_BarCode(string barcode)
        {
            List<string> barcodes = 藥品條碼2.JsonDeserializet<List<string>>();
            if (barcodes == null) barcodes = new List<string>();
            barcodes.Remove(barcode);
            Barcode = barcodes;
        }

        static public SQLUI.Table init(string API_Server)
        {
            string url = $"{API_Server}/api/MED_page/init";

            returnData returnData = new returnData();
            returnData.ServerName = "Main";
            returnData.ServerType = "網頁";
            string tableName = "medicine_page_cloud";
    
            returnData.TableName = tableName;

            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            SQLUI.Table table = json_out.JsonDeserializet<SQLUI.Table>();
            return table;
        }

        static public SQLUI.Table init(string API_Server, string ServerName, string ServerType , StoreType storeType)
        {
            string url = $"{API_Server}/api/MED_page/init";

            returnData returnData = new returnData();
            returnData.ServerName = ServerName;
            returnData.ServerType = ServerType;
            string tableName = "";
            if (storeType == StoreType.藥庫)
            {
                tableName = "medicine_page_firstclass";
            }
            if (storeType == StoreType.藥局)
            {
                tableName = "medicine_page_phar";
            }
            if (storeType == StoreType.調劑台)
            {
                tableName = "medicine_page";
            }
            returnData.TableName = tableName;

            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            SQLUI.Table table = json_out.JsonDeserializet<SQLUI.Table>();
            return table;
        }
 

        static public List<medClass> get_by_apiserver(string API_Server, string ServerName, string ServerType, StoreType storeType)
        {
            List<medClass> medClasses = new List<medClass>();
            string url = $"{API_Server}/api/MED_page/get_by_apiserver";

            returnData returnData = new returnData();
            returnData.ServerName = ServerName;
            returnData.ServerType = ServerType;
            string tableName = "";
            if (storeType == StoreType.藥庫)
            {
                tableName = "medicine_page_firstclass";
            }
            if (storeType == StoreType.藥局)
            {
                tableName = "medicine_page_phar";
            }
            if (storeType == StoreType.調劑台)
            {
                tableName = "medicine_page";
            }
            returnData.TableName = tableName;


            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();
            if (returnData == null) return null;
            if (returnData.Code != 200) return null;
            medClasses = returnData.Data.ObjToClass<List<medClass>>();
            medClasses.Sort(new ICP_By_Code());
            Console.WriteLine($"{returnData}");
            return medClasses;
        }
        static public List<medClass> get_dps_medClass(string API_Server, string ServerName)
        {
            List<medClass> medClasses = new List<medClass>();
            string url = $"{API_Server}/api/MED_page/get_dps_medClass";

            returnData returnData = new returnData();
            returnData.ServerName = ServerName;
   


            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();
            if (returnData == null) return null;
            if (returnData.Code != 200) return null;
            medClasses = returnData.Data.ObjToClass<List<medClass>>();
            medClasses.Sort(new medClass.ICP_By_Code());
            Console.WriteLine($"{returnData}");
            return medClasses;
        }
        static public List<medClass> get_dps_medClass_by_code(string API_Server, string ServerName, string Code)
        {
            List<string> Codes = new List<string>();
            Codes.Add(Code);
            return get_dps_medClass_by_code(API_Server, ServerName, Codes);
        }
        static public List<medClass> get_dps_medClass_by_code(string API_Server, string ServerName ,List<string> Codes)
        {
            List<medClass> medClasses = new List<medClass>();
            string url = $"{API_Server}/api/MED_page/get_dps_medClass_by_code";

            returnData returnData = new returnData();
            returnData.ServerName = ServerName;

            if (Codes.Count == 0) return new List<medClass>();

            string str = "";

            for (int i = 0; i < Codes.Count; i++)
            {
                str += Codes[i];
                if (i != Codes.Count - 1) str += ",";
            }
            returnData.ValueAry.Add(str);
            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();
            if (returnData == null) return null;
            if (returnData.Code != 200) return null;
            medClasses = returnData.Data.ObjToClass<List<medClass>>();
            medClasses.Sort(new ICP_By_Code());
            Console.WriteLine($"{returnData}");
            return medClasses;
        }



        static public List<medClass> get_ds_pharma_med(string API_Server, string ServerName)
        {
            List<medClass> medClasses = new List<medClass>();
            string url = $"{API_Server}/api/MED_page/get_ds_pharma_med";

            returnData returnData = new returnData();
            returnData.ServerName = ServerName;



            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();
            if (returnData == null) return null;
            if (returnData.Code != 200) return null;
            medClasses = returnData.Data.ObjToClass<List<medClass>>();
            medClasses.Sort(new ICP_By_Code());
            Console.WriteLine($"{returnData}");
            return medClasses;
        }
        static public void update_ds_pharma_by_guid(string API_Server, string ServerName, medClass medClass)
        {
            List<medClass> medClasses = new List<medClass>();
            medClasses.Add(medClass);
            update_ds_pharma_by_guid(API_Server, ServerName, medClasses);
        }
        static public void update_ds_pharma_by_guid(string API_Server, string ServerName, List<medClass> medClasses)
        {
            string url = $"{API_Server}/api/MED_page/update_ds_pharma_by_guid";

            returnData returnData = new returnData();
            returnData.ServerName = ServerName;
            returnData.Data = medClasses;
            if (medClasses.Count == 0) return;

            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
        }

        static public List<medClass> get_ds_drugstore_med(string API_Server, string ServerName)
        {
            List<medClass> medClasses = new List<medClass>();
            string url = $"{API_Server}/api/MED_page/get_ds_drugstore_med";

            returnData returnData = new returnData();
            returnData.ServerName = ServerName;



            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();
            if (returnData == null) return null;
            if (returnData.Code != 200) return null;
            medClasses = returnData.Data.ObjToClass<List<medClass>>();
            medClasses.Sort(new ICP_By_Code());
            Console.WriteLine($"{returnData}");
            return medClasses;
        }
        static public void update_ds_drugstore_by_guid(string API_Server, string ServerName, medClass medClass)
        {
            List<medClass> medClasses = new List<medClass>();
            medClasses.Add(medClass);
            update_ds_drugstore_by_guid(API_Server, ServerName, medClasses);
        }
        static public void update_ds_drugstore_by_guid(string API_Server, string ServerName, List<medClass> medClasses)
        {
            string url = $"{API_Server}/api/MED_page/update_ds_drugstore_by_guid";

            returnData returnData = new returnData();
            returnData.ServerName = ServerName;
            returnData.Data = medClasses;
            if (medClasses.Count == 0) return;

            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
        }

        static public List<medClass> get_med_cloud(string API_Server)
        {
            List<medClass> medClasses = new List<medClass>();
            string url = $"{API_Server}/api/MED_page/get_med_cloud";

            returnData returnData = new returnData();


            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();
            if (returnData == null) return null;
            if (returnData.Code != 200) return null;
            medClasses = returnData.Data.ObjToClass<List<medClass>>();
            Console.WriteLine($"{returnData}");
            medClasses.Sort(new ICP_By_Code());
            return medClasses;
        }
        static public medClass get_med_clouds_by_code(string API_Server, string Code)
        {
            List<string> Codes = new List<string>();
            Codes.Add(Code);
            List<medClass> medClasses = get_med_clouds_by_codes(API_Server, Codes);
            if (medClasses == null) return null;
            if (medClasses.Count == 0) return null;
            return medClasses[0];
        }
        static public List<medClass> get_med_clouds_by_codes(string API_Server, List<string> Codes)
        {
            List<medClass> medClasses = new List<medClass>();
            string url = $"{API_Server}/api/MED_page/get_med_clouds_by_codes";

            returnData returnData = new returnData();

            if (Codes.Count == 0) return new List<medClass>();

            string str = "";

            for (int i = 0; i < Codes.Count; i++)
            {
                str += Codes[i];
                if (i != Codes.Count - 1) str += ",";
            }
            returnData.ValueAry.Add(str);
            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();
            if (returnData == null) return null;
            if (returnData.Code != 200) return null;
            medClasses = returnData.Data.ObjToClass<List<medClass>>();
            medClasses.Sort(new ICP_By_Code());
            Console.WriteLine($"{returnData}");
            return medClasses;
        }
        static public List<medClass> POST_get_med_clouds_by_name(string API_Server, string name)
        {
            return POST_get_med_clouds_by_name(API_Server, name, SerchType.模糊);
        }
        static public List<medClass> POST_get_med_clouds_by_name(string API_Server, string name , SerchType serchType)
        {
            List<medClass> medClasses = new List<medClass>();
            string url = $"{API_Server}/api/MED_page/get_med_clouds_by_name";

            returnData returnData = new returnData();

            returnData.ValueAry.Add(name);
            returnData.Value = serchType.GetEnumName();

            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();
            if (returnData == null) return null;
            if (returnData.Code != 200) return null;
            medClasses = returnData.Data.ObjToClass<List<medClass>>();
            medClasses.Sort(new ICP_By_Code());
            Console.WriteLine($"{returnData}");
            return medClasses;
        }
        static public List<medClass> POST_get_med_clouds_by_dianame(string API_Server, string dianame)
        {
            return POST_get_med_clouds_by_dianame(API_Server, dianame, SerchType.模糊);
        }
        static public List<medClass> POST_get_med_clouds_by_dianame(string API_Server, string name, SerchType serchType)
        {
            List<medClass> medClasses = new List<medClass>();
            string url = $"{API_Server}/api/MED_page/get_med_clouds_by_dianame";

            returnData returnData = new returnData();

            returnData.ValueAry.Add(name);
            returnData.Value = serchType.GetEnumName();

            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();
            if (returnData == null) return null;
            if (returnData.Code != 200) return null;
            medClasses = returnData.Data.ObjToClass<List<medClass>>();
            medClasses.Sort(new ICP_By_Code());
            Console.WriteLine($"{returnData}");
            return medClasses;
        }
        static public List<medClass> POST_get_med_clouds_by_chtname(string API_Server, string dianame)
        {
            return POST_get_med_clouds_by_chtname(API_Server, dianame, SerchType.模糊);
        }
        static public List<medClass> POST_get_med_clouds_by_chtname(string API_Server, string name, SerchType serchType)
        {
            List<medClass> medClasses = new List<medClass>();
            string url = $"{API_Server}/api/MED_page/get_med_clouds_by_chtname";

            returnData returnData = new returnData();

            returnData.ValueAry.Add(name);
            returnData.Value = serchType.GetEnumName();

            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();
            if (returnData == null) return null;
            if (returnData.Code != 200) return null;
            medClasses = returnData.Data.ObjToClass<List<medClass>>();
            medClasses.Sort(new ICP_By_Code());
            Console.WriteLine($"{returnData}");
            return medClasses;
        }
        static public void update_med_clouds_by_guid(string API_Server, medClass medClass)
        {
            List<medClass> medClasses = new List<medClass>();
            medClasses.Add(medClass);
            update_med_clouds_by_guid(API_Server, medClasses);
        }
        static public void update_med_clouds_by_guid(string API_Server, List<medClass> medClasses)
        {
            string url = $"{API_Server}/api/MED_page/update_med_clouds_by_guid";

            returnData returnData = new returnData();
            returnData.Data = medClasses;
            if (medClasses.Count == 0) return;

            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
        }

        
        static public List<medClass> serch_by_BarCode(string API_Server ,string barcode)
        {
            List<medClass> medClasses = new List<medClass>();
            string url = $"{API_Server}/api/MED_page/serch_by_BarCode";

            returnData returnData = new returnData();
            returnData.Value = barcode;

            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();
            if (returnData == null) return null;
            if (returnData.Code != 200) return new List<medClass>();
            medClasses = returnData.Data.ObjToClass<List<medClass>>();
            Console.WriteLine($"{returnData}");
            return medClasses;
        }

    
        static public System.Collections.Generic.Dictionary<string, List<medClass>> CoverToDictionaryByCode(List<medClass> medClasses)
        {
            Dictionary<string, List<medClass>> dictionary = new Dictionary<string, List<medClass>>();

            foreach (var item in medClasses)
            {
                string key = item.藥品碼;

                // 如果字典中已經存在該索引鍵，則將值添加到對應的列表中
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key].Add(item);
                }
                // 否則創建一個新的列表並添加值
                else
                {
                    List<medClass> values = new List<medClass> { item };
                    dictionary[key] = values;
                }
            }

            return dictionary;
        }
        static public List<medClass> SortDictionaryByCode(System.Collections.Generic.Dictionary<string, List<medClass>> dictionary, string code)
        {
            if (dictionary.ContainsKey(code))
            {
                return dictionary[code];
            }
            return new List<medClass>();
        }

        public class ICP_By_Code : IComparer<medClass>
        {
            //實作Compare方法
            //依Speed由小排到大。
            public int Compare(medClass x, medClass y)
            {
                return x.藥品碼.CompareTo(y.藥品碼);

            }
        }
    }
    public static class medClassMethod
    {
        static public System.Collections.Generic.Dictionary<string, List<medClass>> CoverToDictionaryByCode(this List<medClass> medClasses)
        {
            Dictionary<string, List<medClass>> dictionary = new Dictionary<string, List<medClass>>();

            foreach (var item in medClasses)
            {
                string key = item.藥品碼;

                // 如果字典中已經存在該索引鍵，則將值添加到對應的列表中
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key].Add(item);
                }
                // 否則創建一個新的列表並添加值
                else
                {
                    List<medClass> values = new List<medClass> { item };
                    dictionary[key] = values;
                }
            }

            return dictionary;
        }
        static public List<medClass> SortDictionaryByCode(this System.Collections.Generic.Dictionary<string, List<medClass>> dictionary, string code)
        {
            if (dictionary.ContainsKey(code))
            {
                return dictionary[code];
            }
            return new List<medClass>();
        }
    
    }
 
}
