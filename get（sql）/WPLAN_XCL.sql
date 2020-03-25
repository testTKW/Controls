USE [P7_002]
GO

/****** Object:  StoredProcedure [dbo].[WPLAN_XCL]    Script Date: 2020/3/25 16:06:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER proc [dbo].[WPLAN_XCL]
@LOWVALUE varchar(255),
@LOWVALUE1  varchar(255),
@ZUZI  varchar(255)
as
begin
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
st04.FNUMBER as MTRL_ID,
ck.FNUMBER as STORE_ID, /*仓库编码*/
case when  isnull(t0.FBASEQTY / dw.FCONVERTNUMERATOR,0)=0 then t0.FBASEQTY 
else isnull(t0.FBASEQTY / dw.FCONVERTNUMERATOR,0)end as BL_QTY
,tt1.FNUMBER
INTO ##AA
FROM T_STK_INVENTORY t0
LEFT OUTER JOIN V_SCM_KEEPERORG tt1 on tt1.FORGID=t0.FSTOCKORGID
LEFT OUTER JOIN T_BD_MATERIAL st04 ON t0.FMATERIALID = st04.FMATERIALID
LEFT OUTER JOIN T_BD_UNIT st013 ON t0.FSTOCKUNITID = st013.FUNITID 
left join T_BD_UNITCONVERTRATE dw on t0.FMATERIALID=dw.FMATERIALID
left join t_BD_Stock ck on ck.FMASTERID=t0.FSTOCKID
where 1=1 ') --and ck.FNUMBER LIKE @LOWVALUE and st04.FNUMBER LIKE @LOWVALUE1

IF(@LOWVALUE  IS NOT NULL and @LOWVALUE  not like  '' )
SET  @sqlcommand = CONCAT(@sqlcommand,'and ck.FNUMBER LIKE @LOWVALUE ')

IF(@LOWVALUE1  IS NOT NULL and @LOWVALUE1  not like  '' )
SET  @sqlcommand = CONCAT(@sqlcommand,' AND st04.FNUMBER LIKE @LOWVALUE1 ')

IF(@ZUZI  IS NOT NULL and @ZUZI  not like  '' )
SET  @sqlcommand = CONCAT(@sqlcommand,'and tt1.FNUMBER LIKE @ZUZI ')

  SET @Parm= '@LOWVALUE varchar(255),@LOWVALUE1 varchar(255),@ZUZI varchar(255)'

   EXEC sp_executesql @sqlcommand,@Parm,
						   @LOWVALUE=@LOWVALUE,
						   @LOWVALUE1=@LOWVALUE1,
						   @ZUZI=@ZUZI

SELECT MTRL_ID,STORE_ID,sum(BL_QTY) AS BL_QTY FROM ##AA a GROUP BY FNUMBER,MTRL_ID,STORE_ID

end

--exec WPLAN_XCL 'A47','1000-010700','101'   ,'101'   'CK062'	CK001
--DROP table ##AA 

GO

