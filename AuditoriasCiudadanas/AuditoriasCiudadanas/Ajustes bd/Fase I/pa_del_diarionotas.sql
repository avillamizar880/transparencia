USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_del_diarionotas]    Script Date: 14/06/2018 10:58:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diana Bautista
-- Create date: <Jun 14 2018>
-- Description:	<Procedimiento para eliminar diario de notas>
-- =============================================
CREATE PROCEDURE [dbo].[pa_del_diarionotas]
	-- Add the parameters for the stored procedure here
		 @idDiarioNotas as int
		,@cod_error int output
		,@mensaje_error varchar(100) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRY
    -- Insert statements for procedure here
	DELETE from DiarioNotasTarea where diarioNotasTareaId=@idDiarioNotas;
	SET @cod_error=0	   
	END TRY
	BEGIN CATCH
		SELECT  
        @cod_error= ERROR_NUMBER()   
        ,@mensaje_error =ERROR_MESSAGE() ; 
	END CATCH
END