USE [P7_002]
GO

/****** Object:  StoredProcedure [dbo].[proc_getMaterail]    Script Date: 2020/3/25 15:57:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







--物料信息
ALTER proc [dbo].[proc_getMaterail]
@updDate datetime 
as
begin
SELECT --添加物料仓库
 --top 198   
 
 tbsc.FNUMBER AS STORE_ID,tbsc1.FNUMBER AS STORE_ID2,
t.FNUMBER MTRL_ID,FNAME MTRL_NAME,FSpecification MTRL_DESC,tbsc.FNUMBER STORE_ID,
case when FERPCLSID=1  then 1  else 2 end  PROD_MTYPE,
FMinPackCount PACK_QTY,u.FNUMBER MUNIT ,'2' MTRL_LEV,
case when t.FFORBIDSTATUS='A' then 'N' else 'Y' end [DISABLE],
'N' IS_STS,T4.FNUMBER as ORG_ID ,'1' SPCL_MTYPE,gg.FNUMBER MTRL_GROUP
,t.F_RCGD_REMARK_JZ AS MTRL_LEV
,CASE WHEN t.F_RCGD_TEXT_ABC='' THEN 'B' ELSE t.F_RCGD_TEXT_ABC END AS PROD_MODEL
FROM T_BD_MATERIAL t 
left join T_BD_MATERIAL_L t1 on t.FMASTERID=t1.FMATERIALID
left join T_BD_MATERIALPURCHASE t2 on t.FMASTERID=t2.FMATERIALID
left join T_BD_MATERIALBASE t3 on t.FMASTERID=t3.FMATERIALID
left join T_BD_UNIT u on u.FUNITID=t3.FBASEUNITID
left join T_ORG_Organizations t4 on t4.FORGID=t.FUseOrgId
LEFT JOIN dbo.T_BD_MATERIALGROUP gg ON gg.FID=FMATERIALGROUP
left join t_BD_MaterialStock st on st.FMATERIALID=t.FMATERIALID
left join t_BD_Stock tbsc on tbsc.FSTOCKID=st.FSTOCKID
left join t_BD_Stock tbsc1 on tbsc1.FSTOCKID=st.FSTOCKID_2
where T.FAPPROVERID>0 and (FERPCLSID=1 or FERPCLSID=2  or FERPCLSID=3 or FERPCLSID=5)
 --and t.FNUMBER='20101-00593' --AND t.FMODIFYDATE is null
 --order by t.FCREATEDATE OFFSET 0 ROWS  FETCH NEXT 10000 ROWS ONLY
and 
(CONVERT(varchar(255), t.FModifyDate,111)=@updDate
or
CONVERT(varchar(255), t.FFORBIDDATE,111)=@updDate)

end












GO

