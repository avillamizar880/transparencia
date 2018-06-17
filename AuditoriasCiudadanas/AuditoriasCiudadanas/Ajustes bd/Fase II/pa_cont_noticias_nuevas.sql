USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_cont_noticias_nuevas]    Script Date: 17/06/2018 2:35:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diana Patricia Bautista Otálora
-- Create date: <Jun 09 2018>
-- Description:	<Procedimiento para traer el total de los proyectos auditables>
-- =============================================
CREATE PROCEDURE [dbo].[pa_cont_noticias_nuevas]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select Count(*) Total from RecursosMultimedia where idTipoRecurso=5 and estado=1 and publicado=1 and fechaCreacion >= DATEADD(DAY,-1, GETDATE());
END