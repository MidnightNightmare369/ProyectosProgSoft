CREATE DATABASE db_colegio
GO
USE db_colegio
GO

CREATE TABLE Notas(
[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[Estudiante] NVARCHAR (150) NOT NULL,
[Materias] NVARCHAR (150) NOT NULL,
[Nota1] DECIMAL (10,2) NOT NULL,
[Nota2] DECIMAL (10,2) NOT NULL,
[Nota3] DECIMAL (10,2) NOT NULL,
[Nota4] DECIMAL (10,2) NOT NULL,
[Nota5] DECIMAL (10,2) NOT NULL,
[NotaFinal] DECIMAL (10,2) NOT NULL,
[fecha] SMALLDATETIME NOT NULL,
);

INSERT INTO [Notas](Estudiante,Materias,Nota1,Nota2,Nota3,Nota4,Nota5,NotaFinal,fecha) 
VALUES ('Pepito Perez','Mat basicas',4.5,2.3,1.5,4.8,2.5,2.5,GETDATE());

SELECT * FROM dbo.Notas
