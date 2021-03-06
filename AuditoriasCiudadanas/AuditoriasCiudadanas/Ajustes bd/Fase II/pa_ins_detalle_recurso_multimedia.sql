USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_ins_detalle_recurso_multimedia]    Script Date: 17/06/2018 2:32:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Diana Bautista
-- Create date: <Jun 09 2018>
-- Description:	<Procedimiento para insertar un detalle de recurso multimedia>
-- Los comentarios que aparecen en verde representa los ajustes solicitados por el cliente.
-- =============================================
CREATE PROCEDURE [dbo].[pa_ins_detalle_recurso_multimedia]
	-- Add the parameters for the stored procedure here
		@idRecurso AS int,
		@rutaImagen AS nvarchar(300),
		@idUsuario AS int,
		@fecha AS datetime,
		@estado AS nvarchar(50),
		@cod_error int output,
		@mensaje_error varchar(100) output

AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRY
    -- Insert statements for procedure here

	
INSERT INTO [dbo].[DetalleRecursoMultimedia]
           ([idRecurso],
            [idTipoMedio],
            [rutaUrl],
            [fechaCreacion],
			[estado],
			[idUsuario]
          )
     VALUES
           (
			@idRecurso,
			1,
			@rutaImagen,
			@fecha,
			@estado,
			@idUsuario
			)

		   SET @cod_error=0
	END TRY
	BEGIN CATCH
	SELECT  
        @cod_error= ERROR_NUMBER()   
        ,@mensaje_error =ERROR_MESSAGE() ; 
	END CATCH
END