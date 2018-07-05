USE [DB_TRANSPARENCIA_CO]
GO
/****** Object:  StoredProcedure [dbo].[pa_obt_urlcap]    Script Date: 17/06/2018 2:22:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<DBautista>
-- Create date: <Mayo 14 2018>
-- Description:	<Procedimiento para obtener la url de una capacitación>
-- =============================================
CREATE PROCEDURE [dbo].[pa_obt_urlcap]
	-- Add the parameters for the stored procedure here
	@nombreCapacitacion AS VARCHAR(100)
AS
BEGIN
 select RecursosCapacitacion.Url from RecursosCapacitacion 
 where Titulo=@nombreCapacitacion
END