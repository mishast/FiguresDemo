--Sql Server 2014 Express Edition
--Batches are separated by 'go'

select @@version as 'sql server version'
go

CREATE TABLE Products(Id INT IDENTITY(1,1) PRIMARY KEY, Name TEXT);
CREATE TABLE Categories(Id INT IDENTITY(1,1) PRIMARY KEY, Name TEXT);
CREATE TABLE ProductCategories(ProductId INT, CategoryId INT);
go

INSERT INTO Products(Name) VALUES ('Car');
INSERT INTO Products(Name) VALUES ('Computer');
INSERT INTO Products(Name) VALUES ('Microwave');
INSERT INTO Products(Name) VALUES ('Blender');
INSERT INTO Categories(Name) VALUES ('Electronic devices');
INSERT INTO Categories(Name) VALUES ('Kitchen');
INSERT INTO Categories(Name) VALUES ('Home');
INSERT INTO Products(Name) VALUES ('Washmachine');

SELECT * FROM Products;

SELECT * FROM Categories;


INSERT INTO ProductCategories VALUES(2,1);
INSERT INTO ProductCategories VALUES(3,1);
INSERT INTO ProductCategories VALUES(3,2);
INSERT INTO ProductCategories VALUES(3,3);
INSERT INTO ProductCategories VALUES(4,1);
INSERT INTO ProductCategories VALUES(4,2);
INSERT INTO ProductCategories VALUES(4,3);
INSERT INTO ProductCategories VALUES(5,1);
INSERT INTO ProductCategories VALUES(5,3);

SELECT p.Id as ProductId, p.Name as ProductName, c.Id as CategoryId, c.Name as CategoryName FROM Products p LEFT JOIN ProductCategories pc ON p.Id=pc.ProductId LEFT JOIN Categories c ON pc.CategoryId=c.Id;

go

-------------------------------------------------------------------------------------------------------------

sql server version
---------------------------------------------------------------------------
Microsoft SQL Server 2014 - 12.0.2000.8 (Intel X86) 
Feb 20 2014 19:20:46 
Copyright (c) Microsoft Corporation
Express Edition on Windows NT 6.3 <X64> (Build 9600: ) (WOW64) (Hypervisor)

Id | Name
---+------------
1  | Car
2  | Computer
3  | Microwave
4  | Blender
5  | Washmachine

Id  | Name
----+-------------------
1   | Electronic devices
2   | Kitchen
3   | Home

ProductId | ProductName | CategoryId | CategoryName
----------+-------------+------------+-------------------
1         | Car	        | NULL       | NULL
2         | Computer    | 1          | Electronic devices
3         | Microwave   | 1          | Electronic devices
3         | Microwave   | 2          | Kitchen
3         | Microwave   | 3          | Home
4         | Blender     | 1          | Electronic devices
4         | Blender     | 2          | Kitchen
4         | Blender     | 3          | Home
5         | Washmachine | 1          | Electronic devices
5         | Washmachine | 3          | Home
