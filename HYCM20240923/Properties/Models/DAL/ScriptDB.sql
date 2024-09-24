--Crear la base de datos dbHYCM20240923
CREATE DATABASE dbHYCM20240923
GO

--Utilizar la base de datos CRMDB
USE dbHYCM20240923
GO 

---Crear la tabla Customers (anteriormente Clients)
CREATE TABLE  ProductsHYCM 
(
	 Id INT IDENTITY(1,1) PRIMARY KEY,
	 NombreHYCM VARCHAR(50) NOT NULL,
	 DescripcionHYCM VARCHAR(50) NOT NULL,
	 Precio DECIMAL (2,2)
)
GO