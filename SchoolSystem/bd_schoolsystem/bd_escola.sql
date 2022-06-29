create database bd_escola;
use bd_escola;

#Aluna: Samuel Felipe Cardoso Leite 3º A INF

create table Escola(
id_esc int primary key auto_increment,
nome_fantasia_esc varchar(250) not null,
razao_social_esc varchar(250) not null,
cnpj_esc varchar(30) not null,
insc_estadual_esc varchar(200) not null,
tipo_esc varchar(50) not null, 
data_criacao_esc date not null,
responsavel_esc varchar(200) not null, 
responsavel_telefone_esc varchar(50) not null, 
email_esc varchar(200) not null,
telefone_esc varchar(50) not null,
rua_esc varchar(200) not null,
numero_esc varchar(50) not null,
bairro_esc varchar(200) not null,
complemento_esc varchar(100) not null,
cep_esc varchar(200) not null,
cidade_esc varchar(200) not null,
estado_esc varchar(200) not null
);

insert into escola values (null, 'Joaquim de Lima Avelino', 'Joaquim Avelino de Lima Filho', '11.222.333/0001-02', '1980101022009-0', 'Público', '1980-02-10', 'Samuel', '69 99234-5678', 'samito@gmail.com', '69 99323-4252', 'Juscelino Kubitscheck', '125', 'Jardim Tropical', 'escola', '76920-000', 'Ouro Preto do Oeste', 'Rondônia');

create table Curso(
id_cur int primary key auto_increment,
nome_cur varchar(200) not null,
carga_horaria_cur int not null,
turno_cur varchar(50) not null,
descricao_cur varchar(100)
);

insert into curso values(null, 'Teatro', 250, 'Matutino', null);
