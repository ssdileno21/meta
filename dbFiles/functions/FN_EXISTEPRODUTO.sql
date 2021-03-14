use [C:\PROJECTS\META\TESTEMETA\TESTEMETA\APP_DATA\BD_META.MDF];

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
-- DESCRIPTION:	VALIDAR PRODUTO
-- =============================================
CREATE FUNCTION DBO.FN_EXISTEPRODUTO
(
	@pID_PRODUTO INT
)
RETURNS INT
AS
BEGIN
	DECLARE @vRETURN INT;
	SET @vRETURN = 0;

	IF ((SELECT TOP 1 1 FROM DBO.TBPRODUTOS C WITH(NOLOCK) WHERE C.ID = @pID_PRODUTO) = 1)
		SET @vRETURN = 1
	
	RETURN (@vRETURN);

END
GO
