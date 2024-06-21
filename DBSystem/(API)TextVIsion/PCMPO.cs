using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLUI;
using Basic;
using ClassLibrary;
using HIS_DB_Lib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DBSystem.NewFolder
{
    [Route("api/[controller]")]
    [ApiController]
    public class PCMPO : ControllerBase
    {
        [HttpPost("init")]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(200, "textVisionClass物件", typeof(textVisionClass))]
        public string init([FromBody] returnData returnData)
        {
            try
            {
                List<Table> tables = TableManager.CheckCreateTable();
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
        [HttpPost("Start")]
        public string POST_start([FromBody] returnData returnData)
        {
            MyTimerBasic myTimerBasic = new MyTimerBasic();
            try
            {
                if (returnData.Data == null)
                {
                    returnData.Code = -200;
                    returnData.Result = "returnData.Data 空白，請輸入對應欄位資料!";
                    return returnData.JsonSerializationt();
                }
                Table table = new Table(new enum_textVision());
                SQLControl sqlControl = new SQLControl("127.0.0.1", "textvision", "user", "66437068");
                List<textVisionClass> profile_sql_add = new List<textVisionClass>();
                List<textVisionClass> profile_input = returnData.Data.ObjToClass<List<textVisionClass>>();

                string GUID = Guid.NewGuid().ToString();
                textVisionClass textVisionClass = profile_input[0];
                textVisionClass.GUID = GUID;
                textVisionClass.操作時間 = DateTime.Now.ToDateTimeString();
                profile_sql_add.Add(textVisionClass);

                OpID.op_ID = textVisionClass.操作者ID;

                List<object[]> list_profile_add = new List<object[]>();
                list_profile_add = profile_sql_add.ClassToSQL<textVisionClass, enum_textVision>();
                if (list_profile_add.Count > 0) sqlControl.AddRows(table.TableName, list_profile_add);
                
                returnData.Code = 200;
                returnData.TimeTaken = $"{myTimerBasic}";
                returnData.Method = "Start";
                returnData.Result = $"新增<{list_profile_add.Count}>筆";
                return returnData.JsonSerializationt(true);
            }
            catch (Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = $"Exception : {ex.Message}";
                return returnData.JsonSerializationt(true);
            }
        }
        [HttpGet("get_test")]
        public string GET_item()
        {
            MyTimerBasic myTimerBasic = new MyTimerBasic();
            Table table = new Table(new enum_textVision());
            string tableName = table.TableName;
            SQLControl sQLControl = new SQLControl("127.0.0.1", "textvision", "user", "66437068");
            string 操作者ID = OpID.op_ID;
            List<object[]> row_values = sQLControl.GetRowsByDefult(tableName,(int)enum_textVision.操作者ID,操作者ID);
            List<textVisionClass> textVisionClass = row_values.SQLToClass<textVisionClass, enum_textVision>();

            var result = (from data in textVisionClass
                         select new GuidBase
                         {
                             GUID = data.GUID,
                             base64 = data.圖片
                         }).ToList();

            return result.JsonSerializationt(true);

        }
    }
    public  static class OpID
    {
        public static string op_ID { get; set; }
    }
    public static class TableManager
    {
        public static List<Table> CheckCreateTable()
        {
            List<Table> tables = new List<Table>();
            tables.Add(CheckCreateTable("127.0.0.1", "textvision", "user", "66437068", 3306, new enum_textVision()));
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
