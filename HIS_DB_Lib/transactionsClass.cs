using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Basic;

namespace HIS_DB_Lib
{
    public enum enum_交易記錄查詢動作
    {
        藥袋刷入,
        掃碼領藥,
        手輸領藥,
        批次領藥,
        系統領藥,
        系統加藥,
        系統退藥,
        系統入庫,
        系統出庫,
        系統撥入,
        系統撥出,
        系統調入,
        系統調出,
        掃碼退藥,
        手輸退藥,
        重複領藥,
        自動過帳,
        指紋登入,
        人臉識別登入,
        RFID登入,
        一維碼登入,
        密碼登入,
        登出,
        操作工程模式,
        效期庫存異動,
        撥入作業,
        撥出作業,
        入庫作業,
        出庫作業,
        調入作業,
        調出作業,
        管制抽屜開啟,
        管制抽屜關閉,
        門片未關閉異常,
        關閉門片,
        開啟門片,
        交班對點,
        取消作業,
        盤點調整,
        批次過帳,
        驗收作業,
        驗收入庫,
        自動撥補,
        緊急申領,
        新增效期,
        修正庫存,
        修正批號,
        盤存盈虧,
        None,
    }
    public enum enum_交易記錄查詢資料
    {
        GUID,
        動作,
        診別,
        庫別,
        藥品碼,
        藥品名稱,
        藥袋序號,
        領藥號,
        類別,
        庫存量,
        交易量,
        結存量,
        盤點量,
        操作人,
        領用人,
        藥師證字號,
        病人姓名,
        頻次,
        病房號,
        床號,
        病歷號,
        操作時間,
        領用時間,
        開方時間,
        收支原因,
        備註,
    }
    public enum enum_交易記錄查詢資料_匯出
    {
        動作,
        藥品碼,
        藥品名稱,
        藥袋序號,
        領藥號,
        類別,
        庫存量,
        交易量,
        結存量,
        盤點量,
        操作人,
        藥師證字號,
        病人姓名,
        床號,
        病歷號,
        操作時間,
        開方時間,
        收支原因,
        備註,
    }

    public enum enum_傳送櫃領用紀錄動作
    {
        藥袋刷入,     
        人臉識別登入,
        RFID登入,
        一維碼登入,
        密碼登入,
        登出,
        操作工程模式,       
        門片未關閉異常,
        關閉門片,
        開啟門片,
        交班對點,
        取消作業,
        盤點量更正,
        批次過帳,
        驗收作業,
        驗收入庫,
        自動撥補,
        緊急申領,
        新增效期,
        修正庫存,
        修正批號,
        盤存盈虧,
        None,
    }
 

