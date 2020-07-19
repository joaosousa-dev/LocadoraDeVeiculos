CREATE DATABASE LocadoraSeven;

USE LocadoraSeven;

CREATE TABLE Categoria(
cod_categoria int primary key auto_increment,
nome_categoria varchar(30),
valor_categoria double,
descricao_categoria varchar(100)
);

CREATE TABLE Marca(
cod_marca int primary key auto_increment,
nome_marca varchar(30)
);

CREATE TABLE Seguro(
cod_seguro int primary key auto_increment,
valor_seguro double,
descricao_seguro varchar(100),
nivel_seguro varchar(20)
);

CREATE TABLE Veiculo(
cod_veiculo int primary key auto_increment,
cod_categoria int ,
cod_marca int ,
trplaca_veiculo varchar(15),
chassi_veiculo varchar(30) not null,
modelo_veiculo varchar(30),
status_veiculo varchar(30) not null,
foreign key (cod_categoria) references Categoria(cod_categoria),
foreign key (cod_marca) references marca(cod_marca)
);

CREATE TABLE Manutencao(
cod_manutencao int primary key auto_increment,
cod_veiculo int,
descricao_manutencao varchar(50),
foreign key (cod_veiculo) references veiculo(cod_veiculo)
);

CREATE TABLE Cliente(
cpf_cliente varchar(15) primary key not null,
nome_cliente varchar(50) not null,
email_cliente varchar(30) not null,
data_nasc_cliente date not null,
cnh_cliente varchar(11) not null,
sexo_cliente varchar(10) not null,
logradouro varchar(50) not null,
numero varchar(10) not null,
CEP varchar(9) not null,
cidade varchar(50) not null,
UF varchar(5) not null,
bairro varchar(30) not null,
usuario varchar(20) not null,
senha varchar(15) not null,
nivel_login int not null
);

CREATE TABLE Reserva(
cod_reserva int primary key auto_increment,
cod_veiculo int,
cpf_cliente varchar(15),
data_reserva date,
previsao_retorno date,
foreign key (cod_veiculo) references Veiculo(cod_veiculo),
foreign key (cpf_cliente) references Cliente(cpf_cliente)
);

CREATE TABLE Locacao(
cod_locacao int primary key auto_increment,
cod_reserva int,
cod_seguro int,
data_locacao date,
valor_locacao decimal(5,2),
foreign key (cod_reserva) references Reserva(cod_reserva),
foreign key (cod_seguro) references Seguro(cod_seguro)
);

CREATE TABLE Pagamento(
cod_pagamento int primary key auto_increment,
cod_locacao int references Locacao(cod_locacao),
acrescimos_multa varchar(40),
forma_pagamento varchar(25) not null,
valor_transferencia varchar(20),
valor_credito varchar(20),
valor_total varchar(20)
);

CREATE TABLE Funcionario(
cod_funcionario int primary key auto_increment,
nome_funcionario varchar(50) not  null,
data_nascimento date not null,
email_funcionario varchar(30) not null,
cpf_funcionario varchar(15) not null,
sexo_funcionario varchar(10),
usuario varchar(20) not null,
senha varchar(15) not null,
nivel_login int
);

insert into funcionario(cod_funcionario,nome_funcionario,data_nascimento,email_funcionario,cpf_funcionario,sexo_funcionario,usuario,senha,nivel_login) values (default,"jose","2001-03-02","jvoliveira@gmail.com","321.213.342-03","MASCULINO","jose123","12345",3);
insert into funcionario(cod_funcionario,nome_funcionario,data_nascimento,email_funcionario,cpf_funcionario,sexo_funcionario,usuario,senha,nivel_login) values (default,"admin","2001-05-23","admin@gmail.com","000.000.000-00","MASCULINO","admin","admin",3);

CREATE TABLE Telefone(
cod_telefone int primary key auto_increment,
cod_funcionario int references Funcionario(cod_funcionario),
cod_cliente int references Cliente(cod_cliente),
numero_tel int not null,
numero_cel int not null
);

create table login(
cpf_cliente varchar(15) null references cliente(cpf_cliente),
cod_funcionario int null references funcionario(cod_funcionario),
usuario varchar(20),
senha varchar(15),
nivel int
);

-- trigger que insere na tabela login com base na tabela cliente
create trigger tr_login after insert
on cliente
for each row
insert into login(cpf_cliente,usuario,senha,nivel) values(new.cpf_cliente,new.usuario,new.senha,new.nivel_login);

-- trigger que altera a tabela login depois de alterar cliente 
create trigger tr_login_edit after update
on cliente
for each row
update login set senha = new.senha where cpf_cliente=old.cpf_cliente ;

-- trigger que altera a tabela login com base na tabela funcionario alterada
create trigger tr_login_edit_func after update
on funcionario
for each row
update login set senha = new.senha where cod_funcionario=old.cod_funcionario;

-- trigger que altera a tabela login com base na tabela funcionario alterada
create trigger tr_login_edit_funcUsu after update
on funcionario
for each row
update login set usuario = new.usuario where cod_funcionario=old.cod_funcionario;

-- trigger que insere na tabela login com base na tab funcionario
create trigger tr_login_func after insert
on funcionario
for each row
insert into login(cod_funcionario,usuario,senha,nivel) values(new.cod_funcionario,new.usuario,new.senha,new.nivel_login);

-- apaga da tab login antes de apagar na funcionario
create trigger tr_login_delete before delete
on funcionario
for each row
delete from login where cod_funcionario=old.cod_funcionario;

-- apaga na tab login antes de apagar na cliente
create trigger tr_login_deleteCli before delete
on cliente
for each row
delete from login where cpf_cliente=old.cpf_cliente;

select * from login;

SELECT * FROM Categoria;

SELECT * FROM Marca;

SELECT * FROM Seguro;

SELECT * FROM Veiculo;

SELECT * FROM Manutencao;

SELECT * FROM Reserva;

SELECT * FROM Locacao;

SELECT * FROM Pagamento;

SELECT * FROM Funcionario;

SELECT * FROM Cliente;

SELECT * FROM Login;

SELECT * FROM Telefone;