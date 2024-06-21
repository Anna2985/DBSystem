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
    [EnumDescription("locker_index_table")]
    public enum enum_Locker_Index_Table
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("IP,VARCHAR,20,INDEX")]
        IP,
        [Description("Num,VARCHAR,20,NONE")]
        Num,
        [Description("輸入位置,VARCHAR,20,NONE")]
        輸入位置,
        [Description("輸入狀態,VARCHAR,20,NONE")]
        輸入狀態,
        [Description("輸出位置,VARCHAR,20,NONE")]
        輸出位置,
        [Description("輸出狀態,VARCHAR,20,NONE")]
        輸出狀態,
        [Description("同步輸出,VARCHAR,20,NONE")]
        同步輸出,
        [Description("Master_GUID,VARCHAR,50,NONE")]
        Master_GUID,
        [Description("Slave_GUID,VARCHAR,50,NONE")]
        Slave_GUID,
        [Description("Device_GUID,VARCHAR,50,NONE")]
        Device_GUID,
    }
}
