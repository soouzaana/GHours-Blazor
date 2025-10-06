CREATE TABLE cliente
(
	id_cli INT NOT NULL AUTO_INCREMENT,
	nome_cli VARCHAR(200) NOT NULL,
	cpf_cli VARCHAR(11) NOT NULL,
	telefone_cli VARCHAR(20),
	email_cli VARCHAR(50),
  PRIMARY KEY (id_cli)
);

CREATE TABLE funcionario
(
	id_fun INT NOT NULL AUTO_INCREMENT,
	nome_fun VARCHAR(200) NOT NULL,
	email_fun VARCHAR(50),
	endereco_fun VARCHAR (300),
	cpf_fun VARCHAR(11),
	telefone_fun VARCHAR(20),
  funcao_fun VARCHAR(50),
  PRIMARY KEY (id_fun)
);

CREATE TABLE quadra (
    id_qua INT AUTO_INCREMENT PRIMARY KEY,
    nome_qua VARCHAR(50),
    descricao_qua VARCHAR(300),
    valor_qua DECIMAL (10, 2),
    status_qua VARCHAR(50),
    PRIMARY KEY (id_qua)
);

CREATE TABLE agendamento (
	id_agen INT AUTO_INCREMENT PRIMARY KEY,
    data_agen DATE,
    horaInicial_agen TIME,
    horaFinal_agen TIME, 
    status_agen VARCHAR(50),
    valor_total DECIMAL (10, 2),
    data_reserva_agen date,
    PRIMARY KEY (id_agen)
    id_qua_fk int not null,
	  foreign key (id_qua_fk) references quadra (id_qua)
);

-- Inserindo dados iniciais nas tabelas
INSERT INTO
  cliente (nome_cli, cpf_cli, telefone_cli, email_cli)
VALUES
  ('João Silva', '123.456.789-01', '(69)99999-9999', 'joao@gmai.com'),
  ('Maria Oliveira', '987.654.321-00', '(69)98888-8888', 'maria@gmail.com'),
  ('Carlos Souza', '456.789.123-45', '(69)97777-7777', 'carluxo@hotmail.com');

INSERT INTO funcionario (nome_fun, email_fun, endereco_fun, cpf_fun, telefone_fun, fruncao_fun)
VALUES
  ('Ana Pereira', 'ana@hotmail.com', 'Rua Farto, 123, Cidade Ji-Paraná', '321.654.987-00', '(69)96666-6666', 'Recepcionista'),
  ('Bruno Lima', 'brunno.lima@gmail.com', 'Av. Central, 456, Cidade Ji-Paraná', '654.321.987-11', '(69)95555-5555', 'Gerente');

INSERT INTO quadra (nome_qua, descricao_qua, valor_qua, status_qua)
VALUES
  ('Quadra de Futebol', 'quadra grande', 150.00, 'Disponível'),
  ('Quadra de Vôlei - A', 'quadra média', 120.00, 'Disponível'),
  ('Quadra de Vôlei - B', 'quadra grande', 120.00, 'Indisponível');

INSERT INTO agendamento (data_agen, horaInicial_agen, horaFinal_agen, status_agen, valor_total, data_reserva_agen, id_qua_fk)
VALUES
  ('2025-07-10', '14:00:00', '15:00:00', 'Confirmado', 150.00, '2025-06-20', 1),
  ('2025-07-11', '16:00:00', '17:30:00', 'Pendente', 180.00, '2025-06-21', 2),
  ('2025-07-12', '10:00:00', '11:00:00', 'Cancelado', 130.00, '2025-06-22', 3);

SELECT * FROM cliente;
SELECT * FROM funcionario;
SELECT * FROM quadra;
SELECT * FROM agendamento;