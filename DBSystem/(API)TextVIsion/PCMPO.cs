﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLUI;
using Basic;
using ClassLibrary;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DBSystem.NewFolder
{
    [Route("api/[controller]")]
    [ApiController]
    public class PCMPO : ControllerBase
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        /// <summary>
        ///初始化pcmpo資料庫
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
        [HttpPost("init_pcmpo")]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(200, "textVisionClass物件", typeof(textVisionClass))]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(200, "UIresult物件", typeof(UIresult))]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(200, "searchMedCODEClass物件", typeof(searchMedCODEClass))]
        public string init([FromBody] returnData returnData)
        {
            try
            {
                List<Table> tables = TableManager.CheckCreateTable("textvision",new enum_textVision());
                Table table = tables.GetTable(new enum_textVision());
                if (table == null)
                {
                    returnData.Code = -200;
                    returnData.Result = "table 空白，請檢查使用者!";
                    return returnData.JsonSerializationt(true);
                }
                return table.JsonSerializationt();
            }
            catch (Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = $"Exception : {ex.Message}";
                return returnData.JsonSerializationt(true);
            }
        }
        /// <summary>
        ///初始化search_medCODE資料庫
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
        [HttpPost("init_search_medCODE")]
        public string POST_init_search_medCODE([FromBody] returnData returnData)
        {
            try
            {
                List<Table> tables = TableManager.CheckCreateTable("ds01", new enum_search_medCODE());
                Table table = tables.GetTable(new enum_search_medCODE());
                if (table == null)
                {
                    returnData.Code = -200;
                    returnData.Result = "table 空白，請檢查使用者!";
                    return returnData.JsonSerializationt(true);
                }
                return table.JsonSerializationt();
            }
            catch (Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = $"Exception : {ex.Message}";
                return returnData.JsonSerializationt(true);
            }
        }
        /// <summary>
        /// 執行文字辨識
        /// </summary>
        /// <remarks>
        /// 以下為JSON範例
        /// <code>
        ///     {
        ///         "Data":
        ///         [
        ///             [textVisionClass]
        ///         ]
        ///         
        ///     }
        /// </code>
        /// </remarks>
        /// <param name="returnData">共用傳遞資料結構</param>
        /// <returns></returns>
        [HttpPost("analyze")]
        public string POST_analyze([FromBody] returnData returnData)
        {
            MyTimerBasic myTimerBasic = new MyTimerBasic();
            try
            {
                if (returnData.Data == null)
                {
                    returnData.Code = -200;
                    returnData.Result = "returnData.Data 空白，請輸入對應欄位資料!";
                    return returnData.JsonSerializationt(true);
                }
                Table table_pcmpo = new Table(new enum_textVision());
                //string tableName = table_pcmpo.TableName;
                SQLControl sQLControl_txt = new SQLControl("127.0.0.1", "textvision", "user", "66437068");
                List<textVisionClass> inputList = returnData.Data.ObjToClass<List<textVisionClass>>();

                textVisionClass textVisionClass = inputList[0];
                textVisionClass.GUID = Guid.NewGuid().ToString();
                textVisionClass.操作時間 = DateTime.Now.ToDateTimeString();

                List<textVisionClass> sqlAddList = new List<textVisionClass>() {textVisionClass};
                List<object[]> addList = sqlAddList.ClassToSQL<textVisionClass, enum_textVision>();
                sQLControl_txt.AddRows(table_pcmpo.TableName, addList);

                GuidBase guidBase = new GuidBase
                {
                    GUID = textVisionClass.GUID,
                    base64 = textVisionClass.圖片
                };
                DataList<GuidBase> dataList = new DataList<GuidBase>();
                dataList.Data.Add(guidBase);

                //var jsonData = (new List<GuidBase> { guidBase }).JsonSerializationt(true);
                string jsonData = dataList.JsonSerializationt(true);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = _httpClient.PostAsync("https://53b1-220-135-128-247.ngrok-free.app/ROI_input", content).Result;
                string responseString = response.Content.ReadAsStringAsync().Result;
                AIResponse aiInputList = responseString.JsonDeserializet<AIResponse>();
                if (aiInputList.Data == null)
                {
                    returnData.Code = -200;
                    returnData.Result = "請重新輸入照片";
                    return returnData.JsonSerializationt(true);
                }
                textVisionClass aiInput = aiInputList.Data[0];
                string uiResult = (aiInput.UI結果).ToString();
                JObject jsonObject = JObject.Parse(uiResult);
                var infoObject = (JObject)jsonObject["info"];
                var batchNumArray = (JArray)infoObject["BATCH NUMBER"];
                var expirydateArray = (JArray)infoObject["EXPIRYDATE"];
                var poNumArray = (JArray)infoObject["PONO"];
                var productArray = (JArray)infoObject["PRODUCT"];
                var qtyArray = (JArray)infoObject["QUANTITY"];

                string batch_num = batchNumArray[0].ToString();
                string expirydate = expirydateArray[0].ToString();
                string po_num = poNumArray[0].ToString();
                string ex_name = productArray[0].ToString();
                string ex_cht_name = productArray[1].ToString();
                string qty = qtyArray[0].ToString();

                string pattern1 = @"^[A-Za-z0-9]+";
                string cht_name = Regex.Replace(ex_cht_name, pattern1, "");

                string pattern2 = @"^\d+";
                string name = Regex.Replace(ex_name, pattern2, "");

                string GUID = aiInput.GUID;
                List<object[]> row_value = sQLControl_txt.GetRowsByDefult(table_pcmpo.TableName, (int)enum_textVision.GUID, GUID);
                List<textVisionClass> sqlResult = row_value.SQLToClass<textVisionClass, enum_textVision>();

                textVisionClass dbRecord = sqlResult[0];
                aiInput.操作者姓名 = dbRecord.操作者姓名;
                aiInput.操作者ID = dbRecord.操作者ID;
                aiInput.圖片 = dbRecord.圖片;
                aiInput.操作時間 = dbRecord.操作時間;
                aiInput.批號 = batch_num;
                aiInput.效期 = expirydate;
                aiInput.單號 = po_num;
                aiInput.藥名 = name;
                aiInput.中文名 = cht_name;
                aiInput.數量 = qty;
                //string 中文名 = "妥復克膜衣錠４０毫克";
                SQLControl sQLControl_ds01 = new SQLControl("127.0.0.1", "ds01", "user", "66437068");
                Table table_med = new Table(new enum_medPageCloud());
                Table table_sch = new Table(new enum_search_medCODE());
                List<object[]> code_value = sQLControl_ds01.GetRowsByDefult(table_med.TableName, (int)enum_medPageCloud.藥品名稱, name);
                List<object[]> code_value2 = sQLControl_ds01.GetRowsByDefult(table_sch.TableName, (int)enum_search_medCODE.藥名, name);
                if (code_value.Count == 0 & code_value2.Count ==0)
                {
                    returnData.Code = -200;
                    returnData.Result = "查無藥品碼";
                    return returnData.JsonSerializationt(true);
                }
                string 藥品碼 = "";
                if (code_value.Count != 0)
                {
                    藥品碼 = code_value[0][(int)enum_medPageCloud.藥品碼].ObjectToString();
                }
                if (code_value2.Count != 0)
                {
                    藥品碼 = code_value2[0][(int)enum_search_medCODE.藥品碼].ObjectToString();
                }

                aiInput.藥品碼 = 藥品碼;

                List<textVisionClass> sqlUpdateList = new List<textVisionClass> { aiInput };
                List<object[]> UpdateList = sqlUpdateList.ClassToSQL<textVisionClass, enum_textVision>();
                sQLControl_txt.UpdateByDefulteExtra(table_pcmpo.TableName, UpdateList);

                UIresult uIresult = new UIresult
                {
                    GUID = GUID,
                    批號 = batch_num,
                    操作者ID = aiInput.操作者ID,
                    操作者姓名 = aiInput.操作者姓名,
                    單號 = po_num,
                    藥名 = name,
                    中文名 = cht_name,
                    數量 = qty,
                    效期 = expirydate,
                    藥品碼 = 藥品碼,
                    操作時間 = aiInput.操作時間
                };
                List<UIresult> uIresults = new List<UIresult>() { uIresult };

                returnData.Code = 200;
                returnData.Data = uIresults;
                returnData.TimeTaken = $"{myTimerBasic}";
                returnData.Method = "";
                returnData.Result = $"新增<{UpdateList.Count}>筆";
                return returnData.JsonSerializationt(true);
            }
            catch (Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = $"Exception : {ex.Message}";
                return returnData.JsonSerializationt(true);
            }
        }
        /// <summary>
        /// 更新檢索表
        /// </summary>
        /// <remarks>
        /// 以下為JSON範例
        /// <code>
        ///     {
        ///         "Data":
        ///         [
        ///             [searchMedCODEClass]
        ///         ]
        ///         
        ///     }
        /// </code>
        /// </remarks>
        /// <param name="returnData">共用傳遞資料結構</param>
        [HttpPost("update_search")]
        public string POST_update_search([FromBody]returnData returnData)
        {
            MyTimerBasic myTimerBasic = new MyTimerBasic();
            try
            {
                if (returnData.Data == null)
                {
                    returnData.Code = -200;
                    returnData.Result = "returnData.Data 空白，請輸入對應欄位資料!";
                    return returnData.JsonSerializationt(true);
                }
                Table table = new Table(new enum_search_medCODE());
                List<searchMedCODEClass> inputList = returnData.Data.ObjToClass<List<searchMedCODEClass>>();
                searchMedCODEClass searchMedCODEClass = inputList[0];
                searchMedCODEClass.GUID = Guid.NewGuid().ToString();
                searchMedCODEClass.操作時間 = DateTime.Now.ToDateTimeString();
                List<searchMedCODEClass> search_medCODE = new List<searchMedCODEClass> { searchMedCODEClass };
                List<object[]> list_search_medCODE_add = new List<object[]>();
                list_search_medCODE_add = search_medCODE.ClassToSQL<searchMedCODEClass, enum_search_medCODE>();

                SQLControl sQLControl_serchMedCODE = new SQLControl("127.0.0.1", "ds01", "user", "66437068");
                sQLControl_serchMedCODE.AddRows(table.TableName, list_search_medCODE_add);

                returnData.Data = searchMedCODEClass;
                returnData.Code = 200;
                returnData.TimeTaken = $"{myTimerBasic}";
                returnData.Method = "update_search";
                returnData.Result = $"新增<{list_search_medCODE_add.Count}>筆";
                return returnData.JsonSerializationt(true);

            }
            catch(Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = $"Exception : {ex.Message}";
                return returnData.JsonSerializationt(true);
            }
        }
        /// <summary>
        /// 以GUID更新資料庫
        /// </summary>
        /// <remarks>
        /// 以下為JSON範例
        /// <code>
        ///     {
        ///         "Data":
        ///         [
        ///             [UIresult]
        ///         ]
        ///         
        ///     }
        /// </code>
        /// </remarks>
        /// <param name="returnData">共用傳遞資料結構</param>
        /// <returns></returns>
        [HttpPost("edit")]
        public string POST_edit([FromBody] returnData returnData)
        {
            MyTimerBasic myTimerBasic = new MyTimerBasic();
            try
            {
                if(returnData.Data == null)
                {
                    returnData.Data = -200;
                    returnData.Result = "returnData.Data 空白，請輸入對應欄位資料!";
                    return returnData.JsonSerializationt();
                }
                Table table = new Table(new enum_textVision());
                string tableName = table.TableName;
                SQLControl sQLControl = new SQLControl("127.0.0.1", "textvision", "user", "66437068");
                List<UIresult> inputList = returnData.Data.ObjToClass<List<UIresult>>();
                UIresult inputClass = inputList[0];
                string GUID = inputClass.GUID;
                List<object[]> row_value = sQLControl.GetRowsByDefult(tableName, (int)enum_textVision.GUID, GUID);
                if (row_value.Count == 0)
                {
                    returnData.Code = -200;
                    returnData.Result = "查無資料";
                    return returnData.JsonSerializationt(true);
                }
                List<textVisionClass> sqlresult = row_value.SQLToClass<textVisionClass, enum_textVision>();
                textVisionClass sqlClass = sqlresult[0];

                if (inputClass.批號 != sqlClass.批號) sqlClass.批號 = inputClass.批號;
                if (inputClass.單號 != sqlClass.單號) sqlClass.單號 = inputClass.單號;
                //if (inputClass.藥名 != sqlClass.藥名) sqlClass.藥名 = inputClass.藥名;
                //if (inputClass.中文名 != sqlClass.中文名) sqlClass.中文名 = inputClass.中文名;
                if (inputClass.數量 != sqlClass.數量) sqlClass.數量 = inputClass.數量;
                if (inputClass.效期 != sqlClass.效期) sqlClass.效期 = inputClass.效期;

                List<textVisionClass> sqlUpdateList = new List<textVisionClass> { sqlClass };
                List<object[]> UpdateList = sqlUpdateList.ClassToSQL<textVisionClass, enum_textVision>();
                sQLControl.UpdateByDefulteExtra(tableName, UpdateList);

                returnData.Code = 200;
                returnData.Data = "";
                returnData.TimeTaken = $"{myTimerBasic}";
                returnData.Method = "edit";
                returnData.Result = $"編輯<{inputList.Count}>筆";
                return returnData.JsonSerializationt(true);
            }
            catch(Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = $"Exception : {ex.Message}";
                return returnData.JsonSerializationt(true);
            }
        }

        /// <summary>
        /// 以GUID刪除資料庫
        /// </summary>
        /// <remarks>
        /// 以下為JSON範例
        /// <code>
        ///     {
        ///         "ValueAry":
        ///         [
        ///             "GUID"
        ///         ]
        ///         
        ///     }
        /// </code>
        /// </remarks>
        /// <param name="returnData">共用傳遞資料結構</param>
        /// <returns></returns>
        [HttpPost("delete")]
        public string POST_delete ([FromBody] returnData returnData)
        {
            MyTimerBasic myTimerBasic = new MyTimerBasic();
            try
            {
                if (returnData.Data == null)
                {
                    returnData.Data = -200;
                    returnData.Result = "returnData.Data 空白，請輸入對應欄位資料!";
                    return returnData.JsonSerializationt();
                }
                Table table = new Table(new enum_textVision());
                string tableName = table.TableName;
                SQLControl sQLControl = new SQLControl("127.0.0.1", "textvision", "user", "66437068");
                string GUID = returnData.ValueAry[0];
                List<object[]> row_value = sQLControl.GetRowsByDefult(tableName, (int)enum_textVision.GUID, GUID);
                if (row_value.Count == 0)
                {
                    returnData.Code = -200;
                    returnData.Result = "查無資料";
                    return returnData.JsonSerializationt(true);
                }
                sQLControl.DeleteExtra(tableName, row_value);
                
                returnData.Code = 200;
                returnData.Data = "";
                returnData.TimeTaken = $"{myTimerBasic}";
                returnData.Method = "delete";
                returnData.Result = $"刪除<{row_value.Count}>筆";
                return returnData.JsonSerializationt(true);
            }
            catch (Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = $"Exception : {ex.Message}";
                return returnData.JsonSerializationt(true);
            }
        }



        public static class TableManager
        {
            public static List<Table> CheckCreateTable(string DB, Enum tableEnum)
            {
                List<Table> tables = new List<Table>();
                tables.Add(CheckCreateTable("127.0.0.1", DB, "user", "66437068", 3306, tableEnum));
                return tables;
            }

            static public Table CheckCreateTable(string server, string db, string user, string password, uint port, Enum Enum)
            {
                Table table = new Table(Enum);

                string Server = server;
                string DB = db;
                string UserName = user;
                string Password = password;
                uint Port = port;
                table.Server = Server;
                table.DBName = DB;
                table.Username = UserName;
                table.Password = Password;
                table.Port = Port.ToString();

                SQLControl sQLControl = new SQLControl(Server, DB, UserName, Password, Port, MySql.Data.MySqlClient.MySqlSslMode.Disabled);

                if (!sQLControl.IsTableCreat()) sQLControl.CreatTable(table);
                else sQLControl.CheckAllColumnName(table, true);
                return table;
            }
        }
    }
}
