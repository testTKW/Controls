USE [P7_002]
GO

/****** Object:  StoredProcedure [dbo].[proc_getSuppliper]    Script Date: 2020/3/25 15:58:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



--供应商信息

ALTER proc [dbo].[proc_getSuppliper]
@updDate datetime 
as
begin
SELECT  t.FNUMBER SUP_ID,FNAME SUP_NAME,case when t.FFORBIDSTATUS='A' then 'N' else 'Y' end [DISABLE],t.FNUMBER ERP_SUP_ID ,
t2.FNUMBER ORG_ID
FROM t_BD_Supplier t 
inner join t_BD_Supplier_L t1 on t.FSUPPLIERID=t1.FSUPPLIERID
left join T_ORG_Organizations t2 on t2.FORGID=t.FUseOrgId
--where t.FMODIFYDATE>'2019-12-26'
where
T.FDOCUMENTSTATUS='C' 
and 
 (CONVERT(varchar(255), t.FModifyDate,111)=@updDate
or
CONVERT(varchar(255), t.FFORBIDDATE,111)=@updDate)

end



GO

