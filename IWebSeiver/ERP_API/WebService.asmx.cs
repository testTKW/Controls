
using Kingdee.BOS.WebApi.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ERP_API
{
    /// <summary>
    /// WebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod(Description = "Hello World")]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string[] getData(string DocType, String InputDTOXml)
        {

            try
            {
                switch (DocType)
                {
                    //case "WPLAN"://动获取ERP工单信息
                    //    DataSet ds = SqlDb.GetDataSetByXml(InputDTOXml);
                    //    DataTable dt = ds.Tables[0];//获取所有的数据
                    //    //读取明细
                    //    string IsSucess = "OK";
                    //    string xmlDate = InputDTOXml;
                    //    string[] result = { IsSucess, xmlDate };

                    //    return result;

                    //手动获取K3工单信息
                    #region 手动获取K3工单信息
                    case "WPLAN"://动获取ERP工单信息
                        DataSet ds = SqlDb.GetDataSetByXml(InputDTOXml);
                        DataTable dt = ds.Tables[0];//获取所有的数据
                        string aa = dt.Rows[0]["LOWVALUE"].ToString();
                        string IsSucess = "";
                        string xmlDate = "";
                        //Xml--dan
                        string sds = SqlDb.OutPutESMasterFromWs(aa);
                        if (sds.Equals(""))
                        {
                            IsSucess = "NG";
                            xmlDate = "没有数据返回";

                        }
                        else
                        {
                            if (sds.Equals("<NewDataSet />"))
                            {
                                IsSucess = "NG";
                                xmlDate = "没有数据返回";
                            }
                            else
                            {
                                IsSucess = "OK";
                                xmlDate = sds;
                            }
                        }
                        string[] result = { IsSucess, xmlDate };
                        return result;
                    #endregion

                    //手动获取 委外ERP工单 信息
                    #region 手动获取委外ERP工单信息
                    case "WPLAN_OUTS"://动获取ERP工单信息
                        DataSet ds_OUTS = SqlDb.GetDataSetByXml(InputDTOXml);
                        DataTable dt_OUTS = ds_OUTS.Tables[0];//获取所有的数据
                        string WPLAN_OUTS = dt_OUTS.Rows[0]["LOWVALUE"].ToString();
                        string IsSucess_OUTS = "";
                        string xmlDate_OUTS = "";
                        //Xml--dan
                        string sds_OUTS = SqlDb.OutPutESMasterFromWs_OUTS(WPLAN_OUTS);
                        if (sds_OUTS.Equals(""))
                        {
                            IsSucess_OUTS = "NG";
                            xmlDate_OUTS = "没有数据返回";
                        }
                        else
                        {
                            if (sds_OUTS.Equals("<NewDataSet />"))
                            {
                                IsSucess_OUTS = "NG";
                                xmlDate_OUTS = "没有数据返回";
                            }
                            else
                            {
                                IsSucess_OUTS = "OK";
                                xmlDate_OUTS = sds_OUTS;
                            }
                        }
                        string[] result_OUTS = { IsSucess_OUTS, xmlDate_OUTS };
                        return result_OUTS;
                    #endregion

                    //K3工单物料需求信息
                    #region K3工单物料需求信息
                    case "WPLAN_MN"://动获取ERP工单信息
                        DataSet dsWPLAN_MO = SqlDb.GetDataSetByXml(InputDTOXml);
                        DataTable dtWPLAN_MO = dsWPLAN_MO.Tables[0];//获取所有的数据
                        string WPLAN_MN = dtWPLAN_MO.Rows[0]["LOWVALUE"].ToString();
                        string ERP_MO_SEQ = dtWPLAN_MO.Rows[1]["LOWVALUE"].ToString();
                        string IsSucessWPLAN_MO = "";
                        string xmlDateWPLAN_MO = "";
                        string sdsWPLAN_MO = SqlDb.OutPutESMasterFromWs_MN(WPLAN_MN, ERP_MO_SEQ);
                        if (sdsWPLAN_MO.Equals(""))
                        {
                            IsSucessWPLAN_MO = "NG";
                            xmlDateWPLAN_MO = "没有数据返回";
                        }
                        else
                        {
                            if (sdsWPLAN_MO.Equals("<NewDataSet />"))
                            {
                                IsSucessWPLAN_MO = "NG";
                                xmlDateWPLAN_MO = "没有数据返回";
                            }
                            else
                            {
                                IsSucessWPLAN_MO = "OK";
                                xmlDateWPLAN_MO = sdsWPLAN_MO;
                            }
                        }
                        string[] resultWPLAN_MO = { IsSucessWPLAN_MO, xmlDateWPLAN_MO };
                        return resultWPLAN_MO;
                    #endregion

                    //ERP 委外工单物料需求信息
                    #region ERP 委外工单物料需求信息
                    case "WPLAN_MN_OUTS"://动获取ERP工单信息
                        DataSet dsWPLAN_MO_OUTS = SqlDb.GetDataSetByXml(InputDTOXml);
                        DataTable dtWPLAN_MO_OUTS = dsWPLAN_MO_OUTS.Tables[0];//获取所有的数据
                        string WPLAN_MO_OUTS = dtWPLAN_MO_OUTS.Rows[0]["LOWVALUE"].ToString();
                        string WPLAN_MO_OUTS_SEQ = dtWPLAN_MO_OUTS.Rows[1]["LOWVALUE"].ToString();
                        string IsSucessWPLAN_MO_OUTS = "";
                        string xmlDateWPLAN_MO_OUTS = "";
                        string sdsWPLAN_MO_OUTS = SqlDb.OutPutESMasterFromWs_MN_OUTS(WPLAN_MO_OUTS, WPLAN_MO_OUTS_SEQ);
                        if (sdsWPLAN_MO_OUTS.Equals(""))
                        {
                            IsSucessWPLAN_MO_OUTS = "NG";
                            xmlDateWPLAN_MO_OUTS = "没有数据返回";
                        }
                        else
                        {
                            if (sdsWPLAN_MO_OUTS.Equals("<NewDataSet />"))
                            {
                                IsSucessWPLAN_MO_OUTS = "NG";
                                xmlDateWPLAN_MO_OUTS = "没有数据返回";
                            }
                            else
                            {
                                IsSucessWPLAN_MO_OUTS = "OK";
                                xmlDateWPLAN_MO_OUTS = sdsWPLAN_MO_OUTS;
                            }
                        }
                        string[] resultWPLAN_MO_OUTS = { IsSucessWPLAN_MO_OUTS, xmlDateWPLAN_MO_OUTS };
                        return resultWPLAN_MO_OUTS;
                    #endregion

                    //BOM
                    #region BOM
                    case "TB_PM_BOM_HD"://动获取ERP工单信息
                        DataSet dsBOM = SqlDb.GetDataSetByXml(InputDTOXml);
                        DataTable dtBOM = dsBOM.Tables[0];//获取所有的数据
                        string BOM = dtBOM.Rows[0]["LOWVALUE"].ToString();
                        string IsSucessBOM = "";
                        string xmlDateBOM = "";
                        string sdsBOM = SqlDb.OutPutESMasterFromWsBOM(BOM);
                        if (sdsBOM.Equals(""))
                        {
                            IsSucessBOM = "NG";
                            xmlDateBOM = "没有数据返回";
                        }
                        else
                        {
                            if (sdsBOM.Equals("<NewDataSet />"))
                            {
                                IsSucessBOM = "NG";
                                xmlDateBOM = "没有数据返回";
                            }
                            else
                            {
                                IsSucessBOM = "OK";
                                xmlDateBOM = sdsBOM;
                            }
                        }
                        string[] resultBOM = { IsSucessBOM, xmlDateBOM };
                        return resultBOM;
                    #endregion

                    //K3库存信息
                    #region K3库存信息
                    case "XCL"://动获取ERP工单信息
                        DataSet dsXCL = SqlDb.GetDataSetByXml(InputDTOXml);
                        DataTable dtXCL = dsXCL.Tables[0];//获取所有的数据
                        string STORE_ID = dtXCL.Rows[0]["LOWVALUE"].ToString();
                        if (dtXCL.Rows.Count >= 3)
                        {
                            string MTRL_ID = dtXCL.Rows[1]["LOWVALUE"].ToString();
                            string ORG_ID = dtXCL.Rows[2]["LOWVALUE"].ToString();
                            string IsSucessXCL = "";
                            string xmlDateXCL = "";
                            string sdsXCL = SqlDb.OutPutESMasterFromWsXCL(STORE_ID, MTRL_ID, ORG_ID);

                            if (sdsXCL.Equals(""))
                            {
                                IsSucessXCL = "NG";
                                xmlDateXCL = "没有数据返回";
                            }
                            else
                            {
                                if (sdsXCL.Equals("<NewDataSet />"))
                                {
                                    IsSucessXCL = "NG";
                                    xmlDateXCL = "没有数据返回";
                                }
                                else
                                {
                                    IsSucessXCL = "OK";
                                    xmlDateXCL = sdsXCL;
                                }
                            }
                            string[] resultXCL = { IsSucessXCL, xmlDateXCL };
                            return resultXCL;
                        }
                        else
                        {
                            string ORG_ID = dtXCL.Rows[1]["LOWVALUE"].ToString();
                            string IsSucessXCL = "";
                            string xmlDateXCL = "";
                            string kuoZi = "";
                            string sdsXCL = SqlDb.OutPutESMasterFromWsXCL(STORE_ID, kuoZi, ORG_ID);

                            if (sdsXCL.Equals(""))
                            {
                                IsSucessXCL = "NG";
                                xmlDateXCL = "没有数据返回";
                            }
                            else
                            {
                                if (sdsXCL.Equals("<NewDataSet />"))
                                {
                                    IsSucessXCL = "NG";
                                    xmlDateXCL = "没有数据返回";
                                }
                                else
                                {
                                    IsSucessXCL = "OK";
                                    xmlDateXCL = sdsXCL;
                                }
                            }
                            string[] resultXCL = { IsSucessXCL, xmlDateXCL };
                            return resultXCL;
                        }
                    #endregion

                    //采购订单信息
                    #region 采购订单信息
                    case "PO"://动获取ERP工单信息
                        DataSet dsPO = SqlDb.GetDataSetByXml(InputDTOXml);
                        DataTable dtPO = dsPO.Tables[0];//获取所有的数据
                        //初始化变量
                        string PO = "";
                        DateTime StartDate =Convert.ToDateTime("1997-01-01");
                        DateTime EndDate = Convert.ToDateTime("9999-01-01");
                        string IsSucessPO = "";
                        string xmlDatePO = "";
                        //判断单号是否为空
                        if (dtPO.Rows[0]["OPTCODE"].ToString() == "PO_ID")
                        {
                            #region 有采购订单号的查询
                            StartDate = Convert.ToDateTime("1997-01-01");
                            EndDate = Convert.ToDateTime("9999-01-01");
                            PO = dtPO.Rows[0]["LOWVALUE"].ToString();
                            string sdsPO = SqlDb.OutPutESMasterFromWsPO(PO, StartDate, EndDate);
                            if (sdsPO.Equals(""))
                            {
                                IsSucessPO = "NG";
                                xmlDatePO = "没有数据返回";
                            }
                            else
                            {
                                if (sdsPO.Equals("<NewDataSet />"))
                                {
                                    IsSucessPO = "NG";
                                    xmlDatePO = "没有数据返回";
                                }
                                else
                                {
                                    IsSucessPO = "OK";
                                    xmlDatePO = sdsPO;
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region 没有采购订单号，有时间段的查询
                            {
                                PO = "";
                                StartDate = Convert.ToDateTime(dtPO.Rows[0]["LOWVALUE"].ToString());
                                EndDate = Convert.ToDateTime(dtPO.Rows[1]["LOWVALUE"].ToString());
                                string sdsPO = SqlDb.OutPutESMasterFromWsPO(PO, StartDate, EndDate);
                                if (sdsPO.Equals(""))
                                {
                                    IsSucessPO = "NG";
                                    xmlDatePO = "没有数据返回";
                                }
                                else
                                {
                                    if (sdsPO.Equals("<NewDataSet />"))
                                    {
                                        IsSucessPO = "NG";
                                        xmlDatePO = "没有数据返回";
                                    }
                                    else
                                    {
                                        IsSucessPO = "OK";
                                        xmlDatePO = sdsPO;
                                    }
                                }
                            #endregion
                            }
                        }
                        string[] resultPO = { IsSucessPO, xmlDatePO };
                        return resultPO;

                    #endregion
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [WebMethod]
        public string[] setData(string DocType, String InputDTOXml)
        {
            //ApiClient client = new ApiClient("http://localhost/K3Cloud/");
            //var loginResult = client.Login("5e5762cbf5fd2d", "Administrator", "88888888", 2052);

            ApiClient client = new ApiClient(System.Configuration.ConfigurationManager.AppSettings["apiUrl"]);
            var loginResult = client.Login(System.Configuration.ConfigurationManager.AppSettings["ztId"], System.Configuration.ConfigurationManager.AppSettings["userId"], System.Configuration.ConfigurationManager.AppSettings["pwd"], 2052);

            List<int> list = new List<int>();
            //读取唯一序号
            SqlConnection conn = new SqlConnection(SqlDb.ConnectionString);

            conn.Open();
            SqlCommand command = conn.CreateCommand();
            string xmlDate = "";
            string IsSucess = "NG";
            //API接口连接成功
            if (loginResult)
            {
                try
                {
                    //string USER_ID = "";//创建人
                    string SUP_ID = "";//供应商
                    string sjson = "";//拼接json
                    string kcOrd = "";//库存
                    string REMARK = "";//备注
                    int QUEUE_ID = 0;//唯一序号
                    string CUST_ID = "";//客户
                    DateTime TRX_DATE = DateTime.Now;
                    DataSet ds = SqlDb.GetDataSetByXml(InputDTOXml);
                    string DEPT_ID = "";//部门
                    string MO_SEQ = "";//源单行号
                    DataTable dt = ds.Tables[0];//获取所有的数据
                    string PO_ORG_ID = "";
                    string ORG_ID = "";
                    string SO_ORG_ID = "";//结算组织
                    string IS_CGWW = "";
                    string RKTYPE = "";
                    string IS_OUTS = "";//判断是否是委外,Y 是,N 否
                    string IS_BONDED = "";//内外销(内销 1, 外销 2)
                    string IS_PRE = "";//是否赠品
                    string REF_TYPE = "";//单据类型
                    string ERP_MO_SEQ = "";
                    //读取明细

                    switch (DocType)
                    {


                        #region 采购入库单（采购类型） R170C/R177C
                        case "R170C":
                        case "R177C":

                            command.CommandText = "SELECT F_ora_QUEUE_N FROM t_STK_InStock ";
                            using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                while (dr.Read())
                                {
                                    //开始读取数据了，接下来你想怎么样就怎么样了
                                    list.Add(Convert.ToInt32(dr[0]));
                                }
                            }
                            conn.Close();
                            //调用API生成单据
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    //取值
                                    //string number = dt.Rows[i]["ERP_MO"].ToString();
                                    //QUEUE_ID	INT64	唯一序号
                                    //TRX_DATE	DATETIME	交易时间
                                    //STORE_ID	VARCHAR	仓库编码
                                    //SUP_ID	VARCHAR	供应商编码
                                    //PO_ID	VARCHAR	采购单号
                                    //PO_SEQ	VARCHAR	采购单行号
                                    //MTRL_ID	VARCHAR	物料编码
                                    //QUANTITY	NUMERICE	数量
                                    //REMARK	VARCHAR	备注
                                    // PO_ORG_ID	VARCHAR	采购组织
                                    //ORG_ID VARCHAR	收料组织
                                    //string IS_OUTS = "";//判断是否是委外,Y 是,N 否
                                    string PO_ID = dt.Rows[i]["PO_ID"].ToString();
                                    QUEUE_ID = Convert.ToInt32(dt.Rows[i]["QUEUE_ID"].ToString());
                                    TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"].ToString());
                                    string STORE_ID = dt.Rows[i]["STORE_ID"].ToString();
                                    SUP_ID = dt.Rows[i]["SUP_ID"].ToString();//供应商编码
                                    if (SUP_ID.Length == 1)
                                    {
                                        SUP_ID = "00" + SUP_ID;
                                    }
                                    else if (SUP_ID.Length == 2)
                                    {
                                        SUP_ID = "0" + SUP_ID; ;
                                    }
                                    else if (SUP_ID.Length > 2)
                                    {
                                        SUP_ID = dt.Rows[i]["SUP_ID"].ToString();//供应商编码
                                    }
                                    string MTRL_ID = dt.Rows[i]["MTRL_ID"].ToString();
                                    double QUANTITY = Convert.ToDouble(dt.Rows[i]["QUANTITY"]);
                                    //USER_ID = dt.Rows[i]["USER_ID"].ToString();
                                    REMARK = dt.Rows[i]["REMARK"].ToString();
                                    string PO_SEQ = dt.Rows[i]["PO_SEQ"].ToString();
                                    PO_ORG_ID = dt.Rows[i]["PO_ORG_ID"].ToString();
                                    ORG_ID = dt.Rows[i]["ORG_ID"].ToString();
                                    if (dt.Rows[i]["IS_OUTS"].ToString() == "Y")//判断物料属性是否是委外
                                    {
                                        //IS_OUTS = "RKD03_SYS";
                                        IS_OUTS = "20CGRK";
                                        IS_CGWW = "WW";
                                        RKTYPE = "QLI";
                                    }
                                    else
                                    {
                                        //IS_OUTS = "RKD01_SYS";
                                        IS_OUTS = "10CGRK";
                                        IS_CGWW = "CG";
                                    }
                                    conn.Open();
                                    command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                    string dw = "";
                                    using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr1.Read())
                                        {
                                            dw = Convert.ToString(dr1[0]);
                                        }
                                    }
                                    conn.Close();
                                    conn.Open();
                                    command.CommandText = "select t1.FID,t2.FENTRYID from t_PUR_POOrder t1 inner join t_PUR_POOrderEntry t2 on t1.FID=t2.FID  where  t1.FBILLNO = '" + PO_ID + "' and t2.FSEQ =  " + PO_SEQ;
                                    int fid = 0;
                                    int fenttyid = 0;
                                    using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr.Read())
                                        {
                                            fid = Convert.ToInt32(dr[0]);
                                            fenttyid = Convert.ToInt32(dr[1]);
                                        }
                                    }
                                    conn.Close();
                                    if (i > 0)
                                    {
                                        sjson += ",";
                                    }
                                    //调用且赋值

                                    sjson += " {\"FRowType\": \"Standard\",\"FMaterialId\": {\"FNumber\": \"" + MTRL_ID + "\"},\"FUnitID\": {\"FNumber\": \"" + dw + "\"},\"FRealQty\": " + QUANTITY + ",\"FPriceUnitID\": {\"FNumber\": \"" + dw + "\"},\"FStockId\": {\"FNumber\": \"" + STORE_ID + "\"},\"FPOOrderNo\":\"" + PO_ID + "\",\"FWWInType\":\"" + RKTYPE + "\",\"FStockStatusId\": {\"FNumber\": \"KCZT01_SYS\"},\"FGiveAway\": false,\"FSRCBILLTYPEID\":\"PUR_PurchaseOrder\",\"FSRCBillNo \":\"" + PO_ID + "\",\"FSRCRowId\":" + PO_SEQ + ",\"FNote\": \"" + REMARK + "\",\"FOWNERTYPEID\": \"BD_OwnerOrg\",\"FCheckInComing\": false,\"FIsReceiveUpdateStock\": false,\"FPriceBaseQty\": " + QUANTITY + ",\"FRemainInStockUnitId\": {\"FNumber\": \"" + dw + "\"},\"FBILLINGCLOSE\": false,\"FRemainInStockQty\": " + QUANTITY + ",\"FAPNotJoinQty\": " + QUANTITY + ",\"FRemainInStockBaseQty\": " + QUANTITY + ",\"FEntryTaxRate\": 13.00,\"FOWNERID\": {\"FNumber\": \"" + ORG_ID + "\"},\"FParentOwnerTypeId\": \"BD_OwnerOrg\",\"FMoEntrySeq\": " + PO_SEQ + ",\"FParentOwnerId\": {\"FNumber\": \"" + kcOrd + "\"},\"FInStockEntry_Link\": [{\"FInStockEntry_Link_FRuleId\": \"PUR_PurchaseOrder-STK_InStock\", \"FInStockEntry_Link_FSTableName\": \"t_PUR_POOrderEntry\",\"FInStockEntry_Link_FSBillId\": " + fid + ",\"FInStockEntry_Link_FSId\": " + fenttyid + "}]}";

                                }
                                //单据头 

                                string sjsonT = "{\"Creator\": \"\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"true\",\"FISINTERLEGALPERSON\":\"true\",\"Model\": {\"FID\": 0,\"FBillTypeID\": {\"FNUMBER\": \"" + IS_OUTS + "\"},\"FBusinessType\":\"" + IS_CGWW + "\",\"FDate\": \"" + TRX_DATE + "\",\"FStockOrgId\": {\"FNumber\": \"" + ORG_ID + "\"},\"FStockerId\": {\"FNumber\": \"HW0039\"},\"FDemandOrgId\": {\"FNumber\": \"" + ORG_ID + "\"},\"FPurchaseOrgId\": {\"FNumber\": \"" + PO_ORG_ID + "\"},\"FSupplierId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FSupplyId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FSupplyAddress\": \"\",\"FSettleId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FChargeId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FOwnerTypeIdHead\": \"BD_OwnerOrg\",\"FOwnerIdHead\": {\"FNumber\": \"" + ORG_ID + "\"},\"FProviderContactID\": {\"FCONTACTNUMBER\": \"CXR005582\"},\"FSplitBillType\": \"A\",\"FInStockFin\": {\"FSettleOrgId\": {\"FNumber\": \"" + PO_ORG_ID + "\"},\"FSettleTypeId\": {\"FNumber\": \"JSFS03_SYS\"},\"FPayConditionId\": {\"FNumber\": \"FKTJ07_SYS\"},\"FSettleCurrId\": {\"FNumber\": \"PRE001\"},\"FIsIncludedTax\": true,\"FPriceTimePoint\": \"1\",\"FLocalCurrId\": {\"FNumber\": \"PRE001\"},\"FExchangeTypeId\": {\"FNumber\": \"HLTX01_SYS\"},\"FExchangeRate\": 1.0,\"FISPRICEEXCLUDETAX\": true}, \"F_ora_QUEUE_N\": " + QUEUE_ID + ", \"FInStockEntry\": [" + sjson + "   ]}}";

                                if (!list.Contains(QUEUE_ID))//不包含唯一序号才保存
                                {
                                    // 调用Web API接口服务，保存

                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "STK_InStock", sjsonT });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        //MessageBox.Show("生成成功，单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】");
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        // MessageBox.Show("同步失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"].ToString());
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"] + sjsonT;
                                        // xmlDate = sjsonT;

                                    }
                                }
                                else
                                {
                                    xmlDate = "唯一序号在系统已经存在";
                                }
                            }

                            break;
                        #endregion

                        #region 采购入库单（委外类型） R177C(数据传输是否包含组织?)
                        //case "R177C":

                        //    command.CommandText = "SELECT F_ora_QUEUE_N FROM t_STK_InStock ";
                        //    using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                        //    {
                        //        while (dr.Read())
                        //        {
                        //            //开始读取数据了，接下来你想怎么样就怎么样了
                        //            list.Add(Convert.ToInt32(dr[0]));
                        //        }
                        //    }
                        //    conn.Close();
                        //    //调用API生成单据
                        //    if (dt.Rows.Count > 0)
                        //    {
                        //        for (int i = 0; i < dt.Rows.Count; i++)
                        //        {
                        //            //取值
                        //            //string number = dt.Rows[i]["ERP_MO"].ToString();
                        //            //QUEUE_ID	INT64	唯一序号
                        //            //TRX_DATE	DATETIME	交易时间
                        //            //STORE_ID	VARCHAR	仓库编码
                        //            //SUP_ID	VARCHAR	供应商编码
                        //            //PO_ID	VARCHAR	采购单号
                        //            //PO_SEQ	VARCHAR	采购单行号
                        //            //MTRL_ID	VARCHAR	物料编码
                        //            //QUANTITY	NUMERICE	数量
                        //            //REMARK	VARCHAR	备注
                        //            // PO_ORG_ID	VARCHAR	收料组织
                        //            //ORG_ID VARCHAR	采购组织
                        //            string PO_ID = dt.Rows[i]["PO_ID"].ToString();
                        //            QUEUE_ID = Convert.ToInt32(dt.Rows[i]["QUEUE_ID"].ToString());
                        //            TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"].ToString());
                        //            string STORE_ID = dt.Rows[i]["STORE_ID"].ToString();
                        //            SUP_ID = dt.Rows[i]["SUP_ID"].ToString();
                        //            string MTRL_ID = dt.Rows[i]["MTRL_ID"].ToString();
                        //            double QUANTITY = Convert.ToDouble(dt.Rows[i]["QUANTITY"]);
                        //            //USER_ID = dt.Rows[i]["USER_ID"].ToString();
                        //            REMARK = dt.Rows[i]["REMARK"].ToString();
                        //            string PO_SEQ = dt.Rows[i]["PO_SEQ"].ToString();
                        //            PO_ORG_ID = dt.Rows[i]["PO_ORG_ID"].ToString();
                        //            ORG_ID = dt.Rows[i]["ORG_ID"].ToString();
                        //            conn.Open();
                        //            command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                        //            string dw = "";
                        //            using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                        //            {
                        //                while (dr1.Read())
                        //                {
                        //                    dw = Convert.ToString(dr1[0]);
                        //                }
                        //            }
                        //            conn.Close();
                        //            conn.Open();
                        //            command.CommandText = "select t1.FID,t2.FENTRYID from t_PUR_POOrder t1 inner join t_PUR_POOrderEntry t2 on t1.FID=t2.FID  where  t1.FBILLNO = '" + PO_ID + "' and t2.FSEQ =  " + PO_SEQ;
                        //            int fid = 0;
                        //            int fenttyid = 0;
                        //            using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                        //            {
                        //                while (dr.Read())
                        //                {
                        //                    fid = Convert.ToInt32(dr[0]);
                        //                    fenttyid = Convert.ToInt32(dr[1]);
                        //                }
                        //            }
                        //            conn.Close();
                        //            if (i > 0)
                        //            {
                        //                sjson += ",";
                        //            }
                        //            //调用且赋值
                        //            //sjson += "{\"FMaterialId\": {\"FNumber\":\"" + MTRL_ID + "\"},\"FMaterialDesc\":\"\",\"FUnitId\": {\"FNumber\":\"kg\"},\"FActReceiveQty\": " + QUANTITY + ",\"FPreDeliveryDate\":\"" + TRX_DATE + "\",\"FSUPDELQTY\": " + QUANTITY + ",\"FPriceUnitId\": {\"FNumber\":\"kg\"},\"FStockID\": {\"FNumber\":\"" + STORE_ID + "\"},\"FStockStatusId\": {\"FNumber\":\"KCZT02_SYS\"},\"FGiveAway\": false,\"FNote\": \"" + REMARK + "\",\"FCtrlStockInPercent\": true,\"FCheckInComing\": false,\"FIsReceiveUpdateStock\": false,\"FStockInMaxQty\": " + QUANTITY + ",\"FStockInMinQty\": " + QUANTITY + ",\"FEntryTaxRate\": 13.00,\"FPriceBaseQty\": " + QUANTITY + ",\"FStockUnitID\": {\"FNumber\":\"kg\"},\"FStockQty\": " + QUANTITY + ",\"FStockBaseQty\": " + QUANTITY + ",\"F_ora_PO_SEQ\": \"" + PO_SEQ + "\",\"FOWNERID\": {\"FNumber\": \""+SUP_ID+"\"},\"FActlandQty\": " + QUANTITY + "}";
                        //            sjson += " {\"FRowType\": \"Standard\",\"FMaterialId\": {\"FNumber\": \"" + MTRL_ID + "\"},\"FUnitID\": {\"FNumber\": \"" + dw + "\"},\"FRealQty\": " + QUANTITY + ",\"FPriceUnitID\": {\"FNumber\": \"" + dw + "\"},\"FStockId\": {\"FNumber\": \"" + STORE_ID + "\"},\"FStockStatusId\": {\"FNumber\": \"KCZT01_SYS\"},\"FGiveAway\": false,\"FSRCBillNo \":\"" + PO_ID + "\",\"FSRCRowId\":" + PO_SEQ + ",\"FPOOrderNo\":\"" + PO_ID + "\",\"FNote\": \"" + REMARK + "\",\"FOWNERTYPEID\": \"BD_OwnerOrg\",\"FCheckInComing\": false,\"FIsReceiveUpdateStock\": false,\"FPriceBaseQty\": " + QUANTITY + ",\"FRemainInStockUnitId\": {\"FNumber\": \"" + dw + "\"},\"FBILLINGCLOSE\": false,\"FRemainInStockQty\": " + QUANTITY + ",\"FAPNotJoinQty\": " + QUANTITY + ",\"FRemainInStockBaseQty\": " + QUANTITY + ",\"FEntryTaxRate\": 13.00,\"FOWNERID\": {\"FNumber\": \"" + PO_ORG_ID + "\"}, \"FInStockEntry_Link\": [{\"FInStockEntry_Link_FFlowId\": \"\",\"FInStockEntry_Link_FFlowLineId\": \"\",\"FInStockEntry_Link_FRuleId\": \"PUR_PurchaseOrder-STK_InStock\",\"FInStockEntry_Link_FSTableName\": \"t_PUR_POOrderEntry\",\"FInStockEntry_Link_FSBillId\": " + fid + ",\"FInStockEntry_Link_FSId\": " + fenttyid + "}]}";

                        //        }
                        //        //单据头 
                        //        //string sjsonT = "{\"Creator\": \"\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"false\",\"Model\": {\"FID\": 0,\"FBillTypeID\": {\"FNUMBER\": \"SLD01_SYS\"},\"FDate\": \"" + TRX_DATE + "\",\"FStockOrgId\": {\"FNumber\": \"" + PO_ORG_ID + "\"},\"FDemandOrgId\": {\"FNumber\": \"101\"},\"FPurchaseOrgId\": {\"FNumber\": \"" + ORG_ID + "\"},\"FPurOrgId\": {\"FNumber\": \"101\"},\"FSupplierId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FSupplyId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FSupplyAddress\": \"\",\"FSettleId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FChargeId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FOwnerTypeIdHead\": \"BD_Supplier\",\"FOwnerIdHead\": {\"FNumber\": \"" + SUP_ID + "\"},\"FIsInsideBill\": false,\"FIsMobile\": false,\"FProviderContactId\": {\"FCONTACTNUMBER\": \"CXR005578\"},\"FIsChangeQty\": false,\"F_ora_QUEUE_N\": " + QUEUE_ID + ", \"FinanceEntity\": {\"FSettleOrgId\": {\"FNumber\": \"101\"},\"FSettleModeId\": {\"FNumber\": \"JSFS03_SYS\"},\"FSettleCurrId\": {\"FNumber\": \"PRE001\"},\"FPayConditionId\": {\"FNumber\": \"FKTJ12_SYS\"},\"FIsIncludedTax\": true,\"FPricePoint\": \"1\",\"FLocalCurrId\": {\"FNumber\": \"PRE001\"},\"FExchangeTypeId\": {\"FNumber\": \"HLTX01_SYS\"},\"FExchangeRate\": 1.0,\"FISPRICEEXCLUDETAX\": true},\"FDetailEntity\": [" + sjson + "   ]}}";
                        //        string sjsonT = "{\"Creator\": \"\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"false\",\"Model\": {\"FID\": 0,\"FBillTypeID\": {\"FNUMBER\": \"RKD03_SYS\"},\"FDate\": \"" + TRX_DATE + "\",\"FStockOrgId\": {\"FNumber\": \"101\"},\"FStockerId\": {\"FNumber\": \"HW0039\"},\"FDemandOrgId\": {\"FNumber\": \"101\"},\"FPurchaseOrgId\": {\"FNumber\": \"" + ORG_ID + "\"},\"FSupplierId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FSupplyId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FSupplyAddress\": \"\",\"FSettleId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FChargeId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FOwnerTypeIdHead\": \"BD_OwnerOrg\",\"FOwnerIdHead\": {\"FNumber\": \"" + PO_ORG_ID + "\"},\"FProviderContactID\": {\"FCONTACTNUMBER\": \"CXR005582\"},\"FSplitBillType\": \"A\",\"FInStockFin\": {\"FSettleOrgId\": {\"FNumber\": \"101\"},\"FSettleTypeId\": {\"FNumber\": \"JSFS03_SYS\"},\"FPayConditionId\": {\"FNumber\": \"FKTJ07_SYS\"},\"FSettleCurrId\": {\"FNumber\": \"PRE001\"},\"FIsIncludedTax\": true,\"FPriceTimePoint\": \"1\",\"FLocalCurrId\": {\"FNumber\": \"PRE001\"},\"FExchangeTypeId\": {\"FNumber\": \"HLTX01_SYS\"},\"FExchangeRate\": 1.0,\"FISPRICEEXCLUDETAX\": true}, \"F_ora_QUEUE_N\": " + QUEUE_ID + ", \"FInStockEntry\": [" + sjson + "  ]}}";

                        //        if (!list.Contains(QUEUE_ID))//不包含唯一序号才保存
                        //        {
                        //            // 调用Web API接口服务，保存
                        //            String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "STK_InStock", sjsonT });

                        //            JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                        //            if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                        //            {
                        //                //MessageBox.Show("生成成功，单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】");
                        //                xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                        //                IsSucess = "OK";
                        //            }
                        //            else
                        //            {
                        //                // MessageBox.Show("同步失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"].ToString());
                        //                xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];

                        //            }
                        //        }
                        //        else
                        //        {
                        //            xmlDate = "唯一序号在系统已经存在";
                        //        }
                        //    }

                        //    break;
                        #endregion

                        #region 客供料收料 R171C
                        //QUEUE_ID	INT64	唯一序号
                        //TRX_DATE	DATETIME	交易时间
                        //STORE_ID	VARCHAR	仓库编码
                        //CUST_ID	VARCHAR	客户编码
                        //MTRL_ID	VARCHAR	物料编码
                        //QUANTITY	NUMERICE	数量
                        //REMARK	VARCHAR	备注
                        //FACT_ID	VARCHAR	库存组织
                        case "R171C":
                            command.CommandText = "SELECT F_ora_QUEUE_N FROM T_STK_OEMINSTOCK ";
                            using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                while (dr.Read())
                                {
                                    //开始读取数据了，接下来你想怎么样就怎么样了
                                    list.Add(Convert.ToInt32(dr[0]));
                                }
                            }
                            conn.Close();
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    QUEUE_ID = Convert.ToInt32(dt.Rows[i]["QUEUE_ID"].ToString());
                                    TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"].ToString());
                                    string STORE_ID = dt.Rows[i]["STORE_ID"].ToString();
                                    CUST_ID = dt.Rows[i]["CUST_ID"].ToString();
                                    if (CUST_ID.Length == 1)
                                    {
                                        CUST_ID = "00" + CUST_ID;
                                    }
                                    else if (CUST_ID.Length == 2)
                                    {
                                        CUST_ID = '0' + CUST_ID;
                                    }
                                    string MTRL_ID = dt.Rows[i]["MTRL_ID"].ToString();
                                    double QUANTITY = Convert.ToDouble(dt.Rows[i]["QUANTITY"]);
                                    REMARK = dt.Rows[i]["REMARK"].ToString();
                                    kcOrd = dt.Rows[i]["ORG_ID"].ToString();
                                    //string PO_SEQ = dt.Rows[i]["PO_SEQ"].ToString();
                                    conn.Open();
                                    command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                    string dw = "";
                                    using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr1.Read())
                                        {
                                            dw = Convert.ToString(dr1[0]);
                                        }
                                    }
                                    conn.Close();
                                    //查询库存状态
                                    conn.Open();
                                    command.CommandText = "select aa.FNUMBER from t_BD_Stock a left join  T_BD_STOCKSTATUS aa on aa.FMASTERID=a.FDEFSTOCKSTATUSID where a.FNUMBER='" + STORE_ID + "'";
                                    string zt = "";
                                    using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr1.Read())
                                        {
                                            zt = Convert.ToString(dr1[0]);
                                        }
                                    }
                                    conn.Close();
                                    if (i > 0)
                                    {
                                        sjson += ",";
                                    }
                                    //调用且赋值
                                    sjson += "{\"FMaterialId\": {\"FNumber\": \"" + MTRL_ID + "\"},\"FUnitID\": {\"FNumber\": \"" + dw + "\"},\"FQty\": " + QUANTITY + ",\"FStockId\": {\"FNumber\": \"" + STORE_ID + "\"},\"FStockStatusId\": {\"FNumber\": \"" + zt + "\"},\"FNoteEntry\": \"" + REMARK + "\",\"FOwnerTypeId\": \"BD_OwnerOrg\",\"FOwnerId\": {\"FNumber\": \"101\"},\"FKeeperTypeId\": \"BD_KeeperOrg\",\"FKeeperId\": {\"FNumber\": \"101\"}}";

                                }
                                //单据头 
                                string sjsonT = "{\"Creator\": \"administrator\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"true\",\"Model\": {\"FID\": 0,\"FBillTypeID\": {\"FNUMBER\": \"10KGRK\"},\"FStockOrgId\": {\"FNumber\": \"" + kcOrd + "\"},\"FDate\": \"" + TRX_DATE + "\",\"FCustId\": {\"FNumber\": \"" + CUST_ID + "\"}, \"F_ora_QUEUE_N\": " + QUEUE_ID + ",\"FBillEntry\": [" + sjson + "   ]}}";

                                if (!list.Contains(QUEUE_ID))//不包含唯一序号才保存
                                {
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "STK_OEMInStock", sjsonT });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        //MessageBox.Show("生成成功，单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】");
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        // MessageBox.Show("同步失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"].ToString());
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];

                                    }
                                }
                                else
                                {
                                    xmlDate = "唯一序号在系统已经存在";
                                }
                            }
                            break;

                        #endregion

                        #region 其它收料 R175C  (加字段)
                        case "R175C":
                            //QUEUE_ID	INT64	唯一序号
                            //TRX_DATE	DATETIME	交易时间
                            //STORE_ID	VARCHAR	仓库编码
                            //MTRL_ID	VARCHAR	物料编码
                            //QUANTITY	NUMERICE	数量
                            //REMARK	VARCHAR	备注
                            command.CommandText = "SELECT F_ora_QUEUE_N FROM T_STK_MISCELLANEOUS ";
                            using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                while (dr.Read())
                                {
                                    //开始读取数据了，接下来你想怎么样就怎么样了
                                    list.Add(Convert.ToInt32(dr[0]));
                                }
                            }
                            conn.Close();
                            if (dt.Rows.Count > 0)
                            {
                                string SHIPPER_TYPE = "";
                                string SHIPPER_ID = "";
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    QUEUE_ID = Convert.ToInt32(dt.Rows[i]["QUEUE_ID"].ToString());
                                    TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"].ToString());
                                    string STORE_ID = dt.Rows[i]["STORE_ID"].ToString();
                                    string MTRL_ID = dt.Rows[i]["MTRL_ID"].ToString();
                                    double QUANTITY = Convert.ToDouble(dt.Rows[i]["QUANTITY"]);
                                    REMARK = dt.Rows[i]["REMARK"].ToString();
                                    //string PO_SEQ = dt.Rows[i]["PO_SEQ"].ToString();
                                    ORG_ID = dt.Rows[i]["ORG_ID"].ToString();
                                    DEPT_ID = dt.Rows[i]["DEPT_ID"].ToString();//部门
                                    string ITEM_ID = Convert.ToString(dt.Rows[i]["ITEM_ID"]);//研发项目编码
                                    #region 部门
                                    if (dt.Rows[i]["DEPT_ID"].ToString().Length == 1)
                                    {
                                        DEPT_ID = "00" + dt.Rows[i]["DEPT_ID"].ToString();
                                    }
                                    else if (dt.Rows[i]["DEPT_ID"].ToString().Length == 2)
                                    {
                                        DEPT_ID = "0" + dt.Rows[i]["DEPT_ID"].ToString();
                                    }
                                    else if (dt.Rows[i]["DEPT_ID"].ToString().Length > 2)
                                    {
                                        DEPT_ID = dt.Rows[i]["DEPT_ID"].ToString();
                                    }
                                    #endregion
                                    SHIPPER_TYPE = dt.Rows[i]["SHIPPER_TYPE"].ToString();
                                    #region 根据客户给的报文,判断（1 业务组织 2供应商 3客户）

                                    if (SHIPPER_TYPE == "1")
                                    {
                                        SHIPPER_TYPE = "BD_OwnerOrg";
                                        SHIPPER_ID = dt.Rows[i]["SHIPPER_ID"].ToString();//货主编码
                                    }
                                    else if (SHIPPER_TYPE == "2")
                                    {
                                        SHIPPER_TYPE = "BD_Supplier";
                                        #region 供应商
                                        if (dt.Rows[i]["SHIPPER_ID"].ToString().Length == 1)
                                        {
                                            SHIPPER_ID = "00" + dt.Rows[i]["SHIPPER_ID"].ToString();
                                        }
                                        else if (dt.Rows[i]["SHIPPER_ID"].ToString().Length == 2)
                                        {
                                            SHIPPER_ID = "0" + dt.Rows[i]["SHIPPER_ID"].ToString();
                                        }
                                        else if (dt.Rows[i]["SHIPPER_ID"].ToString().Length > 2)
                                        {
                                            SHIPPER_ID = dt.Rows[i]["SHIPPER_ID"].ToString();
                                        }
                                        #endregion
                                    }
                                    else if (SHIPPER_TYPE == "3")
                                    {
                                        SHIPPER_TYPE = "BD_Customer";
                                        #region 客户
                                        if (dt.Rows[i]["SHIPPER_ID"].ToString().Length == 1)
                                        {
                                            SHIPPER_ID = "00" + dt.Rows[i]["SHIPPER_ID"].ToString();
                                        }
                                        else if (dt.Rows[i]["SHIPPER_ID"].ToString().Length == 2)
                                        {
                                            SHIPPER_ID = "0" + dt.Rows[i]["SHIPPER_ID"].ToString();
                                        }
                                        else if (dt.Rows[i]["SHIPPER_ID"].ToString().Length > 2)
                                        {
                                            SHIPPER_ID = dt.Rows[i]["SHIPPER_ID"].ToString();
                                        }
                                        #endregion
                                    }
                                    #endregion
                                    REF_TYPE = Convert.ToString(dt.Rows[i]["REF_TYPE"]);//单据类型
                                    #region 单据类型
                                    if (REF_TYPE == "1")
                                    {
                                        REF_TYPE = "10QTRK";
                                    }
                                    else if (REF_TYPE == "2")
                                    {
                                        REF_TYPE = "20QTRK";
                                        #region 研发项目编码
                                        if (dt.Rows[i]["ITEM_ID"].ToString().Length == 1)
                                        {
                                            ITEM_ID = "00" + dt.Rows[i]["ITEM_ID"].ToString();
                                        }
                                        else if (dt.Rows[i]["ITEM_ID"].ToString().Length == 2)
                                        {
                                            ITEM_ID = "0" + dt.Rows[i]["ITEM_ID"].ToString();
                                        }
                                        else if (dt.Rows[i]["ITEM_ID"].ToString().Length > 2)
                                        {
                                            ITEM_ID = dt.Rows[i]["ITEM_ID"].ToString();
                                        }
                                        #endregion
                                    }
                                    else if (REF_TYPE == "3")
                                    {
                                        REF_TYPE = "30QTRK";
                                    }
                                    else if (REF_TYPE == "4")
                                    {
                                        REF_TYPE = "40QTRK";
                                    }
                                    else if (REF_TYPE == "5")
                                    {
                                        REF_TYPE = "50QTRK";
                                    }
                                     else if (REF_TYPE == "6")
                                    {
                                        REF_TYPE = "60QTRK";
                                    }   
                                    else
                                    {
                                        REF_TYPE = "REF_TYPE";
                                    }
                                    #endregion

                                    conn.Open();
                                    command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                    string dw = "";
                                    using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr1.Read())
                                        {
                                            dw = Convert.ToString(dr1[0]);
                                        }
                                    }
                                    conn.Close();
                                    //查询库存状态
                                    conn.Open();
                                    command.CommandText = "select aa.FNUMBER from t_BD_Stock a left join  T_BD_STOCKSTATUS aa on aa.FMASTERID=a.FDEFSTOCKSTATUSID where a.FNUMBER='" + STORE_ID + "'";
                                    string zt = "";
                                    using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr1.Read())
                                        {
                                            zt = Convert.ToString(dr1[0]);
                                        }
                                    }
                                    conn.Close();
                                    if (i > 0)
                                    {
                                        sjson += ",";
                                    }
                                    //调用且赋值
                                    sjson += " {\"FMATERIALID\": {\"FNumber\": \"" + MTRL_ID + "\"},\"FUnitID\": {\"FNumber\": \"" + dw + "\"},\"FSTOCKID\": {\"FNumber\": \"" + STORE_ID + "\"},\"FSTOCKSTATUSID\": {\"FNumber\": \"" + zt + "\"},\"FQty\": " + QUANTITY + ",\"FEntryNote\": \"" + REMARK + "\",\"FOWNERTYPEID\": \"" + SHIPPER_TYPE + "\",\"FOWNERID\": {\"FNumber\": \"" + SHIPPER_ID + "\"},\"FKEEPERTYPEID\": \"BD_KeeperOrg\",\"FKEEPERID\": {\"FNumber\": \"" + ORG_ID + "\"},  \"F_RCGD_Assistant_Y\": {\"FNumber\": \""+ITEM_ID+"\"}}";

                                }
                                //单据头 
                                string sjsonT = "{\"Creator\": \"administrator\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"true\",\"Model\": {\"FID\": 0,\"FBillTypeID\": {\"FNUMBER\": \"" + REF_TYPE + "\"},\"FStockOrgId\": {\"FNumber\": \"" + ORG_ID + "\"},\"FStockDirect\": \"GENERAL\",\"FDate\": \"" + TRX_DATE + "\",\"FSUPPLIERID\": {\"FNumber\": \"\"},\"FDEPTID\": {\"FNumber\": \"" + DEPT_ID + "\"},\"FOwnerTypeIdHead\": \"" + SHIPPER_TYPE + "\",\"FOwnerIdHead\": {\"FNumber\": \"" + SHIPPER_ID + "\"},\"FBaseCurrId\": {\"FNumber\": \"PRE001\"}, \"F_ora_QUEUE_N\": " + QUEUE_ID + ",\"FEntity\": [" + sjson + "   ]}}";

                                if (!list.Contains(QUEUE_ID))//不包含唯一序号才保存
                                {
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "STK_MISCELLANEOUS", sjsonT });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        //MessageBox.Show("生成成功，单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】");
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        // MessageBox.Show("同步失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"].ToString());
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];

                                    }
                                }
                                else
                                {
                                    xmlDate = "唯一序号在系统已经存在";
                                }
                            }
                            break;
                        #endregion

                        #region 工单退料/工单不良品退料  R019(需要上下查)(自动带单位)
                        case "R019":
                            // QUEUE_ID	INT64	唯一序号
                            //TRX_DATE	DATETIME	交易时间
                            //STORE_ID	VARCHAR	仓库编码
                            //ERP_MO	VARCHAR	ERP工单编码
                            //MTRL_ID	VARCHAR	物料编码
                            //QUANTITY	NUMERICE	数量
                            //REMARK	VARCHAR	备注
                            command.CommandText = "SELECT F_ora_QUEUE_N FROM T_PRD_RETURNMTRL ";
                            using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                while (dr.Read())
                                {
                                    //开始读取数据了，接下来你想怎么样就怎么样了
                                    list.Add(Convert.ToInt32(dr[0]));
                                }
                            }
                            conn.Close();
                            if (dt.Rows.Count > 0)
                            {
                                string xmlda = "";
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    QUEUE_ID = Convert.ToInt32(dt.Rows[i]["QUEUE_ID"].ToString());
                                    TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"].ToString());
                                    string STORE_ID = dt.Rows[i]["STORE_ID"].ToString();
                                    string ERP_MO = dt.Rows[i]["ERP_MO"].ToString();//生产订单编码
                                    string MTRL_ID = dt.Rows[i]["MTRL_ID"].ToString();
                                    double QUANTITY = Convert.ToDouble(dt.Rows[i]["QUANTITY"]);
                                    REMARK = dt.Rows[i]["REMARK"].ToString();
                                    string TL_TYPE = dt.Rows[i]["TL_TYPE"].ToString();
                                    MO_SEQ = dt.Rows[i]["ERP_MO_SEQ"].ToString();//ERP工单行号
                                    kcOrd = dt.Rows[i]["ORG_ID"].ToString();
                                    string SEQ = dt.Rows[i]["SEQ"].ToString();//生产用料清单行号
                                    SUP_ID = dt.Rows[i]["SUP_ID"].ToString();
                                    string seqEntry = "";//生产订单分录ID
                                    string seq = "";

                                    if (SUP_ID.Length == 1)
                                    {
                                        SUP_ID = "00" + SUP_ID;
                                    }
                                    else if (SUP_ID.Length == 2)
                                    {
                                        SUP_ID = "0" + SUP_ID; ;
                                    }
                                    else if (SUP_ID.Length > 2)
                                    {
                                        SUP_ID = dt.Rows[i]["SUP_ID"].ToString();//供应商编码
                                    }
                                    conn.Open();
                                    command.CommandText = "select t1.FID,t1.FENTRYID,(FPICKEDQTY-FREPICKEDQTY-FSCRAPQTY-FSELPRCDRETURNQTY-FCONSUMEQTY*(1-FSCRAPRATE/100)) as ktl,t3.dw,t4.FBILLNO,t4.FMOEntryID ,t4.FMoId  from T_PRD_PPBOMENTRY t1 left join T_PRD_PPBOMENTRY_Q t2 on t1.FENTRYID = t2.FENTRYID and t1.fid = t2.FID left join (select t1.FMATERIALID,t1.FNUMBER wl,t3.FNUMBER dw from T_BD_MATERIAL t1 inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID) t3 on t1.FMATERIALID=t3.FMATERIALID left join T_PRD_PPBOM t4 on t4.fid = t1.FID  where t1.FMOBILLNO = '" + ERP_MO + "' and t1.FMOENTRYSEQ=" + MO_SEQ + " and t1.FSEQ=" + SEQ + " and t3.wl = '" + MTRL_ID + "'";
                                    int fid = 0;
                                    int fenttyid = 0;
                                    string dw = "";
                                    string billno = "";
                                    double ketuishuliang = 0;
                                    using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr.Read())
                                        {
                                            fid = Convert.ToInt32(dr[0]);//源单内码
                                            fenttyid = Convert.ToInt32(dr[1]);//源单单据体内码
                                            dw = Convert.ToString(dr[3]);//该物料金蝶系统单位
                                            billno = Convert.ToString(dr[4]);//物料清单编号
                                            ketuishuliang = Convert.ToDouble(dr[2]);//可退数量
                                            seqEntry = dr[5].ToString();//生产订单分录ID
                                            seq = dr[6].ToString();//生产订单ID
                                        }
                                    }
                                    conn.Close();

                                    #region 获取父级代码
                                    conn.Open();
                                    command.CommandText = " select t3.FNUMBER from T_PRD_MO t inner join T_PRD_MOENTRY t1 on t.FID=t1.FID left join T_BD_MATERIAL t3 on t1.FMaterialId=t3.FMATERIALID  where FBILLNO='" + ERP_MO + "' and t1.FSEQ=" + MO_SEQ + "";
                                    string fmaterial = "";
                                    using (SqlDataReader drf = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (drf.Read())
                                        {
                                            fmaterial = Convert.ToString(drf[0]);
                                        }
                                    }
                                    conn.Close();
                                    #endregion

                                    DEPT_ID = Convert.ToString(dt.Rows[i]["DEPT_ID"]);//部门编码
                                    #region 部门
                                    if (DEPT_ID.Length == 1)
                                    {
                                        DEPT_ID = "00" + DEPT_ID;
                                    }
                                    else if (DEPT_ID.Length == 2)
                                    {
                                        DEPT_ID = "0" + DEPT_ID;
                                    }
                                    #endregion
                                    //查询库存状态
                                    conn.Open();
                                    command.CommandText = "select aa.FNUMBER from t_BD_Stock a left join  T_BD_STOCKSTATUS aa on aa.FMASTERID=a.FDEFSTOCKSTATUSID where a.FNUMBER='" + STORE_ID + "'";
                                    string zt = "";
                                    using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr1.Read())
                                        {
                                            zt = Convert.ToString(dr1[0]);
                                        }
                                    }
                                    conn.Close();
                                    //调用且赋值
                                    //if (ketuishuliang >= QUANTITY)
                                    //{
                                    if (i > 0)
                                    {
                                        sjson += ",";
                                    }
                                    sjson += " {\"FMaterialId\": {\"FNumber\": \"" + MTRL_ID + "\"},\"FUnitID\": {\"FNumber\": \"" + dw + "\"},\"FAPPQty\": " + QUANTITY + ",\"FQty\": " + QUANTITY + ",\"FReturnType\": \"" + TL_TYPE + "\",\"FStockId\": {\"FNumber\": \"" + STORE_ID + "\"},\"FEntrtyMemo\": \"" + REMARK + "\",\"FSrcBillType\": \"PRD_PPBOM\",\"FSrcBillNo\": \"" + billno + "\",\"FSRCINTERID\":" + (fenttyid != 0 ? fenttyid : 0) + ",\"FPPBomBillNo\": \"" + billno + "\",\"FParentMaterialId\": {\"FNumber\": \"" + fmaterial + "\"},\"FMoId\": " + (seq != "" ? seq : "0") + ",\"FPPBOMEntryId\":" + fenttyid + ",\"FReserveType\": \"1\",\"FBASESTOCKQTY\": " + QUANTITY + ",\"FMoBillNo\": \"" + ERP_MO + "\",\"FEntryVmiBusiness\": false,\"FMoEntryId\": " + (seqEntry != "" ? seqEntry : "0") + ",\"FMoEntrySeq\": 1,\"FStockUnitId\": {\"FNumber\": \"" + dw + "\"},\"FStockAppQty\": " + QUANTITY + ",\"FStockQty\": " + QUANTITY + ",\"FStockStatusId\": {\"FNumber\": \"" + zt + "\"},\"FKeeperTypeId\": \"BD_KeeperOrg\",\"FKeeperId\": {\"FNumber\": \"" + kcOrd + "\"},\"FBaseUnitId\": {\"FNumber\": \"" + dw + "\"},\"FBaseAppQty\": " + QUANTITY + ",\"FBaseQty\": " + QUANTITY + ",\"FOwnerTypeId\": \"BD_OwnerOrg\",\"FOwnerId\": {\"FNumber\": \"" + kcOrd + "\"},\"FEntrySrcEnteryId\": " + fenttyid + ",\"FWorkShopId1\": {\"FNumber\": \"BM000001\"},\"FParentOwnerTypeId\": \"BD_OwnerOrg\",   \"FMoEntrySeq\": " + (MO_SEQ != "" ? MO_SEQ : "0") + ",\"FParentOwnerId\": {\"FNumber\": \"" + kcOrd + "\"},\"FEntity_Link\": [{\"FEntity_Link_FRuleId\": \"PRD_PPBOM2RETURNMTRL\", \"FEntity_Link_FSTableName\": \"T_PRD_PPBOMENTRY\",\"F_RCGD_Base_ZR\": {\"FNUMBER\":\"" + DEPT_ID + "\"},\"FEntity_Link_FSBillId\": " + fid + ",\"FEntity_Link_FSId\": " + fenttyid + "}] }";
                                    
                                    //}
                                    //else
                                    //{
                                    //    xmlda = xmlda + ";" + MTRL_ID + "物料退料量超过可退数量，请查证后再退！";
                                    //}

                                }
                                //单据头 
                                string sjsonT = "{\"Creator\": \"administrator\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"true\",\"Model\": {\"FID\": 0,\"FBillType\": {\"FNUMBER\": \"10SCTL\"},\"FDate\": \"" + TRX_DATE + "\",\"FStockOrgId\": {\"FNumber\": \"" + kcOrd + "\"},\"FPrdOrgId\": {\"FNumber\": \"" + kcOrd + "\"},\"FOwnerTypeId0\": \"BD_OwnerOrg\",\"FIsCrossTrade\": false,\"FVmiBusiness\": false,\"FIsOwnerTInclOrg\": false, \"F_ora_QUEUE_N\": " + QUEUE_ID + ",\"FEntity\": [" + sjson + "   ]}}";

                                if (!list.Contains(QUEUE_ID))//不包含唯一序号才保存
                                {
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "PRD_ReturnMtrl", sjsonT });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        //MessageBox.Show("生成成功，单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】");
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】" + xmlda;
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        // MessageBox.Show("同步失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"].ToString());
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"] + xmlda;

                                    }
                                }
                                else
                                {
                                    xmlDate = "唯一序号在系统已经存在";
                                }
                            }
                            break;
                        #endregion

                        #region 半成品入库/成品入库  R102
                        case "R102":
                            // QUEUE_ID	INT64	唯一序号
                            //TRX_DATE	DATETIME	交易时间
                            //STORE_ID	VARCHAR	仓库编码
                            //ERP_MO	VARCHAR	ERP工单编码
                            //MTRL_ID	VARCHAR	物料编码
                            //QUANTITY	NUMERICE	数量
                            //REMARK	VARCHAR	备注
                            command.CommandText = "SELECT F_ORA_QUEUE_N FROM T_PRD_INSTOCK ";
                            using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                while (dr.Read())
                                {
                                    //开始读取数据了，接下来你想怎么样就怎么样了
                                    list.Add(Convert.ToInt32(dr[0]));
                                }
                            }
                            conn.Close();
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    QUEUE_ID = Convert.ToInt32(dt.Rows[i]["QUEUE_ID"].ToString());
                                    TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"].ToString());
                                    string STORE_ID = dt.Rows[i]["STORE_ID"].ToString();
                                    string ERP_MO = dt.Rows[i]["ERP_MO"].ToString();//生产订单编码
                                    string MTRL_ID = dt.Rows[i]["MTRL_ID"].ToString();
                                    double QUANTITY = Convert.ToDouble(dt.Rows[i]["QUANTITY"]);
                                    REMARK = dt.Rows[i]["REMARK"].ToString();
                                    //string PO_SEQ = dt.Rows[i]["PO_SEQ"].ToString();
                                    MO_SEQ = dt.Rows[i]["ERP_MO_SEQ"].ToString();
                                    int RK_TYPE = Convert.ToInt32(dt.Rows[i]["RK_TYPE"]);
                                    kcOrd = dt.Rows[i]["ORG_ID"].ToString();
                                    ERP_MO_SEQ = dt.Rows[i]["ERP_MO_SEQ"].ToString();
                                    conn.Open();
                                    command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                    string dw = "";
                                    using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr1.Read())
                                        {
                                            dw = Convert.ToString(dr1[0]);
                                        }
                                    }
                                    conn.Close();
                                    conn.Open();
                                    command.CommandText = "select t1.fid,t2.FENTRYID from T_PRD_MO t1 inner join T_PRD_MOENTRY t2 on t1.fid = t2.fid  where  t1.FBILLNO = '" + ERP_MO + "' and t2.FSEQ =  " + MO_SEQ;
                                    int fid = 0;
                                    int fenttyid = 0;
                                    using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr.Read())
                                        {
                                            fid = Convert.ToInt32(dr[0]);
                                            fenttyid = Convert.ToInt32(dr[1]);
                                        }
                                    }
                                    conn.Close();

                                    if (i > 0)
                                    {
                                        sjson += ",";
                                    }
                                    //调用且赋值
                                    //sjson += "{\"FProductType\": \"1\",\"FCheckProduct\": false,\"FMaterialId\": {\"FNumber\": \"" + MTRL_ID + "\"}, \"FUnitID\": {\"FNumber\": \"" + dw + "\"},\"FMustQty\": " + QUANTITY + ",\"FRealQty\": " + QUANTITY + ",\"FOwnerTypeId\": \"BD_OwnerOrg\",\"FStockId\": {\"FNumber\": \"" + STORE_ID + "\"},\"FInStockType\": \"" + RK_TYPE + "\",\"FProductNumber\": \"" + ERP_MO + "\",\"FOwnerId\": {\"FNumber\": \"" + kcOrd + "\"},\"FStockStatusId\": {\"FNumber\": \"KCZT01_SYS\"},\"FKeeperTypeId\": \"BD_KeeperOrg\",\"FKeeperId\": {\"FNumber\": \"" + kcOrd + "\"},\"FIsAffectCost\": false,\"FSrcEntrySeq\": " + MO_SEQ + ",\"FMemo\": \"" + REMARK + "\",\"FEntity_Link\": [{\"FEntity_Link_FRuleId\": \"PRD_MO2MORPT\", \"FEntity_Link_FSTableName\": \"T_PRD_MOENTRY\",\"FEntity_Link_FSBillId\": " + fid + ",\"FEntity_Link_FSId\": " + fenttyid + "}]}";
                                    sjson += "{\"FSrcEntryId\":\"" + fenttyid + "\",\"FSrcBillType\":\"PRD_MO\"," +
                                             "\"FSrcBillNo\":\"" + ERP_MO + "\",\"FSrcEntrySeq\":\"" + ERP_MO_SEQ + "\",\"FMaterialId\":{\"FNumber\":\"" + MTRL_ID + "\"}," +
                                             "\"FProductType\":\"1\",\"FInStockType\":1,\"FMustQty\": " + QUANTITY + "," +
                                             "\"FRealQty\":" + QUANTITY + ",\"FUnitID\":{\"FNumber\":\"" + dw + "\"}," +
                                             "\"FStockId\":{\"FNumber\":\"" + STORE_ID + "\"},\"FOwnerTypeId\":\"BD_OwnerOrg\"," +
                                             "\"FOwnerId\":{\"FNumber\":\"" + kcOrd + "\"},\"FProduceDate\":\"" + TRX_DATE + "\"," +
                                             "\"FMoBillNo\":\"" + ERP_MO + "\",\"FSRCINTERID\":" + fid + ",\"FMOENTRYID\":" + fenttyid + ",\"FMOID\":" + fid + ",\"FMoEntrySeq\":\"" + ERP_MO_SEQ + "\",\"FBaseUnitId\":{\"FNumber\":\"" + dw + "\"}," +
                                             "\"FCostRate\":100,\"FEntity_Link\":[{\"FEntity_Link_FFlowId\":\"\"," +
                                             "\"FEntity_Link_FFlowLineId\":\"\",\"FEntity_Link_FRuleId\":\"PRD_MO2INSTOCK\"," +
                                             "\"FEntity_Link_FSTableName\":\"T_PRD_MOENTRY\",\"FEntity_Link_FSBillId\":\"" + fid + "\"," +
                                             "\"FEntity_Link_FSId\":\"" + fenttyid + "\",\"FEntity_Link_FBaseUnitQty\":" + QUANTITY + "}]}";
                                    //,\"FEntity_Link_FBaseUnitQtyOld\":1,\"FEntity_Link_FBaseUnitQty\":1

                                }
                                //单据头 
                                //string sjsonT = "{\"Creator\": \"\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"false\",\"Model\": {\"FID\": 0,\"FBillType\": {\"FNUMBER\": \"SCRKD02_SYS\"},\"FDate\": \"" + TRX_DATE + "\",\"FStockOrgId\": {\"FNumber\": \"" + kcOrd + "\"},\"FPrdOrgId\": {\"FNumber\": \"" + kcOrd + "\"},\"FOwnerTypeId0\": \"BD_OwnerOrg\",\"FReqType\": \"I\",\"FIsEntrust\": false,\"F_ora_QUEUE_N\": " + QUEUE_ID + ",\"FEntity\": [" + sjson + "   ]}}";
                                string sjsonT = "{\"Creator\":\"Demo\",\"NeedUpDateFields\":[\"\"],    \"IsAutoSubmitAndAudit\": \"true\",\"Model\":{\"FID\":0,\"FBillType\":{\"FNumber\":\"10SCRK\"},\"FDate\":\"" + TRX_DATE + "\",\"FStockOrgId\":{\"FNumber\":\"" + kcOrd + "\"},\"FPrdOrgId\":{\"FNumber\":\"" + kcOrd + "\"},\"FOwnerTypeId0\":\"BD_OwnerOrg\",\"FOwnerId0\":{\"FNumber\":\"" + kcOrd + "\"},\"FCreateDate\":\"" + TRX_DATE + "\",\"F_ora_QUEUE_N\": " + QUEUE_ID + ",\"FEntity\": [" + sjson + " ]}}";

                                if (!list.Contains(QUEUE_ID))//不包含唯一序号才保存
                                {
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "PRD_INSTOCK", sjsonT });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        //MessageBox.Show("生成成功，单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】");
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        // MessageBox.Show("同步失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"].ToString());
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];

                                    }
                                }
                                else
                                {
                                    xmlDate = "唯一序号在系统已经存在";
                                }
                            }
                            break;
                        #endregion

                        #region 委外入库  R177C
                        //case "R177C":
                        //    //    QUEUE_ID	INT64	唯一序号
                        //    //    TRX_DATE	DATETIME	交易时间
                        //    //    STORE_ID	VARCHAR	仓库编码
                        //    //    ERP_MO	VARCHAR	ERP工单编码
                        //    //    SUP_ID	VARCHAR	供应商编码
                        //    //    MTRL_ID	VARCHAR	物料编码
                        //    //    QUANTITY	NUMERICE	数量
                        //    //    REMARK	VARCHAR	备注
                        //    //    ERP_MO_SEQ	VARCHAR	ERP工单行号
                        //    command.CommandText = "SELECT F_ora_QUEUE_N FROM t_STK_InStock ";
                        //    using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                        //    {
                        //        while (dr.Read())
                        //        {
                        //            list.Add(Convert.ToInt32(dr[0]));
                        //        }
                        //    }
                        //    conn.Close();
                        //    if (dt.Rows.Count > 0)
                        //    {
                        //        for (int i = 0; i < dt.Rows.Count; i++)
                        //        {
                        //            QUEUE_ID = Convert.ToInt32(dt.Rows[i]["QUEUE_ID"].ToString());
                        //            TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"].ToString());
                        //            string STORE_ID = dt.Rows[i]["STORE_ID"].ToString();
                        //            //string ERP_MO = dt.Rows[i]["ERP_MO"].ToString();//工单编码
                        //            SUP_ID = dt.Rows[i]["SUP_ID"].ToString();
                        //            string MTRL_ID = dt.Rows[i]["MTRL_ID"].ToString();
                        //            double QUANTITY = Convert.ToDouble(dt.Rows[i]["QUANTITY"]);
                        //            REMARK = dt.Rows[i]["REMARK"].ToString();
                        //            string ERP_MO_SEQ = dt.Rows[i]["ERP_MO_SEQ"].ToString();
                        //            if (i > 0)
                        //            {
                        //                sjson += ",";
                        //            }
                        //            //调用且赋值
                        //            sjson += " {\"FRowType\": \"Standard\",\"FMaterialId\": {\"FNumber\": \"" + MTRL_ID + "\"},\"FUnitID\": {\"FNumber\": \"kg\"},\"FRealQty\": " + QUANTITY + ",\"FPriceUnitID\": {\"FNumber\": \"kg\"},\"FStockId\": {\"FNumber\": \"" + STORE_ID + "\"},\"FStockStatusId\": {\"FNumber\": \"KCZT01_SYS\"},\"FGiveAway\": false,\"FNote\": \"" + REMARK + "\",\"FOWNERTYPEID\": \"BD_OwnerOrg\",\"FCheckInComing\": false,\"FIsReceiveUpdateStock\": false,\"FPriceBaseQty\": " + QUANTITY + ",\"FRemainInStockUnitId\": {\"FNumber\": \"kg\"},\"FBILLINGCLOSE\": false,\"FRemainInStockQty\": " + QUANTITY + ",\"FAPNotJoinQty\": " + QUANTITY + ",\"FRemainInStockBaseQty\": " + QUANTITY + ",\"FEntryTaxRate\": 13.00,\"F_ora_MO_SEQ_N\": " + ERP_MO_SEQ + ",\"FOWNERID\": {\"FNumber\": \"101\"}}";

                        //        }
                        //        //单据头 
                        //        string sjsonT = "{\"Creator\": \"\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"false\",\"Model\": {\"FID\": 0,\"FBillTypeID\": {\"FNUMBER\": \"RKD01_SYS\"},\"FDate\": \"" + TRX_DATE + "\",\"FStockOrgId\": {\"FNumber\": \"101\"},\"FStockerId\": {\"FNumber\": \"HW0039\"},\"FDemandOrgId\": {\"FNumber\": \"101\"},\"FPurchaseOrgId\": {\"FNumber\": \"101\"},\"FSupplierId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FSupplyId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FSupplyAddress\": \"\",\"FSettleId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FChargeId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FOwnerTypeIdHead\": \"BD_OwnerOrg\",\"FOwnerIdHead\": {\"FNumber\": \"101\"},\"FProviderContactID\": {\"FCONTACTNUMBER\": \"CXR005582\"},\"FSplitBillType\": \"A\",\"FInStockFin\": {\"FSettleOrgId\": {\"FNumber\": \"101\"},\"FSettleTypeId\": {\"FNumber\": \"JSFS03_SYS\"},\"FPayConditionId\": {\"FNumber\": \"FKTJ07_SYS\"},\"FSettleCurrId\": {\"FNumber\": \"PRE001\"},\"FIsIncludedTax\": true,\"FPriceTimePoint\": \"1\",\"FLocalCurrId\": {\"FNumber\": \"PRE001\"},\"FExchangeTypeId\": {\"FNumber\": \"HLTX01_SYS\"},\"FExchangeRate\": 1.0,\"FISPRICEEXCLUDETAX\": true}, \"F_ora_QUEUE_N\": " + QUEUE_ID + ", \"FInStockEntry\": [" + sjson + "   ]}}";
                        //        if (!list.Contains(QUEUE_ID))//不包含唯一序号才保存
                        //        {
                        //            // 调用Web API接口服务，保存
                        //            String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "STK_InStock", sjsonT });

                        //            JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                        //            if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                        //            {
                        //                //MessageBox.Show("生成成功，单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】");
                        //                xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                        //                IsSucess = "OK";
                        //            }
                        //            else
                        //            {
                        //                // MessageBox.Show("同步失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"].ToString());
                        //                xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];

                        //            }
                        //        }
                        //        else
                        //        {
                        //            xmlDate = "唯一序号在系统已经存在";
                        //        }
                        //    }
                        //    break;
                        #endregion

                        #region 销售退货  R180C(后期看看单据类型)
                        case "R180C":
                            //QUEUE_ID	INT64	唯一序号
                            //TRX_DATE	DATETIME	交易时间
                            // STORE_ID	VARCHAR	仓库编码
                            // MTRL_ID	VARCHAR	物料编码
                            // QUANTITY	NUMERICE	数量
                            // REMARK	VARCHAR	备注
                            // FACT_ID	VARCHAR	生产组织、发料组织默认相同
                            //SO_ID	VARCHAR	销售订单
                            // SO_SEQ	VARCHAR	销售订单行号

                            command.CommandText = "SELECT F_ora_QUEUE_N FROM T_SAL_RETURNSTOCK ";
                            using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                while (dr.Read())
                                {
                                    list.Add(Convert.ToInt32(dr[0]));
                                }
                            }
                            conn.Close();
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    QUEUE_ID = Convert.ToInt32(dt.Rows[i]["QUEUE_ID"].ToString());
                                    TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"].ToString());
                                    string STORE_ID = dt.Rows[i]["STORE_ID"].ToString();
                                    //string ERP_MO = dt.Rows[i]["ERP_MO"].ToString();//工单编码
                                    //SUP_ID = dt.Rows[i]["SUP_ID"].ToString();
                                    string MTRL_ID = dt.Rows[i]["MTRL_ID"].ToString();
                                    double QUANTITY = Convert.ToDouble(dt.Rows[i]["QUANTITY"]);
                                    REMARK = dt.Rows[i]["REMARK"].ToString();
                                    kcOrd = dt.Rows[i]["ORG_ID"].ToString();//库存组织
                                    SO_ORG_ID = "";//结算组织
                                    string SO_ID = dt.Rows[i]["SO_ID"].ToString();
                                    string SO_SEQ = dt.Rows[i]["SO_SEQ"].ToString();
                                    IS_BONDED = Convert.ToString(dt.Rows[i]["IS_BONDED"]);//内外销(内销 1, 外销 2)
                                    #region 内外销(内销 1, 外销 2)
                                    if (IS_BONDED == "1")
                                    {
                                        IS_BONDED = "12XSTH";
                                    }
                                    else if (IS_BONDED == "2")
                                    {
                                        IS_BONDED = "11XSTH";
                                    }
                                    #endregion
                                    CUST_ID = Convert.ToString(dt.Rows[i]["CUST_ID"]);//客户编码
                                    #region 客户编码
                                    if (CUST_ID.Length == 1)
                                    {
                                        CUST_ID = "00" + CUST_ID;
                                    }
                                    else if (CUST_ID.Length == 2)
                                    {
                                        CUST_ID = '0' + CUST_ID;
                                    }
                                    #endregion
                                    conn.Open();
                                    command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                    string dw = "";
                                    using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr1.Read())
                                        {
                                            dw = Convert.ToString(dr1[0]);
                                        }
                                    }
                                    conn.Close();
                                    #region 数据库查询出结算组织
                                    conn.Open();
                                    command.CommandText = "select top 1 zz.FNUMBER from T_SAL_ORDERENTRY_F t1 inner join T_SAL_ORDER t2 on t1.FID=t2.FID left join T_ORG_Organizations zz on zz.FORGID=t1.FSETTLEORGID where t2.FBILLNO='" + SO_ID + "'";
                                    using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr1.Read())
                                        {
                                            SO_ORG_ID = Convert.ToString(dr1[0]);
                                        }
                                    }

                                    conn.Close();
                                    #endregion
                                    if (i > 0)
                                    {
                                        sjson += ",";
                                    }
                                    //调用且赋值
                                    sjson += "  {\"FRowType\": \"Standard\",\"FMaterialId\": {\"FNumber\": \"" + MTRL_ID + "\"},\"FUnitID\": {\"FNumber\": \"" + dw + "\"},\"FRealQty\": " + QUANTITY + ",\"FIsFree\": false,\"FEntryTaxRate\": 17.00,\"FReturnType\": {\"FNumber\": \"THLX01_SYS\"},\"FOwnerTypeId\": \"BD_OwnerOrg\",\"FOwnerId\": {\"FNumber\": \"" + kcOrd + "\"},\"FStockId\": {\"FNumber\": \"" + STORE_ID + "\"},\"FStockstatusId\": {\"FNumber\": \"KCZT01_SYS\"},\"FDeliveryDate\": \"" + TRX_DATE + "\",\"FSalUnitID\": {\"FNumber\": \"" + dw + "\"},\"FSalUnitQty\": " + QUANTITY + ",\"FSalBaseQty\": " + QUANTITY + ",\"FPriceBaseQty\": " + QUANTITY + ",\"FIsOverLegalOrg\": false,\"FARNOTJOINQTY\": 1" + QUANTITY + ",\"FNote\": \"" + REMARK + "\",\"FIsReturnCheck\": false}";
                                }
                                //单据头 
                                string sjsonT = "{\"Creator\": \"administrator\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"true\",\"Model\": {\"FID\": 0,\"FBillTypeID\": {\"FNUMBER\": \"" + IS_BONDED + "\"},\"FDate\": \"" + TRX_DATE + "\",\"FSaleOrgId\": {\"FNumber\": \"" + kcOrd + "\"},\"FRetcustId\": {\"FNumber\": \"" + CUST_ID + "\"},\"FSaledeptid\": {\"FNumber\": \"018\"},\"FHeadLocId\": {\"FNumber\": \"BIZ201807101425021\"},\"FTransferBizType\": {\"FNumber\": \"OverOrgSal\"},\"FSalesManId\": {\"FNumber\": \"HW0001\"},\"FStockOrgId\": {\"FNumber\": \"" + kcOrd + "\"},\"FReceiveCustId\": {\"FNumber\": \"" + CUST_ID + "\"},\"FReceiveAddress\": \"\",\"FSettleCustId\": {\"FNumber\": \"" + CUST_ID + "\"},\"FPayCustId\": {\"FNumber\": \"" + CUST_ID + "\"},\"FOwnerTypeIdHead\": \"BD_OwnerOrg\",\"FIsTotalServiceOrCost\": false,\"SubHeadEntity\": {\"FSettleCurrId\": {\"FNumber\": \"PRE001\"},\"FSettleOrgId\": {\"FNumber\": \"" + SO_ORG_ID + "\"},\"FSettleTypeId\": {\"FNumber\": \"JSFS03_SYS\"},\"FChageCondition\": {\"FNumber\": \"036\"},\"FLocalCurrId\": {\"FNumber\": \"PRE001\"},\"FExchangeTypeId\": {\"FNumber\": \"HLTX01_SYS\"},\"FExchangeRate\": 1.0},\"F_ora_QUEUE_N\": " + QUEUE_ID + ",\"FEntity\": [" + sjson + "   ]}}";
                                if (!list.Contains(QUEUE_ID))//不包含唯一序号才保存
                                {
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "SAL_RETURNSTOCK", sjsonT });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        //MessageBox.Show("生成成功，单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】");
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        // MessageBox.Show("同步失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"].ToString());
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];

                                    }
                                }
                                else
                                {
                                    xmlDate = "唯一序号在系统已经存在";
                                }
                            }
                            break;
                        #endregion

                        #region 生产补料  R062(需要上下查)
                        case "R062":
                            //QUEUE_ID	INT64	唯一序号
                            // TRX_DATE	DATETIME	交易时间
                            // STORE_ID	VARCHAR	仓库编码
                            // ERP_MO	VARCHAR	ERP工单编码
                            // SUP_ID	VARCHAR	供应商编码 没有则为空
                            // MTRL_ID	VARCHAR	物料编码
                            // QUANTITY	NUMERICE	数量
                            // REMARK	VARCHAR	备注
                            // FACT_ID	VARCHAR	生产组织、发料组织默认相同
                            // MO_SEQ	VARCHAR	ERP工单行号
                            // SEQ	VARCHAR	需求清单行号

                            command.CommandText = "SELECT F_ora_QUEUE_N FROM T_PRD_FEEDMTRL ";
                            using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                while (dr.Read())
                                {
                                    list.Add(Convert.ToInt32(dr[0]));
                                }
                            }
                            conn.Close();
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    QUEUE_ID = Convert.ToInt32(dt.Rows[i]["QUEUE_ID"].ToString());
                                    TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"].ToString());
                                    string STORE_ID = dt.Rows[i]["STORE_ID"].ToString();
                                    string ERP_MO = dt.Rows[i]["ERP_MO"].ToString();//工单编码
                                    SUP_ID = dt.Rows[i]["SUP_ID"].ToString();
                                    string MTRL_ID = dt.Rows[i]["MTRL_ID"].ToString();
                                    double QUANTITY = Convert.ToDouble(dt.Rows[i]["QUANTITY"]);
                                    REMARK = dt.Rows[i]["REMARK"].ToString();
                                    kcOrd = dt.Rows[i]["ORG_ID"].ToString();
                                    MO_SEQ = dt.Rows[i]["ERP_MO_SEQ"].ToString();
                                    string SEQ = dt.Rows[i]["SEQ"].ToString();
                                    conn.Open();
                                    command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                    string dw = "";
                                    using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr1.Read())
                                        {
                                            dw = Convert.ToString(dr1[0]);
                                        }
                                    }
                                    conn.Close();
                                    conn.Open();
                                    command.CommandText = "select t1.fid,t2.FENTRYID,t3.FBILLNO,t3.yletid,t3.ylid from T_PRD_MO t1 inner join T_PRD_MOENTRY t2 on t1.fid = t2.fid left join (select t1.FMOBILLNO,t1.FBILLNO,t1.FID ylid,t2.FENTRYID yletid,t2.FSEQ,t1.FMOENTRYSEQ from T_PRD_PPBOM t1 inner join T_PRD_PPBOMENTRY t2 on t1.FID=t2.FID) t3 on t1.FBILLNO = t3.FMOBILLNO and t3.FMOENTRYSEQ=t2.FSEQ where  t1.FBILLNO = '" + ERP_MO + "' and t2.FSEQ =  " + MO_SEQ + " and t3.FSEQ =  " + SEQ;
                                    int fid = 0;
                                    int fenttyid = 0;
                                    int ylfenttyid = 0;
                                    int ylfid = 0;
                                    string fbillno = "";//生产用料清单单号
                                    using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr.Read())
                                        {
                                            fid = Convert.ToInt32(dr[0]);
                                            fenttyid = Convert.ToInt32(dr[1]);
                                            fbillno = Convert.ToString(dr[2]);
                                            ylfenttyid = Convert.ToInt32(dr[3]);
                                            ylfid = Convert.ToInt32(dr[4]);
                                        }
                                    }
                                    conn.Close();

                                    #region 获取父级代码
                                    conn.Open();
                                    string scEntryId = "";
                                    command.CommandText = " select t3.FNUMBER,t1.FENTRYID from T_PRD_MO t inner join T_PRD_MOENTRY t1 on t.FID=t1.FID left join T_BD_MATERIAL t3 on t1.FMaterialId=t3.FMATERIALID  where FBILLNO='" + ERP_MO + "' and t1.FSEQ=" + MO_SEQ + "";
                                    string fmaterial = "";
                                    using (SqlDataReader drf = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (drf.Read())
                                        {
                                            fmaterial = Convert.ToString(drf[0]);
                                            scEntryId = Convert.ToString(drf[1]);
                                        }
                                    }
                                    conn.Close();
                                    #endregion

                                    #region 查询库存状态
                                    conn.Open();
                                    command.CommandText = "select aa.FNUMBER from t_BD_Stock a left join  T_BD_STOCKSTATUS aa on aa.FMASTERID=a.FDEFSTOCKSTATUSID where a.FNUMBER='" + STORE_ID + "'";
                                    string zt = "";
                                    using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr1.Read())
                                        {
                                            zt = Convert.ToString(dr1[0]);
                                        }
                                    }
                                    conn.Close();
                                    #endregion
                                    if (i > 0)
                                    {
                                        sjson += ",";
                                    }
                                    //调用且赋值 HWSCDD201701242
                                    sjson += " {\"FParentMaterialId\": {\"FNumber\": \"" + fmaterial + "\"},\"FReserveType\": \"1\",\"FBaseStockActualQty\": " + QUANTITY + ",\"FMaterialId\": {\"FNumber\": \"" + MTRL_ID + "\"},\"FUnitID\": {\"FNumber\": \"" + dw + "\"},\"FAppQty\": " + QUANTITY + ",\"FActualQty\": " + QUANTITY + ",\"FEntryVmiBusiness\": false,\"FStockId\": {\"FNumber\": \"" + STORE_ID + "\"},\"FStockStatusId\": {\"FNumber\": \""+ zt +"\"},\"FMoBillNo\": \"" + ERP_MO + "\",\"FMoEntryId\": " + scEntryId + ",\"FOwnerTypeId\": \"BD_OwnerOrg\",\"FStockAppQty\": " + QUANTITY + ",\"FStockActualQty\": " + QUANTITY + ",\"FMoId\": " + fid + ",\"FMoEntrySeq\": " + MO_SEQ + ",\"FBaseAppQty\": " + QUANTITY + ",\"FPPBomBillNo\": \"" + fbillno + "\",\"FBaseUnitId\": {\"FNumber\": \"" + dw + "\"},\"FStockUnitId\": {\"FNumber\": \"" + dw + "\"},\"FEntryWorkShopId\": {\"FNumber\": \"\"},\"FBaseActualQty\": " + QUANTITY + ",\"FKeeperTypeId\": \"BD_KeeperOrg\",\"FKeeperId\": {\"FNumber\": \"" + kcOrd + "\"},\"FOwnerId\": {\"FNumber\": \"" + kcOrd + "\"},\"FEntrySrcInterId\": " + ylfid + ",\"FEntrySrcBillType\": \"PRD_PPBOM\",\"FEntrySrcBillNo\": \"" + fbillno + "\",\"FEntrySrcEntrySeq\": \"" + SEQ + "\",\"FParentOwnerTypeId\": \"BD_OwnerOrg\",  \"FMoEntryId\": " + fenttyid + ",  \"FPPBomEntryId\": " + ylfenttyid + ", \"FEntrtyDescription\": \"" + REMARK + "\",\"FParentOwnerId\": {\"FNumber\": \"" + kcOrd + "\"},\"FEntity_Link\": [{\"FEntity_Link_FRuleId\": \"PRD_PPBOM2FEEDMTRL\", \"FEntity_Link_FSTableName\": \"T_PRD_PPBOMENTRY\",\"FEntity_Link_FSBillId\": " + ylfid + ",\"FEntity_Link_FSId\": " + ylfenttyid + "}]}";
                                }
                                //单据头 
                                string sjsonT = "{\"Creator\": \"\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"true\",\"Model\": {\"FID\": 0,\"FBillType\": {\"FNUMBER\": \"10SCBL\"},\"FDate\": \"" + TRX_DATE + "\",\"FStockOrgId\": {\"FNumber\": \"" + kcOrd + "\"},\"FPrdOrgId\": {\"FNumber\": \"" + kcOrd + "\"},\"FOwnerTypeId0\": \"BD_OwnerOrg\",\"FCurrId\": {\"FNumber\": \"PRE001\"},\"FIsCrossTrade\": false,\"FVmiBusiness\": false,\"FIsOwnerTInclOrg\": false,\"F_ora_QUEUE_N\": " + QUEUE_ID + ",\"FEntity\": [" + sjson + " ]}}";
                                if (!list.Contains(QUEUE_ID))//不包含唯一序号才保存
                                {
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "PRD_FeedMtrl", sjsonT });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        //MessageBox.Show("生成成功，单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】");
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        // MessageBox.Show("同步失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"].ToString());
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];

                                    }
                                }
                                else
                                {
                                    xmlDate = "唯一序号在系统已经存在";
                                }
                            }
                            break;
                        #endregion

                        #region 生产领料  R014 (生产领料类型未同步)
                        case "R014":
                            //QUEUE_ID	INT64	唯一序号
                            //TRX_DATE	DATETIME	交易时间
                            //STORE_ID	VARCHAR	仓库编码
                            //ERP_MO	VARCHAR	ERP工单编码
                            //MTRL_ID	VARCHAR	物料编码
                            //QUANTITY	NUMERICE	数量
                            //REMARK	VARCHAR	备注
                            //FACT_ID	VARCHAR	生产组织、发料组织默认相同
                            //MO_SEQ	VARCHAR	ERP工单行号
                            //SEQ	VARCHAR	需求清单行号
                            command.CommandText = "SELECT F_ora_QUEUE_N FROM  T_PRD_PICKMTRL";
                            using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                while (dr.Read())
                                {
                                    list.Add(Convert.ToInt32(dr[0]));
                                }
                            }
                            conn.Close();
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    QUEUE_ID = Convert.ToInt32(dt.Rows[i]["QUEUE_ID"].ToString());
                                    TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"].ToString());
                                    string STORE_ID = dt.Rows[i]["STORE_ID"].ToString();
                                    string ERP_MO = dt.Rows[i]["ERP_MO"].ToString();//工单编码
                                    //SUP_ID = dt.Rows[i]["SUP_ID"].ToString();
                                    string MTRL_ID = dt.Rows[i]["MTRL_ID"].ToString();
                                    double QUANTITY = Convert.ToDouble(dt.Rows[i]["QUANTITY"]);
                                    REMARK = dt.Rows[i]["REMARK"].ToString();
                                    kcOrd = dt.Rows[i]["ORG_ID"].ToString();
                                    MO_SEQ = dt.Rows[i]["ERP_MO_SEQ"].ToString();
                                    string SEQ = dt.Rows[i]["SEQ"].ToString();
                                    //string MF_MO_TYPE = dt.Rows[i]["MF_MO_TYPE"].ToString();//领料单类别

                                    #region 上下查
                                    conn.Open();
                                    command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                    string dw = "";
                                    using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr1.Read())
                                        {
                                            dw = Convert.ToString(dr1[0]);
                                        }
                                    }
                                    conn.Close();
                                    conn.Open();
                                    command.CommandText = "select t1.FID,t1.FENTRYID,t4.FBILLNO  from T_PRD_PPBOMENTRY t1 left join T_PRD_PPBOMENTRY_Q t2 on t1.FENTRYID = t2.FENTRYID and t1.fid = t2.FID left join (select t1.FMATERIALID,t1.FNUMBER wl,t3.FNUMBER dw from T_BD_MATERIAL t1 inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID) t3 on t1.FMATERIALID=t3.FMATERIALID left join T_PRD_PPBOM t4 on t4.fid = t1.FID  where t1.FMOBILLNO = '" + ERP_MO + "' and t1.FMOENTRYSEQ=" + MO_SEQ + " and t1.FSEQ=" + SEQ + " and t3.wl = '" + MTRL_ID + "'";
                                    int fid = 0;
                                    int fenttyid = 0;
                                    string fbillNo = "";
                                    using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr.Read())
                                        {
                                            fid = Convert.ToInt32(dr[0]);
                                            fenttyid = Convert.ToInt32(dr[1]);
                                            fbillNo = dr[2].ToString();
                                        }
                                    }
                                    conn.Close();
                                    #endregion

                                    #region 获取父级代码
                                    conn.Open();
                                    string scEntryId = "";
                                    command.CommandText = " select t3.FNUMBER,t1.FENTRYID from T_PRD_MO t inner join T_PRD_MOENTRY t1 on t.FID=t1.FID left join T_BD_MATERIAL t3 on t1.FMaterialId=t3.FMATERIALID  where FBILLNO='" + ERP_MO + "' and t1.FSEQ=" + MO_SEQ + "";
                                    string fmaterial = "";
                                    using (SqlDataReader drf = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (drf.Read())
                                        {
                                            fmaterial = Convert.ToString(drf[0]);
                                            scEntryId = Convert.ToString(drf[1]);
                                        }
                                    }
                                    conn.Close();
                                    #endregion
                                    #region 查询库存状态
                                    conn.Open();
                                    command.CommandText = "select aa.FNUMBER from t_BD_Stock a left join  T_BD_STOCKSTATUS aa on aa.FMASTERID=a.FDEFSTOCKSTATUSID where a.FNUMBER='" + STORE_ID + "'";
                                    string zt = "";
                                    using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr1.Read())
                                        {
                                            zt = Convert.ToString(dr1[0]);
                                        }
                                    }
                                    conn.Close();
                                    #endregion

                                    if (i > 0)
                                    {
                                        sjson += ",";
                                    }
                                    //调用且赋值 HWSCDD201701242
                                    sjson += "{\"FEntryID\": 0,\"FMaterialId\": {\"FNumber\": \"" + MTRL_ID + "\"},\"FParentMaterialId\": {\"FNumber\": \"" + fmaterial + "\"},\"FUnitId\": {\"FNumber\": \"" + dw + "\"},\"FStockUnitId\": {\"FNumber\": \"" + dw + "\"},\"FBaseUnitId\": {\"FNumber\": \"" + dw + "\"},\"FMoBillNo\": \"" + ERP_MO + "\",\"FMoEntryId\":" + scEntryId + ",\"FOwnerTypeId\": \"BD_OwnerOrg\",\"FOwnerId\": {\"FNumber\": \"101\"},\"FAppQty\": " + QUANTITY + ",\"FActualQty\": " + QUANTITY + ",\"FStockId\": {\"FNumber\": \"" + STORE_ID + "\"},\"FStockStatusId\":{\"FNumber\": \""+ zt +"\"},\"FEntryWorkShopId\": {\"FNumber\": \"BM000001\"},\"FNote\": \"" + REMARK + "\",\"FPPBomEntryId\": " + fenttyid + ",\"FPPBomBillNo\": \"" + fbillNo + "\",\"FEntity_Link\": [{\"FEntity_Link_FFlowId\": \"\",\"FEntity_Link_FFlowLineId\": \"\",\"FEntity_Link_FRuleId\": \"PRD_PPBOM2PICKMTRL_NORMAL\",\"FEntity_Link_FSTableName\": \"T_PRD_PPBOMENTRY\",\"FEntity_Link_FSBillId\": " + fid + ",\"FEntity_Link_FSId\": " + fenttyid + "}]}";
                                }
                                //单据头 
                                string sjsonT = "{\"Creator\": \"Demo\",\"NeedUpDateFields\": [\"\"],    \"IsAutoSubmitAndAudit\": \"true\",\"Model\": {\"FID\": 0,\"FBillType\": {\"FNumber\": \"10SCLL\"},\"FPrdOrgId\": {\"FNumber\": \"" + kcOrd + "\"},\"FStockOrgId\": {\"FNumber\": \"" + kcOrd + "\"},\"FDate\": \"" + TRX_DATE + "\",\"FEntity\": [" + sjson + "   ]}}";
                                if (!list.Contains(QUEUE_ID))//不包含唯一序号才保存
                                {
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "PRD_PickMtrl", sjsonT });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        //MessageBox.Show("生成成功，单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】");
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        // MessageBox.Show("同步失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"].ToString());
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];

                                    }
                                }
                                else
                                {
                                    xmlDate = "唯一序号在系统已经存在";
                                }
                            }
                            break;
                        #endregion

                        #region 委外补料 R062-1
                        case "R062-1":
                            //QUEUE_ID	INT64	唯一序号
                            //TRX_DATE	DATETIME	交易时间
                            //STORE_ID	VARCHAR	仓库编码
                            //ERP_MO	VARCHAR	ERP工单编码(委外订单号)
                            //SUP_ID	VARCHAR	供应商编码 没有则为空
                            //MTRL_ID	VARCHAR	物料编码
                            //QUANTITY	NUMERICE	数量
                            //REMARK	VARCHAR	备注
                            //FACT_ID	VARCHAR	生产组织、发料组织默认相同
                            //MO_SEQ	VARCHAR	ERP工单行号
                            //SEQ	VARCHAR	需求清单行号

                            command.CommandText = "SELECT F_ora_QUEUE_N FROM T_SUB_FEEDMTRL ";
                            using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                while (dr.Read())
                                {
                                    list.Add(Convert.ToInt32(dr[0]));
                                }
                            }
                            conn.Close();
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    QUEUE_ID = Convert.ToInt32(dt.Rows[i]["QUEUE_ID"].ToString());
                                    TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"].ToString());
                                    string STORE_ID = dt.Rows[i]["STORE_ID"].ToString();
                                    string ERP_MO = dt.Rows[i]["ERP_MO"].ToString();//工单编码
                                    SUP_ID = dt.Rows[i]["SUP_ID"].ToString();
                                    if (SUP_ID.Length == 1)
                                    {
                                        SUP_ID = "00" + SUP_ID;
                                    }
                                    else if (SUP_ID.Length == 2)
                                    {
                                        SUP_ID = "0" + SUP_ID; ;
                                    }
                                    else if (SUP_ID.Length > 2)
                                    {
                                        SUP_ID = dt.Rows[i]["SUP_ID"].ToString();//供应商编码
                                    }
                                    string MTRL_ID = dt.Rows[i]["MTRL_ID"].ToString();
                                    double QUANTITY = Convert.ToDouble(dt.Rows[i]["QUANTITY"]);
                                    REMARK = dt.Rows[i]["REMARK"].ToString();
                                    kcOrd = dt.Rows[i]["ORG_ID"].ToString();
                                    MO_SEQ = dt.Rows[i]["ERP_MO_SEQ"].ToString();
                                    string SEQ = dt.Rows[i]["SEQ"].ToString();

                                    #region 上下查
                                    conn.Open();
                                    command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                    string dw = "";
                                    using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr1.Read())
                                        {
                                            dw = Convert.ToString(dr1[0]);
                                        }
                                    }
                                    conn.Close();
                                    conn.Open();
                                    //' and t1.FMOENTRYSEQ=" + MO_SEQ + " 订单行号
                                    command.CommandText = " select t1.FID,t1.FENTRYID,t4.FBILLNO,T5.FID,t6.FENTRYID  from T_SUB_PPBOMENTRY t1 left join (select t1.FMATERIALID,t1.FNUMBER wl,t3.FNUMBER dw from T_BD_MATERIAL t1 inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID) t3 on t1.FMATERIALID=t3.FMATERIALID left join T_SUB_PPBOM t4 on t4.fid = t1.FID  LEFT JOIN T_SUB_REQORDER T5 ON T1.FSUBREQBILLNO=T5.FBILLNO  left join T_SUB_REQORDERENTRY t6  on t6.fid=t5.fid   where  t1.FSubReqBillNO = '" + ERP_MO + "' and t1.FSEQ=" + SEQ + " and t3.wl = '" + MTRL_ID + "'";
                                    int fid = 0;
                                    int fenttyid = 0;
                                    string fbillNo = "";
                                    int fidWW = 0;
                                    int fentryWWDD = 0;
                                    using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr.Read())
                                        {
                                            fid = Convert.ToInt32(dr[0]);
                                            fenttyid = Convert.ToInt32(dr[1]);
                                            fbillNo = dr[2].ToString();
                                            fidWW = Convert.ToInt32(dr[3]);
                                            fentryWWDD = Convert.ToInt32(dr[4]);
                                        }
                                    }
                                    conn.Close();
                                    #endregion


                                    #region 获取父级代码
                                    conn.Open();
                                    //string scEntryId = "";
                                    command.CommandText = " select t3.FNUMBER,t1.FENTRYID from T_SUB_REQORDER t inner join T_SUB_REQORDERENTRY t1 on t.FID=t1.FID left join T_BD_MATERIAL t3 on t1.FMaterialId=t3.FMATERIALID  where FBILLNO='" + ERP_MO + "' and t1.FSEQ=" + MO_SEQ + "";
                                    string fmaterial = "";
                                    using (SqlDataReader drf = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (drf.Read())
                                        {
                                            fmaterial = Convert.ToString(drf[0]);
                                           // scEntryId = Convert.ToString(drf[1]);
                                        }
                                    }
                                    conn.Close();
                                    #endregion


                                    if (i > 0)
                                    {
                                        sjson += ",";
                                    }
                                    //调用且赋值 HWSCDD201701242
                                    sjson += " {\"FParentMaterialId\": {\"FNumber\": \"" + fmaterial + "\"},\"FMaterialId\": {\"FNumber\": \"" + MTRL_ID + "\"},\"FUnitID\": {\"FNumber\": \"" + dw + "\"},\"FAPPQty\": " + QUANTITY + ",\"FActualQty\": " + QUANTITY + ",\"FStockId\": {\"FNumber\": \"" + STORE_ID + "\"},\"FSUBReqEntrySeq\":" + MO_SEQ + ",\"FSUBReqBillNo\": \"" + ERP_MO + "\",\"FStockAppQty\": " + QUANTITY + ",\"FOwnerTypeId\": \"BD_OwnerOrg\",\"FSubReqEntryId\": " + fentryWWDD + ",\"FOwnerId\": {\"FNumber\": \"" + kcOrd + "\"},\"FSrcBillType\": \"SUB_PPBOM\",\"FSrcBillNo\": \"" + fbillNo + "\",\"FSUBREQID\":" + fidWW + ",\"FSrcEntrySeq\":" + SEQ + ",\"FSRCENTRYID\":" + fenttyid + ",\"FBaseUnitId\": {\"FNumber\": \"" + dw + "\"},\"FBaseAppQty\": " + QUANTITY + ",\"FBaseActualQty\": " + QUANTITY + ",\"FPPBOMBillNo\": \"" + fbillNo + "\",\"FSrcBillId\": " + fid + ",\"FPPBOMENTRYID\":" + fenttyid + ",\"FStockUnitId\": {\"FNumber\": \"" + dw + "\"},\"FStockActualQty\": " + QUANTITY + ",\"FReserveType\": \"1\",\"FBaseStockActualQty\": " + QUANTITY + ",\"FStockStatusId\": {\"FNumber\": \"KCZT01_SYS\"},\"FKeeperTypeId\": \"BD_KeeperOrg\",\"FKeeperId\": {\"FNumber\": \"" + kcOrd + "\"},\"FEntryVmiBusiness\": false,\"FSupplierId\": {\"FNUMBER\": \"" + SUP_ID + "\"},\"FParentOwnerTypeId\": \"BD_OwnerOrg\",\"FParentOwnerId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FEntity_Link\": [{\"FEntity_Link_FRuleId\": \"SUB_PPBOM_FEED\", \"FEntity_Link_FSTableName\": \"T_SUB_PPBOMENTRY\",\"FEntity_Link_FSBillId\": " + fid + ",\"FEntity_Link_FSId\": " + fenttyid + "}]}";
                                }
                                //单据头 
                                string sjsonT = "{\"Creator\": \"\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"true\",\"Model\": {\"FID\": 0,\"FBillType\": {\"FNUMBER\": \"10WWBL\"},\"FDate\": \"" + TRX_DATE + "\",\"FStockOrgId\": {\"FNumber\": \"" + kcOrd + "\"},\"FSubOrgId\": {\"FNumber\": \"" + kcOrd + "\"},\"FSubSupplierId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FOwnerTypeId0\": \"BD_OwnerOrg\",\"FCurrId\": {\"FNumber\": \"PRE001\"},\"FIsCrossTrade\": false,\"FVmiBusiness\": false,\"FIsOwnerTInclOrg\": false,\"FEntity\": [" + sjson + "   ]}}";
                                if (!list.Contains(QUEUE_ID))//不包含唯一序号才保存
                                {
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "SUB_FEEDMTRL", sjsonT });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        //MessageBox.Show("生成成功，单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】");
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        // MessageBox.Show("同步失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"].ToString());
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];

                                    }
                                }
                                else
                                {
                                    xmlDate = "唯一序号在系统已经存在";
                                }
                            }
                            break;
                        #endregion

                        #region 委外领料 R014-1
                        case "R014-1":
                            //QUEUE_ID	INT64	唯一序号
                            //TRX_DATE	DATETIME	交易时间
                            //STORE_ID	VARCHAR	仓库编码
                            //ERP_MO	VARCHAR	ERP工单编码(委外订单号)
                            //SUP_ID	VARCHAR	供应商编码 没有则为空
                            //MTRL_ID	VARCHAR	物料编码
                            //QUANTITY	NUMERICE	数量
                            //REMARK	VARCHAR	备注
                            //FACT_ID	VARCHAR	生产组织、发料组织默认相同
                            //MO_SEQ	VARCHAR	ERP工单行号
                            //SEQ	VARCHAR	需求清单行号

                            command.CommandText = "SELECT F_ora_QUEUE_N FROM T_SUB_FEEDMTRL ";
                            using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                while (dr.Read())
                                {
                                    list.Add(Convert.ToInt32(dr[0]));
                                }
                            }
                            conn.Close();
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    QUEUE_ID = Convert.ToInt32(dt.Rows[i]["QUEUE_ID"].ToString());
                                    TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"].ToString());
                                    string STORE_ID = dt.Rows[i]["STORE_ID"].ToString();
                                    string ERP_MO = dt.Rows[i]["ERP_MO"].ToString();//工单编码
                                    SUP_ID = dt.Rows[i]["SUP_ID"].ToString();
                                    if (SUP_ID.Length == 1)
                                    {
                                        SUP_ID = "00" + SUP_ID;
                                    }
                                    else if (SUP_ID.Length == 2)
                                    {
                                        SUP_ID = "0" + SUP_ID; ;
                                    }
                                    else if (SUP_ID.Length > 2)
                                    {
                                        SUP_ID = dt.Rows[i]["SUP_ID"].ToString();//供应商编码
                                    }
                                    string MTRL_ID = dt.Rows[i]["MTRL_ID"].ToString();
                                    double QUANTITY = Convert.ToDouble(dt.Rows[i]["QUANTITY"]);
                                    REMARK = dt.Rows[i]["REMARK"].ToString();
                                    kcOrd = dt.Rows[i]["ORG_ID"].ToString();
                                    MO_SEQ = dt.Rows[i]["ERP_MO_SEQ"].ToString();
                                    string SEQ = dt.Rows[i]["SEQ"].ToString();

                                    #region 上下查
                                    conn.Open();
                                    command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                    string dw = "";
                                    using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr1.Read())
                                        {
                                            dw = Convert.ToString(dr1[0]);
                                        }
                                    }
                                    conn.Close();
                                    conn.Open();
                                    //' and t1.FMOENTRYSEQ=" + MO_SEQ + " 订单行号
                                    command.CommandText = " select t1.FID,t1.FENTRYID,t4.FBILLNO  from T_SUB_PPBOMENTRY t1 left join (select t1.FMATERIALID,t1.FNUMBER wl,t3.FNUMBER dw from T_BD_MATERIAL t1 inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID) t3 on t1.FMATERIALID=t3.FMATERIALID left join T_SUB_PPBOM t4 on t4.fid = t1.FID    where  t1.FSubReqBillNO = '" + ERP_MO + "' and t1.FSEQ=" + SEQ + " and t3.wl = '" + MTRL_ID + "'";
                                    int fid = 0;
                                    int fenttyid = 0;
                                    string fbillNo = "";
                                    using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr.Read())
                                        {
                                            fid = Convert.ToInt32(dr[0]);
                                            fenttyid = Convert.ToInt32(dr[1]);
                                            fbillNo = dr[2].ToString();
                                        }
                                    }
                                    conn.Close();
                                    #endregion


                                    if (i > 0)
                                    {
                                        sjson += ",";
                                    }
                                    //调用且赋值 HWSCDD201701242
                                    sjson += " {\"FEntryID\":0,\"FMaterialId\":{\"FNumber\":\"" + MTRL_ID + "\"},\"FUnitId\":{\"FNumber\":\"Pcs\"},\"FStockUnitId\":{\"FNumber\":\"Pcs\"},\"FSupplierId\":{\"FNumber\":\"" + SUP_ID + "\"},\"FBaseUnitId\":{\"FNumber\":\"Pcs\"},\"FSubReqBillNo\":\"" + ERP_MO + "\",\"FOwnerTypeId\":\"BD_OwnerOrg\",\"FOwnerId\":{\"FNumber\":\"" + kcOrd + "\"},\"FAppQty\":" + QUANTITY + ",\"FActualQty\":" + QUANTITY + ",\"FStockId\":{\"FNumber\":\"" + STORE_ID + "\"},\"FStockStatusId\":{\"FNumber\":\"KCZT01_SYS\"},\"FEntryWorkShopId\":{\"FNumber\":\"BM000001\"},\"FNote\":\"" + REMARK + "\",\"FSubReqEntrySeq\":" + MO_SEQ + ",\"FPPbomBillNo\":\"" + fbillNo + "\",\"FEntity_Link\":[{\"FEntity_Link_FFlowId\":\"\",\"FEntity_Link_FFlowLineId\":\"\",\"FEntity_Link_FRuleId\":\"SUB_PPBOM_Pick\",\"FEntity_Link_FSTableName\":\"T_SUB_PPBOMENTRY\",\"FEntity_Link_FSBillId\":" + fid + ",\"FEntity_Link_FSId\":" + fenttyid + "}]}";
                                }
                                //单据头 
                                string sjsonT = "{\"Creator\":\"Demo\",\"NeedUpDateFields\":[\"\"],    \"IsAutoSubmitAndAudit\": \"true\",\"Model\":{\"FID\":0,\"FBillType\":{\"FNumber\":\"10WWLL\"},\"FSubOrgId\":{\"FNumber\":\"" + kcOrd + "\"},\"FStockOrgId\":{\"FNumber\":\"" + kcOrd + "\"},\"FDate\": \"" + TRX_DATE + "\",\"FEntity\":[" + sjson + "   ]}}";
                                if (!list.Contains(QUEUE_ID))//不包含唯一序号才保存
                                {
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "SUB_PickMtrl", sjsonT });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        //MessageBox.Show("生成成功，单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】");
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        // MessageBox.Show("同步失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"].ToString());
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];

                                    }
                                }
                                else
                                {
                                    xmlDate = "唯一序号在系统已经存在";
                                }
                            }
                            break;
                        #endregion

                        #region 采购入库单 R106 (需要上下查)
                        case "R106":
                            //QUEUE_ID	INT64	唯一序号
                            //TRX_DATE	DATETIME	交易时间
                            //STORE_ID	VARCHAR	仓库编码
                            //ERP_MO	VARCHAR	ERP工单编码
                            //MTRL_ID	VARCHAR	物料编码
                            //QUANTITY	NUMERICE	数量
                            //REMARK	VARCHAR	备注
                            //FACT_ID	VARCHAR	入库组织、生产组织相同
                            //MO_SEQ	VARCHAR	ERP工单行号
                            //RK_TYPE		入库类型（1 良品类型 2 不良品入库 3报废品入库 4返工品入库）

                            command.CommandText = "SELECT F_ora_QUEUE_N FROM t_STK_InStock ";
                            using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                while (dr.Read())
                                {
                                    list.Add(Convert.ToInt32(dr[0]));
                                }
                            }
                            conn.Close();
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    QUEUE_ID = Convert.ToInt32(dt.Rows[i]["QUEUE_ID"].ToString());
                                    TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"].ToString());
                                    string STORE_ID = dt.Rows[i]["STORE_ID"].ToString();
                                    string ERP_MO = dt.Rows[i]["ERP_MO"].ToString();//工单编码
                                    // SUP_ID = dt.Rows[i]["SUP_ID"].ToString();
                                    string MTRL_ID = dt.Rows[i]["MTRL_ID"].ToString();
                                    double QUANTITY = Convert.ToDouble(dt.Rows[i]["QUANTITY"]);
                                    REMARK = dt.Rows[i]["REMARK"].ToString();
                                    kcOrd = dt.Rows[i]["ORG_ID"].ToString();
                                    MO_SEQ = dt.Rows[i]["ERP_MO_SEQ"].ToString();
                                    //string SEQ = dt.Rows[i]["SEQ"].ToString();
                                    string K_TYPE = dt.Rows[i]["RK_TYPE"].ToString();
                                    conn.Open();
                                    command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                    string dw = "";
                                    using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr1.Read())
                                        {
                                            dw = Convert.ToString(dr1[0]);
                                        }
                                    }
                                    conn.Close();
                                    conn.Open();
                                    command.CommandText = "select t1.FID,t2.FENTRYID from t_PUR_POOrder t1 inner join t_PUR_POOrderEntry t2 on t1.FID=t2.FID  where  t1.FBILLNO = '" + ERP_MO + "' and t2.FSEQ =  " + MO_SEQ;
                                    int fid = 0;
                                    int fenttyid = 0;
                                    using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (dr.Read())
                                        {
                                            fid = Convert.ToInt32(dr[0]);
                                            fenttyid = Convert.ToInt32(dr[1]);
                                        }
                                    }
                                    conn.Close();
                                    if (i > 0)
                                    {
                                        sjson += ",";
                                    }
                                    //调用且赋值 HWSCDD201701242
                                    sjson += "  {\"FRowType\": \"" + K_TYPE + "\",\"FMaterialId\": {\"FNumber\": \"" + MTRL_ID + "\"},\"FUnitID\": {\"FNumber\": \"" + dw + "\"},\"FRealQty\": " + QUANTITY + ",\"FPriceUnitID\": {\"FNumber\": \"" + dw + "\"},\"FStockId\": {\"FNumber\": \"" + STORE_ID + "\"},\"FStockStatusId\": {\"FNumber\": \"KCZT01_SYS\"},\"FGiveAway\": false,\"FNote\": \"" + REMARK + "\",\"FOWNERTYPEID\": \"BD_OwnerOrg\",\"FCheckInComing\": false,\"FIsReceiveUpdateStock\": false,\"FPriceBaseQty\": " + QUANTITY + ",\"FRemainInStockUnitId\": \"FNumber\": \"" + dw + "\"},\"FBILLINGCLOSE\": false,\"FRemainInStockQty\": " + QUANTITY + ",\"FAPNotJoinQty\": " + QUANTITY + ",\"FRemainInStockBaseQty\": " + QUANTITY + ",\"FEntryTaxRate\": 13.00,\"FOWNERID\": {\"FNumber\": \"" + kcOrd + "\"},\"FInStockEntry_Link\": [{\"FInStockEntry_Link_FRuleId\": \"PUR_PurchaseOrder-STK_InStock\", \"FInStockEntry_Link_FSTableName\": \"t_PUR_POOrderEntry\",\"FInStockEntry_Link_FSBillId\": " + fid + ",\"FInStockEntry_Link_FSId\": " + fenttyid + "}]}";
                                }
                                //单据头 
                                string sjsonT = "{\"Creator\": \"\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"true\",\"Model\": {\"FID\": 0,\"FBillTypeID\": {\"FNUMBER\": \"20CGRK\"},\"FDate\": \"" + TRX_DATE + "\",\"FStockOrgId\": {\"FNumber\": \"" + kcOrd + "\"},\"FStockerId\": {\"FNumber\": \"HW0039\"},\"FDemandOrgId\": {\"FNumber\": \"" + kcOrd + "\"},\"FPurchaseOrgId\": {\"FNumber\": \"" + kcOrd + "\"},\"FSupplierId\": {\"FNumber\": \"VEN00121\"},\"FSupplyId\": {\"FNumber\": \"VEN00121\"},\"FSettleId\": {\"FNumber\": \"VEN00121\"},\"FChargeId\": {\"FNumber\": \"VEN00121\"},\"FOwnerTypeIdHead\": \"BD_OwnerOrg\",\"FOwnerIdHead\": {\"FNumber\": \"" + kcOrd + "\"},\"FSplitBillType\": \"A\",\"FInStockFin\": {\"FSettleOrgId\": {\"FNumber\": \"" + kcOrd + "\"},\"FSettleCurrId\": {\"FNumber\": \"PRE001\"},\"FIsIncludedTax\": true,\"FPriceTimePoint\": \"1\",\"FLocalCurrId\": {\"FNumber\": \"PRE001\"},\"FExchangeTypeId\": {\"FNumber\": \"HLTX01_SYS\"},\"FExchangeRate\": 1.0,\"FISPRICEEXCLUDETAX\": true}, \"F_ora_QUEUE_N\": " + QUEUE_ID + ",\"FInStockEntry\": [" + sjson + "   ]}}";
                                if (!list.Contains(QUEUE_ID))//不包含唯一序号才保存
                                {
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "STK_InStock", sjsonT });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        //MessageBox.Show("生成成功，单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】");
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        // MessageBox.Show("同步失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"].ToString());
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];

                                    }
                                }
                                else
                                {
                                    xmlDate = "唯一序号在系统已经存在";
                                }
                            }
                            break;
                        #endregion

                        #region 迪露
                        case "R104"://动获取ERP销售出库
                            #region 销售出库
                            //读取明细
                            if (dt.Rows.Count > 0)
                            {

                                int shif = 0;
                                QUEUE_ID = Convert.ToInt32(dt.Rows[0]["QUEUE_ID"]);//唯一序号                                  
                                command.CommandText = "select count(1) from T_SAL_OUTSTOCK where F_ORA_QUEUE_N = " + QUEUE_ID;
                                using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                {
                                    while (dr.Read())
                                    {
                                        shif = Convert.ToInt32(dr[0]);
                                    }
                                }
                                conn.Close();
                                if (shif == 0)
                                {
                                    string REMARKt = Convert.ToString(dt.Rows[0]["REMARK"]);//备注 
                                    TRX_DATE = Convert.ToDateTime("2020-01-01");
                                    string time = "";
                                    string fentryjson = "";
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        // QUEUE_ID = Convert.ToInt32(dt.Rows[i]["QUEUE_ID"]);
                                        TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        time = Convert.ToString(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        string STORE_ID = Convert.ToString(dt.Rows[i]["STORE_ID"]);//仓库编码
                                        string AUDIT_ID = Convert.ToString(dt.Rows[i]["AUDIT_ID"]);//发货通知单号  源单类型 SAL_DELIVERYNOTICE
                                        string SO_ID = Convert.ToString(dt.Rows[i]["SO_ID"]);//销售订单单号
                                        string AUDIT_SEQ = Convert.ToString(dt.Rows[i]["AUDIT_SEQ"]);//发货通知单号行号
                                        string MTRL_ID = Convert.ToString(dt.Rows[i]["MTRL_ID"]);//物料编码
                                        decimal QUANTITY = Convert.ToDecimal(dt.Rows[i]["QUANTITY"]);//数量
                                        REMARK = Convert.ToString(dt.Rows[i]["REMARK"]);//备注 
                                        CUST_ID = Convert.ToString(dt.Rows[i]["CUST_ID"]);//客户编码
                                        IS_BONDED = Convert.ToString(dt.Rows[i]["IS_BONDED"]);//内外销(内销 1, 外销 2)
                                        IS_PRE = Convert.ToString(dt.Rows[i]["IS_PRE"]);//是否赠品
                                        ORG_ID = Convert.ToString(dt.Rows[i]["ORG_ID"]);//销售组织
                                        SO_ORG_ID = Convert.ToString(dt.Rows[i]["SO_ORG_ID"]);//结算组织
                                        if (CUST_ID.Length == 1)
                                        {
                                            CUST_ID = "00" + CUST_ID;
                                        }
                                        else if (CUST_ID.Length == 2)
                                        {
                                            CUST_ID = '0' + CUST_ID;
                                        }
                                        #region 内外销(内销 1, 外销 2)
                                        if (IS_BONDED == "1")
                                        {
                                            IS_BONDED = "12XSCK";
                                        }
                                        else if (IS_BONDED == "2")
                                        {
                                            IS_BONDED = "11XSCK";
                                        }
                                        #endregion
                                        #region 是否赠品(Y 是 N 否)
                                        if (IS_PRE == "N")
                                        {
                                            IS_PRE = "false";
                                        }
                                        else
                                        {
                                            IS_PRE = "true";
                                        }
                                        #endregion
                                        conn.Open();
                                        command.CommandText = "select t1.FID,t2.FENTRYID from T_SAL_DELIVERYNOTICE t1 inner join T_SAL_DELIVERYNOTICEENTRY t2 on t1.FID=t2.FID where  t1.FBILLNO = '" + AUDIT_ID + "' and t2.FSEQ =  " + AUDIT_SEQ;
                                        int fid = 0;
                                        int fenttyid = 0;
                                        using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr.Read())
                                            {
                                                fid = Convert.ToInt32(dr[0]);
                                                fenttyid = Convert.ToInt32(dr[1]);
                                            }
                                        }
                                        conn.Close();
                                        conn.Open();
                                        command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                        string dw = "";
                                        using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr1.Read())
                                            {
                                                dw = Convert.ToString(dr1[0]);
                                            }
                                        }
                                        conn.Close();
                                        if (i > 0)
                                        {
                                            fentryjson += ",";
                                        }
                                        fentryjson += "{\"FRowType\": \"Standard\",\"FMaterialID\": { \"FNumber\": \"" + MTRL_ID + "\"}," +
                                                     "\"FUnitID\": {\"FNumber\": \"" + dw + "\"},\"FRealQty\": " + QUANTITY + "," +
                                                     "\"FIsFree\": " + IS_PRE + ",\"FOwnerTypeID\": \"BD_OwnerOrg\",\"FOwnerID\": {\"FNumber\": \"" + ORG_ID + "\" }," +
                                                     "\"FEntryTaxRate\": 13.00," +//物料资料默认带出,前台不显示
                                                     "\"FStockID\": {\"FNumber\": \"" + STORE_ID + "\"}," +
                                                     "\"FStockStatusID\": {\"FNumber\": \"KCZT01_SYS\" }," +//库存状态,此值为默认值
                                                     "\"FEntrynote\": \"" + REMARK + "\"," +
                                                     "\"FSalUnitID\": {\"FNumber\": \"" + dw + "\"}," +
                                                     "\"FSALUNITQTY\": " + QUANTITY + ",\"FSALBASEQTY\": " + QUANTITY + "," +
                                                     " \"FPRICEBASEQTY\": " + QUANTITY + "," +
                                                     "\"FOUTCONTROL\": false,\"FIsOverLegalOrg\": false," +
                                                     "\"FARNOTJOINQTY\": " + QUANTITY + "," +
                                                     "\"FCheckDelivery\": false,\"FSrcType\":\"SAL_DELIVERYNOTICE\",\"FSrcBillNo\":\"" + AUDIT_ID + "\",\"FSoorDerno\":\"" + SO_ID + "\",\"F_PAZE_CheckBox1\": false," +
                                                     "\"FSourceBillNo\": \"" + AUDIT_ID + "\",\"FSOURCETYPE\": \"SAL_DELIVERYNOTICE\"," +
                                                     "\"FEntity_Link \": [{\"FEntity_Link_FRuleId\": \"DeliveryNotice-OutStock\"," +
                                                     " \"FEntity_Link_FSTableName\": \"T_SAL_DELIVERYNOTICEENTRY\"," +
                                                     "\"FEntity_Link_FSBillId\": " + fid + ",\"FEntity_Link_FSId\": " + fenttyid + "}] }";
                                    }
                                    string topjosn = "{\"Creator\": \"\", \"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\", \"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\", \"NumberSearch\": \"true\",\"InterationFlags\": \"\", \"IsAutoSubmitAndAudit\": \"true\", \"Model\": {\"FID\": 0,\"FBillTypeID\": { \"FNUMBER\": \"" + IS_BONDED + "\"},\"FDate\": \"" + time + "\", \"FSaleOrgId\": { \"FNumber\": \"" + SO_ORG_ID + "\" }, \"FCustomerID\": { \"FNumber\": \"" + CUST_ID + "\" }, \"FStockOrgId\": { \"FNumber\": \"" + ORG_ID + "\" },\"FNote\": \"" + REMARKt + "\",\"FReceiverID\": { \"FNumber\": \"" + CUST_ID + "\"}, \"FSettleID\": { \"FNumber\": \"" + CUST_ID + "\" },\"FReceiverContactID\": { \"FNAME\": \"姜海波\" }, \"FPayerID\": { \"FNumber\": \"" + CUST_ID + "\" }, \"FOwnerTypeIdHead\": \"BD_OwnerOrg\", \"FIsTotalServiceOrCost\": false, \"F_ora_QUEUE_N\": \"" + QUEUE_ID + "\", \"SubHeadEntity\": { \"FSettleCurrID\": {\"FNumber\": \"PRE001\" }, \"FSettleOrgID\": { \"FNumber\": \"" + SO_ORG_ID + "\"}, \"FIsIncludedTax\": true,\"FLocalCurrID\": {\"FNumber\": \"PRE001\" }, \"FExchangeTypeID\": {\"FNumber\": \"HLTX01_SYS\" },\"FExchangeRate\": 1.0,\"FIsPriceExcludeTax\": true },";

                                    sjson = topjosn + "\"FEntity\":[" + fentryjson + "]}}";
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "SAL_OUTSTOCK", sjson });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];
                                    }
                                }
                                else
                                {
                                    xmlDate = "生成失败：唯一序号已存在,不可重复生成!";
                                }
                            }
                            #endregion
                            break;
                        case "R006":
                            #region 材料退供应商,采购退料单
                            if (dt.Rows.Count > 0)
                            {

                                int shif = 0;
                                QUEUE_ID = Convert.ToInt32(dt.Rows[0]["QUEUE_ID"]);//唯一序号
                                command.CommandText = "select count(1) from t_PUR_MRB where F_ORA_QUEUE_N = " + QUEUE_ID;
                                using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                {
                                    while (dr.Read())
                                    {
                                        shif = Convert.ToInt32(dr[0]);
                                    }
                                }
                                conn.Close();
                                if (shif == 0)
                                {

                                    TRX_DATE = Convert.ToDateTime("2020-01-01");
                                    string time = "";
                                    string fentryjson = "";
                                    string FACT_ID = "";

                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        time = Convert.ToString(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        string STORE_ID = Convert.ToString(dt.Rows[i]["STORE_ID"]);//仓库编码
                                        SUP_ID = Convert.ToString(dt.Rows[i]["SUP_ID"]);//供应商编码
                                        if (SUP_ID.Length < 3)
                                        {
                                            if (SUP_ID.Length == 2)
                                            {
                                                SUP_ID = "0" + SUP_ID;
                                            }
                                            else
                                            {
                                                SUP_ID = "00" + SUP_ID;
                                            }
                                        }
                                        string MTRL_ID = Convert.ToString(dt.Rows[i]["MTRL_ID"]);//物料编码                                           
                                        decimal QUANTITY = Convert.ToDecimal(dt.Rows[i]["QUANTITY"]);//数量
                                        REMARK = Convert.ToString(dt.Rows[i]["REMARK"]);   //备注 
                                        string PO_SEQ = Convert.ToString(dt.Rows[i]["PO_SEQ"]);//采购单行号
                                        string PO_ID = Convert.ToString(dt.Rows[i]["PO_ID"]);//采购单编码   源单类型 PUR_PurchaseOrder
                                        FACT_ID = Convert.ToString(dt.Rows[i]["ORG_ID"]);//收料组织
                                        PO_ORG_ID = Convert.ToString(dt.Rows[i]["PO_ORG_ID"]);//采购组织
                                        IS_OUTS = Convert.ToString(dt.Rows[i]["IS_OUTS"]);//是否委外
                                        conn.Open();
                                        command.CommandText = "select t1.FID,t2.FENTRYID from t_PUR_POOrder t1 inner join t_PUR_POOrderENTRY t2 on t1.FID=t2.FID  where  t1.FBILLNO = '" + PO_ID + "' and t2.FSEQ =  " + PO_SEQ;
                                        int fid = 0;
                                        int fenttyid = 0;
                                        using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr.Read())
                                            {
                                                fid = Convert.ToInt32(dr[0]);
                                                fenttyid = Convert.ToInt32(dr[1]);
                                            }
                                        }
                                        conn.Close();
                                        conn.Open();
                                        command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                        string dw = "";
                                        using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr1.Read())
                                            {
                                                dw = Convert.ToString(dr1[0]);
                                            }
                                        }
                                        conn.Close();
                                        if (i > 0)
                                        {
                                            fentryjson += ",";
                                        }
                                        fentryjson += "{\"FRowType\": \"Standard\",\"FMATERIALID\": {\"FNumber\": \"" + MTRL_ID + "\" }," +
                                                      "\"FMaterialDesc\": \"ES 全硅胶安全匙梗 印 EASYcare\",\"FUnitID\": { \"FNumber\": \"" + dw + "\" }," +
                                                      "\"FRMREALQTY\": " + QUANTITY + ",\"FREPLENISHQTY\": 1,\"FKEAPAMTQTY\": " + QUANTITY + "," +
                                                      "\"FPRICEUNITID\": {\"FNumber\": \"" + dw + "\"}," +
                                                      "\"FSTOCKID\": {\"FNumber\": \"" + STORE_ID + "\" }," +
                                                      "\"FStockStatusId\": {\"FNumber\": \"KCZT01_SYS\" }," +
                                                      "\"FIsReceiveUpdateStock\": false, \"FGiveAway\": false,\"FPriceBaseQty\": " + QUANTITY + "," +
                                                      "\"FCarryUnitId\": {\"FNumber\": \"" + dw + "\"},\"FCarryQty\": " + QUANTITY + "," +
                                                      "\"FCarryBaseQty\": " + QUANTITY + ", \"FBILLINGCLOSE\": false," +
                                                      "\"FOWNERTYPEID\": \"BD_OwnerOrg\",\"FOWNERID\": { \"FNumber\": \"" + FACT_ID + "\"}," +
                                                      "\"FENTRYTAXRATE\": 13.00,\"FIsStock\": false,\"FORDERNO\": \"" + PO_ID + "\"," +
                                                      "\"FSRCBillNo\": \"" + PO_ID + "\",\"FSRCBillTypeId\": \"PUR_PurchaseOrder\"," +
                                                     "\"FPURMRBENTRY_Link \": [{\"FPURMRBENTRY_Link_FRuleId\": \"PUR_PurchaseOrder-PUR_MRB\"," +
                                                     " \"FPURMRBENTRY_Link_FSTableName\": \"t_PUR_POOrderEntry\"," +
                                                     "\"FPURMRBENTRY_Link_FSBillId\": " + fid + ",\"FPURMRBENTRY_Link_FSId\": " + fenttyid + "}] }";
                                    }
                                    //根据单据类型不同,字段值不同 FBusinessType 有 CG WW   FBillTypeID 有 TLD01_SYS  TLD04_SYS
                                    string FBusinessType = "WW";
                                    string FBillTypeID = "20CGTL";
                                    if (IS_OUTS == "N")
                                    {
                                        FBusinessType = "CG";
                                        FBillTypeID = "11CGTL";
                                    }
                                    string topjosn = "{\"Creator\": \"\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"true\",\"Model\": {\"FID\": 0,\"FBillTypeID\": { \"FNUMBER\": \"" + FBillTypeID + "\" },\"FBusinessType\":\"" + FBusinessType + "\",\"FDate\": \"" + time + "\",\"FMRTYPE\": \"B\",\"FMRMODE\": \"A\",\"FStockOrgId\": {\"FNumber\": \"" + FACT_ID + "\"},\"FRequireOrgId\": {\"FNumber\": \"" + FACT_ID + "\" },\"FPurchaseOrgId\": {\"FNumber\": \"" + PO_ORG_ID + "\"},\"FSupplierID\": {\"FNumber\": \"" + SUP_ID + "\"},\"FACCEPTORID\": {\"FNumber\": \"" + SUP_ID + "\"},\"FSettleId\": {\"FNumber\": \"" + SUP_ID + "\"}, \"FCHARGEID\": {\"FNumber\": \"" + SUP_ID + "\"},\"FOwnerTypeIdHead\": \"BD_OwnerOrg\",\"FOwnerIdHead\": {\"FNumber\": \"" + FACT_ID + "\"},\"FAcceptorContactID\": {\"FCONTACTNUMBER\": \"CXR000092\"}, \"F_ora_QUEUE_N\": \"" + QUEUE_ID + "\",\"FPURMRBFIN\": {\"FSettleOrgId\": {\"FNumber\": \"" + PO_ORG_ID + "\"},\"FSettleCurrId\": { \"FNumber\": \"PRE001\"},\"FPAYCONDITIONID\": {\"FNumber\": \"2\" },\"FIsIncludedTax\": true,\"FPRICETIMEPOINT\": \"1\", \"FLOCALCURRID\": { \"FNumber\": \"PRE001\" },\"FEXCHANGETYPEID\": { \"FNumber\": \"HLTX01_SYS\" }, \"FEXCHANGERATE\": 1.0,\"FISPRICEEXCLUDETAX\": true},";

                                    sjson = topjosn + "\"FPURMRBENTRY\": [" + fentryjson + "]}}";
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "PUR_MRB", sjson });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];
                                    }
                                }
                                else
                                {
                                    xmlDate = "生成失败：唯一序号已存在,不可重复生成!";
                                }
                            }
                            #endregion
                            break;
                        case "R100":
                            #region 其他出库/委外超耗
                            if (dt.Rows.Count > 0)
                            {

                                int shif = 0;
                                QUEUE_ID = Convert.ToInt32(dt.Rows[0]["QUEUE_ID"]);//唯一序号
                                command.CommandText = "select count(1) from T_STK_MISDELIVERY where F_ORA_QUEUE_N = " + QUEUE_ID;
                                using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                {
                                    while (dr.Read())
                                    {
                                        shif = Convert.ToInt32(dr[0]);
                                    }
                                }
                                conn.Close();
                                if (shif == 0)
                                {

                                    string time = "";
                                    string fentryjson = "";
                                    string SHIPPER_ID = "";
                                    string SHIPPER_TYPE = "";
                                    string FACT_ID = "";
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        time = Convert.ToString(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        string STORE_ID = Convert.ToString(dt.Rows[i]["STORE_ID"]);//仓库编码
                                        SHIPPER_ID = Convert.ToString(dt.Rows[i]["SHIPPER_ID"]);//货主编码
                                        SHIPPER_TYPE = Convert.ToString(dt.Rows[i]["SHIPPER_TYPE"]);//货主类型
                                        #region 根据客户给的报文,判断（1 业务组织 2供应商 3客户）
                                        if (SHIPPER_TYPE == "1")
                                        {
                                            SHIPPER_TYPE = "BD_OwnerOrg";
                                        }
                                        else if (SHIPPER_TYPE == "2")
                                        {
                                            SHIPPER_TYPE = "BD_Supplier";
                                            #region 供应商
                                            if (dt.Rows[i]["SHIPPER_ID"].ToString().Length == 1)
                                            {
                                                SHIPPER_ID = "00" + dt.Rows[i]["SHIPPER_ID"].ToString();
                                            }
                                            else if (dt.Rows[i]["SHIPPER_ID"].ToString().Length == 2)
                                            {
                                                SHIPPER_ID = "0" + dt.Rows[i]["SHIPPER_ID"].ToString();
                                            }
                                            #endregion
                                        }
                                        else if (SHIPPER_TYPE == "3")
                                        {
                                            SHIPPER_TYPE = "BD_Customer";
                                            #region 客户
                                            if (dt.Rows[i]["SHIPPER_ID"].ToString().Length == 1)
                                            {
                                                SHIPPER_ID = "00" + dt.Rows[i]["SHIPPER_ID"].ToString();
                                            }
                                            else if (dt.Rows[i]["SHIPPER_ID"].ToString().Length == 2)
                                            {
                                                SHIPPER_ID = "0" + dt.Rows[i]["SHIPPER_ID"].ToString();
                                            }
                                            #endregion
                                        }
                                        #endregion
                                        string MTRL_ID = Convert.ToString(dt.Rows[i]["MTRL_ID"]);//物料编码                                           
                                        decimal QUANTITY = Convert.ToDecimal(dt.Rows[i]["QUANTITY"]);//数量
                                        REMARK = Convert.ToString(dt.Rows[i]["REMARK"]);   //备注 
                                        string ITEM_ID = Convert.ToString(dt.Rows[i]["ITEM_ID"]);//研发项目编码
                                        if (ITEM_ID.Length == 1)
                                        {
                                            ITEM_ID = "00" + ITEM_ID;
                                        }
                                        else if (ITEM_ID.Length == 2)
                                        {
                                            ITEM_ID = "0" + ITEM_ID;
                                        }
                                        DEPT_ID = Convert.ToString(dt.Rows[i]["DEPT_ID"]);//部门编码
                                        #region 部门
                                        if (DEPT_ID.Length == 1)
                                        {
                                            DEPT_ID = "00" + DEPT_ID;
                                        }
                                        else if (DEPT_ID.Length == 2)
                                        {
                                            DEPT_ID = "0" + DEPT_ID;
                                        }
                                        #endregion
                                        FACT_ID = Convert.ToString(dt.Rows[i]["ORG_ID"]);//库存组织
                                        REF_TYPE = Convert.ToString(dt.Rows[i]["REF_TYPE"]);//单据类型
                                        #region 单据类型
                                        if (REF_TYPE == "1")
                                        {
                                            REF_TYPE = "10QTCK";
                                        }
                                        else if (REF_TYPE == "2")
                                        {
                                            REF_TYPE = "20QTCK";
                                            #region 研发项目编码
                                            if (dt.Rows[i]["ITEM_ID"].ToString().Length == 1)
                                            {
                                                ITEM_ID = "00" + dt.Rows[i]["ITEM_ID"].ToString();
                                            }
                                            else if (dt.Rows[i]["ITEM_ID"].ToString().Length == 2)
                                            {
                                                ITEM_ID = "0" + dt.Rows[i]["ITEM_ID"].ToString();
                                            }
                                            else if (dt.Rows[i]["ITEM_ID"].ToString().Length > 2)
                                            {
                                                ITEM_ID = dt.Rows[i]["ITEM_ID"].ToString();
                                            }
                                            #endregion
                                        }
                                        else if (REF_TYPE == "3")
                                        {
                                            REF_TYPE = "30QTCK";
                                        }
                                        else if (REF_TYPE == "4")
                                        {
                                            REF_TYPE = "40QTCK";
                                        }
                                        else if (REF_TYPE == "5")
                                        {
                                            REF_TYPE = "50QTCK";
                                        }
                                        else
                                        {
                                            REF_TYPE = "REF_TYPE";
                                        }
                                        #endregion
                                        conn.Open();
                                        command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                        string dw = "";
                                        using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr1.Read())
                                            {
                                                dw = Convert.ToString(dr1[0]);
                                            }
                                        }
                                        conn.Close();
                                        if (i > 0)
                                        {
                                            fentryjson += ",";
                                        }
                                        fentryjson += "{\"FMaterialId\": {\"FNumber\": \"" + MTRL_ID + "\"}," +
                                                      "\"FUnitID\": {\"FNumber\": \"" + dw + "\"}," +
                                                      "\"FQty\": " + QUANTITY + "," +
                                                      "\"FBaseUnitId\": {\"FNumber\": \"" + dw + "\" },\"FStockId\": {\"FNumber\": \"" + STORE_ID + "\"}," +
                                            //"\"FLot\": {\"FNumber\": \"20190731\"}," +
                                                      "\"FOwnerTypeId\": \"" + SHIPPER_TYPE + "\",\"FOwnerId\": {\"FNumber\": \"" + SHIPPER_ID + "\"}," +
                                                      "\"FEntryNote\": \"" + REMARK + "\"," +
                                                      "\"FStockStatusId\": {\"FNumber\": \"KCZT01_SYS\"}," +
                                                      "\"FKeeperTypeId\": \"BD_KeeperOrg\",\"FDistribution\": false," +
                                                      "\"FKeeperId\": {\"FNumber\": \"" + FACT_ID + "\" },\"F_PAZE_CheckBox\": false," +
                                                      "\"F_RCGD_Assistant_Y\": {\"FNumber\": \"" + ITEM_ID + "\" }}";
                                    }
                                    string topjosn = "{\"Creator\": \"\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"true\",\"Model\": {\"FID\": 0,\"FBillTypeID\": {\"FNUMBER\": \"" + REF_TYPE + "\"},\"FStockOrgId\": {\"FNumber\": \"" + FACT_ID + "\"},\"FPickOrgId\": {\"FNumber\": \"" + FACT_ID + "\"},\"FStockDirect\": \"GENERAL\",\"FDate\": \"" + time + "\",\"FDeptId\": {\"FNumber\": \"" + DEPT_ID + "\"},\"FOwnerTypeIdHead\": \"" + SHIPPER_TYPE + "\",\"FOwnerIdHead\": {\"FNumber\": \"" + SHIPPER_ID + "\"},\"FNote\": \"" + REMARK + "\",\"FBaseCurrId\": {\"FNumber\": \"PRE001\"}, \"F_ora_QUEUE_N\": \"" + QUEUE_ID + "\",";

                                    sjson = topjosn + "\"FEntity\": [" + fentryjson + "]}}";
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "STK_MisDelivery", sjson });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];
                                    }
                                }
                                else
                                {
                                    xmlDate = "生成失败：唯一序号已存在,不可重复生成!";
                                }
                            }
                            #endregion
                            break;
                        case "R006-1":
                            #region 客供料退料,受托加工材料退料单
                            if (dt.Rows.Count > 0)
                            {

                                int shif = 0;
                                QUEUE_ID = Convert.ToInt32(dt.Rows[0]["QUEUE_ID"]);//唯一序号
                                command.CommandText = "select count(1) from T_STK_OEMINSTOCKRTN where F_ORA_QUEUE_N = " + QUEUE_ID;
                                using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                {
                                    while (dr.Read())
                                    {
                                        shif = Convert.ToInt32(dr[0]);
                                    }
                                }
                                conn.Close();
                                if (shif == 0)
                                {


                                    string time = "";
                                    string fentryjson = "";
                                    string FACT_ID = "";

                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        time = Convert.ToString(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        string STORE_ID = Convert.ToString(dt.Rows[i]["STORE_ID"]);//仓库编码
                                        CUST_ID = Convert.ToString(dt.Rows[i]["CUST_ID"]);//客户编码
                                        if (CUST_ID.Length < 3)
                                        {
                                            if (CUST_ID.Length == 2)
                                            {
                                                CUST_ID = "0" + CUST_ID;
                                            }
                                            else
                                            {
                                                CUST_ID = "00" + CUST_ID;
                                            }
                                        }
                                        string MTRL_ID = Convert.ToString(dt.Rows[i]["MTRL_ID"]);//物料编码                                           
                                        decimal QUANTITY = Convert.ToDecimal(dt.Rows[i]["QUANTITY"]);//数量
                                        REMARK = Convert.ToString(dt.Rows[i]["REMARK"]);   //备注 
                                        FACT_ID = Convert.ToString(dt.Rows[i]["ORG_ID"]);//库存组织
                                        conn.Open();
                                        command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                        string dw = "";
                                        using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr1.Read())
                                            {
                                                dw = Convert.ToString(dr1[0]);
                                            }
                                        }
                                        conn.Close();
                                        //查询库存状态
                                        conn.Open();
                                        command.CommandText = "select aa.FNUMBER from t_BD_Stock a left join  T_BD_STOCKSTATUS aa on aa.FMASTERID=a.FDEFSTOCKSTATUSID where a.FNUMBER='" + STORE_ID + "'";
                                        string zt = "";
                                        using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr1.Read())
                                            {
                                                zt = Convert.ToString(dr1[0]);
                                            }
                                        }
                                        conn.Close();
                                        if (i > 0)
                                        {
                                            fentryjson += ",";
                                        }
                                        fentryjson += "{\"FMaterialId\": {\"FNumber\": \"" + MTRL_ID + "\" }," +
                                                      "\"FUnitID\": {\"FNumber\": \"" + dw + "\"},\"FQty\": " + QUANTITY + "," +
                                                      "\"FStockId\": {\"FNumber\": \"" + STORE_ID + "\"}," +
                                                      "\"FStockStatusId\": {\"FNumber\": \"" + zt + "\"}," +
                                                      "\"FNoteEntry\": \"" + REMARK + "\",\"FOwnerTypeId\": \"BD_OwnerOrg\"," +
                                                      "\"FOwnerId\": {\"FNumber\": \"101\"}," +
                                                      "\"FKeeperTypeId\": \"BD_KeeperOrg\"," +
                                                      "\"FKeeperId\": {\"FNumber\": \"101\"}}";
                                    }
                                    string topjosn = "{\"Creator\": \"\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"true\",\"Model\": {\"FID\": 0,\"FBillTypeID\": {\"FNUMBER\": \"10KGTK\"},\"FStockOrgId\": {\"FNumber\": \"" + FACT_ID + "\"},\"FDate\": \"" + time + "\",\"FCustId\": {\"FNumber\": \"" + CUST_ID + "\"},\"FNote\": \"beizt\",\"FOwnerTypeIdHead\": \"BD_OwnerOrg\",\"FCreatorId\": {\"FUserID\": 183893},\"FCreateDate\": \"" + time + "\",\"FReturnStyle\": \"ReturnNoFeed\",\"FReturnType\": \"StockReMat\",\"F_ora_QUEUE_N\": \"" + QUEUE_ID + "\",";

                                    sjson = topjosn + "\"FBillEntry\": [" + fentryjson + "]}}";
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "STK_OEMInStockRETURN", sjson });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];
                                    }
                                }
                                else
                                {
                                    xmlDate = "生成失败：唯一序号已存在,不可重复生成!";
                                }
                            }
                            #endregion
                            break;
                        case "R010":
                            #region 物料调拨,直接调拨单
                            if (dt.Rows.Count > 0)
                            {

                                int shif = 0;
                                QUEUE_ID = Convert.ToInt32(dt.Rows[0]["QUEUE_ID"]);//唯一序号
                                command.CommandText = "select count(1) from T_STK_STKTRANSFERIN where F_ORA_QUEUE_N = " + QUEUE_ID;
                                using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                {
                                    while (dr.Read())
                                    {
                                        shif = Convert.ToInt32(dr[0]);
                                    }
                                }
                                conn.Close();
                                if (shif == 0)
                                {
                                    TRX_DATE = Convert.ToDateTime("2020-01-01");
                                    string time = "";
                                    string fentryjson = "";
                                    string ORG_TYPE = "";
                                    string FACT_ID = "";
                                    string SHIPPER_ID = "";
                                    string SHIPPER_TYPE = "";
                                    string TO_SHIPPER_ID = "";
                                    string TO_SHIPPER_TYPE = "";
                                    string TO_ORG_ID = "";
                                    string STORE_ID = "";
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        time = Convert.ToString(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        STORE_ID = Convert.ToString(dt.Rows[i]["STORE_ID"]);//出库仓库编码
                                        string TOSTORE_ID = Convert.ToString(dt.Rows[i]["TOSTORE_ID"]);//入库仓库编码
                                        SHIPPER_ID = Convert.ToString(dt.Rows[i]["SHIPPER_ID"]);//调出货主编码
                                        SHIPPER_TYPE = Convert.ToString(dt.Rows[i]["SHIPPER_TYPE"]);//调出货主类型    ----货主类型为视图
                                        TO_SHIPPER_ID = Convert.ToString(dt.Rows[i]["TO_SHIPPER_ID"]);//调入货主编码
                                        TO_SHIPPER_TYPE = Convert.ToString(dt.Rows[i]["TO_SHIPPER_TYPE"]);//调入货主类型   ----货主类型为视图,需查表中存储的值
                                        TO_ORG_ID = Convert.ToString(dt.Rows[i]["TO_ORG_ID"]);//传调入组织
                                        string MTRL_ID = Convert.ToString(dt.Rows[i]["MTRL_ID"]);//物料编码                                           
                                        decimal QUANTITY = Convert.ToDecimal(dt.Rows[i]["QUANTITY"]);//数量
                                        REMARK = Convert.ToString(dt.Rows[i]["REMARK"]);   //备注 
                                        ORG_TYPE = Convert.ToString(dt.Rows[i]["ORG_TYPE"]);//调拨类型 （1、组织内调拨 2、跨组织调拨） 暂时默认1  ---已经默认为1,后续修改,需添加判断代码
                                        if (ORG_TYPE == "1")
                                        {
                                            ORG_TYPE = "InnerOrgTransfer";
                                        }
                                        else if (ORG_TYPE == "2")
                                        {
                                            ORG_TYPE = "OverOrgTransfer";
                                        }
                                        FACT_ID = Convert.ToString(dt.Rows[i]["ORG_ID"]);//库存组织
                                        #region 根据客户给的报文,判断（1 业务组织 2供应商 3客户）
                                        if (SHIPPER_TYPE == "1")
                                        {
                                            SHIPPER_TYPE = "BD_OwnerOrg";
                                            TO_SHIPPER_TYPE = "BD_OwnerOrg";
                                        }
                                        else if (SHIPPER_TYPE == "2")
                                        {
                                            SHIPPER_TYPE = "BD_Supplier";
                                            TO_SHIPPER_TYPE = "BD_Supplier";
                                            #region 供应商
                                            if (dt.Rows[i]["SHIPPER_ID"].ToString().Length == 1)
                                            {
                                                SHIPPER_ID = "00" + dt.Rows[i]["SHIPPER_ID"].ToString();
                                            }
                                            else if (dt.Rows[i]["SHIPPER_ID"].ToString().Length == 2)
                                            {
                                                SHIPPER_ID = "0" + dt.Rows[i]["SHIPPER_ID"].ToString();
                                            }
                                            if (Convert.ToString(dt.Rows[i]["TO_SHIPPER_ID"]).Length == 1)
                                            {
                                                TO_SHIPPER_ID = "00" + Convert.ToString(dt.Rows[i]["TO_SHIPPER_ID"]);
                                            }
                                            else if (Convert.ToString(dt.Rows[i]["TO_SHIPPER_ID"]).Length == 2)
                                            {
                                                TO_SHIPPER_ID = "0" + Convert.ToString(dt.Rows[i]["TO_SHIPPER_ID"]);
                                            }
                                            #endregion
                                        }
                                        else if (SHIPPER_TYPE == "3")
                                        {
                                            SHIPPER_TYPE = "BD_Customer";
                                            TO_SHIPPER_TYPE = "BD_Customer";
                                            #region 客户
                                            if (dt.Rows[i]["SHIPPER_ID"].ToString().Length == 1)
                                            {
                                                SHIPPER_ID = "00" + dt.Rows[i]["SHIPPER_ID"].ToString();
                                            }
                                            else if (dt.Rows[i]["SHIPPER_ID"].ToString().Length == 2)
                                            {
                                                SHIPPER_ID = "0" + dt.Rows[i]["SHIPPER_ID"].ToString();
                                            }
                                            if (Convert.ToString(dt.Rows[i]["TO_SHIPPER_ID"]).Length == 1)
                                            {
                                                TO_SHIPPER_ID = "00" + Convert.ToString(dt.Rows[i]["TO_SHIPPER_ID"]);
                                            }
                                            else if (Convert.ToString(dt.Rows[i]["TO_SHIPPER_ID"]).Length == 2)
                                            {
                                                TO_SHIPPER_ID = "0" + Convert.ToString(dt.Rows[i]["TO_SHIPPER_ID"]);
                                            }
                                            #endregion
                                        }
                                        #endregion
                                        conn.Open();
                                        command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                        string dw = "";
                                        using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr1.Read())
                                            {
                                                dw = Convert.ToString(dr1[0]);
                                            }
                                        }

                                        conn.Close();

                                        #region 查询库存状态
                                        conn.Open();
                                        command.CommandText = "select aa.FNUMBER from t_BD_Stock a left join  T_BD_STOCKSTATUS aa on aa.FMASTERID=a.FDEFSTOCKSTATUSID where a.FNUMBER='" + STORE_ID + "'";
                                        string zt = "";
                                        using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr1.Read())
                                            {
                                                zt = Convert.ToString(dr1[0]);
                                            }
                                        }
                                        conn.Close();
                                        conn.Open();
                                        command.CommandText = "select aa.FNUMBER from t_BD_Stock a left join  T_BD_STOCKSTATUS aa on aa.FMASTERID=a.FDEFSTOCKSTATUSID where a.FNUMBER='" + TOSTORE_ID + "'";
                                        string zt1 = "";
                                        using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr1.Read())
                                            {
                                                zt1 = Convert.ToString(dr1[0]);
                                            }
                                        }
                                        conn.Close();
                                        #endregion
                                        if (i > 0)
                                        {
                                            fentryjson += ",";
                                        }
                                        fentryjson += "{\"FMaterialId\": {\"FNumber\": \"" + MTRL_ID + "\"}," +
                                                      "\"FUnitID\": {\"FNumber\": \"" + dw + "\"},\"FQty\": " + QUANTITY + "," +
                                                      "\"FSrcStockId\": {\"FNumber\": \"" + STORE_ID + "\"}," +
                                                      "\"FDestStockId\": {\"FNumber\": \"" + TOSTORE_ID + "\"}," +
                                                      "\"FSrcStockStatusId\": {\"FNumber\": \"" + zt + "\"}," +
                                                      "\"FDestStockStatusId\": {\"FNumber\": \"" + zt1 + "\"}," +
                                                      "\"FBusinessDate\": \"2020-01-08 00:00:00\"," +
                                                      "\"FOwnerTypeOutId\": \"" + SHIPPER_TYPE + "\"," +
                                                      "\"FOwnerOutId\": {\"FNumber\": \"" + SHIPPER_ID + "\"}," +
                                                      "\"FOwnerTypeId\": \"" + TO_SHIPPER_TYPE + "\"," +
                                                      "\"FOwnerId\": {\"FNumber\": \"" + TO_SHIPPER_ID + "\"}," +
                                                      "\"FNoteEntry\": \"" + REMARK + "\"," +
                                                      "\"FBaseUnitId\": {\"FNumber\": \"" + dw + "\"},\"FBaseQty\": " + QUANTITY + "," +
                                                      "\"FISFREE\": false,\"FKeeperTypeId\": \"BD_KeeperOrg\"," +
                                                      "\"FKeeperId\": {\"FNumber\": \"" + TO_ORG_ID + "\"},\"FKeeperTypeOutId\": \"BD_KeeperOrg\"," +
                                                      "\"FKeeperOutId\": {\"FNumber\": \"" + FACT_ID + "\"}," +
                                                      "\"FDestMaterialId\": {\"FNUMBER\": \"" + MTRL_ID + "\"}," +
                                                      "\"FSaleUnitId\": {\"FNumber\": \"" + dw + "\"},\"FSaleQty\": " + QUANTITY + "," +
                                                      "\"FSalBaseQty\": " + QUANTITY + ",\"FPriceUnitID\": {\"FNumber\": \"" + dw + "\"}," +
                                                      "\"F_PAZE_CheckBox\": false,\"FTransReserveLink\": false,\"FCheckDelivery\": false}";
                                    }
                                    string topjosn = "{\"Creator\": \"\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"true\",\"Model\": {\"FID\": 0,\"FBillTypeID\": {\"FNUMBER\": \"10ZJDB\"},\"FBizType\": \"NORMAL\",\"FTransferDirect\": \"GENERAL\",\"FTransferBizType\": \"" + ORG_TYPE + "\",\"FSettleOrgId\": {\"FNumber\": \"" + FACT_ID + "\"},\"FSaleOrgId\": {\"FNumber\": \"" + FACT_ID + "\"},\"FStockOutOrgId\": {\"FNumber\": \"" + FACT_ID + "\"},\"FOwnerTypeOutIdHead\": \"" + SHIPPER_TYPE + "\",\"FOwnerOutIdHead\": {\"FNumber\": \"" + SHIPPER_ID + "\"},\"FStockOrgId\": {\"FNumber\": \"" + TO_ORG_ID + "\"},\"FIsIncludedTax\": true,\"FIsPriceExcludeTax\": true,\"FOwnerTypeIdHead\": \"" + TO_SHIPPER_TYPE + "\",\"FSETTLECURRID\": {\"FNUMBER\": \"PRE001\"},\"FOwnerIdHead\": {\"FNumber\": \"" + TO_SHIPPER_ID + "\"},\"FDate\": \"" + time + "\",\"FNote\": \"备注\",\"FBaseCurrId\": {\"FNumber\": \"PRE001\"}, \"F_ora_QUEUE_N\": \"" + QUEUE_ID + "\",";

                                    sjson = topjosn + "\"FBillEntry\": [" + fentryjson + "]}}";
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "STK_TransferDirect", sjson });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];
                                    }
                                }
                                else
                                {
                                    xmlDate = "生成失败：唯一序号已存在,不可重复生成!";
                                }
                            }
                            #endregion
                            break;
                        case "R023":
                            #region 盘点盘盈
                            if (dt.Rows.Count > 0)
                            {

                                int shif = 0;
                                QUEUE_ID = Convert.ToInt32(dt.Rows[0]["QUEUE_ID"]);//唯一序号
                                command.CommandText = "select count(1) from T_STK_STKCOUNTGAIN where F_ORA_QUEUE_N = " + QUEUE_ID;
                                using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                {
                                    while (dr.Read())
                                    {
                                        shif = Convert.ToInt32(dr[0]);
                                    }
                                }
                                conn.Close();
                                if (shif == 0)
                                {

                                    TRX_DATE = Convert.ToDateTime("2020-01-01");
                                    string time = "";
                                    string fentryjson = "";
                                    string FACT_ID = "";
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        time = Convert.ToString(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        string STORE_ID = Convert.ToString(dt.Rows[i]["STORE_ID"]);//仓库编码
                                        string MTRL_ID = Convert.ToString(dt.Rows[i]["MTRL_ID"]);//物料编码                                           
                                        decimal QUANTITY = Convert.ToDecimal(dt.Rows[i]["QUANTITY"]);//数量
                                        REMARK = Convert.ToString(dt.Rows[i]["REMARK"]);   //备注 
                                        FACT_ID = Convert.ToString(dt.Rows[i]["ORG_ID"]);//库存组织
                                        conn.Open();
                                        command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                        string dw = "";
                                        using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr1.Read())
                                            {
                                                dw = Convert.ToString(dr1[0]);
                                            }
                                        }
                                        conn.Close();
                                        //查询库存状态
                                        conn.Open();
                                        command.CommandText = "select aa.FNUMBER from t_BD_Stock a left join  T_BD_STOCKSTATUS aa on aa.FMASTERID=a.FDEFSTOCKSTATUSID where a.FNUMBER='" + STORE_ID + "'";
                                        string zt = "";
                                        using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr1.Read())
                                            {
                                                zt = Convert.ToString(dr1[0]);
                                            }
                                        }
                                        conn.Close();
                                        //查询该物料该组织该仓库下的即时库存
                                        conn.Open();
                                        command.CommandText = "select isnull(sum(t1.FBASEQTY),0) from T_STK_INVENTORY t1 left join V_SCM_KEEPERORG t2 on t1.FSTOCKORGID = t2.FORGID left join t_BD_Stock t3 on t1.FSTOCKID = t3.FSTOCKID left join T_BD_MATERIAL t4 on t1.FMATERIALID = t4.FMATERIALID where t2.FNUMBER = '" + FACT_ID + "' and t4.FNUMBER = '" + MTRL_ID + "' and t3.FNUMBER = '" + STORE_ID + "'";
                                        decimal sl = 0;
                                        using (SqlDataReader dr2 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr2.Read())
                                            {
                                                sl = Convert.ToDecimal(dr2[0]);
                                            }
                                        }
                                        conn.Close();
                                        if (i > 0)
                                        {
                                            fentryjson += ",";
                                        }
                                        fentryjson += "{\"FMaterialId\": {\"FNumber\": \"" + MTRL_ID + "\"}," +
                                                      "\"FUnitID\": {\"FNumber\": \"" + dw + "\"}," +
                                                      "\"FAcctQty\": " + sl + ",\"FCountQty\": " + (sl + QUANTITY) + ",\"FGainQty\": " + QUANTITY + "," +
                                                      "\"FStockId\": {\"FNumber\": \"" + STORE_ID + "\"}," +
                                            //"\"FLOT\": {\"FNumber\": \"111\"}," +
                                                      "\"FBusinessDate\": \"" + time + "\",\"FOwnerTypeId\": \"BD_OwnerOrg\"," +
                                                      "\"FOwnerid\": {\"FNumber\": \"101\"},\"Fnote\": \"" + REMARK + "\"," +
                                                      "\"FStockStatusId\": {\"FNumber\": \"" + zt + "\"}," +
                                                      "\"FBaseAcctQty\": " + sl + ",\"FBaseCountQty\": " + (sl + QUANTITY) + ",\"FBaseGainQty\": " + QUANTITY + "," +
                                                      "\"FKeeperTypeId\": \"BD_KeeperOrg\",\"FKeeperId\": {\"FNumber\": \"101\"}}";
                                    }
                                    string topjosn = "{\"Creator\": \"\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"true\",\"Model\": {\"FID\": 0,\"FBillTypeID\": {\"FNUMBER\": \"10PYDJ\"},\"FStockOrgId\": {\"FNumber\": \"" + FACT_ID + "\"},\"FOwnerTypeIdHead\": \"BD_OwnerOrg\",\"FOwnerIdHead\": {\"FNumber\": \"101\"},\"FDate\": \"" + time + "\",\"FNoteHead\": \"" + REMARK + "\",\"F_ora_QUEUE_N\": \"" + QUEUE_ID + "\",";

                                    sjson = topjosn + "\"FBillEntry\": [" + fentryjson + "]}}";
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "STK_StockCountGain", sjson });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];
                                    }
                                }
                                else
                                {
                                    xmlDate = "生成失败：唯一序号已存在,不可重复生成!";
                                }
                            }
                            #endregion
                            break;
                        case "R024":
                            #region 盘点盘亏
                            if (dt.Rows.Count > 0)
                            {

                                int shif = 0;
                                QUEUE_ID = Convert.ToInt32(dt.Rows[0]["QUEUE_ID"]);//唯一序号
                                command.CommandText = "select count(1) from T_STK_STKCOUNTLOSS where F_ORA_QUEUE_N = " + QUEUE_ID;
                                using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                {
                                    while (dr.Read())
                                    {
                                        shif = Convert.ToInt32(dr[0]);
                                    }
                                }
                                conn.Close();
                                if (shif == 0)
                                {
                                    string xlmata = "";
                                    TRX_DATE = Convert.ToDateTime("2020-01-01");
                                    string time = "";
                                    string fentryjson = "";
                                    string FACT_ID = "";
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        time = Convert.ToString(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        string STORE_ID = Convert.ToString(dt.Rows[i]["STORE_ID"]);//仓库编码
                                        string MTRL_ID = Convert.ToString(dt.Rows[i]["MTRL_ID"]);//物料编码                                           
                                        decimal QUANTITY = Convert.ToDecimal(dt.Rows[i]["QUANTITY"]);//数量
                                        REMARK = Convert.ToString(dt.Rows[i]["REMARK"]);   //备注 
                                        FACT_ID = Convert.ToString(dt.Rows[i]["ORG_ID"]);//库存组织
                                        conn.Open();
                                        command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                        string dw = "";
                                        using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr1.Read())
                                            {
                                                dw = Convert.ToString(dr1[0]);
                                            }
                                        }
                                        conn.Close();
                                        //查询该物料该组织该仓库下的即时库存
                                        conn.Open();
                                        command.CommandText = "select isnull(sum(t1.FBASEQTY),0) from T_STK_INVENTORY t1 left join V_SCM_KEEPERORG t2 on t1.FSTOCKORGID = t2.FORGID left join t_BD_Stock t3 on t1.FSTOCKID = t3.FSTOCKID left join T_BD_MATERIAL t4 on t1.FMATERIALID = t4.FMATERIALID where t2.FNUMBER = '" + FACT_ID + "' and t4.FNUMBER = '" + MTRL_ID + "' and t3.FNUMBER = '" + STORE_ID + "'";
                                        decimal sl = 0;
                                        using (SqlDataReader dr2 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr2.Read())
                                            {
                                                sl = Convert.ToDecimal(dr2[0]);
                                            }
                                        }
                                        conn.Close();
                                        if (sl - QUANTITY > 0)
                                        {
                                            if (i > 0)
                                            {
                                                fentryjson += ",";
                                            }
                                            fentryjson += "{\"FMaterialId\": {\"FNumber\": \"" + MTRL_ID + "\"}," +
                                                          "\"FUnitID\": {\"FNumber\": \"" + dw + "\"},\"FBaseUnitId\": {\"FNumber\": \"" + dw + "\"}," +
                                                          "\"FAcctQty\": " + sl + ",\"FCountQty\": " + (sl - QUANTITY) + ",\"FLossQty\": " + QUANTITY + "," +
                                                          "\"FStockId\": {\"FNumber\": \"" + STORE_ID + "\"}," +
                                                // "\"FStockLocId\": {\"FNumber\": \"A01A0204\"}," +
                                                          "\"FStockStatusId\": {\"FNumber\": \"KCZT01_SYS\"}," +
                                                          "\"FOwnerTypeId\": \"BD_OwnerOrg\",\"FOwnerid\": {\"FNumber\": \"101\"}," +
                                                          "\"Fnote\": \"" + REMARK + "\",\"FKeeperTypeId\": \"BD_KeeperOrg\"," +
                                                          "\"FKeeperId\": {\"FNumber\": \"101\"},\"FBaseLossQty\": " + QUANTITY + "," +
                                                          "\"FBaseAcctQty\": " + sl + ",\"FBaseCountQty\": " + (sl - QUANTITY) + "}";
                                        }
                                        else
                                        {
                                            xlmata = xlmata + ";" + MTRL_ID + "，该物料库存不足盘亏，请查证后再生成！";
                                        }

                                    }
                                    string topjosn = "{\"Creator\": \"\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"true\",\"Model\": {\"FID\": 0,\"FBillTypeID\": {\"FNUMBER\": \"10PKDJ\"},\"FDate\": \"" + time + "\",\"FStockOrgId\": {\"FNumber\": \"" + FACT_ID + "\"},\"FOwnerTypeIdHead\": \"BD_OwnerOrg\",\"FOwnerIdHead\": {\"FNumber\": \"101\"},\"FNoteHead\": \"" + REMARK + "\",\"F_ora_QUEUE_N\": \"" + QUEUE_ID + "\",";

                                    sjson = topjosn + "\"FBillEntry\": [" + fentryjson + "]}}";
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "STK_StockCountLoss", sjson });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】" + xlmata;
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"] + xlmata;
                                    }
                                }
                                else
                                {
                                    xmlDate = "生成失败：唯一序号已存在,不可重复生成!";
                                }
                            }
                            #endregion
                            break;
                        case "TKWBG":
                            #region 工时汇报,生产汇报单
                            if (dt.Rows.Count > 0)
                            {

                                int shif = 0;
                                QUEUE_ID = Convert.ToInt32(dt.Rows[0]["QUEUE_ID"]);//唯一序号
                                command.CommandText = "select count(1) from T_PRD_MORPT where F_ORA_QUEUE_N = " + QUEUE_ID;
                                using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                {
                                    while (dr.Read())
                                    {
                                        shif = Convert.ToInt32(dr[0]);
                                    }
                                }
                                conn.Close();
                                if (shif == 0)
                                {

                                    TRX_DATE = Convert.ToDateTime("2020-01-01");
                                    string time = "";
                                    string fentryjson = "";
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        time = Convert.ToString(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        string ERP_MO = Convert.ToString(dt.Rows[i]["ERP_MO"]);//ERP工单编码
                                        ERP_MO_SEQ = Convert.ToString(dt.Rows[i]["ERP_MO_SEQ"]);//ERP工单行号                                           
                                        decimal PASS_QTY = Convert.ToDecimal(dt.Rows[i]["PASS_QTY"]);//合格数量
                                        decimal NG_QTY = Convert.ToDecimal(dt.Rows[i]["NG_QTY"]);//不合格数量
                                        decimal REPAIR_QTY = Convert.ToDecimal(dt.Rows[i]["REPAIR_QTY"]);//待返修数量
                                        decimal SCRAP_QTY = Convert.ToDecimal(dt.Rows[i]["SCRAP_QTY"]);//报废数量
                                        decimal REWORK_QTY = Convert.ToDecimal(dt.Rows[i]["REWORK_QTY"]);//返工数量
                                        decimal COMPLETE_QTY = Convert.ToDecimal(dt.Rows[i]["COMPLETE_QTY"]);//完成数量
                                        decimal PERSON_TIME = Convert.ToDecimal(dt.Rows[i]["PERSON_TIME"]);//人员实作工时(小时)
                                        decimal DEV_TIME = Convert.ToDecimal(dt.Rows[i]["DEV_TIME"]);//机器实作工时(小时)
                                        string STRAT_DATE = Convert.ToString(dt.Rows[i]["STRAT_DATE"]);   //开始时间
                                        string END_DATE = Convert.ToString(dt.Rows[i]["END_DATE"]);//结束时间

                                        conn.Open();
                                        command.CommandText = "select t1.FID,t2.FENTRYID,t3.wl,t3.dw from T_PRD_MO t1 inner join T_PRD_MOENTRY t2 on t1.FID=t2.FID left join (select t1.FMATERIALID,t1.FNUMBER wl,t3.FNUMBER dw from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID) t3 on t2.FMATERIALID=t3.FMATERIALID  where  t1.FBILLNO = '" + ERP_MO + "' and t2.FSEQ =  " + ERP_MO_SEQ;
                                        int fid = 0;
                                        int fenttyid = 0;
                                        string wl = "";
                                        string dw = "";
                                        using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr.Read())
                                            {
                                                fid = Convert.ToInt32(dr[0]);
                                                fenttyid = Convert.ToInt32(dr[1]);
                                                wl = Convert.ToString(dr[2]);
                                                dw = Convert.ToString(dr[3]);
                                            }
                                        }
                                        conn.Close();
                                        if (i > 0)
                                        {
                                            fentryjson += ",";
                                        }
                                        fentryjson += "{\"FSrcEntryId\": " + fenttyid + ",\"FIsNew\": false,\"FMaterialId\": {\"FNumber\": \"" + wl + "\"}," +
                                                      "\"FProductType\": \"1\",\"FReportType\": {\"FNumber\": \"CTG001\"}," +
                                                      "\"FUnitID\": {\"FNumber\": \"" + dw + "\"},\"FWorkshipId\": {\"FNumber\": \"D006\"}," +
                                                      "\"FCheckProduct\": false,\"FIsEntrust\": false,\"FMaterialUnitID\": {\"FNumber\": \"" + dw + "\"}," +
                                                      "\"FFinishQty\":" + COMPLETE_QTY + ",\"FQuaQty\":" + PASS_QTY + "," +
                                                      "\"FFailQty\":" + NG_QTY + ",\"FReworkQty\":" + REPAIR_QTY + "," +
                                                      "\"FScrapQty\":" + SCRAP_QTY + ",\"FReMadeQty\":" + REWORK_QTY + "," +
                                                      "\"FStartTime\": \"" + STRAT_DATE + "\",\"FEndTime\": \"" + END_DATE + "\"," +
                                                      "\"FTimeUnitId\": \"1\",\"FStandHourUnitId\": \"3600\"," +
                                                      "\"FHrPrepareTime\": " + PERSON_TIME + ",\"FHrWorkTime\": " + PERSON_TIME + "," +
                                                      "\"FMacWorkTime\": " + DEV_TIME + ",\"FBaseUnitId\": {\"FNumber\": \"" + dw + "\"}," +
                                                      "\"FOwnerTypeId\": \"BD_OwnerOrg\",\"FISBACKFLUSH\": false," +
                                                      "\"FSrcBillNo\": \"" + ERP_MO + "\",\"FSrcBillType\": \"PRD_MO\"," +
                                                      "\"FEntity_Link\": [{\"FEntity_Link_FRuleId\": \"PRD_MO2MORPT\"," +
                                                      " \"FEntity_Link_FSTableName\": \"T_PRD_MOENTRY\"," +
                                                      "\"FEntity_Link_FSBillId\": " + fid + ",\"FEntity_Link_FSId\": " + fenttyid + "}] }";
                                    }
                                    string topjosn = "{\"Creator\": \"\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"true\",\"Model\": {\"FID\": 0,\"FBillType\": {\"FNUMBER\": \"10SCHB\"},\"FDocumentStatus\": \"Z\",\"FDate\": \"" + time + "\",\"FPrdOrgId\": {\"FNumber\": \"101\"},\"FDescription\": \"备注\",\"F_ora_QUEUE_N\": \"" + QUEUE_ID + "\",";

                                    sjson = topjosn + "\"FEntity\": [" + fentryjson + "]}}";
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "PRD_MORPT", sjson });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];
                                    }
                                }
                                else
                                {
                                    xmlDate = "生成失败：唯一序号已存在,不可重复生成!";
                                }
                            }
                            #endregion
                            break;
                        #endregion

                        #region 小林
                        case "R019-1":
                            #region 委外退料
                            if (dt.Rows.Count > 0)
                            {
                                int shif = 0;
                                QUEUE_ID = Convert.ToInt32(dt.Rows[0]["QUEUE_ID"]);//唯一序号
                                command.CommandText = "select count(1) from t_PUR_MRB where F_ORA_QUEUE_N = " + QUEUE_ID;
                                using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                {
                                    while (dr.Read())
                                    {
                                        shif = Convert.ToInt32(dr[0]);
                                    }
                                }
                                conn.Close();
                                if (shif == 0)
                                {

                                    TRX_DATE = Convert.ToDateTime("2020-01-01");
                                    string time = "";
                                    string fentryjson = "";
                                    string FACT_ID = "";

                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        TRX_DATE = Convert.ToDateTime(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        time = Convert.ToString(dt.Rows[i]["TRX_DATE"]);//交易时间
                                        string STORE_ID = Convert.ToString(dt.Rows[i]["STORE_ID"]);//仓库编码
                                        SUP_ID = Convert.ToString(dt.Rows[i]["SUP_ID"]);//供应商编码
                                        if (SUP_ID.Length < 3)
                                        {
                                            if (SUP_ID.Length == 2)
                                            {
                                                SUP_ID = "0" + SUP_ID;
                                            }
                                            else
                                            {
                                                SUP_ID = "00" + SUP_ID;
                                            }
                                        }
                                        string MTRL_ID = Convert.ToString(dt.Rows[i]["MTRL_ID"]);//物料编码                                           
                                        decimal QUANTITY = Convert.ToDecimal(dt.Rows[i]["QUANTITY"]);//数量
                                        REMARK = Convert.ToString(dt.Rows[i]["REMARK"]);   //备注 
                                        string PO_SEQ = Convert.ToString(dt.Rows[i]["ERP_MO_SEQ"]);//采购单行号
                                        string ERP_MO = Convert.ToString(dt.Rows[i]["ERP_MO"]);//采购单编码   源单类型 PUR_PurchaseOrder
                                        FACT_ID = Convert.ToString(dt.Rows[i]["ORG_ID"]);//采购组织
                                        string SEQ = Convert.ToString(dt.Rows[i]["SEQ"]);
                                        DEPT_ID = Convert.ToString(dt.Rows[i]["DEPT_ID"]);//部门编码
                                        #region 部门
                                        if (DEPT_ID.Length == 1)
                                        {
                                            DEPT_ID = "00" + DEPT_ID;
                                        }
                                        else if (DEPT_ID.Length == 2)
                                        {
                                            DEPT_ID = "0" + DEPT_ID;
                                        }
                                        #endregion
                                        #region 上下查
                                        conn.Open();
                                        command.CommandText = "select t3.FNUMBER from T_BD_MATERIAL t1  inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID where t1.FNUMBER='" + MTRL_ID + "'";
                                        string dw = "";
                                        using (SqlDataReader dr1 = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr1.Read())
                                            {
                                                dw = Convert.ToString(dr1[0]);
                                            }
                                        }
                                        conn.Close();
                                        conn.Open();
                                        //' and t1.FMOENTRYSEQ=" + MO_SEQ + " 订单行号
                                        command.CommandText = " select t1.FID,t1.FENTRYID,t4.FBILLNO,T5.FID,t6.FENTRYID   from T_SUB_PPBOMENTRY t1 left join (select t1.FMATERIALID,t1.FNUMBER wl,t3.FNUMBER dw from T_BD_MATERIAL t1 inner join t_BD_MaterialBase t2 on t1.FMATERIALID = t2.FMATERIALID left join T_BD_UNIT t3 on t2.FBASEUNITID = t3.FUNITID) t3 on t1.FMATERIALID=t3.FMATERIALID left join T_SUB_PPBOM t4 on t4.fid = t1.FID  LEFT JOIN T_SUB_REQORDER T5 ON T1.FSUBREQBILLNO=T5.FBILLNO  left join T_SUB_REQORDERENTRY t6  on t6.fid=t5.fid   where  t1.FSubReqBillNO = '" + ERP_MO + "' and t1.FSEQ=" + SEQ + " and t3.wl = '" + MTRL_ID + "'";
                                        int fid = 0;
                                        int fenttyid = 0;
                                        string fbillNo = "";
                                        int fidWW = 0;
                                        int fentryWWDD = 0;
                                        using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                                        {
                                            while (dr.Read())
                                            {
                                                fid = Convert.ToInt32(dr[0]);
                                                fenttyid = Convert.ToInt32(dr[1]);
                                                fbillNo = dr[2].ToString();
                                                fidWW = Convert.ToInt32(dr[3]);
                                                fentryWWDD = Convert.ToInt32(dr[4]);
                                            }
                                        }
                                        conn.Close();
                                        #endregion
                                        
                                        #region 获取父级代码
                                    conn.Open();
                                    string scEntryId = "";
                                    command.CommandText = " select t3.FNUMBER,t1.FENTRYID from T_SUB_REQORDER t inner join T_SUB_REQORDERENTRY t1 on t.FID=t1.FID left join T_BD_MATERIAL t3 on t1.FMaterialId=t3.FMATERIALID  where FBILLNO='" + ERP_MO + "' and t1.FSEQ=" + PO_SEQ + "";
                                    string fmaterial = "";
                                    using (SqlDataReader drf = command.ExecuteReader(CommandBehavior.CloseConnection))
                                    {
                                        while (drf.Read())
                                        {
                                            fmaterial = Convert.ToString(drf[0]);
                                            scEntryId = Convert.ToString(drf[1]);
                                        }
                                    }
                                    conn.Close();
                                    #endregion

                                        if (i > 0)
                                        {
                                            fentryjson += ",";
                                        }
                                        fentryjson += "  {\"FMaterialId\": {\"FNumber\": \"" + MTRL_ID + "\"},  \"FParentMaterialId\": {\"FNumber\": \"" + fmaterial + "\"},\"FUnitID\": {\"FNumber\": \"" + dw + "\"},\"FAPPQty\": " + QUANTITY + ",\"FQty\": " + QUANTITY + ",\"FReturnType\": \"1\",\"FStockId\": {\"FNumber\": \"" + STORE_ID + "\"},\"FSUBReqBillNo\": \"" + ERP_MO + "\",\"FSUBReqId\": " + fidWW + ",\"FSUBReqEntrySeq\": " + PO_SEQ + ",\"FPPBOMEntryId\":" + fenttyid + ",\"FSrcEntrySeq\":" + SEQ + ",\"FSubReqEntryId\": " + fentryWWDD + ",\"FOwnerTypeId\": \"BD_OwnerOrg\",\"FOwnerId\": {\"FNumber\": \"" + FACT_ID + "\"},\"FSrcBillNo\": \"" + fbillNo + "\",\"FSrcBillType\": \"SUB_PPBOM\",\"FSrcEntryId\": " + fenttyid + ",\"FBaseUnitId\": {\"FNumber\": \"" + dw + "\"},\"FReserveType\": \"1\",\"FBaseStockQty\": " + QUANTITY + ",\"FBaseAppQty\": " + QUANTITY + ",\"FBaseQty\": " + QUANTITY + ",\"FStockUnitId\": {\"FNumber\": \"" + dw + "\"},\"FStockAppQty\": " + QUANTITY + ",\"FStockQty\": " + QUANTITY + ",\"FStockStatusId\": {\"FNumber\": \"KCZT01_SYS\"},\"FKeeperTypeId\": \"BD_KeeperOrg\",\"FKeeperId\": {\"FNumber\": \"" + FACT_ID + "\"},\"FEntryVmiBusiness\": false,\"FSupplierId\": {\"FNUMBER\": \"" + SUP_ID + "\"},\"FParentOwnerTypeId\": \"BD_OwnerOrg\",\"FParentOwnerId\": {\"FNumber\": \"" + FACT_ID + "\"},\"F_RCGD_Base_ZR\": " + DEPT_ID + ",\"FPPBomBillNo\": \"" + fbillNo + "\",\"FEntity_Link\": [{\"FEntity_Link_FRuleId\": \"SUB_PPBOM2RETURNMTRLL\", \"FEntity_Link_FSTableName\":\"T_SUB_PPBOMENTRY\",\"FEntity_Link_FSBillId\": " + fid + ",\"FEntity_Link_FSId\":" + fenttyid + " }] }";
                                    }
                                    sjson = "{\"Creator\": \"\",\"NeedUpDateFields\": [],\"NeedReturnFields\": [],\"IsDeleteEntry\": \"true\",\"SubSystemId\": \"\",\"IsVerifyBaseDataField\": \"false\",\"IsEntryBatchFill\": \"true\",\"ValidateFlag\": \"true\",\"NumberSearch\": \"true\",\"InterationFlags\": \"\",\"IsAutoSubmitAndAudit\": \"true\",\"Model\": {\"FID\": 0,\"FBillType\": {\"FNUMBER\": \"10WWTL\"},\"FDate\": \"" + TRX_DATE + "\",\"FStockOrgId\": {\"FNumber\": \"" + FACT_ID + "\"},\"FSubOrgId\": {\"FNumber\": \"" + FACT_ID + "\"},\"FSubSupplierId\": {\"FNumber\": \"" + SUP_ID + "\"},\"FOwnerTypeId0\": \"BD_OwnerOrg\",\"FIsCrossTrade\": false,\"FVmiBusiness\": false,\"FIsOwnerTInclOrg\": false,\"FEntity\": [" + fentryjson + "]}}";
                                    // 调用Web API接口服务，保存
                                    String resstr = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "SUB_RETURNMTRL", sjson });

                                    JObject jo = (JObject)JsonConvert.DeserializeObject(resstr);
                                    if ((bool)jo["Result"]["ResponseStatus"]["IsSuccess"])
                                    {
                                        xmlDate = "生成成功,单号为：【" + jo["Result"]["ResponseStatus"]["SuccessEntitys"][0]["Number"].ToString() + "】";
                                        IsSucess = "OK";
                                    }
                                    else
                                    {
                                        xmlDate = "生成失败：" + jo["Result"]["ResponseStatus"]["Errors"][0]["Message"];
                                    }
                                }
                                else
                                {
                                    xmlDate = "生成失败：唯一序号已存在,不可重复生成!";
                                }
                            }
                            #endregion
                            break;
                        #endregion


                        default:
                            xmlDate = "请输入DocType！！！";
                            break;


                    }

                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                xmlDate = "无法正常访问API接口！！！";
            }
            string[] result = { IsSucess, xmlDate };

            return result;
        }

    }
}
