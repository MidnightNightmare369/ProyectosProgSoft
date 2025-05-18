CREATE DATABASE db_parqueadero;
GO
USE db_parqueadero;
GO

CREATE TABLE TipoVehiculos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TipoVehiculo NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE TipoClientes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TipoCliente NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE TipoPagos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TipoPago NVARCHAR(50) NOT NULL 
);

CREATE TABLE Parqueaderos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Tarifas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Tipo NVARCHAR(50) NOT NULL,
    Valor DECIMAL(18,2) NOT NULL
);

CREATE TABLE Vehiculos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Placa NVARCHAR(20) NOT NULL UNIQUE,
    TipoVehiculo INT NOT NULL REFERENCES TipoVehiculos(Id),
);

CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Cedula NVARCHAR(20) NOT NULL, -- Se asume que la cedula se puede repetir por eso no la deje UNIQUE
    Nombre NVARCHAR(100) NOT NULL,
    Vehiculo INT NOT NULL REFERENCES Vehiculos (Id),
    TipoCliente INT NOT NULL REFERENCES TipoClientes (Id),
    Codigo INT NOT NULL,
);

CREATE TABLE Turnos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Rango NVARCHAR(50) NOT NULL, 
    Turno NVARCHAR(50) NOT NULL 
);

CREATE TABLE Contratos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Referencia NVARCHAR(50) NOT NULL,
    FechaInicio NVARCHAR(50) NOT NULL,
    FechaTerminacion NVARCHAR(50) NOT NULL 
);

CREATE TABLE Cargos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Cargo NVARCHAR(50) NOT NULL 
);

CREATE TABLE Empleados (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Cedula NVARCHAR(20) NOT NULL,  
    Nombre NVARCHAR(100) NOT NULL,
    Cargo INT NOT NULL REFERENCES Cargos (Id),
    Turno INT NOT NULL REFERENCES Turnos (Id),
    Contrato INT NOT NULL REFERENCES Contratos (Id),
);

CREATE TABLE ParqueaderosClientes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Tiempo DECIMAL NOT NULL,
    Posicion NVARCHAR(30) NOT NULL,
    Total DECIMAL(18,2) NOT NULL,
    Tarifa INT NOT NULL REFERENCES Tarifas(Id),
    TipoPago INT NOT NULL REFERENCES TipoPagos(Id),
    Cliente INT NOT NULL REFERENCES Clientes(Id),
    Parqueadero INT NOT NULL REFERENCES Parqueaderos(Id),
    Empleado INT NOT NULL REFERENCES Empleados(Id),
);

-- Insertar datos en TipoVehiculos
INSERT INTO TipoVehiculos (TipoVehiculo) VALUES ('moto');
INSERT INTO TipoVehiculos (TipoVehiculo) VALUES ('automovil');

-- Insertar datos en TipoClientes
INSERT INTO TipoClientes (TipoCliente) VALUES ('regular');
INSERT INTO TipoClientes (TipoCliente) VALUES ('VIP');

-- Insertar datos en TipoPagos
INSERT INTO TipoPagos (TipoPago) VALUES ('efectivo');
INSERT INTO TipoPagos (TipoPago) VALUES ('tarjeta');

-- Insertar datos en Parqueaderos
INSERT INTO Parqueaderos (Nombre) VALUES ('Parqueaderoo');

-- Insertar datos en Tarifas
INSERT INTO Tarifas (Tipo, Valor) VALUES ('MotoR', 9000);
INSERT INTO Tarifas (Tipo, Valor) VALUES ('MotoVIP', 15000);
INSERT INTO Tarifas (Tipo, Valor) VALUES ('AutoR', 12000);
INSERT INTO Tarifas (Tipo, Valor) VALUES ('AutoVIP', 18000);

-- Insertar datos en Vehiculos
INSERT INTO Vehiculos (Placa, TipoVehiculo) VALUES ('HSF369', 1);
INSERT INTO Vehiculos (Placa, TipoVehiculo) VALUES ('THL666', 2);
INSERT INTO Vehiculos (Placa, TipoVehiculo) VALUES ('LDL666', 2);
INSERT INTO Vehiculos (Placa, TipoVehiculo) VALUES ('PYK555', 1);
INSERT INTO Vehiculos (Placa, TipoVehiculo) VALUES ('NPY693', 2);
INSERT INTO Vehiculos (Placa, TipoVehiculo) VALUES ('ETN527', 1);
INSERT INTO Vehiculos (Placa, TipoVehiculo) VALUES ('CLT009', 1);
INSERT INTO Vehiculos (Placa, TipoVehiculo) VALUES ('FCK911', 2);

