USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_del_detalle_multimedia_tarea_url]    Script Date: 25/06/2018 1:30:24 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Diana Bautista>
-- Create Date: <Junio 25 2018>
-- Description: <Procedimiento para eliminar el recurso multimedia de una tarea por url>
-- =============================================
CREATE PROCEDURE [dbo].[pa_del_detalle_multimedia_tarea_url]
(
	@id_usuario as int,
    @url as nvarchar(1000),
	@cod_error int output,
    @mensaje_error varchar(100) output
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET @cod_error=0;
	SET @mensaje_error='';
	SET NOCOUNT ON
	BEGIN TRY
		delete from [dbo].[AdjuntosTarea] where url=@url;
	END TRY
	BEGIN CATCH
		SELECT  
        @cod_error= ERROR_NUMBER()   
        ,@mensaje_error =ERROR_MESSAGE() ; 
	END CATCH
END
