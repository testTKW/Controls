USE [P7_002]
GO

/****** Object:  StoredProcedure [dbo].[WPLAN_PO]    Script Date: 2020/3/25 16:06:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--查询采购订单
ALTER proc [dbo].[WPLAN_PO]
@LOWVALUE varchar(255)
,@Start_Date DateTime 
,@End_Date DateTime

as
begin
set @LOWVALUE=@LOWVALUE+'%'
IF(@Start_Date = '1900-01-01 00:00:00.000')
SET @Start_Date='1900-01-01 00:00:00.000'

IF(@End_Date =  '1900-01-01 00:00:00.000')
SET @End_Date='9999-12-30' 

 set nocount on;
 DECLARE @sqlcommand   NVARCHAR(MAX) 
 DECLARE @Parm         NVARCHAR(MAX) 

 --清理临时表
 if object_id('tempdb..##AA') is not null 
begin
 drop table ##AA
end

SET @sqlcommand=('
SELECT 
FBILLNO as PO_ID/*采购单编码*/  
,AA.FSeq as PO_LINE/*采购单行号*/ 
,WL.FNUMBER as MTRL_ID	
,AA.FQTY as M_QTY   /*物料数量*/
, AAr.FSTOCKINQTY as SM_QTY /*实收数量*/
,gys.FNUMBER as SUP_ID/*供应商编码*/   
,'''' as STORE_ID
,case when  a.FBUSINESSTYPE =''WW'' THEN ''Y'' ELSE ''N'' END AS IS_OUTS
,AA_D.FDELIVERYDATE as PDH_DATE
,AA_F.FTAXPRICE as PRICE
,zz.FNUMBER as PO_ORG_ID/*采购组织*/
,zz1.FNUMBER as ORG_ID/*收料组织*/
,AA_CR.FNUMBER AS CURRENCY_ID /*结算币别*/
,AA_F.FTAXRATE as TAX_RATE /*税率*/
,AA_F.FALLAMOUNT as TOTAL_PRICE /*价税合计*/
,case when  AA_CGY.FNUMBER !=0 then AA_CGY.FNUMBER else '''' end as PUR_ID /*采购员*/
INTO ##AA FROM t_PUR_POOrder A
INNER JOIN t_PUR_POOrderEntry AA ON A.FID=AA.FID
INNER JOIN T_PUR_POORDERENTRY_F  AA_F ON AA_F.FENTRYID=AA.FENTRYID
INNER JOIN T_PUR_POORDERENTRY_D  AA_D ON AA_D.FENTRYID=AA.FENTRYID
left join T_PUR_POORDERENTRY_R AAr on AAr.FENTRYID=AA.FENTRYID
left join T_PUR_POORDERFIN  AA_R on AA_R.FID=AA.FID
left join  T_BD_CURRENCY AA_CR on AA_R.FSETTLECURRID=AA_CR.FCURRENCYID
left join  V_BD_BUYER AA_CGY on AA_CGY.fid=A.FPURCHASERID
INNER JOIN T_BD_MATERIAL WL ON AA.FMATERIALID=WL.FMATERIALID
LEFT JOIN T_BD_MATERIAL_L WL1 ON WL.FMATERIALID=WL1.FMATERIALID 
left join T_BD_SUPPLIER gys on gys.FSUPPLIERID=a.FSUPPLIERID
left join T_ORG_Organizations zz on zz.FORGID=a.FPURCHASEORGID/*采购组织*/
left join T_ORG_Organizations zz1 on zz1.FORGID=AA_D.FRECEIVEORGID/*收料组织*/
where 1=1 AND A.FDOCUMENTSTATUS=''C'' ')
IF(@LOWVALUE  IS NOT NULL and @LOWVALUE  not like  '' )
SET  @sqlcommand = CONCAT(@sqlcommand,' and A.FBILLNO like @LOWVALUE')


SET @sqlcommand = CONCAT(@sqlcommand,'  and ((A.FCHANGEDATE>=@Start_Date AND A.FCHANGEDATE<=@End_Date) 
OR (A.FAPPROVEDATE>=@Start_Date AND A.FAPPROVEDATE<=@End_Date))')

print @Start_Date
print @End_Date

  SET @Parm= '@LOWVALUE varchar(255),@Start_Date DateTime,@End_Date DateTime'

   EXEC sp_executesql @sqlcommand,@Parm,
						   @LOWVALUE=@LOWVALUE,
						   @Start_Date=@Start_Date
						   ,@End_Date=@End_Date
SELECT * FROM ##AA
print @sqlcommand

--order by FBILLNO,AA.FSeq
end

--exec WPLAN_PO '','2020/03/25 10:28:43','2020/03/25 10:41:26' '2020-01-21 00:00:00.000','2020-03-23 00:00:00.000'



GO

