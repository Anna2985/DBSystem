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
    public class medCarList : ControllerBase
    {

        static private string API_Server = "http://127.0.0.1:4433/api/serversetting";
        static private MySqlSslMode SSLMode = MySqlSslMode.None;
        /// <summary>
        ///初始化dbvm.med_carList資料庫
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
        [HttpPost("init_med_carList")]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(200, "medCarListClass物件", typeof(medCarListClass))]
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

            Table table = MethodClass.CheckCreatTable(serverSettingClass, new enum_med_carList());
            return table.JsonSerializationt(true);
        }
        /// <summary>
        ///新增護理站資料
        /// </summary>
        /// <remarks>
        /// 以下為JSON範例
        /// <code>
        ///     {
        ///         "ValueAry":[藥局, 護理站]
        ///     }
        /// </code>
        /// </remarks>
        /// <param name="returnData">共用傳遞資料結構</param>
        /// <returns></returns>
        [HttpPost("add")]
        public string add([FromBody] returnData returnData)
        {
            MyTimerBasic myTimerBasic = new MyTimerBasic();
            returnData.Method = "add";
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
                    returnData.Result = $"returnData.ValueAry 內容應為[藥局, 護理站]";
                    return returnData.JsonSerializationt(true);
                }
                string 藥局 = returnData.ValueAry[0];
                string 護理站 = returnData.ValueAry[1];
                if (!PharmacyData.PharmacyDictionary.TryGetValue(藥局, out string 藥局名))
                {
                    returnData.Code = -200;
                    returnData.Result = "找不到對應的藥局名稱";
                    return returnData.JsonSerializationt(true);
                }
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
                Table table = new Table(new enum_med_carList());
                SQLControl sQLControl_med_carInfo = new SQLControl(Server, DB, table.TableName, UserName, Password, Port, SSLMode);
                List<object[]> list_medCart = sQLControl_med_carInfo.GetAllRows(null);

                List<medCarListClass> medCart_sql = list_medCart.SQLToClass<medCarListClass, enum_med_carList>();
                List<medCarListClass> medCart_sql_buf = new List<medCarListClass>();
                List<medCarListClass> medCart_sql_add = new List<medCarListClass>();
                List<medCarListClass> medCart_sql_replace = new List<medCarListClass>();

                medCart_sql_buf = (from temp in medCart_sql
                                   where temp.藥局 == 藥局
                                   where temp.護理站 == 護理站
                                   select temp).ToList();
                if (medCart_sql_buf.Count != 0)
                {
                    returnData.Code = -200;
                    returnData.Result = "資料已存在";
                    return returnData.JsonSerializationt(true);
                }
                else
                {
                    string GUID = Guid.NewGuid().ToString();
                    medCarListClass medCarListClass = new medCarListClass
                    {
                        GUID = GUID,
                        藥局 = 藥局,
                        藥局名 = 藥局名,
                        護理站 = 護理站
                    };
                    medCart_sql_add.Add(medCarListClass);
                }
                List<object[]> list_medCart_add = new List<object[]>();
                list_medCart_add = medCart_sql_add.ClassToSQL<medCarListClass, enum_med_carList>();
                if (list_medCart_add.Count > 0) sQLControl_med_carInfo.AddRows(null, list_medCart_add);
                List<object[]> list_carList = sQLControl_med_carInfo.GetAllRows(null);
                List<medCarListClass> carList = list_carList.SQLToClass<medCarListClass, enum_med_carList>();
                returnData.Code = 200;
                returnData.TimeTaken = $"{myTimerBasic}";
                returnData.Data = carList;
                returnData.Result = $"護理站清單共{carList.Count}筆";
                return returnData.JsonSerializationt(true);
            }
            catch (Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = ex.Message;
                return returnData.JsonSerializationt(true);
            }

        }
        /// <summary>
        ///刪除護理站資料
        /// </summary>
        /// <remarks>
        /// 以下為JSON範例
        /// <code>
        ///     {
        ///         "ValueAry":[藥局, 護理站]
        ///     }
        /// </code>
        /// </remarks>
        /// <param name="returnData">共用傳遞資料結構</param>
        /// <returns></returns>
        [HttpPost("delete")]
        public string delete([FromBody] returnData returnData)
        {
            MyTimerBasic myTimerBasic = new MyTimerBasic();
            returnData.Method = "delete";
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
                    returnData.Result = $"returnData.ValueAry 內容應為[藥局, 護理站]";
                    return returnData.JsonSerializationt(true);
                }
                string 藥局 = returnData.ValueAry[0];
                string 護理站 = returnData.ValueAry[1];

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
                Table table = new Table(new enum_med_carList());
                SQLControl sQLControl_med_carInfo = new SQLControl(Server, DB, table.TableName, UserName, Password, Port, SSLMode);
                List<object[]> list_medCart = sQLControl_med_carInfo.GetAllRows(null);

                List<medCarListClass> medCart_sql = list_medCart.SQLToClass<medCarListClass, enum_med_carList>();
                List<medCarListClass> medCart_sql_buf = new List<medCarListClass>();
                List<medCarListClass> medCart_sql_delete = new List<medCarListClass>();

                medCart_sql_buf = (from temp in medCart_sql
                                   where temp.藥局 == 藥局
                                   where temp.護理站 == 護理站
                                   select temp).ToList();
                if (medCart_sql_buf.Count == 0)
                {
                    returnData.Code = -200;
                    returnData.Result = "資料不存在";
                    return returnData.JsonSerializationt(true);
                }
                else
                {
                    medCart_sql_delete.Add(medCart_sql_buf[0]);
                }
                List<object[]> list_medCart_delete = new List<object[]>();
                list_medCart_delete = medCart_sql_delete.ClassToSQL<medCarListClass, enum_med_carList>();
                if (medCart_sql_delete.Count > 0) sQLControl_med_carInfo.DeleteExtra(null, list_medCart_delete);
                List<object[]> list_carList = sQLControl_med_carInfo.GetAllRows(null);
                List<medCarListClass> carList = list_carList.SQLToClass<medCarListClass, enum_med_carList>();
                returnData.Code = 200;
                returnData.TimeTaken = $"{myTimerBasic}";
                returnData.Data = medCart_sql_delete;
                returnData.Result = $"刪除護理站資料共{list_medCart_delete.Count}筆";
                return returnData.JsonSerializationt(true);
            }
            catch (Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = ex.Message;
                return returnData.JsonSerializationt(true);
            }

        }
        /// <summary>
        ///取得藥局護理站資料
        /// </summary>
        /// <remarks>
        /// 以下為JSON範例
        /// <code>
        ///     {
        ///         "ValueAry":[藥局]
        ///     }
        /// </code>
        /// </remarks>
        /// <param name="returnData">共用傳遞資料結構</param>
        /// <returns></returns>
        [HttpPost("get_medcar_by_phar")]
        public string get_medcar_by_phar([FromBody] returnData returnData)
        {
            MyTimerBasic myTimerBasic = new MyTimerBasic();
            returnData.Method = "get_medcar_by_phar";
            try
            {
                if (returnData.ValueAry == null)
                {
                    returnData.Code = -200;
                    returnData.Result = $"returnData.ValueAry 無傳入資料";
                    return returnData.JsonSerializationt(true);
                }
                if (returnData.ValueAry.Count != 1)
                {
                    returnData.Code = -200;
                    returnData.Result = $"returnData.ValueAry 內容應為[藥局]";
                    return returnData.JsonSerializationt(true);
                }
                string 藥局 = returnData.ValueAry[0];

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
                Table table = new Table(new enum_med_carList());
                SQLControl sQLControl_med_carInfo = new SQLControl(Server, DB, table.TableName, UserName, Password, Port, SSLMode);
                List<object[]> list_medCart = sQLControl_med_carInfo.GetAllRows(null);

                List<medCarListClass> medCart_sql = list_medCart.SQLToClass<medCarListClass, enum_med_carList>();
                List<medCarListClass> medCart_sql_buf = new List<medCarListClass>();
                List<medCarListClass> medCart_sql_delete = new List<medCarListClass>();

                medCart_sql_buf = (from temp in medCart_sql
                                   where temp.藥局 == 藥局
                                   select temp).ToList();
                if (medCart_sql_buf.Count == 0)
                {
                    returnData.Code = -200;
                    returnData.Result = "資料不存在";
                    return returnData.JsonSerializationt(true);
                }

                returnData.Code = 200;
                returnData.TimeTaken = $"{myTimerBasic}";
                returnData.Data = medCart_sql_buf;
                returnData.Result = $"取得{藥局}的護理站共{medCart_sql_buf.Count}筆";
                return returnData.JsonSerializationt(true);
            }
            catch (Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = ex.Message;
                return returnData.JsonSerializationt(true);
            }

        }
        /// <summary>
        ///取得藥局資料
        /// </summary>
        /// <remarks>
        /// 以下為JSON範例
        /// <code>
        ///     {
        ///         "ValueAry":[]
        ///     }
        /// </code>
        /// </remarks>
        /// <param name="returnData">共用傳遞資料結構</param>
        /// <returns></returns>
        [HttpPost("get_phar")]
        public string get_phar([FromBody] returnData returnData)
        {
            MyTimerBasic myTimerBasic = new MyTimerBasic();
            returnData.Method = "get_phar";
            try
            {
                List<medCarListClass> medCarListClasses = new List<medCarListClass>();
                //Dictionary<string, string> pharList = new PharmacyData.PharmacyDictionary();
                foreach (var row in PharmacyData.PharmacyDictionary)
                {
                    medCarListClass medCarListClass = new medCarListClass
                    {
                        藥局 = row.Key,
                        藥局名 = row.Value
                    };
                    medCarListClasses.Add(medCarListClass);
                }


                returnData.Code = 200;
                returnData.TimeTaken = $"{myTimerBasic}";
                returnData.Data = medCarListClasses;
                returnData.Result = $"取得藥局資料共{medCarListClasses.Count}";
                return returnData.JsonSerializationt(true);
            }
            catch (Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = ex.Message;
                return returnData.JsonSerializationt(true);
            }

        }

    }
}