-- Item para a criação do banco de dados
create database if not exists db;
use db;


CREATE table Owner
(
	Id int(4) primary key NOT NULL auto_increment,
	Nome varchar(300) null	
);

create table Cats
(
	Id int(4) primary key NOT NULL auto_increment,
	Nome varchar(300) null,
	Age int(4) null,
	OwnerId int(4) not null
);

create table Dogs
(
	Id int(4) primary key NOT NULL auto_increment,
	Nome varchar(300) null,
	Age int(4) null,
	OwnerId int(4) not null
);

alter table Cats
add constraint fk_OwnerId
foreign key (OwnerId)
references Owner(Id);

alter table Dogs
add constraint fk_Dogs_OwnerId
foreign key (OwnerId)
references Owner(Id);

INSERT INTO Owner (Nome) VALUE
('Adam Smith'),
('Scott Johnson'),
('Kimberly Parker');

INSERT INTO Cats (Nome, Age, OwnerId) VALUE
('Lily',5,1),
('Chloe',2,3),
('Charlie',3,2);

INSERT INTO Dogs (Nome, Age, OwnerId) VALUE
('Maggie',1,2),
('Duke',7,1),
('Buddy',4, 2);


-- 3) Monte uma query que selecione apenas os nomes da tabela Cats que começem com 'c', e os nomes da tabela Dogs que terminem com 'e'.
SELECT nome as result
FROM cats
UNION ALL
SELECT nome
FROM dogs

-- 4) Selecione o registro na tabela Dogs com menor Age 

SELECT *
FROM dogs
ORDER BY Age
LIMIT 1

-- 5) Selecione a soma da coluna Age da tabela Cats

SELECT SUM(Age)
FROM cats

-- 6) Selecione os nomes dos Owner e seus respectivos Cats

SELECT owner.Id, owner.Nome, cats.OwnerId, cats.Nome
FROM owner, cats
WHERE owner.Id = cats.OwnerId

-- 7) Selecione os registros da tabela Dogs com maior Age separados por OwnerId

SELECT OwnerId, Id, OwnerId, Nome, OwnerId, Age, OwnerId
FROM dogs  
ORDER BY Age  DESC
LIMIT 1

-- 8) Retorne o nome do Owner e a respectiva quantidade de animais total

SELECT o.Nome, (COUNT(c.Nome) + COUNT(d.Nome))
FROM owner AS o 
LEFT JOIN  cats AS c on o.Id = c.OwnerId
LEFT JOIN dogs AS d on o.Id = d.OwnerId
GROUP BY o.Nome