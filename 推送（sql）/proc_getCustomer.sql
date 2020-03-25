USE [P7_002]
GO

/****** Object:  StoredProcedure [dbo].[proc_getCustomer]    Script Date: 2020/3/25 15:56:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



--客户基础信息
ALTER proc [dbo].[proc_getCustomer]
@updDate datetime 
as
begin
SELECT distinct  t.FNUMBER CUST_ID,FNAME CUST_NAME,case when t.FFORBIDSTATUS='A' then 'N' else 'Y' end AS [DISABLE],t.FNUMBER ERP_CUST_ID ,
t2.FNUMBER ORG_ID
FROM T_BD_CUSTOMER t 
inner join T_BD_CUSTOMER_L t1 on t.FCUSTID=t1.FCUSTID
 join T_ORG_Organizations t2 on t2.FORGID=t.FUseOrgId
where 
T.FDOCUMENTSTATUS='C'
 and 
 (CONVERT(varchar(255), t.FModifyDate,111)=@updDate
or
CONVERT(varchar(255), t.FFORBIDDATE,111)=@updDate)

--CONVERT(varchar(255), t.FModifyDate,111)=@updDate
--where t.FModifyDate>'2020-01-14'




end




GO

