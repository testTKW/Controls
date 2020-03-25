USE [P7_002]
GO

/****** Object:  StoredProcedure [dbo].[proc_getPrd_MO]    Script Date: 2020/3/25 15:57:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




--K3工单信息
ALTER proc [dbo].[proc_getPrd_MO]
@updDate datetime 
as
begin
SELECT top 102  FBILLNO ERP_MO,t3.FNUMBER PROD_ID,FQty P_QTY,FPlanStartDate PB_DATE,FPLANFINISHDATE PE_DATE, 
'Y' IS_IMS_MO,'' SO_ID,'' SO_SEQ,'' CUST_ID,'N' IS_OUTS,t4.FNUMBER ORG_ID,
FSEQ ERP_MO_SEQ,t5.FNUMBER PT_ID,'' SUP_ID
,case when SUBSTRING(t.FBILLNO,charindex('SCDD',t.FBILLNO)-1,1)=1 then 2 else 1 end 
as IS_BONDED
 FROM T_PRD_MO  t 
inner join T_PRD_MO_L t1 on t.FID=t1.FID
left join T_PRD_MOENTRY t2 on t.FID=t2.FID
left join T_BD_MATERIAL t3 on t2.FMATERIALID=t3.FMASTERID
left join T_ORG_Organizations t4 on t4.FORGID=t.FPrdOrgId
left join T_BD_DEPARTMENT t5 on t5.FDEPTID=t2.FWorkShopID
left join T_PRD_MOENTRY_A t6 on t6.FID=t.FID
--where 1=2
where t.FAPPROVERID>0 
and 
CONVERT(varchar(255), t6.FConveyDate,111)=@updDate
end




GO

