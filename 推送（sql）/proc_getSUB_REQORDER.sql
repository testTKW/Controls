USE [P7_002]
GO

/****** Object:  StoredProcedure [dbo].[proc_getSUB_REQORDER]    Script Date: 2020/3/25 15:58:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--委外订单
ALTER proc [dbo].[proc_getSUB_REQORDER]
@updDate datetime 
as
begin
SELECT FBillNo ERP_MO,t3.FNUMBER PROD_ID,FQty P_QTY,FPlanStartDate PB_DATE,FPlanFinishDate PE_DATE,
'Y' IS_IMS_MO,FSaleOrderId SO_ID,FSrcBillEntrySeq SO_SEQ, 
'' CUST_ID,'Y' IS_OUTS,t4.FNUMBER ORG_ID,T1.FSEQ ERP_MO_SEQ , '' PT_ID,t5.FNUMBER SUP_ID
,case when SUBSTRING(t.FBILLNO,charindex('WWDD',t.FBILLNO)-1,1)=1 then 2 else 1 end as IS_BONDED
FROM T_SUB_REQORDER t inner join T_SUB_REQORDERENTRY t1 on t.FID=t1.FID
left join T_BD_MATERIAL t3 on t1.FMATERIALID=t3.FMASTERID
left join T_ORG_Organizations t4 on t4.FORGID=t.FSubOrgId
left join T_BD_SUPPLIER t5 on t5.FSUPPLIERID=t1.FSupplierId
left join T_SUB_REQORDERENTRY_A t2 on t2.FID=t.FID
--left join T_SUB_REQORDERENTRY t6 on t2.FENTRYID=t6.FENTRYID
where t.FAPPROVERID>0 
--and 
--CONVERT(varchar(255), t1.FConveyDate,111)=@updDate
end
GO

