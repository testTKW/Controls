USE [P7_002]
GO

/****** Object:  StoredProcedure [dbo].[proc_getMaterailTest]    Script Date: 2020/3/25 15:57:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--物料信息
ALTER proc [dbo].[proc_getMaterailTest]
@update datetime
as
begin
SELECT --添加物料仓库
 --top 198   
 FSTOCKID_2,
t.FNUMBER MTRL_ID,FNAME MTRL_NAME,FSpecification MTRL_DESC,tbsc.FNUMBER STORE_ID,
case when FERPCLSID=1  then FERPCLSID  when FERPCLSID=2  then FERPCLSID  else 1 end  PROD_MTYPE,
FMinPackCount PACK_QTY,u.FNUMBER MUNIT ,'2' MTRL_LEV,
case when t.FFORBIDSTATUS='A' then 'N' else 'Y' end [DISABLE],
'N' IS_STS,T4.FNUMBER ORG_ID ,'1' SPCL_MTYPE,gg.FNUMBER MTRL_GROUP
FROM T_BD_MATERIAL t 
left join T_BD_MATERIAL_L t1 on t.FMASTERID=t1.FMATERIALID
left join T_BD_MATERIALPURCHASE t2 on t.FMASTERID=t2.FMATERIALID
left join T_BD_MATERIALBASE t3 on t.FMASTERID=t3.FMATERIALID
left join T_BD_UNIT u on u.FUNITID=t3.FBASEUNITID
left join T_ORG_Organizations t4 on t4.FORGID=t.FUseOrgId
LEFT JOIN dbo.T_BD_MATERIALGROUP gg ON gg.FID=FMATERIALGROUP
left join t_BD_MaterialStock st on st.FMATERIALID=t.FMATERIALID
left join t_BD_Stock tbsc on tbsc.FSTOCKID=st.FSTOCKID
where T.FAPPROVERID>0 --AND t.FMODIFYDATE is null
order by t.FCREATEDATE OFFSET 40001 ROWS FETCH NEXT 10000 ROWS ONLY
end
GO

