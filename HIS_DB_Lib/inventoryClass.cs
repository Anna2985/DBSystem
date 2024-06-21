using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Basic;
namespace HIS_DB_Lib
{
    public enum enum_盤點定盤_Excel
    {
        藥碼,
        料號,
        藥名,
        單位,
        單價,
        庫存量,
        庫存金額,
        盤點量,
        庫存差異量,
        異動後結存量,
        消耗量,
        結存金額,
        誤差量,
        誤差金額
    }
    public enum enum_盤點覆盤_Excel
    {
        藥碼,
        料號,
        藥名,
        單位,
        單價,
        庫存量,
        庫存金額,
        盤點量,
        庫存差異量,
        異動後結存量,
        消耗量,
        覆盤量,
        結存金額,
        誤差量,
        誤差金額
    }
    public enum enum_盤點單上傳_Excel
    {
        藥碼,
        藥名,
        儲位名稱,
    }
    public enum enum_盤點狀態
    {
        盤點中,
        等待盤點,
        鎖定,
    }
    public enum enum_盤點單號
    {
        GUID,
        盤點名稱,
        盤點單號,
        建表人,
        建表時間,
        盤點開始時間,
        盤點結束時間,
        盤點狀態,
        預設盤點人,
        備註,
    }
    public enum enum_盤點內容
    {
        GUID,
        Master_GUID,
        序號,
        盤點單號,
        藥品碼,
        料號,
        藥品條碼1,
        藥品條碼2,
        儲位名稱,
        理論值,
        新增時間,
        備註,
    }
    public enum enum_盤點明細
    {
        GUID,
        Master_GUID,
        盤點單號,
        藥品碼,
        料號,
        藥品條碼1,
        藥品條碼2,
        盤點量,
        效期,
        批號,
        操作時間,
        操作人,
        狀態,
        備註,
    }
    public class inventoryClass
    {
        public class creat
        {
            [JsonPropertyName("GUID")]
            public string GUID { get; set; }
            [JsonPropertyName("IC_NAME")]
            public string 盤點名稱 { get; set; }
            [JsonPropertyName("IC_SN")]
            public string 盤點單號 { get; set; }
            [JsonPropertyName("CT")]
            public string 建表人 { get; set; }
            [JsonPropertyName("CT_TIME")]
            public string 建表時間 { get; set; }
            [JsonPropertyName("START_TIME")]
            public string 盤點開始時間 { get; set; }
            [JsonPropertyName("END_TIME")]
            public string 盤點結束時間 { get; set; }
            [JsonPropertyName("STATE")]
            public string 盤點狀態 { get; set; }
            [JsonPropertyName("DEFAULT_OP")]
            public string 預設盤點人 { get; set; }
            [JsonPropertyName("NOTE")]
            public string 備註 { get; set; }

            private List<content> _contents = new List<content>();
            public List<content> Contents { get => _contents; set => _contents = value; }

            public void ContentAdd(content content)
            {
                List<content> Contents_buf = new List<content>();
                Contents_buf = (from temp in Contents
                                where temp.藥品碼 == content.藥品碼
                                select temp).ToList();
                if(Contents_buf.Count == 0)
                {
                    Contents.Add(content);
                }
            }
          
        }
        public class content
        {
            [JsonPropertyName("GUID")]
            public string GUID { get; set; }
            [JsonPropertyName("Master_GUID")]
            public string Master_GUID { get; set; }
            [JsonPropertyName("INDEX")]
            public string 序號 { get; set; }
            [JsonPropertyName("IC_SN")]
            public string 盤點單號 { get; set; }
            [JsonPropertyName("CODE")]
            public string 藥品碼 { get; set; }
            [JsonPropertyName("BRD")]
            public string 廠牌 { get; set; }
            [JsonPropertyName("SKDIACODE")]
            public string 料號 { get; set; }
            [JsonPropertyName("CHT_NAME")]
            public string 中文名稱 { get; set; }
            [JsonPropertyName("NAME")]
            public string 藥品名稱 { get; set; }
            [JsonPropertyName("PAKAGE")]
            public string 包裝單位 { get; set; }
            [JsonPropertyName("STORAGE_NAME")]
            public string 儲位名稱 { get; set; }
            [JsonPropertyName("BARCODE1")]
            public string 藥品條碼1 { get; set; }
            [JsonPropertyName("BARCODE2")]
            public string 藥品條碼2 { get; set; }
            [JsonPropertyName("START_QTY")]
            public string 理論值 { get; set; }
            [JsonPropertyName("END_QTY")]
            public string 盤點量 { get; set; }
            [JsonPropertyName("ADD_TIME")]
            public string 新增時間 { get; set; }
            [JsonPropertyName("NOTE")]
            public string 備註 { get; set; }

