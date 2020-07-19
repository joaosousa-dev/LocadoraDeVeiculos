CREATE DATABASE LocadoraSeven;
use LocadoraSeven;

CREATE TABLE Categoria(
cod_categoria int primary key auto_increment,
nome_categoria varchar(30),
valor_categoria decimal(5,2),
descricao_categoria varchar(100));

CREATE TABLE Marca(
cod_marca int primary key auto_increment,
nome_marca varchar(30));

CREATE TABLE Seguro(
cod_seguro int primary key auto_increment,
valor_seguro decimal(5,2),
descricao_seguro varchar(100),
nivel_seguro varchar(20));

CREATE TABLE Veiculo(
cod_veiculo int primary key auto_increment,
cod_categoria int ,
cod_marca int ,
placa_veiculo varchar(15),
chassi_veiculo varchar(30),
modelo_veiculo varchar(30),
imagem varchar(1000),
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
nivel_login int not null);

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
foreign key (cod_seguro) references Seguro(cod_seguro),
foreign key (cod_reserva) references Reserva(cod_reserva));

CREATE TABLE Pagamento(
cod_pagamento int primary key auto_increment,
cod_locacao int,
acrescimos_multa decimal(5,2),
forma_pagamento varchar(25) not null,
valor_transferencia decimal(5,2),
valor_credito decimal(5,2),
valor_total decimal(5,2),
foreign key (cod_locacao) references Locacao(cod_locacao));

CREATE TABLE Funcionario(
cod_funcionario int primary key auto_increment,
nome_funcionario varchar(50) not  null,
data_nascimento date not null,
email_funcionario varchar(30) not null,
cpf_funcionario varchar(15) not null,
sexo_funcionario varchar(10),
usuario varchar(20) not null,
senha varchar(15) not null,
nivel_login int);

CREATE TABLE Telefone(
cod_telefone int primary key auto_increment,
cod_funcionario int references Funcionario(cod_funcionario),
cod_cliente int references Cliente(cod_cliente),
numero_tel int not null,
numero_cel int not null);

create table login(
cpf_cliente varchar(15) null,
cod_funcionario int null ,
usuario varchar(20),
senha varchar(15),
nivel int,
foreign key (cod_funcionario) references funcionario(cod_funcionario),
foreign key (cpf_cliente) references cliente(cpf_cliente));

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

-- atualiza o status do veiculo
create trigger tr_atualizaveiculo before insert
on manutencao 
for each row
update veiculo set status_veiculo='Indisponivel' where cod_veiculo=new.cod_veiculo;

create trigger tr_atualizaveiculo2 before delete
on manutencao 
for each row
update veiculo set status_veiculo='Disponivel' where cod_veiculo=old.cod_veiculo;

insert into funcionario(cod_funcionario,nome_funcionario,data_nascimento,email_funcionario,cpf_funcionario,sexo_funcionario,usuario,senha,nivel_login) values (default,"JOAO VICTOR DE S OLIVEIRA","2001-03-02","jvoliveira@gmail.com","321.213.342-03","MASCULINO","admin","admin",3);

create view vwveiculo as 
select cod_veiculo,m.cod_marca,c.cod_categoria,nome_marca,placa_veiculo,chassi_veiculo,modelo_veiculo,status_veiculo,nome_categoria,imagem from veiculo as v
left join categoria as c on c.cod_categoria=v.cod_categoria
left join marca as m on m.cod_marca = v.cod_marca;

create view vwmanutencao as 
select cod_manutencao,v.cod_veiculo,descricao_manutencao,v.modelo_veiculo,v.placa_veiculo,v.chassi_veiculo from manutencao as m
left join veiculo as v on m.cod_veiculo=v.cod_veiculo;

select * FROM vwmanutencao;

SELECT * FROM Marca;

SELECT * FROM seguro;

SELECT * FROM Veiculo;

SELECT * FROM Manutencao;

SELECT * FROM Reserva;

SELECT * FROM Locacao;

SELECT * FROM Pagamento;

select * FROM funcionario;

SELECT * FROM Cliente;

SELECT * FROM Login;

SELECT * FROM Endereco;

SELECT * FROM Telefone;