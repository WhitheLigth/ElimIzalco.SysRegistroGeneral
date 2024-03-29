---- CREACION DE TABLAS

CREATE DATABASE BdSysRegistroElimIzalco
GO
USE BdSysRegistroElimIzalco
GO
CREATE TABLE Estatus(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(11) NOT NULL
);
CREATE TABLE Sexo(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(11) NOT NULL
);
CREATE TABLE EstadoCivil(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(11) NOT NULL
);
CREATE TABLE BautizmoEnAgua(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(25) NOT NULL
);
CREATE TABLE BautizmoEspirituSanto(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(11) NOT NULL
);
CREATE TABLE ListaCalendario(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(11) NOT NULL
);
CREATE TABLE Pastores(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(100) NOT NULL,
Edad VARCHAR(2) NOT NULL,
Dui VARCHAR(10) NOT NULL,
FechaNacimiento DATETIME NOT NULL,
Telefono VARCHAR(8) NOT NULL,
FechaCreacion DATETIME NOT NULL,
FechaModificacion DATETIME NULL DEFAULT GETDATE()
);
CREATE TABLE Supervisores(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(100) NOT NULL,
Edad VARCHAR(2) NOT NULL,
Dui VARCHAR(10) NOT NULL,
FechaNacimiento DATETIME NOT NULL,
Telefono VARCHAR(8) NOT NULL,
FechaCreacion DATETIME NOT NULL,
FechaModificacion DATETIME NULL DEFAULT GETDATE()
);
CREATE TABLE Distrito(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Numero VARCHAR(11) NOT NULL,
);
CREATE TABLE Zona(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Numero VARCHAR(11) NOT NULL,
);
CREATE TABLE Sector(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Numero VARCHAR(11) NOT NULL,
);
CREATE TABLE Celula(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Numero VARCHAR(11) NOT NULL,
);
CREATE TABLE CategoriaParaProfesionUOficio(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(30) NOT NULL
);
CREATE TABLE ProfesionUOficio(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50) NOT NULL,
IdCategoria INT NOT NULL FOREIGN KEY REFERENCES CategoriaParaProfesionUOficio(Id)
);
CREATE TABLE Privilegios(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(60) NOT NULL
);
CREATE TABLE Membresia(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(100) NOT NULL,
Apellido VARCHAR (100) NOT NULL,
Dui VARCHAR(9) NOT NULL,
FechaNacimiento DATETIME NOT NULL,
Edad VARCHAR(2) NOT NULL,
Direccion VARCHAR(200) NOT NULL,
Telefono VARCHAR(8) NOT NULL,
LugarDeTrabajo VARCHAR(100) NOT NULL,
TelefonoDelTrabajo VARCHAR(8) NOT NULL,
FechaConversion DATETIME NOT NULL,
LugarDeConversion VARCHAR(100) NOT NULL,
Digito VARCHAR(3) NOT NULL,
NombreLider VARCHAR(100) NOT NULL,
Observaciones VARCHAR(500) NOT NULL,
FechaCreacion DATETIME NOT NULL,
FechaModificacion DATETIME NULL DEFAULT GETDATE(),
Fotografia VARBINARY(MAX) NULL,
IdProfesionUOficio INT NOT NULL FOREIGN KEY REFERENCES ProfesionUOficio(Id),
IdSexo INT NOT NULL FOREIGN KEY REFERENCES Sexo(Id),
IdEstatus INT NOT NULL FOREIGN KEY REFERENCES Estatus(Id),
IdEstadoCivil INT NOT NULL FOREIGN KEY REFERENCES EstadoCivil(Id),
IdBautizmoEnAgua INT NOT NULL FOREIGN KEY REFERENCES BautizmoEnAgua(Id),
IdBautizmoEspirituSanto INT NOT NULL FOREIGN KEY REFERENCES BautizmoEspirituSanto(Id),
IdListaCalendario INT NOT NULL FOREIGN KEY REFERENCES ListaCalendario(Id),
IdNombrePastor INT NOT NULL FOREIGN KEY REFERENCES Pastores(Id),
IdNombreSupervisor INT NOT NULL FOREIGN KEY REFERENCES Supervisores(Id),
IdDistrito INT NOT NULL FOREIGN KEY REFERENCES Distrito(Id),
IdZona INT NOT NULL FOREIGN KEY REFERENCES Zona(Id),
IdSector INT NOT NULL FOREIGN KEY REFERENCES Sector(Id),
IdCelula INT NOT NULL FOREIGN KEY REFERENCES Celula(Id),
);

CREATE TABLE Servidores(
Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
IdMembresia INT NOT NULL FOREIGN KEY REFERENCES Membresia(Id),
IdEstatus INT NOT NULL FOREIGN KEY REFERENCES Estatus(Id),
IdPrivilegios INT NOT NULL FOREIGN KEY REFERENCES Privilegios(Id)
);

CREATE TABLE Historial_Servidores(
Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
IdMembresia INT NOT NULL FOREIGN KEY REFERENCES Membresia(Id),
IdEstatus INT NOT NULL FOREIGN KEY REFERENCES Estatus(Id),
IdPrivilegios INT NOT NULL FOREIGN KEY REFERENCES Privilegios(Id),
FechaDeIngreso DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Rol(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50) NOT NULL,
);

CREATE TABLE Users(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50) NOT NULL,
Apellido VARCHAR(50) NOT NULL,
Dui VARCHAR(9) NOT NULL,
Correo VARCHAR(50) NOT NULL,
Passw VARCHAR(50) NOT NULL,
IdRol INT NOT NULL FOREIGN KEY REFERENCES Rol(Id)
);