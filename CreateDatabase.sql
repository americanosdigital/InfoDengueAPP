-- Criar banco de dados
CREATE DATABASE InfoDengueDB;
GO

-- Usar o banco de dados criado
USE InfoDengueDB;
GO

-- Tabela Solicitantes
CREATE TABLE Solicitantes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Cpf NVARCHAR(11) NOT NULL UNIQUE
);

-- Tabela Relatorios
CREATE TABLE Relatorios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Municipio NVARCHAR(100) NOT NULL,
    CodigoIbge NVARCHAR(10) NOT NULL,
    Arbovirose NVARCHAR(50) NOT NULL,
    TotalCasos INT NOT NULL,
    DataSolicitacao DATETIME NOT NULL DEFAULT GETDATE(),
    SolicitanteId INT NOT NULL,
    CONSTRAINT FK_Relatorios_Solicitantes FOREIGN KEY (SolicitanteId) REFERENCES Solicitantes(Id)
);


--Inserir solicitantes
INSERT INTO Solicitantes (Nome, Cpf)
VALUES ('João Silva', '12345678901'),
       ('Maria Oliveira', '98765432100');

--Inserir relatórios
INSERT INTO Relatorios (Municipio, CodigoIbge, Arbovirose, TotalCasos, SolicitanteId)
VALUES ('Rio de Janeiro', '3304557', 'Dengue', 1200, 1),
       ('São Paulo', '3550308', 'Zika', 800, 2);

