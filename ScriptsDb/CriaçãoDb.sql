-- Cria��o do banco de dados
CREATE DATABASE CadastroFarmaciaDb;
GO

-- Uso do banco de dados CadastroFarmacia
USE CadastroFarmaciaDb;
GO

-- Cria��o da tabela ProdutoFarmaceutico
CREATE TABLE ProdutoFarmaceutico (
    IDProduto INT PRIMARY KEY,
    NomeProduto NVARCHAR(100),
    Descricao NVARCHAR(255),
    Fabricante NVARCHAR(100),
    Preco DECIMAL(10, 2),
    QuantidadeEstoque INT,
    DataValidade DATE
);
GO

-- Cria��o da tabela Cliente
CREATE TABLE Cliente (
    IDCliente INT PRIMARY KEY,
    Nome NVARCHAR(100),
    Endereco NVARCHAR(255),
    NumeroTelefone NVARCHAR(20),
    Email NVARCHAR(100)
);
GO

-- Cria��o da tabela Farmaceutico
CREATE TABLE Farmaceutico (
    IDFarmacutico INT PRIMARY KEY,
    Nome NVARCHAR(100),
    NumeroRegistroProfissional NVARCHAR(50),
    NumeroTelefone NVARCHAR(20),
    Email NVARCHAR(100)
);
GO

-- Cria��o da tabela VendaProdutos
CREATE TABLE VendaProdutos (
    IDVenda INT PRIMARY KEY,
    DataVenda DATE,
    ClienteID INT FOREIGN KEY REFERENCES Cliente(IDCliente),
    FarmaceuticoID INT FOREIGN KEY REFERENCES Farmaceutico(IDFarmacutico),
    ValorTotal DECIMAL(10, 2)
);
GO

-- Cria��o da tabela PrescricaoMedica
CREATE TABLE PrescricaoMedica (
    IDPrescricao INT PRIMARY KEY,
    PacienteID INT FOREIGN KEY REFERENCES Cliente(IDCliente),
    FarmaceuticoID INT FOREIGN KEY REFERENCES Farmaceutico(IDFarmacutico),
    DataPrescricao DATE,
    MedicamentosPrescritos NVARCHAR(MAX)
);
GO

-- Cria��o da tabela Fornecedor
CREATE TABLE Fornecedor (
    IDFornecedor INT PRIMARY KEY,
    NomeFornecedor NVARCHAR(100),
    Endereco NVARCHAR(255),
    NumeroTelefone NVARCHAR(20),
    Email NVARCHAR(100)
);
GO

-- Cria��o da tabela EntregaProdutos
CREATE TABLE EntregaProdutos (
    IDEntrega INT PRIMARY KEY,
    FornecedorID INT FOREIGN KEY REFERENCES Fornecedor(IDFornecedor),
    ProdutosEntregues NVARCHAR(MAX),
    QuantidadeEntregue INT,
    DataEntrega DATE
);
GO