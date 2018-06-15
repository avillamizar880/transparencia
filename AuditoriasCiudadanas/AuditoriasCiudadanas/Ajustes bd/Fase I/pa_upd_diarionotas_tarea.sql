USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_upd_diarionotas_tarea]    Script Date: 14/06/2018 10:02:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diana Baustista
-- Create date: <Jun 14 2018>
-- Description:	<Procedimiento para actualizar un diario de notas de una tarea>
-- =============================================
CREATE PROCEDURE [dbo].[pa_upd_diarionotas_tarea]
	-- Add the parameters for the stored procedure here
		@idDiarioNotas int,
	    @idTarea int,
        @descripcion nvarchar(1000),
        @reflexion nvarchar(1000),
		@fecha datetime,
		@cod_error int output,
		@mensaje_error varchar(100) output
AS
BEGIN
	BEGIN TRY
    -- Insert statements for procedure here
	UPDATE DiarioNotasTarea
	SET idTarea=@idTarea,
	fechaCumplimiento=@fecha,
	descripcion=@descripcion,
	reflexion=@reflexion
	where diarioNotasTareaId=@idDiarioNotas;
	SET @cod_error=0
	END TRY
	BEGIN CATCH
	SELECT  
        @cod_error= ERROR_NUMBER()   
        ,@mensaje_error =ERROR_MESSAGE() ; 
	END CATCH
END