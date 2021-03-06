USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_obt_detalle_recu_multimedia]    Script Date: 17/06/2018 2:28:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Diana Bautista>
-- Create date: <Jun 09 2018>
-- Description:	<Procedimiento para obtener el id y la rutaUrl del recurso multimedia dado el id del recurso>
-- =============================================
CREATE PROCEDURE [dbo].[pa_obt_detalle_recu_multimedia]
	-- Add the parameters for the stored procedure here
		@idRecurso AS INT

AS
BEGIN 
	SET NOCOUNT ON;
	select idDetalleRecurso, rutaUrl from DetalleRecursoMultimedia where idRecurso=@idRecurso;

END