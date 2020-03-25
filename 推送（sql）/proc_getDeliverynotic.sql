USE [P7_002]
GO

/****** Object:  StoredProcedure [dbo].[proc_getDeliverynotic]    Script Date: 2020/3/25 15:56:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




--K3成品发货通知单

ALTER proc [dbo].[proc_getDeliverynotic]
@updDate datetime 
as
begin
SELECT t.FBILLNO AUDIT_ID,t4.FNUMBER CUST_ID,t3.FNUMBER MTRL_ID,t1.FPlanDeliveryDate H_DATE,
t2.FNUMBER STORE_ID,t1.FQty QUANTITY,t.FNOTE REMARK,t8.FNUMBER ORG_ID,t7.FNUMBER SO_ORG_ID, 
t1.FSEQ  MTRL_SEQ,
t1.FORDERNO SO_ID,oe.FSEQ SO_SEQ,
case when FIsFree=0 then 'N' else 'Y' end as IS_PRE ,
case when t.FBILLTYPEID='5df7281e0d294e' then 2 else 1 end IS_BONDED
FROM T_SAL_DELIVERYNOTICE t 
left join T_SAL_DELIVERYNOTICEENTRY t1 on t.FID=t1.FID
left join T_SAL_DELIVERYNOTICEFIN t6 on t1.FENTRYID=t6.FENTRYID
left join t_BD_Stock t2 on t1.FSHIPMENTSTOCKID=t2.FSTOCKID
LEFT JOIN T_BD_MATERIAL t3 on t1.FMaterialID=t3.FMATERIALID
left join T_BD_CUSTOMER t4 on t.FCustomerID=t4.FCUSTID
left join T_SAL_DELIVERYNOTICEENTRY_F t5 on t.FID=t5.FID and t5.FENTRYID=t1.FENTRYID
left join  T_SAL_ORDER o on o.FBILLNO=t1.FORDERNO
left join T_SAL_ORDERENTRY oe on oe.FID=o.FID and oe.FENTRYID=t1.FORDERSEQ
left join T_ORG_Organizations t7 on t7.FORGID=t6.FSETTLEORGID
left join T_ORG_Organizations t8 on t8.FORGID=t.FDELIVERYORGID
where t.FBILLNO='101FHTZ2003248'
--where t.FAPPROVERID>0
--where CONVERT(varchar(255), t.FModifyDate,111)=@updDate
end




GO

