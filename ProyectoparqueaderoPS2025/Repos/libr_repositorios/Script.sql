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

CREATE TABLE Vehiculos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Placa NVARCHAR(20) NOT NULL UNIQUE,
    TipoVehiculo INT NOT NULL REFERENCES TipoVehiculos(Id),
);

CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Cedula NVARCHAR(20) NOT NULL, -- Se asume que la cedula se puede repetir por eso no la deje UNIQUE
    Nombre NVARCHAR(100) NOT NULL,
    Vehiculo INT NOT NULL,
    TipoCliente INT NOT NULL,
    FOREIGN KEY (Vehiculo) REFERENCES Vehiculos(Id),
    FOREIGN KEY (TipoCliente) REFERENCES TipoClientes(Id)
);

CREATE TABLE ParqueaderosClientes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Tiempo FLOAT NOT NULL,
    Posicion NVARCHAR(10) NOT NULL,
    Total DECIMAL(18,2) NOT NULL,
    Tarifa INT NOT NULL,
    TipoPago INT NOT NULL,
    Cliente INT NOT NULL,
    Parqueadero INT NOT NULL,
    FOREIGN KEY (Tarifa) REFERENCES Tarifas(Id),
    FOREIGN KEY (TipoPago) REFERENCES TipoPagos(Id),
    FOREIGN KEY (Cliente) REFERENCES Clientes(Id),
    FOREIGN KEY (Parqueadero) REFERENCES Parqueaderos(Id)
);

CREATE TABLE Tarifas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Tipo NVARCHAR(50) NOT NULL,
    Valor DECIMAL(18,2) NOT NULL
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
INSERT INTO Clientes (Cedula, Nombre, Vehiculo, TipoCliente) VALUES ('1000', 'Pedro Sanchez', 1, 1);
INSERT INTO Clientes (Cedula, Nombre, Vehiculo, TipoCliente) VALUES ('1333', 'Alex Crowley', 2, 2);
INSERT INTO Clientes (Cedula, Nombre, Vehiculo, TipoCliente) VALUES ('1333', 'Alex Crowley', 3, 2);
INSERT INTO Clientes (Cedula, Nombre, Vehiculo, TipoCliente) VALUES ('1369', 'Juan Zapata', 4, 2);
INSERT INTO Clientes (Cedula, Nombre, Vehiculo, TipoCliente) VALUES ('1666', 'Esteban Gomez', 5, 1);
INSERT INTO Clientes (Cedula, Nombre, Vehiculo, TipoCliente) VALUES ('1234', 'Andres Garcia', 6, 1);
INSERT INTO Clientes (Cedula, Nombre, Vehiculo, TipoCliente) VALUES ('1111', 'Pedro Ortiz', 7, 1);
INSERT INTO Clientes (Cedula, Nombre, Vehiculo, TipoCliente) VALUES ('1245', 'Alvaro Loaiza', 8, 2);

-- Insertar datos en Tarifas
INSERT INTO Tarifas (Tipo, Valor) VALUES ('MotoR', 9000);
INSERT INTO Tarifas (Tipo, Valor) VALUES ('MotoVIP', 15000);
INSERT INTO Tarifas (Tipo, Valor) VALUES ('AutoR', 12000);
INSERT INTO Tarifas (Tipo, Valor) VALUES ('AutoVIP', 18000);

-- Insertar datos en ParqueaderosClientes
INSERT INTO ParqueaderosClientes (Tiempo, Posicion, Total, Tarifa, TipoPago, Cliente, Parqueadero) 
VALUES (2, 'A1', 18000.0, 1, 1, 1, 1);
INSERT INTO ParqueaderosClientes (Tiempo, Posicion, Total, Tarifa, TipoPago, Cliente, Parqueadero) 
VALUES (24, 'H5', 435000.0, 4, 2, 2, 1);
INSERT INTO ParqueaderosClientes (Tiempo, Posicion, Total, Tarifa, TipoPago, Cliente, Parqueadero) 
VALUES (5, 'H6', 90000.0, 4, 2, 3, 1);
INSERT INTO ParqueaderosClientes (Tiempo, Posicion, Total, Tarifa, TipoPago, Cliente, Parqueadero) 
VALUES (12, 'E1', 180000.0, 2, 1, 4, 1);
INSERT INTO ParqueaderosClientes (Tiempo, Posicion, Total, Tarifa, TipoPago, Cliente, Parqueadero) 
VALUES (2, 'A2', 24000.0, 3, 2, 5, 1);
INSERT INTO ParqueaderosClientes (Tiempo, Posicion, Total, Tarifa, TipoPago, Cliente, Parqueadero) 
VALUES (10, 'A6', 90000.0, 1, 1, 6, 1);
INSERT INTO ParqueaderosClientes (Tiempo, Posicion, Total, Tarifa, TipoPago, Cliente, Parqueadero) 
VALUES (5, 'A5', 45000.0, 1, 1, 7, 1);
INSERT INTO ParqueaderosClientes (Tiempo, Posicion, Total, Tarifa, TipoPago, Cliente, Parqueadero) 
VALUES (10, 'H3', 180000.0, 4, 2, 8, 1);

