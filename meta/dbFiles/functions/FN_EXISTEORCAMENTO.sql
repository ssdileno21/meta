USE META;

-- ================================================
-- TESTE - META
-- ================================================

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- AUTHOR:		DILENO S SANTOS
-- CREATE DATE: 14/02/2021
-- DESCRIPTION:	VALIDAR ORCAMENTO
-- =============================================
CREATE FUNCTION DBO.FN_EXISTEORCAMENTO
(
	@pID_ORCAMENTO INT
)
RETURNS INT
AS
BEGIN
	DECLARE @vRETURN INT;
	SET @vRETURN = 0;

	IF ((SELECT TOP 1 1 FROM DBO.TBORCAMENTOS C WITH(NOLOCK) WHERE C.ID = @pID_ORCAMENTO) = 1)
		SET @vRETURN = 1
	
	RETURN (@vRETURN);

END
GO
