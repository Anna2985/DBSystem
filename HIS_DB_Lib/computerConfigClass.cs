using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Basic;

namespace HIS_DB_Lib
{
    public enum enum_computerConfig
    {
        GUID,
        名稱,
        顏色,
        備註,
    }
    public enum enum_sub_computerConfig
    {
        GUID,
        Master_GUID,
        type,
        name,
        value,
    }
    public class computerConfigClass
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("deviceName")]
        public string 名稱 { get; set; }
        [JsonPropertyName("color")]
        public string 顏色 { get; set; }
        [JsonPropertyName("note")]
        public string 備註 { get; set; }
     
        private List<sub_computerConfigClass> parameters = new List<sub_computerConfigClass>();
        [JsonPropertyName("parameter")]
        public List<sub_computerConfigClass> Parameters { get => parameters; set => parameters = value; }

        public string GetValue(string type, string name)
        {
            sub_computerConfigClass peremeter = FindParameter(type, name);
            if (peremeter == null) return "";
            return peremeter.value;
        }
        public sub_computerConfigClass FindParameter(string type, string name)
        {
            List<sub_computerConfigClass> parameters_buf = new List<sub_computerConfigClass>();
            parameters_buf = (from temp in Parameters
                              where temp.type == type
                              where temp.name == name
                              select temp).ToList();
            if (parameters_buf.Count == 0) return null;
            return parameters_buf[0];
        }
        public void SetValue(string type, string name, string value)
        {
            List<sub_computerConfigClass> parameters_buf = new List<sub_computerConfigClass>();
            parameters_buf = (from temp in Parameters
                              where temp.type == type
                              where temp.name == name
                              select temp).ToList();
            if (parameters_buf.Count == 0)
            {
                sub_computerConfigClass peremeter = new sub_computerConfigClass();
                peremeter.type = type;
                peremeter.name = name;
                peremeter.value = value;
                Parameters.Add(peremeter);
            }
            else
            {
                parameters_buf[0].value = value;
            }
        }

        public static computerConfigClass DownloadConfig(string APIServer ,string deviceName)
        {
            returnData returnData = new returnData();
            returnData.Value = deviceName;
            string json_in = returnData.JsonSerializationt();
            string json_result = Net.WEBApiPostJson($"{APIServer}/api/computeConfig/get_parameter", json_in);
            returnData = json_result.JsonDeserializet<returnData>();
            if (returnData == null)
            {
                return null;
            }
            if (returnData.Code != 200)
            {
                return null;
            }
            computerConfigClass computerConfigClass = returnData.Data.ObjToClass<computerConfigClass>();
            return computerConfigClass;
        }
        public static bool UploadConfig(string APIServer, computerConfigClass computerConfigClass)
        {
            returnData returnData = new returnData();
            returnData.Data = computerConfigClass;
            string json_in = returnData.JsonSerializationt();
            string json_result = Net.WEBApiPostJson($"{APIServer}/api/computeConfig/add_device", json_in);
            returnData = json_result.JsonDeserializet<returnData>();
            if (returnData == null)
            {
                return false;
            }
            if (returnData.Code != 200)
            {
                return false;
            }
            return true;
        }
    }
    public class sub_computerConfigClass
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("Master_GUID")]
        public string Master_GUID { get; set; }
        [JsonPropertyName("type")]
        public string type { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("value")]
        public string value { get; set; }
    }

}
