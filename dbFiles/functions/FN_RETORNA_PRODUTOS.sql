USE [C:\PROJECTS\META\TESTEMETA\TESTEMETA\APP_DATA\BD_META.MDF]
-- ================================================
-- TESTE - META
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- AUTHOR:		DILENO S SANTOS
-- CREATE DATE: 15/02/2021
-- DESCRIPTION:	RETORNA PRODUTOS
-- =============================================
CREATE FUNCTION [DBO].[FN_RETORNA_PRODUTOS]
(	
	   @PID INT
)

RETURNS TABLE 
AS
RETURN 
(
	SELECT
			 P.*
	FROM DBO.TBPRODUTOS P WITH(NOLOCK)
	WHERE P.ID = CASE WHEN ISNULL(@PID,P.ID) = 0 THEN P.ID ELSE ISNULL(@PID,P.ID) END
)
GO