    public class transactionsClass
    {
        /// <summary>
        /// 唯一KEY
        /// </summary>
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 動作
        /// </summary>
        [JsonPropertyName("ACTION")]
        public string 動作 { get; set; }
        /// <summary>
        /// 診別
        /// </summary>
        [JsonPropertyName("MEDKND")]
        public string 診別 { get; set; }
        /// <summary>
        /// 庫別
        /// </summary>
        [JsonPropertyName("STOREHOUSE")]
        public string 庫別 { get; set; }
        /// <summary>
        /// 藥品碼
        /// </summary>
        [JsonPropertyName("CODE")]
        public string 藥品碼 { get; set; }
        /// <summary>
        /// 藥品名稱
        /// </summary>
        [JsonPropertyName("NAME")]
        public string 藥品名稱 { get; set; }
        /// <summary>
        /// 領藥號
        /// </summary>
        [JsonPropertyName("MED_BAG_NUM")]
        public string 領藥號 { get; set; }
        /// <summary>
        /// 藥袋序號
        /// </summary>
        [JsonPropertyName("MED_BAG_SN")]
        public string 藥袋序號 { get; set; }
        /// <summary>
        /// 類別
        /// </summary>
        [JsonPropertyName("TYPE")]
        public string 類別 { get; set; }
        /// <summary>
        /// 庫存量
        /// </summary>
        [JsonPropertyName("INV_QTY")]
        public string 庫存量 { get; set; }
        /// <summary>
        /// 交易量
        /// </summary>
        [JsonPropertyName("TXN_QTY")]
        public string 交易量 { get; set; }
        /// <summary>
        /// 結存量
        /// </summary>
        [JsonPropertyName("EBQ_QTY")]
        public string 結存量 { get; set; }
        /// <summary>
        /// 盤點量
        /// </summary>
        [JsonPropertyName("PHY_QTY")]
        public string 盤點量 { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [JsonPropertyName("OP")]
        public string 操作人 { get; set; }
        /// <summary>
        /// 領用人
        /// </summary>
        [JsonPropertyName("RECV")]
        public string 領用人 { get; set; }
        /// <summary>
        /// 藥師證字號
        /// </summary>
        [JsonPropertyName("LICENSE")]
        public string 藥師證字號 { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        [JsonPropertyName("PAT")]
        public string 病人姓名 { get; set; }
        /// <summary>
        /// 病房號
        /// </summary>
        [JsonPropertyName("WARD_NAME")]
        public string 病房號 { get; set; }
        /// <summary>
        /// 床號
        /// </summary>
        [JsonPropertyName("BED")]
        public string 床號 { get; set; }
        /// <summary>
        /// 頻次
        /// </summary>
        [JsonPropertyName("FREQ")]
        public string 頻次 { get; set; }
        /// <summary>
        /// 病歷號
        /// </summary>
        [JsonPropertyName("MRN")]
        public string 病歷號 { get; set; }
        /// <summary>
        /// 操作時間
        /// </summary>
        [JsonPropertyName("OP_TIME")]
        public string 操作時間 { get; set; }
        /// <summary>
        /// 開方時間
        /// </summary>
        [JsonPropertyName("RX_TIME")]
        public string 開方時間 { get; set; }
        /// <summary>
        /// 領用時間
        /// </summary>
        [JsonPropertyName("RECV_TIME")]
        public string 領用時間 { get; set; }
        /// <summary>
        /// 收支原因
        /// </summary>
        [JsonPropertyName("RSN")]
        public string 收支原因 { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        [JsonPropertyName("NOTE")]
        public string 備註 { get; set; }


        static public byte[] download_cdmis_datas_excel(string API_Server, string 藥碼, DateTime dateTime_st, DateTime dateTime_end, List<string> serverNames, List<string> serverTypes)
        {
            string url = $"{API_Server}/api/transactions/download_cdmis_datas_excel";
            string str_serverNames = "";
            string str_serverTypes = "";
            for (int i = 0; i < serverNames.Count; i++)
            {
                str_serverNames += serverNames[i];
                if (i != serverNames.Count - 1) str_serverNames += ",";
            }
            for (int i = 0; i < serverTypes.Count; i++)
            {
                str_serverTypes += serverTypes[i];
                if (i != serverTypes.Count - 1) str_serverTypes += ",";
            }
            returnData returnData = new returnData();
            returnData.ValueAry.Add(藥碼);
            returnData.ValueAry.Add(dateTime_st.ToDateTimeString());
            returnData.ValueAry.Add(dateTime_end.ToDateTimeString());
            returnData.ValueAry.Add(str_serverNames);
            returnData.ValueAry.Add(str_serverTypes);


            string json_in = returnData.JsonSerializationt();
            byte[] bytes = Basic.Net.WEBApiPostDownloaFile(url, json_in);

            return bytes;
        }
        static public byte[] download_datas_excel(string API_Server, List<transactionsClass> transactionsClasses)
        {
            string url = $"{API_Server}/api/transactions/download_datas_excel";
      
            returnData returnData = new returnData();
            returnData.Data = transactionsClasses;

            string json_in = returnData.JsonSerializationt();
            byte[] bytes = Basic.Net.WEBApiPostDownloaFile(url, json_in);
            return bytes;
        }
        static public List<MyOffice.SheetClass> get_cdmis_datas_sheet(string API_Server, string 藥碼, DateTime dateTime_st, DateTime dateTime_end, List<string> serverNames, List<string> serverTypes)
        {
            string url = $"{API_Server}/api/transactions/get_cdmis_datas_sheet";
            string str_serverNames = "";
            string str_serverTypes = "";
            for (int i = 0; i < serverNames.Count; i++)
            {
                str_serverNames += serverNames[i];
                if (i != serverNames.Count - 1) str_serverNames += ",";
            }
            for (int i = 0; i < serverTypes.Count; i++)
            {
                str_serverTypes += serverTypes[i];
                if (i != serverTypes.Count - 1) str_serverTypes += ",";
            }
            returnData returnData = new returnData();
            returnData.ValueAry.Add(藥碼);
            returnData.ValueAry.Add(dateTime_st.ToDateTimeString());
            returnData.ValueAry.Add(dateTime_end.ToDateTimeString());
            returnData.ValueAry.Add(str_serverNames);
            returnData.ValueAry.Add(str_serverTypes);


            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData returnData_out = json_out.JsonDeserializet<returnData>();
            if(returnData_out == null)
            {
                return null;
            }
            if(returnData_out.Data == null)
            {
                return null;
            }
            Console.WriteLine($"[{returnData_out.Method}]:{returnData_out.Result}");
            List<MyOffice.SheetClass> sheetClasses = returnData_out.Data.ObjToClass<List<MyOffice.SheetClass>>();
            return sheetClasses;
        }
        static public List<transactionsClass> get_datas_by_code(string API_Server, string 藥碼, string serverName, string serverType)
        {
            List<string> serverNames = new List<string>();
            List<string> serverTypes = new List<string>();
            serverNames.Add(serverName);
            serverTypes.Add(serverType);
            return get_datas_by_code(API_Server, 藥碼, serverNames, serverTypes);
        }
        static public List<transactionsClass> get_datas_by_code(string API_Server, string 藥碼, List<string> serverNames, List<string> serverTypes)
        {
            string url = $"{API_Server}/api/transactions/get_datas_by_code";
            string str_serverNames = "";
            string str_serverTypes = "";
            for (int i = 0; i < serverNames.Count; i++)
            {
                str_serverNames += serverNames[i];
                if (i != serverNames.Count - 1) str_serverNames += ",";
            }
            for (int i = 0; i < serverTypes.Count; i++)
            {
                str_serverTypes += serverTypes[i];
                if (i != serverTypes.Count - 1) str_serverTypes += ",";
            }
            returnData returnData = new returnData();
            returnData.ValueAry.Add(藥碼);
            returnData.ValueAry.Add(str_serverNames);
            returnData.ValueAry.Add(str_serverTypes);


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
            Console.WriteLine($"[{returnData_out.Method}]:{returnData_out.Result}");
            List<transactionsClass> transactionsClasses = returnData_out.Data.ObjToClass<List<transactionsClass>>();
            return transactionsClasses;
        }
        static public List<transactionsClass> get_datas_by_name(string API_Server, string 藥名, string serverName, string serverType)
        {
            List<string> serverNames = new List<string>();
            List<string> serverTypes = new List<string>();
            serverNames.Add(serverName);
            serverTypes.Add(serverType);
            return get_datas_by_name(API_Server, 藥名, serverNames, serverTypes);
        }
        static public List<transactionsClass> get_datas_by_name(string API_Server, string 藥名, List<string> serverNames, List<string> serverTypes)
        {
            string url = $"{API_Server}/api/transactions/get_datas_by_name";
            string str_serverNames = "";
            string str_serverTypes = "";
            for (int i = 0; i < serverNames.Count; i++)
            {
                str_serverNames += serverNames[i];
                if (i != serverNames.Count - 1) str_serverNames += ",";
            }
            for (int i = 0; i < serverTypes.Count; i++)
            {
                str_serverTypes += serverTypes[i];
                if (i != serverTypes.Count - 1) str_serverTypes += ",";
            }
            returnData returnData = new returnData();
            returnData.ValueAry.Add(藥名);
            returnData.ValueAry.Add(str_serverNames);
            returnData.ValueAry.Add(str_serverTypes);


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
            Console.WriteLine($"[{returnData_out.Method}]:{returnData_out.Result}");
            List<transactionsClass> transactionsClasses = returnData_out.Data.ObjToClass<List<transactionsClass>>();
            return transactionsClasses;
        }
        static public List<transactionsClass> get_datas_by_mrn(string API_Server, string 病歷號, string serverName, string serverType)
        {
            List<string> serverNames = new List<string>();
            List<string> serverTypes = new List<string>();
            serverNames.Add(serverName);
            serverTypes.Add(serverType);
            return get_datas_by_mrn(API_Server, 病歷號, serverNames, serverTypes);
        }
        static public List<transactionsClass> get_datas_by_mrn(string API_Server, string 病歷號, List<string> serverNames, List<string> serverTypes)
        {
            string url = $"{API_Server}/api/transactions/get_datas_by_mrn";
            string str_serverNames = "";
            string str_serverTypes = "";
            for (int i = 0; i < serverNames.Count; i++)
            {
                str_serverNames += serverNames[i];
                if (i != serverNames.Count - 1) str_serverNames += ",";
            }
            for (int i = 0; i < serverTypes.Count; i++)
            {
                str_serverTypes += serverTypes[i];
                if (i != serverTypes.Count - 1) str_serverTypes += ",";
            }
            returnData returnData = new returnData();
            returnData.ValueAry.Add(病歷號);
            returnData.ValueAry.Add(str_serverNames);
            returnData.ValueAry.Add(str_serverTypes);


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
            Console.WriteLine($"[{returnData_out.Method}]:{returnData_out.Result}");
            List<transactionsClass> transactionsClasses = returnData_out.Data.ObjToClass<List<transactionsClass>>();
            return transactionsClasses;
        }
        static public List<transactionsClass> get_datas_by_pat(string API_Server, string 病人姓名, string serverName, string serverType)
        {
            List<string> serverNames = new List<string>();
            List<string> serverTypes = new List<string>();
            serverNames.Add(serverName);
            serverTypes.Add(serverType);
            return get_datas_by_pat(API_Server, 病人姓名, serverNames, serverTypes);
        }
        static public List<transactionsClass> get_datas_by_pat(string API_Server, string 病人姓名, List<string> serverNames, List<string> serverTypes)
        {
            string url = $"{API_Server}/api/transactions/get_datas_by_pat";
            string str_serverNames = "";
            string str_serverTypes = "";
            for (int i = 0; i < serverNames.Count; i++)
            {
                str_serverNames += serverNames[i];
                if (i != serverNames.Count - 1) str_serverNames += ",";
            }
            for (int i = 0; i < serverTypes.Count; i++)
            {
                str_serverTypes += serverTypes[i];
                if (i != serverTypes.Count - 1) str_serverTypes += ",";
            }
            returnData returnData = new returnData();
            returnData.ValueAry.Add(病人姓名);
            returnData.ValueAry.Add(str_serverNames);
            returnData.ValueAry.Add(str_serverTypes);


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
            Console.WriteLine($"[{returnData_out.Method}]:{returnData_out.Result}");
            List<transactionsClass> transactionsClasses = returnData_out.Data.ObjToClass<List<transactionsClass>>();
            return transactionsClasses;
        }
        static public List<transactionsClass> get_datas_by_med_bag_num(string API_Server, string 領藥號, string serverName, string serverType)
        {
            List<string> serverNames = new List<string>();
            List<string> serverTypes = new List<string>();
            serverNames.Add(serverName);
            serverTypes.Add(serverType);
            return get_datas_by_med_bag_num(API_Server, 領藥號, serverNames, serverTypes);
        }
        static public List<transactionsClass> get_datas_by_med_bag_num(string API_Server, string 領藥號, List<string> serverNames, List<string> serverTypes)
        {
            string url = $"{API_Server}/api/transactions/get_datas_by_med_bag_num";
            string str_serverNames = "";
            string str_serverTypes = "";
            for (int i = 0; i < serverNames.Count; i++)
            {
                str_serverNames += serverNames[i];
                if (i != serverNames.Count - 1) str_serverNames += ",";
            }
            for (int i = 0; i < serverTypes.Count; i++)
            {
                str_serverTypes += serverTypes[i];
                if (i != serverTypes.Count - 1) str_serverTypes += ",";
            }
            returnData returnData = new returnData();
            returnData.ValueAry.Add(領藥號);
            returnData.ValueAry.Add(str_serverNames);
            returnData.ValueAry.Add(str_serverTypes);


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
            Console.WriteLine($"[{returnData_out.Method}]:{returnData_out.Result}");
            List<transactionsClass> transactionsClasses = returnData_out.Data.ObjToClass<List<transactionsClass>>();
            return transactionsClasses;
        }
        static public List<transactionsClass> get_datas_by_op(string API_Server, string 操作人, string serverName, string serverType)
        {
            List<string> serverNames = new List<string>();
            List<string> serverTypes = new List<string>();
            serverNames.Add(serverName);
            serverTypes.Add(serverType);
            return get_datas_by_op(API_Server, 操作人, serverNames, serverTypes);
        }
        static public List<transactionsClass> get_datas_by_op(string API_Server, string 操作人, List<string> serverNames, List<string> serverTypes)
        {
            string url = $"{API_Server}/api/transactions/get_datas_by_op";
            string str_serverNames = "";
            string str_serverTypes = "";
            for (int i = 0; i < serverNames.Count; i++)
            {
                str_serverNames += serverNames[i];
                if (i != serverNames.Count - 1) str_serverNames += ",";
            }
            for (int i = 0; i < serverTypes.Count; i++)
            {
                str_serverTypes += serverTypes[i];
                if (i != serverTypes.Count - 1) str_serverTypes += ",";
            }
            returnData returnData = new returnData();
            returnData.ValueAry.Add(操作人);
            returnData.ValueAry.Add(str_serverNames);
            returnData.ValueAry.Add(str_serverTypes);


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
            Console.WriteLine($"[{returnData_out.Method}]:{returnData_out.Result}");
            List<transactionsClass> transactionsClasses = returnData_out.Data.ObjToClass<List<transactionsClass>>();
            return transactionsClasses;
        }
        static public List<transactionsClass> get_datas_by_op_time_st_end(string API_Server, DateTime dateTime_st, DateTime dateTime_end, string serverName, string serverType)
        {
            List<string> serverNames = new List<string>();
            List<string> serverTypes = new List<string>();
            serverNames.Add(serverName);
            serverTypes.Add(serverType);
            return get_datas_by_op_time_st_end(API_Server, dateTime_st, dateTime_end, serverNames, serverTypes);
        }
        static public List<transactionsClass> get_datas_by_op_time_st_end(string API_Server, DateTime dateTime_st, DateTime dateTime_end, List<string> serverNames, List<string> serverTypes)
        {
            string url = $"{API_Server}/api/transactions/get_datas_by_op_time_st_end";
            string str_serverNames = "";
            string str_serverTypes = "";
            for (int i = 0; i < serverNames.Count; i++)
            {
                str_serverNames += serverNames[i];
                if (i != serverNames.Count - 1) str_serverNames += ",";
            }
            for (int i = 0; i < serverTypes.Count; i++)
            {
                str_serverTypes += serverTypes[i];
                if (i != serverTypes.Count - 1) str_serverTypes += ",";
            }
            returnData returnData = new returnData();
            returnData.ValueAry.Add(dateTime_st.ToDateTimeString_6());
            returnData.ValueAry.Add(dateTime_end.ToDateTimeString_6());
            returnData.ValueAry.Add(str_serverNames);
            returnData.ValueAry.Add(str_serverTypes);


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
            Console.WriteLine($"[{returnData_out.Method}]:{returnData_out.Result}");
            List<transactionsClass> transactionsClasses = returnData_out.Data.ObjToClass<List<transactionsClass>>();
            return transactionsClasses;
        }
        static public List<transactionsClass> get_datas_by_rx_time_st_end(string API_Server, DateTime dateTime_st, DateTime dateTime_end, string serverName, string serverType)
        {
            List<string> serverNames = new List<string>();
            List<string> serverTypes = new List<string>();
            serverNames.Add(serverName);
            serverTypes.Add(serverType);
            return get_datas_by_rx_time_st_end(API_Server, dateTime_st, dateTime_end, serverNames, serverTypes);
        }
        static public List<transactionsClass> get_datas_by_rx_time_st_end(string API_Server, DateTime dateTime_st, DateTime dateTime_end, List<string> serverNames, List<string> serverTypes)
        {
            string url = $"{API_Server}/api/transactions/get_datas_by_rx_time_st_end";
            string str_serverNames = "";
            string str_serverTypes = "";
            for (int i = 0; i < serverNames.Count; i++)
            {
                str_serverNames += serverNames[i];
                if (i != serverNames.Count - 1) str_serverNames += ",";
            }
            for (int i = 0; i < serverTypes.Count; i++)
            {
                str_serverTypes += serverTypes[i];
                if (i != serverTypes.Count - 1) str_serverTypes += ",";
            }
            returnData returnData = new returnData();
            returnData.ValueAry.Add(dateTime_st.ToDateTimeString_6());
            returnData.ValueAry.Add(dateTime_end.ToDateTimeString_6());
            returnData.ValueAry.Add(str_serverNames);
            returnData.ValueAry.Add(str_serverTypes);


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
            Console.WriteLine($"[{returnData_out.Method}]:{returnData_out.Result}");
            List<transactionsClass> transactionsClasses = returnData_out.Data.ObjToClass<List<transactionsClass>>();
            return transactionsClasses;
        }
        static public void add(string API_Server, transactionsClass transactionsClass, string serverName, string serverType)
        {
            string url = $"{API_Server}/api/transactions/add";
            string str_serverNames = "";
            string str_serverTypes = "";

            returnData returnData = new returnData();
            returnData.ServerName = serverName;
            returnData.ServerType = serverType;
            returnData.Data = transactionsClass;


            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData returnData_out = json_out.JsonDeserializet<returnData>();
            if (returnData_out == null)
            {
                return;
            }
            if (returnData_out.Data == null)
            {
                return;
            }
            Console.WriteLine($"[{returnData_out.Method}]:{returnData_out.Result}");

        }
        static public void add(string API_Server, List<transactionsClass> transactionsClasses, string serverName, string serverType)
        {
            string url = $"{API_Server}/api/transactions/add_datas";
            string str_serverNames = "";
            string str_serverTypes = "";

            returnData returnData = new returnData();
            returnData.ServerName = serverName;
            returnData.ServerType = serverType;
            returnData.Data = transactionsClasses;


            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData returnData_out = json_out.JsonDeserializet<returnData>();
            if (returnData_out == null)
            {
                return;
            }
            if (returnData_out.Data == null)
            {
                return;
            }
            Console.WriteLine($"[{returnData_out.Method}]:{returnData_out.Result}");

        }
        static public List<H_Pannel_lib.StockClass> get_stock_by_code(string API_Server, string 藥碼, string serverName, string serverType)
        {
            string url = $"{API_Server}/api/transactions/get_stock_by_code";

            returnData returnData = new returnData();
            returnData.ServerName = serverName;
            returnData.ServerType = serverType;
            returnData.Value = 藥碼;


            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData returnData_result = json_out.JsonDeserializet<returnData>();
            if (returnData_result == null)
            {
                return null;
            }
            if (returnData_result.Data == null)
            {
                return null;
            }
            List<H_Pannel_lib.StockClass> stockClasses = returnData_result.Data.ObjToClass<List<H_Pannel_lib.StockClass>>();

            Console.WriteLine($"{returnData_result}");

            return stockClasses;
        }
        static public System.Collections.Generic.Dictionary<string, List<transactionsClass>> CoverToDictionaryByCode(List<transactionsClass> transactionsClasses)
        {
            Dictionary<string, List<transactionsClass>> dictionary = new Dictionary<string, List<transactionsClass>>();

            foreach (var item in transactionsClasses)
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
                    List<transactionsClass> values = new List<transactionsClass> { item };
                    dictionary[key] = values;
                }
            }

            return dictionary;
        }
        static public List<transactionsClass> SortDictionaryByCode(System.Collections.Generic.Dictionary<string, List<transactionsClass>> dictionary, string code)
        {
            if (dictionary.ContainsKey(code))
            {
                return dictionary[code];
            }
            return new List<transactionsClass>();
        }

        static public SQLUI.Table Init(string API_Server ,string ServerName ,string ServerType)
        {
            string url = $"{API_Server}/api/transactions/init";

            returnData returnData = new returnData();
            returnData.ServerName = ServerName;
            returnData.ServerType = ServerType;

            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            SQLUI.Table table = json_out.JsonDeserializet<SQLUI.Table>();
            return table;
        }



        public class ICP_By_OP_Time : IComparer<object[]>
        {
            //實作Compare方法
            //依Speed由小排到大。
            public int Compare(object[] x, object[] y)
            {
                DateTime datetime1 = x[(int)enum_交易記錄查詢資料.操作時間].ToDateTimeString_6().StringToDateTime();
                DateTime datetime2 = y[(int)enum_交易記錄查詢資料.操作時間].ToDateTimeString_6().StringToDateTime();
                int compare = DateTime.Compare(datetime1, datetime2);
                if (compare != 0) return compare;
                int 結存量1 = x[(int)enum_交易記錄查詢資料.結存量].StringToInt32();
                int 結存量2 = y[(int)enum_交易記錄查詢資料.結存量].StringToInt32();
                if (結存量1 > 結存量2)
                {
                    return -1;
                }
                else if (結存量1 < 結存量2)
                {
                    return 1;
                }
                else if (結存量1 == 結存量2) return 0;
                return 0;

            }
        }
    }
}
