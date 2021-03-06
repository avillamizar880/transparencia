USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_del_compromisoactareuniontarea]    Script Date: 22/06/2018 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diana Bautista
-- Create date: <Jun 22 2018>
-- Description:	<Procedimiento para eliminar comprimos del acta de reunión de las tareas>
-- =============================================
CREATE PROCEDURE [dbo].[pa_del_compromisoactareuniontarea]
	-- Add the parameters for the stored procedure here
		 @idCompromisoActaReunion as int
		,@cod_error int output
		,@mensaje_error varchar(100) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRY
    -- Insert statements for procedure here
	DELETE FROM [dbo].CompromisosTarea where compromisoTareaId=@idCompromisoActaReunion;
	SET @cod_error=0	   
	END TRY
	BEGIN CATCH
		SELECT  
        @cod_error= ERROR_NUMBER()   
        ,@mensaje_error =ERROR_MESSAGE() ; 
	END CATCH
END