-- Insertar datos en Clientes
INSERT INTO Clientes (Cedula, Nombre, Vehiculo, TipoCliente, Codigo) VALUES ('1000', 'Pedro Sanchez', 1, 1, 1);
INSERT INTO Clientes (Cedula, Nombre, Vehiculo, TipoCliente, Codigo) VALUES ('1333', 'Alex Crowley', 2, 2, 2);
INSERT INTO Clientes (Cedula, Nombre, Vehiculo, TipoCliente, Codigo) VALUES ('1333', 'Alex Crowley', 3, 2, 2);
INSERT INTO Clientes (Cedula, Nombre, Vehiculo, TipoCliente, Codigo) VALUES ('1369', 'Juan Zapata', 4, 2, 3);
INSERT INTO Clientes (Cedula, Nombre, Vehiculo, TipoCliente, Codigo) VALUES ('1666', 'Esteban Gomez', 5, 1, 4);
INSERT INTO Clientes (Cedula, Nombre, Vehiculo, TipoCliente, Codigo) VALUES ('1234', 'Andres Garcia', 6, 1, 5);
INSERT INTO Clientes (Cedula, Nombre, Vehiculo, TipoCliente, Codigo) VALUES ('1111', 'Pedro Ortiz', 7, 1, 6);
INSERT INTO Clientes (Cedula, Nombre, Vehiculo, TipoCliente, Codigo) VALUES ('1245', 'Alvaro Loaiza', 8, 2, 7);

-- Insertar datos en TURNOS
INSERT INTO Turnos (Rango, Turno) VALUES
  ('6-2',  'Mañana'),
  ('2-10', 'Tarde'),
  ('10-6', 'Noche');

-- Insertar datos en CONTRATOS
INSERT INTO Contratos (Referencia, FechaInicio, FechaTerminacion) VALUES
  ('CJ001', '03/06/2019', '03/06/2025'),
  ('CJ002', '03/03/2023', '03/03/2026'),
  ('CJ003', '03/09/2016', '03/09/2026'),
  ('ROOT001', '03/06/2009', '03/06/2025'),
  ('ROOT002', '03/06/2016', '03/06/2025');

-- Insertar datos en CARGOS
INSERT INTO Cargos (Cargo) VALUES
  ('Administrador'),
  ('Cajero');

-- Insertar datos en EMPLEADOS
INSERT INTO Empleados (Cedula, Nombre, Cargo, Turno, Contrato) VALUES
  ('3693', 'Federico Sanchez',    2, 1, 1),
  ('9999', 'Sebastian Gomez',     2, 2, 2),
  ('1266', 'Fernando Alonzo',     2, 3, 3),
  ('6663', 'Yevgeny Prigozhin',   1, 1, 4),
  ('9639', 'Vladimir Kravchenko', 1, 2, 5);

-- Insertar datos en ParqueaderosClientes
INSERT INTO ParqueaderosClientes (Tiempo, Posicion, Total, Tarifa, TipoPago, Cliente, Parqueadero, Empleado) 
VALUES (2, 'A1', 18000.0, 1, 1, 1, 1,1);
INSERT INTO ParqueaderosClientes (Tiempo, Posicion, Total, Tarifa, TipoPago, Cliente, Parqueadero, Empleado) 
VALUES (24, 'H5', 435000.0, 4, 2, 2, 1,3);
INSERT INTO ParqueaderosClientes (Tiempo, Posicion, Total, Tarifa, TipoPago, Cliente, Parqueadero, Empleado) 
VALUES (5, 'H6', 90000.0, 4, 2, 3, 1,3);
INSERT INTO ParqueaderosClientes (Tiempo, Posicion, Total, Tarifa, TipoPago, Cliente, Parqueadero, Empleado) 
VALUES (12, 'E1', 180000.0, 2, 1, 4, 1,3);
INSERT INTO ParqueaderosClientes (Tiempo, Posicion, Total, Tarifa, TipoPago, Cliente, Parqueadero, Empleado) 
VALUES (2, 'A2', 24000.0, 3, 2, 5, 1,1);
INSERT INTO ParqueaderosClientes (Tiempo, Posicion, Total, Tarifa, TipoPago, Cliente, Parqueadero, Empleado) 
VALUES (10, 'A6', 90000.0, 1, 1, 6, 1,1);
INSERT INTO ParqueaderosClientes (Tiempo, Posicion, Total, Tarifa, TipoPago, Cliente, Parqueadero, Empleado) 
VALUES (5, 'A5', 45000.0, 1, 1, 7, 1,2);
INSERT INTO ParqueaderosClientes (Tiempo, Posicion, Total, Tarifa, TipoPago, Cliente, Parqueadero, Empleado) 
VALUES (10, 'H3', 180000.0, 4, 2, 8, 1,2);

