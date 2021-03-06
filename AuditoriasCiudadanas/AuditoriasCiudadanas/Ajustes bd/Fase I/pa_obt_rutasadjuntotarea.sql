USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_obt_rutasadjuntotarea]    Script Date: 16/06/2018 10:15:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diana Patricia Bautista Otálora
-- Create date: <Jun 16 2018>
-- Description:	<Procedimiento para obtener las rutas del adjunto de cada tarea>
-- =============================================
CREATE PROCEDURE [dbo].[pa_obt_rutasadjuntotarea]
	-- Add the parameters for the stored procedure here
	@idTarea int,
	@idTipoAdjunto int
AS
BEGIN
	select url
	from AdjuntosTarea
	where idTarea=@idTarea and idTipoAdjunto=@idTipoAdjunto;
END