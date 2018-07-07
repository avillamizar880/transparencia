USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_obt_diarionotastarea]    Script Date: 14/06/2018 12:57:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diana Patricia Bautista Otálora
-- Create date: <Feb 11 2017>
-- Description:	<Procedimiento para obtener los compromisos de las actas de reunión>
-- =============================================
ALTER PROCEDURE [dbo].[pa_obt_diarionotastarea]
	@idTarea int
AS
BEGIN
	select convert(varchar(10),DiarioNotasTarea.fechaCumplimiento,103) fecha, DiarioNotasTarea.descripcion, DiarioNotasTarea.reflexion,Tareas.estado, DiarioNotasTarea.diarioNotasTareaId
	from DiarioNotasTarea
	join Tareas on DiarioNotasTarea.idTarea=Tareas.idTarea
	where DiarioNotasTarea.idTarea=@idTarea;
END