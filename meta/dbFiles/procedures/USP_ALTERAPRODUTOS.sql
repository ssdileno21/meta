SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- AUTHOR:		DILENO S SANTOS
-- CREATE DATE: 14/02/2021
-- DESCRIPTION:	ALTERA CLIENTES
-- =============================================
CREATE PROCEDURE [dbo].[USP_ALTERAPRODUTOS](@PID INT, @PNOMEPRODUTO VARCHAR(100), @PPRECO FLOAT)
AS
BEGIN
	IF @PID IS NULL
		RETURN;
	IF @PNOMEPRODUTO IS NULL
		RETURN;
	IF @PPRECO IS NULL
		RETURN;

	UPDATE TBPRODUTOS SET
		NOME = @PNOMEPRODUTO,
		PRECO = @PPRECO
	WHERE ID = @PID;

END
GO