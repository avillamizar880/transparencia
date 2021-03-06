USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_obt_recursos_tarea]    Script Date: 2/07/2018 4:01:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Diana Bautista
-- Create date: <Dic 25 2016>
-- Modify date: <Jul 02 2018>
-- Description:	<Procedimiento para traer los recursos de una tarea>
-- =============================================
ALTER PROCEDURE [dbo].[pa_obt_recursos_tarea]
	-- Add the parameters for the stored procedure here
		@idTarea int
AS
BEGIN
select url, convert(varchar(10), AdjuntosTarea.fechaCreacion,103) fechaCreacion, descripcion, AdjuntosTarea.responsable, AdjuntosTarea.lugar, Tareas.estado, AdjuntosTarea.idAdjuntoTarea
from AdjuntosTarea 
join Tareas on AdjuntosTarea.IdTarea=Tareas.IdTarea
left join MiembrosGac on AdjuntosTarea.idMiembroGac= MiembrosGac.idMiembroGac
left join Usuario on MiembrosGac.IdUsuario=Usuario.IdUsuario
where Tareas.idTarea=@idTarea;
END