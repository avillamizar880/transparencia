USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_obt_compromisosactareuniones]    Script Date: 21/06/2018 10:38:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diana Patricia Bautista Otálora
-- Create date: <Feb 09 2017>
-- Description:	<Procedimiento para obtener los compromisos de las actas de reunión>
-- =============================================
ALTER PROCEDURE [dbo].[pa_obt_compromisosactareuniones]
	@idTarea int
AS
BEGIN
	select CompromisosTarea.nombre, CompromisosTarea.responsable, convert(varchar(10),CompromisosTarea.fecha,103) fecha, compromisoTareaId from CompromisosTarea 
	where idTarea=@idTarea
	order by fecha asc;
END