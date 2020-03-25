USE [P7_002]
GO

/****** Object:  StoredProcedure [dbo].[proc_getBilltype]    Script Date: 2020/3/25 15:56:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--收发类别信息
ALTER proc [dbo].[proc_getBilltype]
@updDate datetime 
as
begin
SELECT FNUMBER SRTYPE_ID,FNAME SRTYPE_NAME FROM T_BAS_BILLTYPE t 
inner join T_BAS_BILLTYPE_L t1 on t.FBILLTYPEID=t1.FBILLTYPEID
where CONVERT(varchar(255), t.FModifyDate,111)=@updDate
end


GO

