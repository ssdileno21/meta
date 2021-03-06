SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- AUTHOR:		DILENO S SANTOS
-- CREATE DATE: 14/02/2021
-- DESCRIPTION:	ALTERA CLIENTES
-- =============================================
CREATE PROCEDURE [dbo].[USP_ALTERACLIENTES](@PID INT, @PNOMECLIENTE VARCHAR(100), @PTELEFONE VARCHAR(20))
AS
BEGIN
	IF @PID IS NULL
		RETURN;
	IF @PNOMECLIENTE IS NULL
		RETURN;

	UPDATE TBCLIENTES SET
		NOME = @PNOMECLIENTE,
		TELEFONE = @PTELEFONE
	WHERE ID = @PID;

END
GO
