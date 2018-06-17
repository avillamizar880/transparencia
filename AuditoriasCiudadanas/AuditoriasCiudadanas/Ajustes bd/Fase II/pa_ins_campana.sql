USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_ins_campana]    Script Date: 17/06/2018 2:28:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diana Baustista
-- Create date: <Jun 8 2018>
-- Description:	<Procedimiento para insertar campañas>
-- Los comentarios en verde representan ajustes solicitados por el cliente
-- =============================================
CREATE PROCEDURE [dbo].[pa_ins_campana]
	-- Add the parameters for the stored procedure here
	    @titulo nvarchar(2000),
		@fecha datetime,
        @detalle nvarchar(1000),
		@urlNoticia nvarchar(300),
        @idUsuario int,
		@estado nvarchar(1),
		@publicado nvarchar(1),
		@cod_error int output,
		@mensaje_error varchar(100) output

AS
BEGIN
	BEGIN TRY
    INSERT INTO RecursosMultimedia
           (titulo,
		    descripcion,
			idTipoRecurso,
			idUsuario,
			fechaCreacion,
			rutaUrl,
			estado,
			Publicado
           )
     VALUES
           (@titulo,
			@detalle,
			6,
			@idUsuario,
			@fecha,
			@urlNoticia,
			@estado,
			@publicado
			)
           
		   SET @cod_error=0
	END TRY
	BEGIN CATCH
	SELECT  
        @cod_error= ERROR_NUMBER()   
        ,@mensaje_error =ERROR_MESSAGE() ; 
	END CATCH
END