using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using Basic;
using MySql.Data.MySqlClient;
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
                    占床狀態 = "O"

                };
                medCarInfoClasses.Add(value1);
                medCarInfoClass value2 = new medCarInfoClass
                {
                    住院藥局 = 住院藥局,
                    護理站 = 護理站,
                    床號 = "8",
                    病歷號 = "21702181",
                    住院號 = "31540178",
                    姓名 = "方可炫",
                    占床狀態 = "O"

                };
                medCarInfoClasses.Add(value2);
                medCarInfoClass value3 = new medCarInfoClass
                {
                    住院藥局 = 住院藥局,
                    護理站 = 護理站,
                    床號 = "3",
                    病歷號 = "41168109",
                    住院號 = "31580064",
                    姓名 = "安迪",
                    占床狀態 = "O"

                };
                medCarInfoClasses.Add(value3);
                medCarInfoClass value4 = new medCarInfoClass
                {
                    住院藥局 = 住院藥局,
                    護理站 = 護理站,
                    床號 = "20",
                    病歷號 = "16433275",
                    住院號 = "31490583",
                    姓名 = "湯馬士",
                    占床狀態 = "O"

                };
                medCarInfoClasses.Add(value1);
                medCarInfoClass value5 = new medCarInfoClass
                {
                    住院藥局 = 住院藥局,
                    護理站 = 護理站,
                    床號 = "50",
                    病歷號 = "28870306",
                    住院號 = "31517761",
                    姓名 = "偉杰戰士",
                    占床狀態 = "O"

                };
                medCarInfoClasses.Add(value5);
                //以上請修改
                
                List<ServerSettingClass> serverSettingClasses = ServerSettingClassMethod.WebApiGet($"{API_Server}");
                serverSettingClasses = serverSettingClasses.MyFind("Main", "網頁", "VM端");
                string Server = serverSettingClasses[0].Server;
                uint Port = (uint)serverSettingClasses[0].Port.StringToInt32();

                string url = $"{HttpContext.Request.Scheme}://{Server}:4433/api/med_cart/update";
                List<string> names = new List<string> { "Data" };

                string json = medCarInfoClasses.JsonSerializationt();
                List<string> values = new List<string> { json };

                string result = Basic.Net.WEBApiPost(url, names, values);



                returnData.Code = 200;
                returnData.TimeTaken = $"{myTimerBasic}";
                returnData.Data = medCarInfoClasses;
                returnData.Result = $"取得 {護理站} 的病床資訊共{medCarInfoClasses.Count}筆";
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
        public string get_bed_info([FromBody]returnData returnData)
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
                List<medCpoeClass> medCpoeClasses = new List<medCpoeClass>();
                medCpoeClass value1 = new medCpoeClass
                {
                    床號 = "",
                    姓名 = "",
                    護理站 = 護理站,
                    住院號 = 住院號,
                    病歷號 = "",
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
                medCpoeClasses.Add(value1);
                List<ServerSettingClass> serverSettingClasses = ServerSettingClassMethod.WebApiGet($"{API_Server}");
                serverSettingClasses = serverSettingClasses.MyFind("Main", "網頁", "VM端");
                string Server = serverSettingClasses[0].Server;
                uint Port = (uint)serverSettingClasses[0].Port.StringToInt32();

                string url = $"{HttpContext.Request.Scheme}://{Server}:4433/api/med_cart/update";
                List<string> names = new List<string> { "Data" };

                string json = medCpoeClasses.JsonSerializationt();
                List<string> values = new List<string> { json };

                string result = Basic.Net.WEBApiPost(url, names, values);

                returnData.Code = 200;
                returnData.TimeTaken = $"{myTimerBasic}";
                returnData.Data = medCpoeClasses;
                returnData.Result = $"取得 {護理站} 的病床資訊共{medCpoeClasses.Count}筆";
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
