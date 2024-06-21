using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Basic;
namespace HIS_DB_Lib
{
    public enum enum_驗收單匯入
    {
        請購單號,
        藥碼,
        名稱,
        規格,
        單位,
        採購數量,
        已交貨數量,
        未交量,
        供應商名稱,
        供應商電話,
        請購日期,
        採購日期,
        下單日期,
        請購發票年月
    }
    public enum enum_驗收單號
    {
        GUID,
        驗收名稱,
        請購單號,
        驗收單號,
        建表人,
        建表時間,
        驗收開始時間,
        驗收結束時間,
        驗收狀態,
        備註,
    }
    public enum enum_驗收內容
    {
        GUID,
        Master_GUID,
        請購單號,
        驗收單號,
        藥品碼,
        廠牌,
        料號,
        藥品條碼1,
        藥品條碼2,
        應收數量,
        新增時間,
        備註,
    }
    public enum enum_驗收明細
    {
        GUID,
        Master_GUID,
        驗收單號,
        藥品碼,
        料號,
        藥品條碼1,
        藥品條碼2,
        實收數量,
        效期,
        批號,
        操作時間,
        操作人,
        狀態,
        備註
    }
    public class inspectionClass
    {
        public class creat
        {
            [JsonPropertyName("GUID")]
            public string GUID { get; set; }
            [JsonPropertyName("IC_NAME")]
            public string 驗收名稱 { get; set; }
            [JsonPropertyName("PON")]
            public string 請購單號 { get; set; }
            [JsonPropertyName("IC_SN")]
            public string 驗收單號 { get; set; }
            [JsonPropertyName("CT")]
            public string 建表人 { get; set; }
            [JsonPropertyName("CT_TIME")]
            public string 建表時間 { get; set; }
            [JsonPropertyName("START_TIME")]
            public string 驗收開始時間 { get; set; }
            [JsonPropertyName("END_TIME")]
            public string 驗收結束時間 { get; set; }
            [JsonPropertyName("STATE")]
            public string 驗收狀態 { get; set; }
            [JsonPropertyName("NOTE")]
            public string 備註 { get; set; }

            private List<content> _contents = new List<content>();
            public List<content> Contents { get => _contents; set => _contents = value; }

        }
        public class content
        {
            [JsonPropertyName("GUID")]
            public string GUID { get; set; }
            [JsonPropertyName("Master_GUID")]
            public string Master_GUID { get; set; }
            [JsonPropertyName("PON")]
            public string 請購單號 { get; set; }
            [JsonPropertyName("IC_SN")]
            public string 驗收單號 { get; set; }
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
            [JsonPropertyName("BARCODE1")]
            public string 藥品條碼1 { get; set; }
            [JsonPropertyName("BARCODE2")]
            public string 藥品條碼2 { get; set; }
            [JsonPropertyName("START_QTY")]
            public string 應收數量 { get; set; }
            [JsonPropertyName("END_QTY")]
            public string 實收數量 { get; set; }
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
            [JsonPropertyName("ACPT_SN")]
            public string 驗收單號 { get; set; }
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
            public string 實收數量 { get; set; }
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
    }
}
