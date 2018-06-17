USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_publicar_campana]    Script Date: 17/06/2018 2:27:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diana B
-- Create date: <Jun 03 2018>
-- Description:	<Procedimiento para publicar una campaña>
-- =============================================
CREATE PROCEDURE [dbo].[pa_publicar_campana]
	-- Add the parameters for the stored procedure here
		 @idCampana int,
		 @idUsuario int,
		 @cod_error int output,
		 @mensaje_error varchar(100) output

AS
BEGIN
    
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	BEGIN TRY
    -- Insert statements for procedure here
	UPDATE [dbo].RecursosMultimedia set Publicado='1', idUsuarioModif=@idUsuario, fechaModificacion= GETDATE()  where idRecurso=@idCampana;
	
	SET @cod_error=0	   
	
	END TRY
	BEGIN CATCH
		SELECT  
        @cod_error= ERROR_NUMBER()   
        ,@mensaje_error =ERROR_MESSAGE() ; 
	END CATCH
END