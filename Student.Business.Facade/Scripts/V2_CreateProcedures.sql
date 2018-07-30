USE [VuelingApi]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
/*Procedure to insert into table*/
Create Procedure [dbo].[DataInsert] 
(
	 @RowGuid uniqueidentifier,
	 @Nombre varchar,
	 @Apellidos varchar,
	 @DNI varchar,
	 @Registro varchar,
	 @Nacimiento varchar,
	 @Edad integer
)
As

Begin

    Insert into dbo.Alumnos (RowGuid,Nombre,Apellidos,Dni,Nacimiento,Registro,Edad)
	values (@RowGuid,@Nombre,@Apellidos,@DNI,@Registro,@Nacimiento,@Edad);

End
GO
/*Procedure to return all table contain*/
CREATE PROCEDURE [dbo].[DataSelect]

AS  
BEGIN  
   select * from Alumnos;
END
GO
/*Procedure to select by id*/
create procedure [dbo].[DataSelectById]
(
@guid uniqueidentifier 
)
	AS  
	BEGIN  
	   select * from Alumnos ;
END
GO
/*Procedure to update Columns*/
Create Procedure [dbo].[DataUpdate] 
(
	 @Guid uniqueidentifier,
	 @Nombre varchar,
	 @Apellidos varchar,
	 @DNI varchar,
	 @Registro varchar,
	 @Nacimiento varchar,
	 @Edad integer
)
As

Begin

    UPDATE dbo.Alumnos SET Guid=@Guid, Nombre=@Nombre, Apellidos=@Apellidos, Dni=@Dni,
    Registro=@Registro, Nacimiento=@Nacimiento, Edad=@Edad WHERE Guid=@Guid;

End