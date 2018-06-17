USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_upd_campana]    Script Date: 17/06/2018 2:29:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Diana Bautista>
-- Create Date: <Junio 8 2018>
-- Description: <Procedimiento para actualizar información de recursos Multimedia>
-- =============================================
CREATE PROCEDURE [dbo].[pa_upd_campana]
(
    @idcampana as int,
	@titulo as varchar(max),
	@fecha as datetime,
	@detalle as varchar(max),
	@urlNoticia as varchar(300),
	@idusuario as int,
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
	  
		UPDATE [dbo].[RecursosMultimedia]
		SET titulo=@titulo,
		    descripcion=@detalle,
			rutaUrl=@urlNoticia,
			fechaModificacion=@fecha,
			idUsuarioModif=@idusuario
		WHERE idRecurso = @idcampana;

	
	END TRY
	BEGIN CATCH
		SELECT  
        @cod_error= ERROR_NUMBER()   
        ,@mensaje_error =ERROR_MESSAGE() ; 
	END CATCH

   
END
