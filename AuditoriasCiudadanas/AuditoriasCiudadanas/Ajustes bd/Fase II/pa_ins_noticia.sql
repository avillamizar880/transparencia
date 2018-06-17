USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_ins_noticia]    Script Date: 17/06/2018 2:43:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diana Baustista
-- Create date: <Jun 4 2018>
-- Description:	<Procedimiento para insertar noticias>
-- Los comentarios en verde representan ajustes solicitados por el cliente
-- =============================================
CREATE PROCEDURE [dbo].[pa_ins_noticia]
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

	DECLARE @idNoticia INT;

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
			5,
			@idUsuario,
			@fecha,
			@urlNoticia,
			@estado,
			@publicado
			)

		SELECT @idNoticia = scope_identity();


		IF @estado='1' AND @publicado = '1'
		BEGIN
			INSERT INTO Notificacion 
				(	idUsuario
					,tipo
					,mensaje
					,parametros
				)
			SELECT u.IdUsuario
					,'3'
					,'Nueva noticia: ' + @titulo
					,'{"url":"Informacion/verDetalleNoticia","div":"dvPrincipal","params":"'+ CONVERT(VARCHAR(10),@idNoticia) +'"}'
			FROM Usuario u
			WHERE Estado = 'ACTIVO'
		END
           
		   SET @cod_error=0
	END TRY
	BEGIN CATCH
	SELECT  
        @cod_error= ERROR_NUMBER()   
        ,@mensaje_error =ERROR_MESSAGE() ; 
	END CATCH
END