            private List<sub_content> _sub_content = new List<sub_content>();
            public List<sub_content> Sub_content { get => _sub_content; set => _sub_content = value; }

        
        }
        public class sub_content
        {
            [JsonPropertyName("GUID")]
            public string GUID { get; set; }
            [JsonPropertyName("Master_GUID")]
            public string Master_GUID { get; set; }
            [JsonPropertyName("IC_SN")]
            public string 盤點單號 { get; set; }
            [JsonPropertyName("CODE")]
            public string 藥品碼 { get; set; }
            [JsonPropertyName("SKDIACODE")]
            public string 料號 { get; set; }
            [JsonPropertyName("CHT_NAME")]
            public string 中文名稱 { get; set; }
            [JsonPropertyName("NAME")]
            public string 藥品名稱 { get; set; }
            [JsonPropertyName("PAKAGE")]
            public string 包裝單位 { get; set; }
            [JsonPropertyName("BARCODE1")]
            public string 藥品條碼1 { get; set; }
            [JsonPropertyName("BARCODE2")]
            public string 藥品條碼2 { get; set; }
            [JsonPropertyName("END_QTY")]
            public string 盤點量 { get; set; }
            [JsonPropertyName("TOLTAL_QTY")]
            public string 總量 { get; set; }
            [JsonPropertyName("VAL")]
            public string 效期 { get; set; }
            [JsonPropertyName("LOT")]
            public string 批號 { get; set; }
            [JsonPropertyName("OP")]
            public string 操作人 { get; set; }
            [JsonPropertyName("OP_TIME")]
            public string 操作時間 { get; set; }
            [JsonPropertyName("STATE")]
            public string 狀態 { get; set; }
            [JsonPropertyName("NOTE")]
            public string 備註 { get; set; }     
        }

