USE [P7_002]
GO

/****** Object:  StoredProcedure [dbo].[WPLAN_Mo]    Script Date: 2020/3/25 16:05:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER proc [dbo].[WPLAN_Mo]
@LOWVALUE varchar(255)
as

begin
set @LOWVALUE = @LOWVALUE+'%'

select 
s.FBILLNO as ERP_MO/*ERP工单编码*/
,wl.FNUMBER as PROD_ID/*成品编码*/
,ss.FQTY as P_QTY/*计划数量*/
,SS.FPLANSTARTDATE as PB_DATE/*计划开始时间*/
,SS.FPLANFINISHDATE as PE_DATE/*计划结束时间*/
,'Y' as IS_IMS_MO /*是否IMS工单（Y是N否）*/
,x.FBILLNO as SO_ID
,xx.FSEQ as SO_SEQ
,kh.FNUMBER as CUST_ID
,zz.FNUMBER as ORG_ID /*生产组织*/
,bm.FNUMBER as PT_ID /*生产车间*/
,ss.FSEQ as ERP_MO_SEQ
--,case when  ss_A.FSTATUS = 3 then '下达' end  as ERPMO_STAT
,'N' as IS_OUTS
,NULL as SUP_ID
,case when SUBSTRING(s.FBILLNO,charindex('SCDD',s.FBILLNO)-1,1)=1 then 2 else 1 end 
as IS_BONDED
 from T_PRD_MO s
inner join T_PRD_MOENTRY ss on s.FID=ss.FID
inner join T_PRD_MOENTRY_A ss_A on ss_A.FENTRYID=ss.FENTRYID
left join T_SAL_ORDERENTRY xx on xx.FENTRYID=ss.FSALEORDERENTRYID and xx.FID=ss.FSALEORDERID
left join T_SAL_ORDER x on x.FID=xx.FID
left join T_BD_DEPARTMENT bm on bm.FMASTERID=SS.FWORKSHOPID
left join T_BD_CUSTOMER kh on kh.FCUSTID=x.FCUSTID
left join T_BD_MATERIAL wl on wl.FMATERIALID=ss.FMATERIALID
left join T_ORG_Organizations zz on zz.FORGID=S.FPRDORGID 
--select FSTATUS,* from T_PRD_MOENTRY_A
where 1=1 and ss_A.FSTATUS = 3 and s.FBILLNO like @LOWVALUE
end

--exec WPLAN_Mo '10121SCDD2003182'


GO

