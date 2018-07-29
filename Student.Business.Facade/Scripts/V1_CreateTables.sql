use VuelingApi
go
create table Alumnos (
RowGuid uniqueidentifier NOT NULL DEFAULT newid(),
Nombre varchar (20),
Apellidos varchar (20),
Dni varchar (20),
Nacimiento datetime,
Registro datetime,
Edad integer
);