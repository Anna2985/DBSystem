using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using Basic;
using MySql.Data.MySqlClient;
using System.Net.Http;
using System.Text.Json;
using System.Text;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DBSystem._API_VM住院調劑系統
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class medcarController : ControllerBase
    {
        static private string API_Server = "http://127.0.0.1:4433/api/serversetting";
        static private MySqlSslMode SSLMode = MySqlSslMode.None;
        [HttpPost("get_bed_list_by_cart")]
        public string get_bed_list_by_cart([FromBody] returnData returnData)
        {

            MyTimerBasic myTimerBasic = new MyTimerBasic();
            try
            {
                if (returnData.ValueAry == null)
                {
                    returnData.Code = -200;
                    returnData.Result = $"returnData.ValueAry 無傳入資料";
                    return returnData.JsonSerializationt(true);
                }
                if (returnData.ValueAry.Count != 2)
                {
                    returnData.Code = -200;
                    returnData.Result = $"returnData.ValueAry 內容應為[住院藥局, 護理站]";
                    return returnData.JsonSerializationt(true);
                }
                string 住院藥局 = returnData.ValueAry[0];
                string 護理站 = returnData.ValueAry[1];
                List<medCarInfoClass> medCarInfoClasses = new List<medCarInfoClass>();
                //以下請修改
                medCarInfoClass value1 = new medCarInfoClass
                {
                    住院藥局 = 住院藥局,
                    護理站 = 護理站,
                    床號 = "18",
                    病歷號 = "50487939",
                    住院號 = "31463236",
                    姓名 = "克里斯",
                    占床狀態 = "已佔床"

                };
                medCarInfoClasses.Add(value1);
                medCarInfoClass value2 = new medCarInfoClass
                {
                    住院藥局 = 住院藥局,
                    護理站 = 護理站,
                    床號 = "7",
                    病歷號 = "21702181",
                    住院號 = "31540178",
                    姓名 = "方可炫",
                    占床狀態 = "已佔床"

                };
                medCarInfoClasses.Add(value2);
                medCarInfoClass value3 = new medCarInfoClass
                {
                    住院藥局 = 住院藥局,
                    護理站 = 護理站,
                    床號 = "2",
                    病歷號 = "41168109",
                    住院號 = "31580064",
                    姓名 = "安迪",
                    占床狀態 = "已佔床"

                };
                medCarInfoClasses.Add(value3);
                medCarInfoClass value4 = new medCarInfoClass
                {
                    住院藥局 = 住院藥局,
                    護理站 = 護理站,
                    床號 = "20",
                    病歷號 = "78945",
                    住院號 = "777777",
                    姓名 = "湯馬士",
                    占床狀態 = "已佔床"

                };
                medCarInfoClasses.Add(value1);
                medCarInfoClass value5 = new medCarInfoClass
                {
                    住院藥局 = 住院藥局,
                    護理站 = 護理站,
                    床號 = "50",
                    病歷號 = "",
                    住院號 = "",
                    姓名 = "",
                    占床狀態 = ""

                };
                medCarInfoClasses.Add(value5);
                //以上請修改
                
                //呼叫另一隻SP
                for(int i = 0; i < medCarInfoClasses.Count; i++)
                {
                    if(medCarInfoClasses[i].占床狀態 == "已佔床")
                    {
                        string 病歷號 = medCarInfoClasses[i].病歷號;
                        string 住院號 = medCarInfoClasses[i].住院號;

                        medCarInfoClasses[i].性別 = "";
                        medCarInfoClasses[i].出生日期 = "";
                        medCarInfoClasses[i].科別 = "";
                        medCarInfoClasses[i].財務 = "";
                        medCarInfoClasses[i].入院日期 = "";
                        medCarInfoClasses[i].訪視號碼 = "";
                        medCarInfoClasses[i].診所名稱 = "";
                        medCarInfoClasses[i].醫生姓名 = "";
                        medCarInfoClasses[i].身高 = "";
                        medCarInfoClasses[i].體重 = "";
                        medCarInfoClasses[i].體表面積 = "";
                        medCarInfoClasses[i].國際疾病分類代碼1 = "";
                        medCarInfoClasses[i].疾病說明1 = "";
                        medCarInfoClasses[i].國際疾病分類代碼2 = "";
                        medCarInfoClasses[i].疾病說明2 = "";
                        medCarInfoClasses[i].國際疾病分類代碼3 = "";
                        medCarInfoClasses[i].疾病說明3 = "";
                        medCarInfoClasses[i].國際疾病分類代碼4 = "";
                        medCarInfoClasses[i].疾病說明4 = "";
                        medCarInfoClasses[i].鼻胃管使用狀況 = "";
                        medCarInfoClasses[i].其他管路使用狀況 = "";
                        medCarInfoClasses[i].過敏史 = "";

                        testResult testResult = new testResult
                        {
                            白蛋白 = "",
                            肌酸酐 = "",
                            估算腎小球過濾率 = "",
                            丙氨酸氨基轉移酶 = "",
                            鉀離子 = "",
                            鈣離子 = "",
                            總膽紅素 = "",
                            鈉離子 = "",
                            白血球計數 = "",
                            血紅素 = "",
                            血小板計數 = "",
                            國際標準化比率 = "",
                        };
                        medCarInfoClasses[i].檢驗結果 = testResult;
                    }             
                }
                //以上要改
                List<ServerSettingClass> serverSettingClasses = ServerSettingClassMethod.WebApiGet($"{API_Server}");
                serverSettingClasses = serverSettingClasses.MyFind("Main", "網頁", "VM端");
                string Server = serverSettingClasses[0].Server;
                uint Port = (uint)serverSettingClasses[0].Port.StringToInt32();

                //string url = $"{HttpContext.Request.Scheme}://{Server}:4433/api/med_cart/update";
                string url = $"http://{Server}:4436/api/med_cart/update_bed_list";

                //List<string> names = new List<string> { "Data" };
                //string json = medCarInfoClasses.JsonSerializationt();
                //var medCarInfoList = json.JsonDeserializet<List<object>>();
                //var dataWrapper = new { Data = medCarInfoList };
                //string wrappedJson = dataWrapper.JsonSerializationt(); 
                //List<string> values = new List<string> { wrappedJson };
                //string result = Basic.Net.WEBApiPost(url, names, values);
                DataList<medCarInfoClass> dataList = new DataList<medCarInfoClass>
                {
                    Data = new List<medCarInfoClass>(medCarInfoClasses)
                };
                string jsonData = dataList.JsonSerializationt(true);
                //List<string> names = new List<string> { "json" };
                //List<string> values = new List<string> { jsonData };
                //string result = Basic.Net.WEBApiPost(url, names, values);

                HttpClient httpClient = new HttpClient();
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync(url, content).Result;
                string responseString = response.Content.ReadAsStringAsync().Result;
                returnData result = responseString.JsonDeserializet<returnData>();

                returnData.Code = 200;
                returnData.TimeTaken = $"{myTimerBasic}";
                returnData.Data = result.Data;
                returnData.Result = $"取得 {護理站} 的病床資訊共筆";
                return returnData.JsonSerializationt(true);
            }
            catch (Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = $"Exception:{ex.Message}";
                return returnData.JsonSerializationt(true);
            }
        }
        [HttpPost("get_bed_info")]
        public string get_cpoe_by_caseno([FromBody]returnData returnData)
        {
            MyTimerBasic myTimerBasic = new MyTimerBasic();
            try
            {
                if (returnData.ValueAry == null)
                {
                    returnData.Code = -200;
                    returnData.Result = $"returnData.ValueAry 無傳入資料";
                    return returnData.JsonSerializationt(true);
                }
                if (returnData.ValueAry.Count != 3)
                {
                    returnData.Code = -200;
                    returnData.Result = $"returnData.ValueAry 內容應為[住院藥局, 護理站, 住院號]";
                    return returnData.JsonSerializationt(true);
                }
                string 住院藥局 = returnData.ValueAry[0];
                string 護理站 = returnData.ValueAry[1];
                string 住院號 = returnData.ValueAry[2];
                //更新病床資訊
                List<string> ValueAry = new List<string> { 住院藥局, 護理站, 住院號 };
                string url = $"http://127.0.0.1:4436/api/medcar/get_bed_list_by_cart";
                string jsonData = ValueAry.JsonSerializationt(true);
                HttpClient httpClient = new HttpClient();
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync(url, content).Result;
                //取得目標病人資料
                url = "http://127.0.0.1:4436/api/med_cart/get_bed_list_by_cart";
                content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                response = httpClient.PostAsync(url, content).Result;
                string responseString = response.Content.ReadAsStringAsync().Result;
                returnData result = responseString.JsonDeserializet<returnData>();
                medCarInfoClass medCarInfo = (result.Data).ObjToClass<medCarInfoClass>();
                List<medCarInfoClass> target_patient = new List<medCarInfoClass>(){medCarInfo};


                //從SP取得處方資料
                List<medCpoeClass> prescription = new List<medCpoeClass>(); 
                medCpoeClass value1 = new medCpoeClass
                {
                    住院號 = 住院號,
                    序號 = "",                   
                    狀態 = "",
                    開始日期 = "",
                    開始時間 = "",
                    結束日期 = "",
                    結束時間 = "",
                    藥碼 = "",
                    頻次代碼 = "",
                    頻次屬性 = "",
                    藥品名 = "",
                    途徑 = "",
                    數量 = "",
                    劑量 = "",
                    單位 = "",
                    期限 = "",
                    自動包藥機 = "",
                    化癌分類 = "",
                    自購 = "",
                    血液製劑註記 = "",
                    處方醫師 = "",
                    處方醫師姓名 = "",
                    操作人員 = "",
                    藥局代碼 = "",
                    大瓶點滴 = "",
                    LKFLAG = "",
                    排序 = "",
                    判讀藥師代碼 = "",
                    判讀FLAG = "",
                    勿磨 = "",
                    抗生素等級 = "",
                    重複用藥 = "",
                    配藥天數 = "",
                    交互作用 = "",
                    交互作用等級 = ""
                };
                prescription.Add(value1);
                prescription.Add(value1);
                target_patient[0].處方 = prescription;

                //server
                url = $"http://127.0.0.1:4436/api/med_cart/update_bed_list";

                
                DataList<medCpoeClass> dataList = new DataList<medCpoeClass>
                {
                    Data = new List<medCpoeClass>(prescription)
                };
                jsonData = dataList.JsonSerializationt(true);
                

                content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                response = httpClient.PostAsync(url, content).Result;
                responseString = response.Content.ReadAsStringAsync().Result;
                result = responseString.JsonDeserializet<returnData>();

                returnData.Code = 200;
                returnData.TimeTaken = $"{myTimerBasic}";
                returnData.Data = target_patient[0];
                returnData.Result = $"取得{target_patient[0].姓名}的處方";
                return returnData.JsonSerializationt(true);
            }
            catch(Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = $"Exception:{ex.Message}";
                return returnData.JsonSerializationt(true);
            }
        }

    }
}
