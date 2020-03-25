USE [P7_002]
GO

/****** Object:  StoredProcedure [dbo].[WPLAN_BOM]    Script Date: 2020/3/25 16:05:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER proc [dbo].[WPLAN_BOM]
@LOWVALUE varchar(255)
as
begin
set @LOWVALUE=@LOWVALUE+'%'
select /**/
w.FNUMBER as 父项物料编码,/*父项物料编码*/
w1.FNUMBER as 子项物料编码/*子项物料编码*/
,(aa.FNUMERATOR/aa.FDENOMINATOR) as DOSAGE /*用量:分子*/
,FPOSITIONNO as POINT_STR
,aa.FREPLACEGROUP/*项次*/
,aa.FSEQ,/*行号*/
aa.FENTRYID,
a.FNUMBER/*版本号*/
,row_number() over 
(partition by aa.FREPLACEGROUP,a.FNUMBER
order by aa.FREPLACEGROUP,a.FNUMBER,aa.FENTRYID) as 是否主料
into #a
from T_ENG_BOM  a
inner join T_ENG_BOMCHILD  aa on a.FID=aa.FID
left join T_BD_MATERIAL w on w.FMATERIALID=a.FMATERIALID
left join T_BD_MATERIAL w1 on w1.FMATERIALID=aa.FMATERIALID
where w.FNUMBER like @LOWVALUE

select 
父项物料编码 as PROD_ID,
case when 是否主料 != 1 then 子项物料编码 ELSE 子项物料编码 end as MTRL_ID,
case when 是否主料 =1 then 'Y' else 'N' end  as IS_MAIN,
case when 是否主料 =1 then 子项物料编码 
--else (select case when 是否主料 != 1 then 子项物料编码 end from #a )  
end as MAIN_ID,
 DOSAGE, 
POINT_STR
,FREPLACEGROUP/*项次*/
,FSEQ,/*行号*/
FENTRYID,
FNUMBER/*版本号*/
into #aa from #a
where 1=1 
and 父项物料编码 like @LOWVALUE

update #aa  set  #aa.MAIN_ID=a.子项物料编码  from #a a 
where #aa.IS_MAIN='N' AND #aa.FREPLACEGROUP=a.FSEQ 
and #aa.PROD_ID=a.父项物料编码 AND #aa.FNUMBER=a.FNUMBER

select PROD_ID,MTRL_ID,IS_MAIN,MAIN_ID,DOSAGE,POINT_STR
 from #aa where 1=1 and PROD_ID LIKE @LOWVALUE
end

--exec WPLAN_BOM '20101-0195'


GO

