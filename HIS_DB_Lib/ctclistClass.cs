using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Basic;

namespace HIS_DB_Lib
{
    public enum enum_ctclist
    {
        GUID,
        病歷號,
        病人姓名,
        領藥號,
        藥局代碼,
        就醫序號,
        處方箋序號,
        處方狀態,
        年齡,
        Regimen名稱,
        主分類,
        次分類,
        生日,
        性別,
        病房,
        病床,
        藥囑開始日期,
        藥囑結束日期,
        開立醫師,
        審核醫師,
        CTC分類代號,
        CTC分類中文,
        科別,
        身高,
        體重,
        BSA,
        藥品狀態,
        Performance_status,
        細胞型態,
        檢查驗資料,
        XRAY文字,
        EKG文字,
        Pulmdata,
        診斷,
        癌症用藥途徑,
        加入時間,
    }
    public class ctclistClass
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("hhisnum")]
        public string 病歷號 { get; set; }
        [JsonPropertyName("hnamec")]
        public string 病人姓名 { get; set; }
        [JsonPropertyName("udppcsn")]
        public string 領藥號 { get; set; }
        [JsonPropertyName("hcasetyp")]
        public string 藥局代碼 { get; set; }
        [JsonPropertyName("hcaseno")]
        public string 就醫序號 { get; set; }
        [JsonPropertyName("udrelseq")]
        public string 處方箋序號 { get; set; }
        [JsonPropertyName("udTitle")]
        public string 處方狀態 { get; set; }
        [JsonPropertyName("age")]
        public string 年齡 { get; set; }
        [JsonPropertyName("regname")]
        public string Regimen名稱 { get; set; }
        [JsonPropertyName("canmname")]
        public string 主分類 { get; set; }
        [JsonPropertyName("cansname")]
        public string 次分類 { get; set; }
        [JsonPropertyName("hbirthdt")]
        public string 生日 { get; set; }
        [JsonPropertyName("hsex")]
        public string 性別 { get; set; }
        [JsonPropertyName("hnursta")]
        public string 病房 { get; set; }
        [JsonPropertyName("hbedno")]
        public string 病床 { get; set; }
        [JsonPropertyName("udbgndtRage")]
        public string 藥囑開始日期 { get; set; }
        [JsonPropertyName("udenddt")]
        public string 藥囑結束日期 { get; set; }
        [JsonPropertyName("udoename")]
        public string 開立醫師 { get; set; }
        [JsonPropertyName("udptvsnam")]
        public string 審核醫師 { get; set; }
        [JsonPropertyName("reghbsag")]
        public string CTC分類代號 { get; set; }
        [JsonPropertyName("reghbsagnm")]
        public string CTC分類中文 { get; set; }
        [JsonPropertyName("hcursvcl")]
        public string 科別 { get; set; }
        [JsonPropertyName("hheight")]
        public string 身高 { get; set; }
        [JsonPropertyName("hweight")]
        public string 體重 { get; set; }
        [JsonPropertyName("bsa")]
        public string BSA { get; set; }
        //以上主要資訊
        //-----------------------------------------------------------------------------------
        [JsonPropertyName("udstatus")]//40以前:未開立,41:開立中,41以上:停藥中 
        public string 藥品狀態 { get; set; }
        [JsonPropertyName("perfstat")]
        public string Performance_status { get; set; }
        [JsonPropertyName("celltype")]
        public string 細胞型態 { get; set; }
        [JsonPropertyName("labdata")]
        public string 檢查驗資料 { get; set; }
        [JsonPropertyName("cxrdata")]
        public string XRAY文字 { get; set; }
        [JsonPropertyName("ekgdata")]
        public string EKG文字 { get; set; }
        [JsonPropertyName("pulmdata")]
        public string Pulmdata { get; set; }
        [JsonPropertyName("hdiagcod")]
        public string 診斷 { get; set; }
        [JsonPropertyName("injroute")]
        public string 癌症用藥途徑 { get; set; }

        [JsonPropertyName("udAry")]
        public List<ctclist_udAryClass> udAry { get; set; }
        [JsonPropertyName("changAry")]
        public List<ctclist_changAryClass> changAry { get; set; }
        [JsonPropertyName("ctcAry")]
        public List<ctclist_ctcAryClass> ctcAry { get; set; }
        [JsonPropertyName("noteAry")]
        public List<ctclist_noteAryClass> noteAry { get; set; }

        [JsonPropertyName("ctdate")]
        public string 加入時間 { get; set; }
    }


    public enum enum_ctclist_udAry
    {
        GUID,
        Master_GUID,
        病歷號,
        藥局代碼,
        醫囑序號,
        藥囑序號,
        服藥順序,
        REGIMEN編號,
        藥碼,
        藥囑名稱,
        自費,
        劑量,
        頻次,
        途徑,
        天數,
        開始時間,
        結束時間,
        藥品外型外觀,
        藥品使用,
        藥品下方註記,
        藥品圖片網址,
    }
    public enum enum_ctclist_changAry
    {
        GUID,
        Master_GUID,
        藥品名稱,
        變異時間,
        變異原因,
        變異內容,
    }
    public enum enum_ctclist_ctcAry
    {
        GUID,
        Master_GUID,
        歷經第幾次化療,
        開立日期,
        Regimen名稱,
    }
    public enum enum_ctclist_noteAry
    {
        GUID,
        Master_GUID,
        藥品名稱,
        調整與注意事項,
    }
    public class ctclist_udAryClass
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("Master_GUID")]
        public string Master_GUID { get; set; }
        [JsonPropertyName("hhisnum")]
        public string 病歷號 { get; set; }
        [JsonPropertyName("hcasetyp")]
        public string 藥局代碼 { get; set; }
        [JsonPropertyName("hcaseno")]
        public string 醫囑序號 { get; set; }
        [JsonPropertyName("udordseq")]
        public string 藥囑序號 { get; set; }
        [JsonPropertyName("udseqseq")]
        public string 服藥順序 { get; set; }
        [JsonPropertyName("udstaseq")]
        public string REGIMEN編號 { get; set; }
        [JsonPropertyName("uddrgno")]
        public string 藥碼 { get; set; }
        [JsonPropertyName("udmdpnam")]
        public string 藥囑名稱 { get; set; }
        [JsonPropertyName("udselbuy")]
        public string 自費 { get; set; }
        [JsonPropertyName("uddosage")]
        public string 劑量 { get; set; }
        [JsonPropertyName("udfreqn")]
        public string 頻次 { get; set; }
        [JsonPropertyName("udroute")]
        public string 途徑 { get; set; }
        [JsonPropertyName("uddurat")]
        public string 天數 { get; set; }
        [JsonPropertyName("udbgndt")]
        public string 開始日 { get; set; }
        [JsonPropertyName("udbgntm")]
        public string 開始時間 { get; set; }
        [JsonPropertyName("udenddt")]
        public string 結束日 { get; set; }
        [JsonPropertyName("udendtm")]
        public string 結束時間 { get; set; }

        [JsonPropertyName("coldesch")]
        public string 藥品外型外觀 { get; set; }
        [JsonPropertyName("aprdesch")]
        public string 藥品使用 { get; set; }
        [JsonPropertyName("udwords")]
        public string 藥品下方註記 { get; set; }
        [JsonPropertyName("udpicUrl")]
        public string 藥品圖片網址 { get; set; }

        
    }
    public class ctclist_changAryClass
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("Master_GUID")]
        public string Master_GUID { get; set; }
        [JsonPropertyName("udmdpnam")]
        public string 藥品名稱 { get; set; }
        [JsonPropertyName("usdate")]
        public string 變異日期 { get; set; }
        [JsonPropertyName("ustime")]
        public string 變異時間 { get; set; }
        [JsonPropertyName("varrsn")]
        public string 變異原因 { get; set; }
        [JsonPropertyName("vardata")]
        public string 變異內容 { get; set; }
    }
    public class ctclist_ctcAryClass
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("Master_GUID")]
        public string Master_GUID { get; set; }
        [JsonPropertyName("ctcseq")]
        public string 歷經第幾次化療 { get; set; }
        [JsonPropertyName("udbgndt")]
        public string 開立日期 { get; set; }
        [JsonPropertyName("regname")]
        public string Regimen名稱 { get; set; }
    }
    public class ctclist_noteAryClass
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("Master_GUID")]
        public string Master_GUID { get; set; }
        [JsonPropertyName("dgname")]
        public string 藥品名稱 { get; set; }
        [JsonPropertyName("dgnote")]
        public string 調整與注意事項 { get; set; }
    }
}
