CREATE DATABASE ConfeccionesElCondor;

USE ConfeccionesElCondor;
CREATE TABLE TiposDocumento (
    IdTipoDocumento INT PRIMARY KEY IDENTITY,
    NombreTipo VARCHAR(60) NOT NULL UNIQUE
);

CREATE TABLE Areas (
    IdArea INT PRIMARY KEY IDENTITY	,
    NombreArea VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Empleados (
    IdEmpleado INT PRIMARY KEY IDENTITY,
    IdTipoDocumento INT NOT NULL,
    NumeroDocumento VARCHAR(50) UNIQUE NOT NULL,
    PrimerNombre VARCHAR(100) NOT NULL,
	SegundoNombre VARCHAR(100),
	PrimerApellido VARCHAR(100) NOT NULL,
    SegundoApellido VARCHAR(100),
    FechaNacimiento DATE NOT NULL,
    IdArea INT NOT NULL,
    FOREIGN KEY (IdTipoDocumento) REFERENCES TiposDocumento(IdTipoDocumento),
    FOREIGN KEY (IdArea) REFERENCES Areas(IdArea)
);
DROP TABLE empleados;
INSERT INTO TiposDocumento (NombreTipo) 
VALUES 
('Cédula Ciudadanía'),
('Cédula Extranjería'),
('Pasaporte')

INSERT INTO Areas (NombreArea) 
VALUES 
('Producción'),
('Ventas'),
('Logística'),
('Recursos Humanos'),
('Finanzas'),
('Tecnología');
