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
CREATE FUNCTION DBO.FN_EXISTEM_ITENS_ORCAMENTO
(
	@pID_ORCAMENTO INT
)
RETURNS INT
AS
BEGIN
	DECLARE @vRETURN INT;
	SET @vRETURN = 0;

	IF ((SELECT COUNT(*) FROM DBO.TBORCAMENTOS_ITENS I WITH(NOLOCK) WHERE I.ID = @pID_ORCAMENTO) > 0)
		SET @vRETURN = 1
	
	RETURN (@vRETURN);

END
GO
