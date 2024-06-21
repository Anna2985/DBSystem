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

    [EnumDescription("orderT_list")]
    public enum enum_OrderT
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("PRI_KEY,VARCHAR,200,INDEX")]
        PRI_KEY,
        [Description("藥局代碼,VARCHAR,15,NONE")]
        藥局代碼,
        [Description("藥袋條碼,VARCHAR,200,NONE")]
        藥袋條碼,
        [Description("藥袋類型,VARCHAR,15,NONE")]
        藥袋類型,
        [Description("藥品碼,VARCHAR,10,INDEX")]
        藥品碼,
        [Description("藥品名稱,VARCHAR,200,NONE")]
        藥品名稱,
        [Description("領藥號,VARCHAR,15,INDEX")]
        領藥號,
        [Description("批序,VARCHAR,15,NONE")]
        批序,
        [Description("天數,VARCHAR,15,NONE")]
        天數,
        [Description("單次劑量,VARCHAR,10,NONE")]
        單次劑量,
        [Description("劑量單位,VARCHAR,10,NONE")]
        劑量單位,
        [Description("途徑,VARCHAR,10,NONE")]
        途徑,
        [Description("頻次,VARCHAR,10,NONE")]
        頻次,
        [Description("費用別,VARCHAR,10,NONE")]
        費用別,
        [Description("病房,VARCHAR,10,INDEX")]
        病房,
        [Description("床號,VARCHAR,10,NONE")]
        床號,
        [Description("病人姓名,VARCHAR,50,NONE")]
        病人姓名,
        [Description("性別,VARCHAR,20,INDEX")]
        性別,
        [Description("年齡,VARCHAR,20,NONE")]
        年齡,
        [Description("病歷號,VARCHAR,20,NONE")]
        病歷號,
        [Description("科別,VARCHAR,20,NONE")]
        科別,
        [Description("醫師姓名,VARCHAR,50,NONE")]
        醫師姓名,
        [Description("醫師ID,VARCHAR,20,NONE")]
        醫師ID,
        [Description("交易量,VARCHAR,15,NONE")]
        交易量,
        [Description("實際調劑量,VARCHAR,15,NONE")]
        實際調劑量,
        [Description("開方日期,DATETIME,20,INDEX")]
        開方日期,
        [Description("結方日期,DATETIME,20,NONE")]
        結方日期,
        [Description("展藥時間,DATETIME,20,NONE")]
        展藥時間,
        [Description("產出時間,DATETIME,20,INDEX")]
        產出時間,
        [Description("過帳時間,DATETIME,20,INDEX")]
        過帳時間,
        [Description("藥師姓名,VARCHAR,50,INDEX")]
        藥師姓名,
        [Description("藥師ID,VARCHAR,15,INDEX")]
        藥師ID,
        [Description("核對姓名,VARCHAR,50,INDEX")]
        核對姓名,
        [Description("核對ID,VARCHAR,15,INDEX")]
        核對ID,
        [Description("領藥姓名,VARCHAR,50,INDEX")]
        領藥姓名,
        [Description("領藥ID,VARCHAR,15,INDEX")]
        領藥ID,
        [Description("狀態,VARCHAR,15,NONE")]
        狀態,
        [Description("備註,VARCHAR,300,NONE")]
        備註,
    }
    /// <summary>
    /// 中藥醫令資料
    /// </summary>
    public class OrderTClass
    {
        /// <summary>
        /// 唯一KEY
        /// </summary>
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// PRI_KEY
        /// </summary>
        [JsonPropertyName("PRI_KEY")]
        public string PRI_KEY { get; set; }
        /// <summary>
        /// 藥局代碼
        /// </summary>
        [JsonPropertyName("PHARM_CODE")]
        public string 藥局代碼 { get; set; }
        /// <summary>
        /// 藥袋條碼
        /// </summary>
        [JsonPropertyName("MED_BAG_SN")]
        public string 藥袋條碼 { get; set; }
        /// <summary>
        /// 藥袋類型
        /// </summary>
        [JsonPropertyName("BRYPE")]
        public string 藥袋類型 { get; set; }
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
        /// 住院序號
        /// </summary>
        [JsonPropertyName("HCASENO")]
        public string 住院序號 { get; set; }
        /// <summary>
        /// 就醫序號
        /// </summary>
        [JsonPropertyName("UDORDSEQ")]
        public string 就醫序號 { get; set; }
        /// <summary>
        /// 就醫類別
        /// </summary>
        [JsonPropertyName("HCASETYP")]
        public string 就醫類別 { get; set; }
        /// <summary>
        /// 批序
        /// </summary>
        [JsonPropertyName("DOS")]
        public string 批序 { get; set; }
        /// <summary>
        /// 天數
        /// </summary>
        [JsonPropertyName("DAYS")]
        public string 天數 { get; set; }
        /// <summary>
        /// 單次劑量
        /// </summary>
        [JsonPropertyName("SD")]
        public string 單次劑量 { get; set; }
        /// <summary>
        /// 劑量單位
        /// </summary>
        [JsonPropertyName("DUNIT")]
        public string 劑量單位 { get; set; }
        /// <summary>
        /// 途徑
        /// </summary>
        [JsonPropertyName("RROUTE")]
        public string 途徑 { get; set; }
        /// <summary>
        /// 頻次
        /// </summary>
        [JsonPropertyName("FREQ")]
        public string 頻次 { get; set; }
        /// <summary>
        /// 費用別
        /// </summary>
        [JsonPropertyName("CTYPE")]
        public string 費用別 { get; set; }
        /// <summary>
        /// 病房
        /// </summary>
        [JsonPropertyName("WARD")]
        public string 病房 { get; set; }
        /// <summary>
        /// 床號
        /// </summary>
        [JsonPropertyName("BEDNO")]
        public string 床號 { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        [JsonPropertyName("PATNAME")]
        public string 病人姓名 { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        [JsonPropertyName("SEX")]
        public string 性別 { get; set; }
        /// <summary>
        /// 年齡
        /// </summary>
        [JsonPropertyName("AGE")]
        public string 年齡 { get; set; }
        /// <summary>
        /// 病歷號
        /// </summary>
        [JsonPropertyName("PATCODE")]
        public string 病歷號 { get; set; }
        /// <summary>
        /// 科別
        /// </summary>
        [JsonPropertyName("SECTNO")]
        public string 科別 { get; set; }
        /// <summary>
        /// 醫師姓名
        /// </summary>
        [JsonPropertyName("DOCNAME")]
        public string 醫師姓名 { get; set; }
        /// <summary>
        /// 醫師ID
        /// </summary>
        [JsonPropertyName("DOCID")]
        public string 醫師ID { get; set; }
        /// <summary>
        /// 交易量
        /// </summary>
        [JsonPropertyName("TXN_QTY")]
        public string 交易量 { get; set; }
        /// <summary>
        /// 實際調劑量
        /// </summary>
        [JsonPropertyName("DISP_QTY")]
        public string 實際調劑量 { get; set; }
        /// <summary>
        /// 開方日期
        /// </summary>
        [JsonPropertyName("ORD_START")]
        public string 開方日期 { get; set; }
        /// <summary>
        /// 結方日期
        /// </summary>
        [JsonPropertyName("ORD_END")]
        public string 結方日期 { get; set; }
        /// <summary>
        /// 展藥時間
        /// </summary>
        [JsonPropertyName("EXT_TIME")]
        public string 展藥時間 { get; set; }
        /// <summary>
        /// 產出時間
        /// </summary>
        [JsonPropertyName("CT_TIME")]
        public string 產出時間 { get; set; }
        /// <summary>
        /// 過帳時間
        /// </summary>
        [JsonPropertyName("POST_TIME")]
        public string 過帳時間 { get; set; }
        /// <summary>
        /// 藥師姓名
        /// </summary>
        [JsonPropertyName("PHARER_NAME")]
        public string 藥師姓名 { get; set; }
        /// <summary>
        /// 藥師ID
        /// </summary>
        [JsonPropertyName("PHARER_ID")]
        public string 藥師ID { get; set; }
        /// <summary>
        /// 核對姓名
        /// </summary>
        [JsonPropertyName("CHK_NAME")]
        public string 核對姓名 { get; set; }
        /// <summary>
        /// 核對ID
        /// </summary>
        [JsonPropertyName("CHK_ID")]
        public string 核對ID { get; set; }
        /// <summary>
        /// 領藥姓名
        /// </summary>
        [JsonPropertyName("TAKER_NAME")]
        public string 領藥姓名 { get; set; }
        /// <summary>
        /// 領藥ID
        /// </summary>
        [JsonPropertyName("TAKER_ID")]
        public string 領藥ID { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        [JsonPropertyName("STATE")]
        public string 狀態 { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        [JsonPropertyName("NOTE")]
        public string 備註 { get; set; }

        static public SQLUI.Table init(string API_Server)
        {
            string url = $"{API_Server}/api/orderT/init";

            returnData returnData = new returnData();
            string tableName = "";

            returnData.TableName = tableName;

            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            SQLUI.Table table = json_out.JsonDeserializet<SQLUI.Table>();
            return table;
        }
        static public List<OrderTClass> get_by_rx_time_st_end(string API_Server, DateTime dateTime_st, DateTime dateTime_end)
        {
            string url = $"{API_Server}/api/orderT/get_by_rx_time_st_end";

            returnData returnData = new returnData();
            returnData.ValueAry.Add(dateTime_st.ToDateTimeString_6());
            returnData.ValueAry.Add(dateTime_end.ToDateTimeString_6());


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
            Console.WriteLine($"{returnData_out}");
            List<OrderTClass> orderTClasses = returnData_out.Data.ObjToClass<List<OrderTClass>>();
            return orderTClasses;
        }
        static public List<OrderTClass> get_by_post_time_st_end(string API_Server, DateTime dateTime_st, DateTime dateTime_end)
        {
            string url = $"{API_Server}/api/orderT/get_by_post_time_st_end";

            returnData returnData = new returnData();
            returnData.ValueAry.Add(dateTime_st.ToDateTimeString_6());
            returnData.ValueAry.Add(dateTime_end.ToDateTimeString_6());


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
            Console.WriteLine($"{returnData_out}");
            List<OrderTClass> orderTClasses = returnData_out.Data.ObjToClass<List<OrderTClass>>();
            return orderTClasses;
        }
        static public List<OrderTClass> get_by_pri_key(string API_Server, string PRI_KEY)
        {
            string url = $"{API_Server}/api/orderT/get_by_pri_key";

            returnData returnData = new returnData();
            returnData.ValueAry.Add(PRI_KEY);


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
            Console.WriteLine($"{returnData_out}");
            List<OrderTClass> orderTClasses = returnData_out.Data.ObjToClass<List<OrderTClass>>();
            return orderTClasses;
        }
        static public OrderTClass get_by_guid(string API_Server, string value)
        {
            string url = $"{API_Server}/api/orderT/get_by_guid";

            returnData returnData = new returnData();
            returnData.ValueAry.Add(value);


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
            Console.WriteLine($"{returnData_out}");
            OrderTClass orderTClass = returnData_out.Data.ObjToClass<OrderTClass>();
            return orderTClass;
        }
        static public List<OrderTClass> get_by_MED_BAG_NUM(string API_Server, string value)
        {
            string url = $"{API_Server}/api/orderT/get_by_MED_BAG_NUM";

            returnData returnData = new returnData();
            returnData.ValueAry.Add(value);


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
            Console.WriteLine($"{returnData_out}");
            List<OrderTClass> orderTClasses = returnData_out.Data.ObjToClass<List<OrderTClass>>();
            return orderTClasses;
        }
        static public List<OrderTClass> get_by_PATCODE(string API_Server, string value)
        {
            string url = $"{API_Server}/api/orderT/get_by_PATCODE";

            returnData returnData = new returnData();
            returnData.ValueAry.Add(value);


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
            Console.WriteLine($"{returnData_out}");
            List<OrderTClass> orderTClasses = returnData_out.Data.ObjToClass<List<OrderTClass>>();
            return orderTClasses;
        }
        static public List<OrderTClass> get_by_PATNAME(string API_Server, string value)
        {
            string url = $"{API_Server}/api/orderT/get_by_PATNAME";

            returnData returnData = new returnData();
            returnData.ValueAry.Add(value);


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
            Console.WriteLine($"{returnData_out}");
            List<OrderTClass> orderTClasses = returnData_out.Data.ObjToClass<List<OrderTClass>>();
            return orderTClasses;
        }
      
        

        static public void updete_by_guid(string API_Server, OrderTClass orderTClass)
        {
            List<OrderTClass> orderTClasse = new List<OrderTClass>();
            orderTClasse.Add(orderTClass);
            updete_by_guid(API_Server, orderTClasse);
        }
        static public void updete_by_guid(string API_Server, List<OrderTClass> orderTClasses)
        {
            string url = $"{API_Server}/api/orderT/updete_by_guid";

            returnData returnData = new returnData();
            returnData.Data = orderTClasses;


            string json_in = returnData.JsonSerializationt();
            string json_out = Net.WEBApiPostJson(url, json_in);
            returnData returnData_out = json_out.JsonDeserializet<returnData>();
            if (returnData_out == null)
            {
             
            }
            if (returnData_out.Data == null)
            {
                
            }
            Console.WriteLine($"{returnData_out}");
            OrderTClass orderTClass = returnData_out.Data.ObjToClass<OrderTClass>();
      
        }
    }




    static public class OrderTClassMethod
    {
        public enum SortType
        {
            批序,
            開方日期,
            產出時間,
            領藥號
        }

        static public void sort(this List<OrderTClass> orderTClasses, SortType sortType)
        {
            if (orderTClasses == null) return;
            if (sortType == SortType.開方日期)
            {
                orderTClasses.Sort(new ICP_By_rx_time());
            }
            if (sortType == SortType.產出時間)
            {
                orderTClasses.Sort(new ICP_By_op_time());
            }
            if (sortType == SortType.領藥號)
            {
                orderTClasses.Sort(new ICP_By_MED_BAG_NUM());
            }
            if (sortType == SortType.批序)
            {
                orderTClasses.Sort(new ICP_By_DOS());
            }
        }

        public class ICP_By_rx_time : IComparer<OrderTClass>
        {
            //實作Compare方法
            //依Speed由小排到大。
            public int Compare(OrderTClass x, OrderTClass y)
            {
                DateTime datetime1 = x.開方日期.StringToDateTime();
                DateTime datetime2 = y.開方日期.StringToDateTime();
                int compare = DateTime.Compare(datetime1, datetime2);
                return compare;

            }
        }
        public class ICP_By_op_time : IComparer<OrderTClass>
        {
            //實作Compare方法
            //依Speed由小排到大。
            public int Compare(OrderTClass x, OrderTClass y)
            {
                DateTime datetime1 = x.產出時間.StringToDateTime();
                DateTime datetime2 = y.產出時間.StringToDateTime();
                int compare = DateTime.Compare(datetime1, datetime2);
                return compare;

            }
        }
        public class ICP_By_MED_BAG_NUM : IComparer<OrderTClass>
        {
            //實作Compare方法
            //依Speed由小排到大。
            public int Compare(OrderTClass x, OrderTClass y)
            {
                string temp0 = x.領藥號;
                string temp1 = y.領藥號;
                int compare = temp0.CompareTo(temp1);
                return compare;

            }
        }
        public class ICP_By_DOS : IComparer<OrderTClass>
        {
            //實作Compare方法
            //依Speed由小排到大。
            public int Compare(OrderTClass x, OrderTClass y)
            {
                string temp0 = x.批序;
                string temp1 = y.批序;
                int compare = temp0.CompareTo(temp1);
                return compare;

            }
        }
        static public bool GetFreqIsDone(this List<OrderTClass> orderTClasses, string freq)
        {
            List<OrderTClass> orderTClasses_buf = (from temp in orderTClasses
                                                   where temp.頻次 == freq
                                                   where temp.實際調劑量.StringIsDouble() == false
                                                   select temp).ToList();
            return (orderTClasses_buf.Count == 0);
        }
        static public string GetCurrentFreq(this List<OrderTClass> orderTClasses)
        {
            List<string> freqs = (from temp in orderTClasses
                                  select temp.頻次).Distinct().ToList();
            List<OrderTClass> orderTClasses_buf = new List<OrderTClass>();
            for (int i = 0; i < freqs.Count; i++)
            {
                if(orderTClasses.GetFreqIsDone(freqs[i]) == false)
                {
                    orderTClasses_buf = (from temp in orderTClasses
                                         where temp.頻次 == freqs[i]
                                         where temp.實際調劑量.StringIsDouble() == true
                                         select temp).ToList();
                    if (orderTClasses_buf.Count != 0)
                    {
                        return orderTClasses_buf[0].頻次;
                    }
                }
            }
            return null;

        }
        static public System.Collections.Generic.Dictionary<string, List<OrderTClass>> CoverToDictionaryBy_PRI_KEY(this List<OrderTClass> orderTClasses)
        {
            Dictionary<string, List<OrderTClass>> dictionary = new Dictionary<string, List<OrderTClass>>();

            foreach (var item in orderTClasses)
            {
                string key = item.PRI_KEY;

                // 如果字典中已經存在該索引鍵，則將值添加到對應的列表中
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key].Add(item);
                }
                // 否則創建一個新的列表並添加值
                else
                {
                    List<OrderTClass> values = new List<OrderTClass> { item };
                    dictionary[key] = values;
                }
            }

            return dictionary;
        }
        static public List<OrderTClass> SortDictionaryBy_PRI_KEY(this System.Collections.Generic.Dictionary<string, List<OrderTClass>> dictionary, string value)
        {
            if (dictionary.ContainsKey(value))
            {
                return dictionary[value];
            }
            return new List<OrderTClass>();
        }
    }
}