        static public List<inventoryClass.creat> creat_get_by_CT_TIME_ST_END(string API_Server, DateTime start, DateTime end)
        {
            string url = $"{API_Server}/api/inventory/creat_get_by_CT_TIME_ST_END";
            returnData returnData = new returnData();
            returnData.Value = $"{start.ToDateString()},{end.ToDateString()}";
            string json_in = returnData.JsonSerializationt();
            string json_out = Basic.Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();
            if (returnData == null)
            {
                return null;
            }
            if (returnData.Code != 200)
            {
                Console.WriteLine($"-----------------------------------------------");
                Console.WriteLine($"url : {url}");
                Console.WriteLine($"Result : {returnData.Result}");
                Console.WriteLine($"-----------------------------------------------");
                return null;
            }
            List<inventoryClass.creat> creats = returnData.Data.ObjToClass<List<inventoryClass.creat>>();
            if (creats == null)
            {
                return null;
            }
            return creats;
        }
        static public void creat_delete_by_IC_SN(string API_Server, string IC_SN)
        {
            string url = $"{API_Server}/api/inventory/creat_delete_by_IC_SN";
            returnData returnData = new returnData();
            returnData.Value = IC_SN;
            string json_in = returnData.JsonSerializationt();
            string json_out = Basic.Net.WEBApiPostJson(url, json_in);
            returnData = json_out.JsonDeserializet<returnData>();

            if (returnData.Code != 200)
            {
                Console.WriteLine($"-----------------------------------------------");
                Console.WriteLine($"url : {url}");
                Console.WriteLine($"Result : {returnData.Result}");
                Console.WriteLine($"-----------------------------------------------");
            }
        }
        static public List<string> creat_get_default_op_by_IC_SN(string API_Server, string IC_SN)
        {
            string url = $"{API_Server}/api/inventory/creat_get_default_op_by_IC_SN";
            returnData returnData = new returnData();
            returnData.Value = IC_SN;
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
            List<string> list_op = new List<string>();
            creat creat = returnData.Data.ObjToClass<creat>();
            if (creat == null) return list_op;
            string[] temp_ary = creat.預設盤點人.Split(',');
            for (int i = 0; i < temp_ary.Length; i++)
            {
                list_op.Add(temp_ary[i]);
            }
            return list_op;
        }
        static public void creat_update_default_op_by_IC_SN(string API_Server, string IC_SN , List<string> list_op)
        {
            string url = $"{API_Server}/api/inventory/creat_update_default_op_by_IC_SN";
            creat creat = new creat();
            string str = "";
            for (int i = 0; i < list_op.Count; i++)
            {
                str += list_op[i];
                if (i != list_op.Count - 1) str += ",";
            }
            creat.預設盤點人 = str;
            returnData returnData = new returnData();
            returnData.Value = IC_SN;
            returnData.Data = creat;
            string json_in = returnData.JsonSerializationt();
            string json_out = Basic.Net.WEBApiPostJson(url, json_in);
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
        static public creat creat_get_by_IC_SN(string API_Server, string IC_SN)
        {
            string url = $"{API_Server}/api/inventory/creat_get_by_IC_SN";
            returnData returnData = new returnData();
            returnData.Value = IC_SN;
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
            List<creat> creats = returnData.Data.ObjToClass<List<creat>>();
            if (creats == null) return null;
            if (creats.Count == 0) return null;
            return creats[0];
        }
        static public byte[] download_excel_by_IC_SN(string API_Server, string IC_SN)
        {
            string url = $"{API_Server}/api/inventory/download_excel_by_IC_SN";
            returnData returnData = new returnData();
            returnData.Value = IC_SN;
            string json_in = returnData.JsonSerializationt();
            byte[] bytes = Basic.Net.WEBApiPostDownloaFile(url, json_in);
            return bytes;
        }
        
        static public void contents_delete_by_GUID(string API_Server, string GUID)
        {
            List<content> contents = new List<content>();
            content content = new content();
            content.GUID = GUID;
            contents.Add(content);
            contents_delete_by_GUID(API_Server, contents);
        }
        static public void contents_delete_by_GUID(string API_Server, content content)
        {
            List<content> contents = new List<content>();
            contents.Add(content);
            contents_delete_by_GUID(API_Server, contents);
        }
        static public void contents_delete_by_GUID(string API_Server, List<content> contents)
        {
            string url = $"{API_Server}/api/inventory/contents_delete_by_GUID";
            returnData returnData = new returnData();
            returnData.Data = contents;
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

    public enum enum_inv_combinelist
    {
        GUID,
        Master_GUID,
        合併單號,
        合併單名稱,
        建表姓名,
        建表時間,
    }
    public class inv_combinelist
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("Master_GUID")]
        public string Master_GUID { get; set; }
        [JsonPropertyName("ICB_SN")]
        public string 合併單號 { get; set; }
        [JsonPropertyName("ICB_NAME")]
        public string 合併單名稱 { get; set; }
        [JsonPropertyName("CT")]
        public string 建表姓名 { get; set; }
        [JsonPropertyName("CT_TIME")]
        public string 建表時間 { get; set; }
        [JsonPropertyName("ICB_ARY")]
        List<ICB_ARY_Class> ICB_ARY { get; set; }
        public enum enum_ICB_ARY
        {
            GUID,
            Master_GUID,
            合併子單號,
            合併子單名稱,
            合併單類型,
            加入表單姓名,
            加入表單時間,
        }
        public class ICB_ARY_Class
        {
            [JsonPropertyName("GUID")]
            public string GUID { get; set; }
            [JsonPropertyName("Master_GUID")]
            public string 合併子單號 { get; set; }
            [JsonPropertyName("Master_GUID")]
            public string 合併子單名稱 { get; set; }
            [JsonPropertyName("Master_GUID")]
            public string 合併單類型 { get; set; }
            [JsonPropertyName("Master_GUID")]
            public string 加入表單姓名 { get; set; }
            [JsonPropertyName("Master_GUID")]
            public string 加入表單時間 { get; set; }
        }

    }
}
