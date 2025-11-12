CREATE TABLE Cliente (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) UNIQUE NOT NULL,
    Telefone NVARCHAR(20),
);


CREATE TABLE Funcao (
    IdFuncao INT IDENTITY(1,1) PRIMARY KEY,
    NomeFuncao NVARCHAR(50) NOT NULL
);


CREATE TABLE Agente (
    IdAgente INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) UNIQUE NOT NULL,
    SenhaHash NVARCHAR(255) NOT NULL, -- nunca salvar senha pura
    IdFuncao INT FOREIGN KEY REFERENCES Funcao(IdFuncao),
    DataCadastro DATETIME DEFAULT GETDATE()
);

CREATE TABLE Problema (
    IdProblema INT IDENTITY(1,1) PRIMARY KEY,
    Titulo NVARCHAR(150) NOT NULL,
    Descricao NVARCHAR(MAX) NOT NULL,
    Solucao NVARCHAR(MAX),
    DataRegistro DATETIME DEFAULT GETDATE()
);


CREATE TABLE Ticket (
    IdTicket INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente),
    IdAgente INT NULL FOREIGN KEY REFERENCES Agente(IdAgente),
    IdProblema INT NULL FOREIGN KEY REFERENCES Problema(IdProblema),
    Titulo NVARCHAR(150) NOT NULL,
    Descricao NVARCHAR(MAX) NOT NULL,
    Status NVARCHAR(50) DEFAULT 'Aberto',
    Prioridade NVARCHAR(20) DEFAULT 'Normal',
    DataCriacao DATETIME DEFAULT GETDATE(),
    DataFechamento DATETIME NULL
);

CREATE TABLE PRODUTO(
IDproduto int identity (1,1) primary key,
NomeProduto NVARCHAR (30) NOT NULL,
MoodeloProduto NVARCHAR(30) NOT NULL,
DescricaoProduto NVARCHAR(320)
);



CREATE TABLE MENSAGENS_TICKET (
    IDMensagem INT IDENTITY(1,1) PRIMARY KEY,
    IDTicket INT FOREIGN KEY REFERENCES Ticket(IDTicket),
    IDCliente INT FOREIGN KEY REFERENCES Cliente(IDCliente),
    Mensagem NVARCHAR(2000) NOT NULL,
    DataEnvio DATETIME2 DEFAULT GETDATE(),
    EhInterno BIT DEFAULT 0 -- Se é nota interna (só agentes veem)
);

INSERT INTO PRODUTO (NomeProduto, MoodeloProduto, DescricaoProduto) VALUES
('Filtro de Óleo', 'FO-2023', 'Filtro de óleo para motores a gasolina e diesel, capacidade de filtragem de 20 micrômetros'),
('Pastilha de Freio', 'PF-DiscBrake', 'Pastilha de freio para sistema de disco dianteiro, material cerâmico com baixo ruído'),
('Bateria 60Ah', 'BatPower-60', 'Bateria automotiva 12V 60Ah, ideal para carros populares e compactos'),
('Amortecedor Dianteiro', 'ShockPro-Front', 'Amortecedor hidráulico dianteiro, conforto e estabilidade em diversos terrenos'),
('Pneu 195/55 R15', 'TireMax-195', 'Pneu radial para uso urbano, ótima aderência em piso seco e molhado'),
('Vela de Ignição', 'SparkPlug-NG', 'Vela de ignição com eletrodo de platina, maior durabilidade e performance'),
('Correia Dentada', 'TimingBelt-Pro', 'Correia dentada de alta resistência para comando de válvulas, kit completo'),
('Radiador Alumínio', 'CoolMax-Alu', 'Radiador em alumínio para melhor dissipação de calor, compatível com vários modelos'),
('Sensor de Oxigênio', 'O2-Sensor02', 'Sensor de oxigênio para sistema de injeção eletrônica, reduz emissão de poluentes'),
('Limpador Parabrisa', 'WiperBlade-24', 'Palheta de limpador 24 polegadas, borracha silicone para maior durabilidade');





SELECT NomeProduto, DescricaoProduto FROM PRODUTO;