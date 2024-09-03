create database cadastroprofessor;
use cadastroprofessor;

create table professor
(
 id_professor int primary key auto_increment,
 nome varchar(50),
 Cpf varchar(14),
 Email varchar(50),
 telefone varchar(20),
 dataNascimento date,
 sexo varchar(10),
 formacao varchar(50)
);
select * from professor;
