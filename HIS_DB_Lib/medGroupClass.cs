using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Basic;

namespace HIS_DB_Lib
{
    public enum enum_藥品群組
    {
        GUID,
        名稱,
        建立時間,        
    }
    public enum enum_藥品群組明細
    {
        GUID,
        Master_GUID,
        藥品碼,
    }
    public class medGroupClass
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("NAME")]
        public string 名稱 { get; set; }
        [JsonPropertyName("CT_TIME")]
        public string 建立時間 { get; set; }
       
        private List<medClass> medClasses = new List<medClass>();
        public List<medClass> MedClasses { get => medClasses; set => medClasses = value; }
    }
  
}
