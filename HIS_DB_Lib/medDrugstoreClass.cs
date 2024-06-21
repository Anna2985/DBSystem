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
    [EnumDescription("medicine_page_firstclass")]
    public enum enum_medDrugstore
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("藥品碼,VARCHAR,20,INDEX")]
        藥品碼,
        [Description("料號,VARCHAR,20,INDEX")]
        料號,
        [Description("中文名稱,VARCHAR,300,NONE")]
        中文名稱,
        [Description("藥品名稱,VARCHAR,300,NONE")]
        藥品名稱,
        [Description("藥品學名,VARCHAR,300,NONE")]
        藥品學名,
        [Description("藥品群組,VARCHAR,300,NONE")]
        藥品群組,
        [Description("健保碼,VARCHAR,50,NONE")]
        健保碼,
        [Description("包裝單位,VARCHAR,10,NONE")]
        包裝單位,
        [Description("包裝數量,VARCHAR,10,NONE")]
        包裝數量,
        [Description("最小包裝單位,VARCHAR,10,NONE")]
        最小包裝單位,
        [Description("最小包裝數量,VARCHAR,10,NONE")]
        最小包裝數量,
        [Description("藥局庫存,VARCHAR,20,NONE")]
        藥局庫存,
        [Description("藥庫庫存,VARCHAR,20,NONE")]
        藥庫庫存,
        [Description("總庫存,VARCHAR,20,NONE")]
        總庫存,
        [Description("基準量,VARCHAR,20,NONE")]
        基準量,
        [Description("安全庫存,VARCHAR,20,NONE")]
        安全庫存,
        [Description("藥品條碼1,VARCHAR,300,NONE")]
        藥品條碼1,
        [Description("藥品條碼2,TEXT,300,NONE")]
        藥品條碼2,
        [Description("類別,VARCHAR,500,NONE")]
        類別,
        [Description("廠牌,VARCHAR,200,NONE")]
        廠牌,
        [Description("藥品許可證號,VARCHAR,50,NONE")]
        藥品許可證號,
        [Description("開檔狀態,VARCHAR,50,NONE")]
        開檔狀態,
    }

}
