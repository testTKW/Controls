USE [P7_002]
GO

/****** Object:  StoredProcedure [dbo].[proc_getDepatment]    Script Date: 2020/3/25 15:57:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




--部门信息
ALTER proc [dbo].[proc_getDepatment]
@updDate datetime 
as
begin
SELECT t.FNUMBER DEPT_ID,FNAME DEPT_NAME,
case when t.FFORBIDSTATUS='A' then 'N' else 'Y' end [DISABLE],
t2.FNUMBER ORG_ID FROM T_BD_DEPARTMENT t 
inner join T_BD_DEPARTMENT_L t1 on t.FDEPTID=t1.FDEPTID
left join T_ORG_Organizations t2 on t2.FORGID=t.FUseOrgId
WHERE T.FDOCUMENTSTATUS='C'

--where CONVERT(varchar(255), t.FModifyDate,111)=@updDate
end




GO

