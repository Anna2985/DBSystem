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
    [EnumDescription("consumption")]
    public enum enum_consumption
    {
        [Description("藥品碼,VARCHAR,20,INDEX")]
        藥品碼,
        [Description("藥品名稱,VARCHAR,300,NONE")]
        藥品名稱,
        [Description("交易量,VARCHAR,20,NONE")]
        交易量,
        [Description("結存量,VARCHAR,20,NONE")]
        結存量,
        [Description("庫存量,VARCHAR,20,NONE")]
        庫存量,
    }

    public class consumptionClass
    {
        [JsonPropertyName("CODE")]
        public string 藥品碼 { get; set; }
        [JsonPropertyName("NAME")]
        public string 藥品名稱 { get; set; }
        [JsonPropertyName("TXN_QTY")]
        public string 交易量 { get; set; }
        [JsonPropertyName("EBQ_QTY")]
        public string 結存量 { get; set; }
        [JsonPropertyName("INV_QTY")]
        public string 庫存量 { get; set; }
    }
}
