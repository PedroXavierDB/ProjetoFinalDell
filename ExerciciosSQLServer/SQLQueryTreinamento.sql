/*
use PedroXavierDatabase;
create table Cliente(
	Id int IDENTITY(0,1) not null PRIMARY KEY,
	FirstName varchar(50) not null,
	LastName varchar(50) not null,
	Email varchar(50) not null,
	PhoneNumber varchar(50) not null,
	Birthdate varchar(50) not null
);

use PedroXavierDatabase;
create table Pedido(
	OrderId int IDENTITY(0,1) not null PRIMARY KEY,
	ProductName varchar(50) not null,
	Quantity int not null,
	ClienteId int FOREIGN KEY REFERENCES Cliente(Id)
);
*/

/*
INSERT INTO PedroXavierDatabase.dbo.Cliente
values ('batata', 'batata', 'batata', 'batata', 'batata');

INSERT INTO PedroXavierDatabase.dbo.Cliente
values ('Pedro', 'Xavier', 'pewx@hotmail.com', '5551995968401', '09/08/1999');

INSERT INTO PedroXavierDatabase.dbo.Cliente
values ('Bruno', 'Xavier', 'bruno@hotmail.com', '55519980013931', '16/11/2000');

INSERT INTO PedroXavierDatabase.dbo.Cliente
values ('Thais', 'Miller', 'thais@hotmail.com', '5551995867034', '01/06/1999');

INSERT INTO PedroXavierDatabase.dbo.Cliente
values ('Squall', 'Santoro', 'squall@hotmail.com', '5551985767584', '11/05/1986');
*/
/*
INSERT INTO PedroXavierDatabase.dbo.Cliente
values ('Pedro', 'Mariano', 'Mariano@hotmail.com', '5551995867789', '18/08/1998');

INSERT INTO PedroXavierDatabase.dbo.Pedido
values ('Cotonete', 10, 1);
*/

--SELECT * FROM PedroXavierDatabase.dbo.Cliente;
--SELECT * FROM PedroXavierDatabase.dbo.Pedido;
--DELETE FROM PedroXavierDatabase.dbo.Cliente WHERE Id=0;
--TRUNCATE TABLE PedroXavierDatabase.dbo.Cliente;
--SELECT Id,FirstName,LastName FROM PedroXavierDatabase.dbo.Cliente WHERE LastName LIKE 'Xa%';
--SELECT Id, CONCAT(FirstName, ' ',LastName) AS Nome FROM PedroXavierDatabase.dbo.Cliente WHERE LastName LIKE 'Xa%';
--SELECT COUNT(*) FROM PedroXavierDatabase.dbo.Cliente;
--SELECT COUNT(*) AS Contador,FirstName FROM PedroXavierDatabase.dbo.Cliente GROUP BY FirstName HAVING COUNT(*)>=2;
--SELECT DISTINCT FirstName FROM PedroXavierDatabase.dbo.Cliente;
--SELECT SUM(Id) FROM PedroXavierDatabase.dbo.Cliente;
--SELECT AVG(Id) FROM PedroXavierDatabase.dbo.Cliente;
--SELECT FirstName FROM PedroXavierDatabase.dbo.Cliente ORDER BY RAND() OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY;

--SELECT * FROM PedroXavierDatabase.dbo.Pedido AS p JOIN PedroXavierDatabase.dbo.Cliente AS c ON p.OrderId=c.Id;
/*
SELECT Cliente.FirstName, Pedido.ProductName, Pedido.Quantity 
FROM PedroXavierDatabase.dbo.Pedido, PedroXavierDatabase.dbo.Cliente
WHERE Cliente.Id=Pedido.OrderId AND Pedido.Quantity>=1;

SELECT * 
FROM PedroXavierDatabase.dbo.Pedido AS p
INNER JOIN PedroXavierDatabase.dbo.Cliente AS c
ON p.ClienteId=c.Id;

SELECT * 
FROM PedroXavierDatabase.dbo.Pedido AS p
Left JOIN PedroXavierDatabase.dbo.Cliente AS c
ON p.OrderId=c.Id;

SELECT * 
FROM PedroXavierDatabase.dbo.Pedido AS p
RIGHT JOIN PedroXavierDatabase.dbo.Cliente AS c
ON p.ClienteId=c.Id;

SELECT * 
FROM PedroXavierDatabase.dbo.Pedido AS p
FULL JOIN PedroXavierDatabase.dbo.Cliente AS c
ON p.ClienteId=c.Id;

SELECT * 
FROM PedroXavierDatabase.dbo.Pedido AS p
CROSS JOIN PedroXavierDatabase.dbo.Cliente AS c
ORDER BY 1;
*/
/*
DELETE Pedido
FROM PedroXavierDatabase.dbo.Pedido AS p
INNER JOIN PedroXavierDatabase.dbo.Cliente AS c
ON p.ClienteId=c.Id
WHERE p.Quantity=2;
*/