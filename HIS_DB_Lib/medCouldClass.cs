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
    [EnumDescription("medicine_page_cloud")]
    public enum enum_雲端藥檔
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
        [Description("藥品條碼1,VARCHAR,200,NONE")]
        藥品條碼1,
        [Description("藥品條碼2,TEXT,50,NONE")]
        藥品條碼2,
        [Description("警訊藥品,VARCHAR,10,NONE")]
        警訊藥品,
        [Description("高價藥品,VARCHAR,10,NONE")]
        高價藥品,
        [Description("生物製劑,VARCHAR,10,NONE")]
        生物製劑,
        [Description("管制級別,VARCHAR,10,NONE")]
        管制級別,
        [Description("圖片網址,VARCHAR,500,NONE")]
        圖片網址,
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
