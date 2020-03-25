USE [P7_002]
GO

/****** Object:  StoredProcedure [dbo].[proc_getStock]    Script Date: 2020/3/25 15:57:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




--仓库
ALTER proc [dbo].[proc_getStock]
@updDate datetime 
as
begin
SELECT  t.FNUMBER STORE_ID,t.FNUMBER ERP_STORE_ID,FNAME STORE_NAME,
1 STORE_TYPE,1 STORE_MD,
--FStockProperty PPT_TYPE, 
'1' PPT_TYPE, 
case when t.FFORBIDSTATUS='A' then 'N' else 'Y' end [DISABLE],
t2.FNUMBER ORG_ID ,t.FAddress STORE_ADDRESS
  FROM t_BD_Stock  t 
inner join T_BD_STOCK_L t1 on t.FSTOCKID=t1.FSTOCKID
left join T_ORG_Organizations t2 on t2.FORGID=t.FUseOrgId
where t.FDOCUMENTSTATUS='C'
-- CONVERT(varchar(255), t.FModifyDate,111)=@updDate
end




GO

