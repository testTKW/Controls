USE [P7_002]
GO

/****** Object:  StoredProcedure [dbo].[WPLAN_MN_OUTS]    Script Date: 2020/3/25 16:05:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER proc [dbo].[WPLAN_MN_OUTS]
@LOWVALUE varchar(255),
@SEQ varchar(100)
as
begin
set @LOWVALUE=@LOWVALUE+'%'
select
a.FSUBBILLNO as 工单编码/*工单编码*/
,w.FNUMBER as 成品编码
,a.FQTY as 计划数量 /*计划数量*/
,row_number() over 
(partition by FREPLACEGROUP,a.FBILLNO
order by FREPLACEGROUP,a.FBILLNO,aa.FENTRYID) as 是否主料
,w1.FNUMBER as 物料编码
,FNUMERATOR/FDENOMINATOR as 用量 /*用量*/
,case when FISSUETYPE=7 then '' else aa.FNEEDQTY end as 净需求数量
,case when FISSUETYPE=7 then '' else aa.FMUSTQTY end as 实际需求数量
,aa.FREPLACEGROUP/*项次*/
,aa.FSeq as SEQ/*用料清单行号*/
,a1.FPOSITIONNO as POINT_STR
,aa.FENTRYID
,a.FID,a.FSUBREQID,a.FSUBREQENTRYID
,a.FSUBREQENTRYSEQ/*委外订单行号*/
,FISSUETYPE
into #b
from  T_SUB_PPBOM a
inner join T_SUB_PPBOMENTRY aa on a.FID=aa.FID
left join T_SUB_PPBOMENTRY_C a1 on a1.FENTRYID=aa.FENTRYID
left join T_BD_MATERIAL w on w.FMATERIALID=a.FMATERIALID
left join T_BD_MATERIAL w1 on w1.FMATERIALID=aa.FMATERIALID
--left join T_PRD_PICKMTRLDATA ll on ll.FSRCINTERID=a.FID and ll.FSRCENTRYID=aa.FENTRYID
where 1=1 and a.FSUBBILLNO like @LOWVALUE  and a.FSUBREQENTRYSEQ = @SEQ

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
,SEQ /*行号*/
,POINT_STR/*位置号*/
,FSUBREQENTRYSEQ as ERP_MO_SEQ
into #bb from #b
where 1=1 and (select ss.FSTATUS from T_SUB_REQORDER s
inner join T_SUB_REQORDERENTRY ss on s.FID=ss.FID
inner join T_SUB_REQORDERENTRY_A ss_A on ss_A.FENTRYID=ss.FENTRYID
where s.FID=FSUBREQID and ss.FENTRYID=FSUBREQENTRYID)=3 and 工单编码 like @LOWVALUE
and FSUBREQENTRYSEQ like @SEQ

update #bb  set  #bb.MAIN_ID=a.物料编码  from #b a 
where #bb.IS_MAIN='N' AND #bb.FREPLACEGROUP=a.SEQ 
and #bb.ERP_MO=a.工单编码 AND #bb.ERP_MO_SEQ=a.FSUBREQENTRYSEQ

select ERP_MO,PROD_ID,P_QTY,MTRL_ID,IS_MAIN,MAIN_ID,DOSAGE,NN_QTY,TN_QTY,SEQ,POINT_STR,ERP_MO_SEQ
 from #bb

end

--exec WPLAN_MN_OUTS '10131SCDD2003205','1'


GO

