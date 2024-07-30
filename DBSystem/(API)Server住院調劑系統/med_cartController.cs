using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basic;
using MySql.Data.MySqlClient;
using SQLUI;
using ClassLibrary;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DBSystem._API_Server住院調劑系統
{
    [Route("api/[controller]")]
    [ApiController]
    public class med_cartController : ControllerBase
    {
        static private string API_Server = "http://127.0.0.1:4433/api/serversetting";
        static private MySqlSslMode SSLMode = MySqlSslMode.None;
        /// <summary>
        ///初始化dbvm.med_carinfo資料庫
        /// </summary>
        /// <remarks>
        /// 以下為JSON範例
        /// <code>
        ///     {
        ///         "ValueAry":[""]
        ///     }
        /// </code>
        /// </remarks>
        /// <param name="returnData">共用傳遞資料結構</param>
        /// <returns></returns>
        [HttpPost("init_med_carinfo")]
        public string init_med_carinfo([FromBody] returnData returnData)
        {

            MyTimerBasic myTimerBasic = new MyTimerBasic();
            try
            {
                List<ServerSettingClass> serverSettingClasses = ServerSettingClassMethod.WebApiGet($"{API_Server}");
                serverSettingClasses = serverSettingClasses.MyFind("Main", "網頁", "VM端");
                if (serverSettingClasses.Count == 0)
                {
                    returnData.Code = -200;
                    returnData.Result = $"找無Server資料!";
                    return returnData.JsonSerializationt();
                }
                return CheckCreatTable(serverSettingClasses[0]);
            }
            catch (Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = $"Exception : {ex.Message}";
                return returnData.JsonSerializationt(true);
            }
        }
        private string CheckCreatTable(ServerSettingClass serverSettingClass)
        {
            string Server = serverSettingClass.Server;
            string DB = serverSettingClass.DBName;
            string UserName = serverSettingClass.User;
            string Password = serverSettingClass.Password;
            uint Port = (uint)serverSettingClass.Port.StringToInt32();

            Table table = MethodClass.CheckCreatTable(serverSettingClass, new enum_病床資訊());
            return table.JsonSerializationt(true);
        }
        [HttpPost("update_bed_list")]
        public string update_bed_list([FromBody] returnData returnData)
        {
            MyTimerBasic myTimerBasic = new MyTimerBasic();
            returnData.Method = "update_bed_list";
            try
            {
                List<ServerSettingClass> serverSettingClasses = ServerSettingClassMethod.WebApiGet($"{API_Server}");
                serverSettingClasses = serverSettingClasses.MyFind("Main", "網頁", "VM端");
                if (serverSettingClasses.Count == 0)
                {
                    returnData.Code = -200;
                    returnData.Result = $"找無Server資料";
                    return returnData.JsonSerializationt();
                }

                string Server = serverSettingClasses[0].Server;
                string DB = serverSettingClasses[0].DBName;
                string UserName = serverSettingClasses[0].User;
                string Password = serverSettingClasses[0].Password;
                uint Port = (uint)serverSettingClasses[0].Port.StringToInt32();
                Table table = new Table(new enum_病床資訊());
                SQLControl sQLControl_med_carInfo = new SQLControl(Server, DB, table.TableName, UserName, Password, Port, SSLMode);
                List<object[]> list_medCart = sQLControl_med_carInfo.GetAllRows(null);

                List<medCarInfoClass> medCart_sql = list_medCart.SQLToClass<medCarInfoClass, enum_病床資訊>();
                List<medCarInfoClass> medCart_sql_buf = new List<medCarInfoClass>();
                List<medCarInfoClass> medCart_sql_add = new List<medCarInfoClass>();
                List<medCarInfoClass> medCart_sql_replace = new List<medCarInfoClass>();
                List<medCarInfoClass> input_medCarInfo = returnData.Data.ObjToClass<List<medCarInfoClass>>();

                // 示範輸出

                if (input_medCarInfo == null)
                {
                    returnData.Code = -200;
                    returnData.Result = $"傳入Data資料異常";
                    return returnData.JsonSerializationt();
                }
                string 藥局 = input_medCarInfo[0].藥局;
                string 護理站 = input_medCarInfo[0].護理站;
                for (int i = 0; i < input_medCarInfo.Count; i++)
                {                  
                    string 床號 = input_medCarInfo[i].床號;
                    string 病歷號 = input_medCarInfo[i].病歷號;
                    medCart_sql_buf = (from temp in medCart_sql
                                       where temp.藥局 == 藥局
                                       where temp.護理站 == 護理站
                                       where temp.床號 == 床號
                                       select temp).ToList();
                    if (medCart_sql_buf.Count == 0)
                    {
                        string GUID = Guid.NewGuid().ToString();
                        medCarInfoClass medCarInfoClass = input_medCarInfo[i];
                        medCarInfoClass.GUID = GUID;
                        medCart_sql_add.Add(medCarInfoClass);
                    }
                    else
                    {
                        medCarInfoClass sql_medCart = medCart_sql_buf[0];
                        if (sql_medCart.病歷號 != 病歷號)
                        {

                            medCarInfoClass medCarInfoClass = input_medCarInfo[i];
                            input_medCarInfo[i].GUID = sql_medCart.GUID;
                            medCart_sql_replace.Add(input_medCarInfo[i]);
                        }
                        else
                        {
                            medCarInfoClass medCarInfoClass = input_medCarInfo[i];
                            medCart_sql_replace.Add(input_medCarInfo[i]);
                        }

                    }
                }
                List<object[]> list_medCart_add = new List<object[]>();
                List<object[]> list_medCart_repalce = new List<object[]>();

                list_medCart_add = medCart_sql_add.ClassToSQL<medCarInfoClass, enum_病床資訊>();
                list_medCart_repalce = medCart_sql_replace.ClassToSQL<medCarInfoClass, enum_病床資訊>();

                if (list_medCart_add.Count > 0) sQLControl_med_carInfo.AddRows(null, list_medCart_add);
                if (list_medCart_repalce.Count > 0) sQLControl_med_carInfo.UpdateByDefulteExtra(null, list_medCart_repalce);
                string 占床狀態 = "已占床";
                List<object[]> list_bedList = sQLControl_med_carInfo.GetRowsByDefult(null, (int)enum_病床資訊.藥局, 藥局);
                List<medCarInfoClass> bedList = list_bedList.SQLToClass<medCarInfoClass, enum_病床資訊>();
                List<medCarInfoClass> medCarInfoClasses = new List<medCarInfoClass>();
                medCarInfoClasses = (from temp in bedList
                                     where temp.護理站 == 護理站
                                     where temp.占床狀態 == 占床狀態
                                     select temp).ToList();
                medCarInfoClasses.Sort(new medCarInfoClass.ICP_By_bedNum());


                returnData.Code = 200;
                returnData.TimeTaken = $"{myTimerBasic}";
                returnData.Data = medCarInfoClasses;
                returnData.Result = $"病床清單共{bedList.Count}筆";
                return returnData.JsonSerializationt(true);
            }
            catch (Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = ex.Message;
                return returnData.JsonSerializationt(true);
            }
        }
        [HttpPost("get_patient_by_bedNum")]
        public string get_patient_by_bedNum([FromBody] returnData returnData)
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
                    returnData.Result = $"returnData.ValueAry 內容應為[藥局, 護理站, 床號]";
                    return returnData.JsonSerializationt(true);
                }
                string 藥局 = returnData.ValueAry[0];
                string 護理站 = returnData.ValueAry[1];
                string 床號 = returnData.ValueAry[2];

                List<ServerSettingClass> serverSettingClasses = ServerSettingClassMethod.WebApiGet($"{API_Server}");
                serverSettingClasses = serverSettingClasses.MyFind("Main", "網頁", "VM端");
                string Server = serverSettingClasses[0].Server;
                string DB = serverSettingClasses[0].DBName;
                string UserName = serverSettingClasses[0].User;
                string Password = serverSettingClasses[0].Password;
                uint Port = (uint)serverSettingClasses[0].Port.StringToInt32();
                Table table = new Table(new enum_病床資訊());
                SQLControl sQLControl_med_carInfo = new SQLControl(Server, DB, table.TableName, UserName, Password, Port, SSLMode);
                List<object[]> list_medCart = sQLControl_med_carInfo.GetRowsByDefult(null, (int)enum_病床資訊.藥局, 藥局);

                List<medCarInfoClass> sql_medCar = list_medCart.SQLToClass<medCarInfoClass, enum_病床資訊>();
                List<medCarInfoClass> targetPatient = new List<medCarInfoClass>();
                targetPatient = (from temp in sql_medCar
                                 where temp.護理站 == 護理站
                                 where temp.床號 == 床號
                                 select temp).ToList();

                returnData.Code = 200;
                returnData.TimeTaken = $"{myTimerBasic}";
                returnData.Data = targetPatient;
                returnData.Result = $"";
                return returnData.JsonSerializationt(true);
            }
            catch(Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = ex.Message;
                return returnData.JsonSerializationt(true);
            }
        }
        [HttpPost("check_dispense")]
        public string check_dispense([FromBody] returnData returnData)
        {
            MyTimerBasic myTimerBasic = new MyTimerBasic();
            returnData.Method = "check_dispense";
            try
            {
                List<ServerSettingClass> serverSettingClasses = ServerSettingClassMethod.WebApiGet($"{API_Server}");
                serverSettingClasses = serverSettingClasses.MyFind("Main", "網頁", "VM端");
                if (serverSettingClasses.Count == 0)
                {
                    returnData.Code = -200;
                    returnData.Result = $"找無Server資料";
                    return returnData.JsonSerializationt();
                }

                string Server = serverSettingClasses[0].Server;
                string DB = serverSettingClasses[0].DBName;
                string UserName = serverSettingClasses[0].User;
                string Password = serverSettingClasses[0].Password;
                uint Port = (uint)serverSettingClasses[0].Port.StringToInt32();
                Table table = new Table(new enum_病床資訊());
                SQLControl sQLControl_med_carInfo = new SQLControl(Server, DB, table.TableName, UserName, Password, Port, SSLMode);
                List<medCarInfoClass> input_medCarInfo = returnData.Data.ObjToClass<List<medCarInfoClass>>();

                if (input_medCarInfo == null)
                {
                    returnData.Code = -200;
                    returnData.Result = $"傳入Data資料異常";
                    return returnData.JsonSerializationt();
                }
                if(input_medCarInfo.Count != 1)
                {
                    returnData.Code = -200;
                    returnData.Result = $"傳入Data資料異常";
                    return returnData.JsonSerializationt();
                }
                if (returnData.ValueAry == null)
                {
                    returnData.Code = -200;
                    returnData.Result = $"無調劑藥品";
                    return returnData.JsonSerializationt(true);
                }

                string 藥局 = input_medCarInfo[0].藥局;
                string 護理站 = input_medCarInfo[0].護理站;
                string 床號 = input_medCarInfo[0].床號;

                List<object[]> list_medCart = sQLControl_med_carInfo.GetRowsByDefult(null, (int)enum_病床資訊.藥局, 藥局);

                List<medCarInfoClass> sql_medCar = list_medCart.SQLToClass<medCarInfoClass, enum_病床資訊>();
                List<medCarInfoClass> targetPatient = new List<medCarInfoClass>();
                targetPatient = (from temp in sql_medCar
                                 where temp.護理站 == 護理站
                                 where temp.床號 == 床號
                                 select temp).ToList();
                if(targetPatient.Count != 1)
                {
                    returnData.Code = -200;
                    returnData.Result = $"資料錯誤";
                    return returnData.JsonSerializationt(true);
                }
                List<medCpoeClass> 處方 = ((string)targetPatient[0].處方).JsonDeserializet<List<medCpoeClass>>();
                List<medCpoeClass> medCpoeClasses = new List<medCpoeClass>();
            
                int 處方數量 = 處方.Count;
                int 處方已調劑數量 = 0;
                for (int i = 0; i < 處方.Count; i++)
                {
                    medCpoeClass value = 處方[i];
                    if (returnData.ValueAry.Contains(value.藥品名))
                    {
                        value.調劑狀態 = "已調劑";
                        處方已調劑數量 += 1;
                    }
                    else
                    {
                        value.調劑狀態 = "";
                    }
                    medCpoeClasses.Add(value);
                }
                if (處方已調劑數量 == 處方數量)
                {
                    targetPatient[0].調劑狀態 = "已完成";
                }
                else
                {
                    targetPatient[0].調劑狀態 = "";
                }

                string cpoe = medCpoeClasses.JsonSerializationt();    
                targetPatient[0].處方 = cpoe;

                List<object[]> list_medCart_repalce = new List<object[]>();
                list_medCart_repalce = targetPatient.ClassToSQL<medCarInfoClass, enum_病床資訊>();
                if (list_medCart_repalce.Count > 0) sQLControl_med_carInfo.UpdateByDefulteExtra(null, list_medCart_repalce);

                returnData.Code = 200;
                returnData.TimeTaken = $"{myTimerBasic}";
                returnData.Data = targetPatient;
                returnData.Result = $"";
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
