USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_obt_lista_campanas]    Script Date: 17/06/2018 2:25:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diana Bautista
-- Create date: <Jun 08 2018>
-- Description:	<Procedimiento para listar las campañas>
-- =============================================
CREATE PROCEDURE [dbo].[pa_obt_lista_campanas]
	-- Add the parameters for the stored procedure here
	@palabraClave nvarchar(100),
	@pagenum  AS INT = 1,
    @pagesize AS INT = 20

AS
BEGIN
	DECLARE
	@clave nvarchar(100);
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @palabraClave is null
	BEGIN
	select  RecursosMultimedia.idRecurso as idNoticia,
			RecursosMultimedia.fechaCreacion as FechaNoticia,
			RecursosMultimedia.titulo as Titulo,
			RecursosMultimedia.descripcion as Resumen,
			RecursosMultimedia.rutaUrl as Url,
			DetalleRecursoMultimedia.rutaUrl as ImagenUrl,
			DetalleRecursoMultimedia.idTipoMedio
			from RecursosMultimedia 
			join DetalleRecursoMultimedia on RecursosMultimedia.idRecurso=DetalleRecursoMultimedia.idRecurso
			where idTipoRecurso=6 and DetalleRecursoMultimedia.estado=1 and RecursosMultimedia.estado=1
			order by RecursosMultimedia.fechaCreacion desc;
	END
	ELSE
	BEGIN
		SELECT @clave = '%' + (upper(@palabraClave)) + '%';  
		SELECT @clave = @clave COLLATE Latin1_General_CI_AI;
		 WITH C AS
		( 
		    select Row_number() OVER(ORDER BY RecursosMultimedia.fechaCreacion desc) as rownum,
		    RecursosMultimedia.idRecurso as idNoticia,
			RecursosMultimedia.fechaCreacion as FechaNoticia,
			RecursosMultimedia.titulo as Titulo,
			RecursosMultimedia.descripcion as Resumen,
			RecursosMultimedia.rutaUrl as Url,
			DetalleRecursoMultimedia.rutaUrl as ImagenUrl,
			DetalleRecursoMultimedia.idTipoMedio
			from RecursosMultimedia 
			join DetalleRecursoMultimedia on RecursosMultimedia.idRecurso=DetalleRecursoMultimedia.idRecurso
		   where 
		   (
				(upper(Titulo) COLLATE Latin1_General_CI_AI like @clave
				OR upper(descripcion) COLLATE Latin1_General_CI_AI like @clave)
				and idTipoRecurso=6 and DetalleRecursoMultimedia.estado=1 and RecursosMultimedia.estado=1
		   )
		)
		SELECT
			idNoticia,
			FechaNoticia,
			Titulo,
			Resumen,
			Url,
			ImagenUrl
  		FROM C
		WHERE  rownum BETWEEN (@pagenum-1)*@pagesize + 1 AND @pagenum*@pagesize
		ORDER BY FechaNoticia desc;
	END;
END