USE [P7_002]
GO

/****** Object:  StoredProcedure [dbo].[WPLAN_MN]    Script Date: 2020/3/25 16:05:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER proc [dbo].[WPLAN_MN]
@LOWVALUE varchar(255),
@SEQ varchar(100)
as
begin
set @LOWVALUE=@LOWVALUE+'%'
select
a.FMOBILLNO as 工单编码/*工单编码*/
,a.FMOENTRYSEQ as ERP_MO_SEQ
,w.FNUMBER as 成品编码
,a.FQTY as 计划数量 /*计划数量*/
,row_number() over 
(partition by FREPLACEGROUP,a.FBILLNO
order by FREPLACEGROUP,a.FBILLNO,aa.FENTRYID) as 是否主料
,w1.FNUMBER as 物料编码
,FNUMERATOR/FDENOMINATOR as 用量 /*用量*/
,case when FISSUETYPE=7 then 0 else  aa.FNEEDQTY end as 净需求数量
,case when FISSUETYPE=7 then 0 else aa.FMUSTQTY end as 实际需求数量
,aa.FREPLACEGROUP/*项次*/
,aa.FSEQ /*行号*/
,aa.FENTRYID
,a.FID,
a.FMOID,a.FMOENTRYID
,a1.FPOSITIONNO
into #b
from  T_PRD_PPBOM a
inner join T_PRD_PPBOMENTRY aa on a.FID=aa.FID
left join T_PRD_PPBOMENTRY_C a1 on a1.FENTRYID=aa.FENTRYID
left join T_BD_MATERIAL w on w.FMATERIALID=a.FMATERIALID
left join T_BD_MATERIAL w1 on w1.FMATERIALID=aa.FMATERIALID
where 1=1 and a.FMOBILLNO like @LOWVALUE  and a.FMOENTRYSEQ = @SEQ

select
工单编码 as ERP_MO
,成品编码 as PROD_ID
,计划数量 as P_QTY 
,case when 是否主料 !=1 then 物料编码 else 物料编码 end as MTRL_ID
,case when 是否主料=1 then 'Y' else 'N' end as IS_MAIN
,case when  是否主料 =1 then 物料编码 end as MAIN_ID
,用量 as DOSAGE 
,净需求数量 as NN_QTY
,实际需求数量 as TN_QTY
,FREPLACEGROUP/*项次*/
,FSEQ as SEQ /*行号*/
,FPOSITIONNO as POINT_STR
,ERP_MO_SEQ /*生产订单行号*/
into #bb from #b 
where 1=1  and (select FSTATUS from T_PRD_MO g
inner join T_PRD_MOENTRY gg on g.FID=gg.FID
inner join T_PRD_MOENTRY_A gg_A on  gg_A.FENTRYID=gg.FENTRYID
 where g.FID=FMOID and gg.FENTRYID=FMOENTRYID)=3 
 and 工单编码 like @LOWVALUE
 and ERP_MO_SEQ = @SEQ

update #bb  set  #bb.MAIN_ID=a.物料编码  from #b a 
where #bb.IS_MAIN='N' AND #bb.FREPLACEGROUP=a.FSEQ 
and #bb.ERP_MO=a.工单编码 AND #bb.ERP_MO_SEQ=a.ERP_MO_SEQ

select ERP_MO,PROD_ID,P_QTY,MTRL_ID,IS_MAIN,MAIN_ID,DOSAGE
,NN_QTY,TN_QTY,SEQ,POINT_STR,ERP_MO_SEQ
from #bb 
where 1=1 and ERP_MO like @LOWVALUE
 and ERP_MO_SEQ = @SEQ
end

--exec WPLAN_MN '10131SCDD2003205','1'


GO

