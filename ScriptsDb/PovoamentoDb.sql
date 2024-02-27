-- Inserção de dados na tabela ProdutoFarmaceutico
INSERT INTO ProdutoFarmaceutico (IDProduto, NomeProduto, Descricao, Fabricante, Preco, QuantidadeEstoque, DataValidade)
VALUES
    (1, 'Paracetamol', 'Analgésico e antipirético', 'Farmacêutica XYZ', 10.50, 100, '2024-06-30'),
    (2, 'Amoxicilina', 'Antibiótico de amplo espectro', 'Farmacêutica ABC', 15.75, 50, '2024-08-15'),
    (3, 'Dipirona', 'Analgésico e antipirético', 'Farmacêutica XYZ', 8.25, 80, '2024-07-20');

-- Inserção de dados na tabela Cliente
INSERT INTO Cliente (IDCliente, Nome, Endereco, NumeroTelefone, Email)
VALUES
    (1, 'João Silva', 'Rua das Flores, 123', '(11) 9999-8888', 'joao@example.com'),
    (2, 'Maria Santos', 'Av. Principal, 456', '(11) 7777-6666', 'maria@example.com'),
    (3, 'José Oliveira', 'Rua das Palmeiras, 789', '(11) 5555-4444', 'jose@example.com');

-- Inserção de dados na tabela Farmaceutico
INSERT INTO Farmaceutico (IDFarmacutico, Nome, NumeroRegistroProfissional, NumeroTelefone, Email)
VALUES
    (1, 'Ana Souza', 'CRF-12345', '(11) 3333-2222', 'ana@example.com'),
    (2, 'Pedro Rocha', 'CRF-54321', '(11) 1111-0000', 'pedro@example.com'),
    (3, 'Mariana Oliveira', 'CRF-98765', '(11) 9999-9999', 'mariana@example.com');

-- Inserção de dados na tabela VendaProdutos
INSERT INTO VendaProdutos (IDVenda, DataVenda, ClienteID, FarmaceuticoID, ValorTotal)
VALUES
    (1, '2024-02-25', 1, 1, 25.00),
    (2, '2024-02-24', 2, 2, 35.50),
    (3, '2024-02-23', 3, 3, 42.75);

-- Inserção de dados na tabela PrescricaoMedica
INSERT INTO PrescricaoMedica (IDPrescricao, PacienteID, FarmaceuticoID, DataPrescricao, MedicamentosPrescritos)
VALUES
    (1, 1, 1, '2024-02-20', 'Paracetamol, Amoxicilina'),
    (2, 2, 2, '2024-02-19', 'Dipirona'),
    (3, 3, 3, '2024-02-18', 'Paracetamol');

-- Inserção de dados na tabela Fornecedor
INSERT INTO Fornecedor (IDFornecedor, NomeFornecedor, Endereco, NumeroTelefone, Email)
VALUES
    (1, 'Distribuidora ABC', 'Av. dos Comerciantes, 100', '(11) 2222-3333', 'distribuidora@example.com'),
    (2, 'FarmaSupplier', 'Rua das Indústrias, 200', '(11) 4444-5555', 'farmasupplier@example.com'),
    (3, 'PharmaCompany', 'Travessa das Farmácias, 300', '(11) 6666-7777', 'pharmacompany@example.com');

-- Inserção de dados na tabela EntregaProdutos
INSERT INTO EntregaProdutos (IDEntrega, FornecedorID, ProdutosEntregues, QuantidadeEntregue, DataEntrega)
VALUES
    (1, 1, 'Paracetamol, Amoxicilina', 200, '2024-02-20'),
    (2, 2, 'Dipirona', 150, '2024-02-19'),
    (3, 3, 'Paracetamol', 100, '2024-02-18');