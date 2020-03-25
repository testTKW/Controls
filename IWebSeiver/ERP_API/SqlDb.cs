using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.IO;


namespace ERP_API
{
    public class SqlDb
    {
        //连接数据库字符串
        public static string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
        }
      

        public static DataSet GetDataSetByXml(string xmlData)
        {
            try
            {
                DataSet ds = new DataSet();

                using (StringReader xmlSR = new StringReader(xmlData.Trim()))
                {
                    //忽视任何内联架构，从数据推断出强类型架构并加载数据。如果无法推断，则解释成字符串数据
                    ds.ReadXml(xmlSR, XmlReadMode.InferTypedSchema); 
                    if (ds.Tables.Count > 0)
                    {
                        return ds;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //手动获取K3工单信息
        public static string OutPutESMasterFromWs(string fbillNo)
        {
            DataTable dt = new DataTable();
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "WPLAN_Mo", fbillNo.Trim());
            ds.Tables.Add(dt);
            string InputDTOXml = ds.GetXml();
            return InputDTOXml;
        }
        //手动获取委外ERP工单信息
        public static string OutPutESMasterFromWs_OUTS(string fbillNo)
        {
            DataTable dt = new DataTable();
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "WPLAN_OUTS", fbillNo.Trim());
            ds.Tables.Add(dt);
            string InputDTOXml = ds.GetXml();
            return InputDTOXml;
        }

        //K3工单物料需求信息
        public static string OutPutESMasterFromWs_MN(string fbillNo, string fbillNo1)
        {
            DataTable dt = new DataTable();
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "WPLAN_MN", fbillNo.Trim(), fbillNo1.Trim());
            ds.Tables.Add(dt);
            string InputDTOXml = ds.GetXml();
            return InputDTOXml;
        }

        //ERP 委外工单物料需求信息
        public static string OutPutESMasterFromWs_MN_OUTS(string fbillNo, string fbillNo1)
        {
            DataTable dt = new DataTable();
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "WPLAN_MN_OUTS", fbillNo.Trim(), fbillNo1.Trim());
            ds.Tables.Add(dt);
            string InputDTOXml = ds.GetXml();
            return InputDTOXml;
        }

        //BOM
        public static string OutPutESMasterFromWsBOM(string fbillNo)
        {
            DataTable dt = new DataTable();
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "WPLAN_BOM", fbillNo.Trim());
            ds.Tables.Add(dt);
            string InputDTOXml = ds.GetXml();
            return InputDTOXml;
        }

        //K3库存信息
        public static string OutPutESMasterFromWsXCL(string fbillNo, string fbillNo1, string fbillNo2)
        {
            DataTable dt = new DataTable();

            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "WPLAN_XCL", fbillNo.Trim(), fbillNo1.Trim(), fbillNo2.Trim());
            ds.Tables.Add(dt);
            string InputDTOXml = ds.GetXml();
            return InputDTOXml;
        }

        //采购订单信息
        public static string OutPutESMasterFromWsPO(string fbillNo, DateTime fbillNo1, DateTime fbillNo2)
        {
            DataTable dt = new DataTable();
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "WPLAN_PO", fbillNo.Trim(), fbillNo1, fbillNo2);
            ds.Tables.Add(dt);
            string InputDTOXml = ds.GetXml();
            return InputDTOXml;
        }

       
    }
}