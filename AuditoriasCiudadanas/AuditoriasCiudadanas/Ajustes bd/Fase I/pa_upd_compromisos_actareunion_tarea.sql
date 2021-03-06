USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_upd_diarionotas_tarea]    Script Date: 22/06/2018 9:54:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diana Baustista
-- Create date: <Jun 22 2018>
-- Description:	<Procedimiento para actualizar un compromiso de una reunion para una tarea>
-- =============================================
CREATE PROCEDURE [dbo].[pa_upd_compromisos_actareunion_tarea]
	-- Add the parameters for the stored procedure here
		@idCompromisoTarea int,
	    @idTarea int,
        @nombre nvarchar(200),
        @responsable nvarchar(200),
		@fecha datetime,
		@cod_error int output,
		@mensaje_error varchar(100) output
AS
BEGIN
	BEGIN TRY
    -- Insert statements for procedure here
	UPDATE CompromisosTarea
	SET idTarea=@idTarea,
	fecha=@fecha,
	nombre=@nombre,
	responsable=@responsable
	where compromisoTareaId=@idCompromisoTarea;
	SET @cod_error=0
	END TRY
	BEGIN CATCH
	SELECT  
        @cod_error= ERROR_NUMBER()   
        ,@mensaje_error =ERROR_MESSAGE() ; 
	END CATCH
END