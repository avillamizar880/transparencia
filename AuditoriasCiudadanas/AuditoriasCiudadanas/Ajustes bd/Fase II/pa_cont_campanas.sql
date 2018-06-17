USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_cont_campanas]    Script Date: 17/06/2018 2:23:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Diana Patricia Bautista Otálora>
-- Create Date: <Mayo 15 2018>
-- Description: <Procedimiento para traer el total de los campañas>
-- =============================================
CREATE PROCEDURE [dbo].[pa_cont_campanas]
	-- Add the parameters for the stored procedure here
		@palabraClave nvarchar(100)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @clave nvarchar(200);
	SELECT @clave = '%' + (upper(@palabraClave)) + '%';  
	SELECT @clave = @clave COLLATE Latin1_General_CI_AI;
	select Count(*) Total from RecursosMultimedia where UPPER(titulo)  COLLATE Latin1_General_CI_AI like @clave and idTipoRecurso=6 and estado=1;
END