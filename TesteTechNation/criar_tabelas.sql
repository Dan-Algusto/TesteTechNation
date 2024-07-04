-- Criando as tabelas no banco de dados

-- 1.  **Conecte-se ao seu servidor SQL Server:** Use o SQL Server Management Studio ou outra ferramenta de sua preferência.
-- 2.  **Selecione o banco de dados:** Escolha o banco de dados onde você deseja criar as tabelas.
-- 3.  **Execute o script SQL:** Abra o arquivo `criar_tabelas.sql` e execute o script para criar a tabela `NotasFiscais`.


CREATE TABLE NotasFiscais (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NomePagador VARCHAR(255) NOT NULL,
    NumeroIdentificacao VARCHAR(50) NOT NULL,
    DataEmissao DATE NOT NULL,
    DataCobranca DATE,
    DataPagamento DATE,
    Valor DECIMAL(18, 2) NOT NULL,
    DocumentoNotaFiscal VARCHAR(255) NOT NULL,
    DocumentoBoleto VARCHAR(255) NULL,
    Status VARCHAR(50) NOT NULL
);

--INSERIR PARA TER DADOS PARA TESTES

INSERT INTO NotasFiscais (NomePagador, NumeroIdentificacao, DataEmissao, DataCobranca, DataPagamento, Valor, DocumentoNotaFiscal, DocumentoBoleto, Status)
VALUES
    ('João Silva', 'NF-001', '2023-01-15', '2023-01-20', '2023-02-01', 500.00, 'DocNF-001.pdf', 'Boleto-001.pdf', 'Pagamento realizado'),
    ('Maria Souza', 'NF-002', '2023-04-20', '2023-04-25', '2023-05-10', 800.00, 'DocNF-002.pdf', 'Boleto-002.pdf', 'Pagamento realizado'),
    ('Carlos Santos', 'NF-003', '2023-07-10', '2023-07-15', '2023-07-25', 1200.00, 'DocNF-003.pdf', 'Boleto-003.pdf', 'Pagamento realizado');

-- Notas Fiscais com Cobrança Realizada
INSERT INTO NotasFiscais (NomePagador, NumeroIdentificacao, DataEmissao, DataCobranca, DataPagamento, Valor, DocumentoNotaFiscal, DocumentoBoleto, Status)
VALUES
    ('Ana Oliveira', 'NF-004', '2023-02-05', '2023-02-10', NULL, 300.00, 'DocNF-004.pdf', 'Boleto-004.pdf', 'Cobrança realizada'),
    ('Pedro Almeida', 'NF-005', '2023-05-18', '2023-05-23', NULL, 950.00, 'DocNF-005.pdf', 'Boleto-005.pdf', 'Cobrança realizada'),
    ('Laura Fernandes', 'NF-006', '2023-08-30', '2023-09-04', NULL, 720.00, 'DocNF-006.pdf', 'Boleto-006.pdf', 'Cobrança realizada');

-- Notas Fiscais com Pagamento em Atraso
INSERT INTO NotasFiscais (NomePagador, NumeroIdentificacao, DataEmissao, DataCobranca, DataPagamento, Valor, DocumentoNotaFiscal, DocumentoBoleto, Status)
VALUES
    ('Ricardo Lima', 'NF-007', '2023-03-12', '2023-03-17', NULL, 480.00, 'DocNF-007.pdf', 'Boleto-007.pdf', 'Pagamento em atraso'),
    ('Beatriz Castro', 'NF-008', '2023-06-25', '2023-06-30', NULL, 1100.00, 'DocNF-008.pdf', 'Boleto-008.pdf', 'Pagamento em atraso'),
    ('Gustavo Pereira', 'NF-009', '2023-09-03', '2023-09-08', NULL, 650.00, 'DocNF-009.pdf', 'Boleto-009.pdf', 'Pagamento em atraso');
	
	-- Notas Fiscais Emitidas
INSERT INTO NotasFiscais (NomePagador, NumeroIdentificacao, DataEmissao, DataCobranca, DataPagamento, Valor, DocumentoNotaFiscal, DocumentoBoleto, Status)
VALUES
    ('João Silva', 'NF-001', '2023-01-15', NULL, NULL, 500.00, 'DocNF-001.pdf', 'Pendente', 'Emitida'),
    ('Maria Souza', 'NF-002', '2023-04-20', NULL, NULL, 800.00, 'DocNF-002.pdf', 'Pendente', 'Emitida'),
    ('Carlos Santos', 'NF-003', '2023-07-10', NULL, NULL, 1200.00, 'DocNF-003.pdf', 'Pendente', 'Emitida');

