USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_obt_detallenoticia]    Script Date: 17/06/2018 2:35:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diana Patricia Bautista Otálora
-- Create date: <Jun 16 2018>
-- Description:	<Procedimiento para obtener el registro de una noticia>
-- =============================================
CREATE PROCEDURE [dbo].[pa_obt_detallenoticia]
	@idNoticia int
AS
BEGIN
select      RecursosMultimedia.idRecurso as idNoticia,
			convert(varchar(10),RecursosMultimedia.fechaCreacion,105) as FechaNoticia,
			RecursosMultimedia.titulo as Titulo,
			RecursosMultimedia.descripcion as Resumen,
			RecursosMultimedia.rutaUrl as Url,
			DetalleRecursoMultimedia.rutaUrl as ImagenUrl,
			DetalleRecursoMultimedia.idTipoMedio
			from RecursosMultimedia 
			left join DetalleRecursoMultimedia on RecursosMultimedia.idRecurso=DetalleRecursoMultimedia.idRecurso
		   where 
		   (
				idTipoRecurso=5 and RecursosMultimedia.estado=1
				and RecursosMultimedia.idRecurso=@idNoticia
		   );
END