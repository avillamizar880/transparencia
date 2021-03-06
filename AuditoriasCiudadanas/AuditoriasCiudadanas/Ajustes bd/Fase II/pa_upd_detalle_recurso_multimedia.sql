USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_upd_detalle_recurso_multimedia]    Script Date: 17/06/2018 2:33:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Diana Bautista>
-- Create Date: <Junio 10 2018>
-- Description: <Procedimiento para actualizar información del detalle del recurso multimedia>
-- =============================================
CREATE PROCEDURE [dbo].[pa_upd_detalle_recurso_multimedia]
(
    @idDetalleRecurso as int,
	@urlNoticia as varchar(300),
	@idusuario as int,
	@fecha as datetime,
	@estado as varchar(1),
	@cod_error int output,
	@mensaje_error varchar(100) output
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON
	SET @cod_error=0;
	SET @mensaje_error='';
	BEGIN TRY
		UPDATE [DetalleRecursoMultimedia]
		SET rutaUrl=@urlNoticia,
		    fechaModif=@fecha,
			idUsuarioModif=@idusuario
		WHERE idDetalleRecurso = @idDetalleRecurso;
	END TRY
	BEGIN CATCH
		SELECT  
        @cod_error= ERROR_NUMBER()   
        ,@mensaje_error =ERROR_MESSAGE() ; 
	END CATCH
END
