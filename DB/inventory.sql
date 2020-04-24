CREATE DATABASE INVENTORY;
USE INVENTORY;

--Crear tabla administrador...

CREATE TABLE ADMINISTRADOR(
ID_ADMON INT PRIMARY KEY IDENTITY(1,1),
NOMBRE_ADMON VARCHAR(30),
APELLIDO_ADMON VARCHAR(30),
TELEFONO VARCHAR (30),
DIRECCION VARCHAR (30),
NICK_NAME VARCHAR(30),
PASSWORD_ADMON VARCHAR(30)
);

CREATE TABLE CATEGORIA(
ID_CATEGORIA INT PRIMARY KEY IDENTITY(1,1),
NOMBRE_CATEGORIA VARCHAR (30)
);

CREATE TABLE PRODUCTO(
ID_PRODUCTO INT PRIMARY KEY IDENTITY(1,1),
CODIGO_PRODUCTO VARCHAR (30),
NOMBRE_PRODUCTO VARCHAR (30),
DESCRIPCION VARCHAR (50),
IMAGEN_PROD VARCHAR(100),
CANTIDAD_PRODUCTO  INT,
PRECIO_UNIDAD DECIMAL (5,1),
ID_CATEGORIA INT,
FOREIGN KEY (ID_CATEGORIA) REFERENCES CATEGORIA (ID_CATEGORIA)
);

CREATE TABLE F_VENTA(
ID_F_VENTA INT PRIMARY KEY IDENTITY(200,1),
DOCUMENTO_C VARCHAR(30),
NOMBRE_C VARCHAR(30),
APELLIDO_C VARCHAR(30),
TELEFONO_C VARCHAR(30),
FECHA VARCHAR(50),
ID_PRODUCTO INT,
CANTIDAD INT,
PRECIO DECIMAL (10,2),
SUBTOTAL DECIMAL (10,2),
TOTAL DECIMAL (10,2),
FOREIGN KEY (ID_PRODUCTO) REFERENCES PRODUCTO (ID_PRODUCTO)
);
truncate table f_venta;
SELECT * FROM PRODUCTO;
select * from AspNetUsers
select * from F_VENTA
select * from CATEGORIA
----------------------------------------------------

INSERT INTO F_VENTA VALUES('213133','MARIANO','GONZALES','2093311','03/04/2020',1,3,8000,9000, 8600);
INSERT INTO ADMINISTRADOR VALUES('Arcangel', 'Cataño', '299 11 93', 'calle 21h 41d - 14', 'arca01', '1234');
INSERT INTO CATEGORIA VALUES('Tecnologia');
INSERT INTO PRODUCTO VALUES('2192', 'Carne de cerdo', 'Carne de cerdo', null, 10, 9000, 1);
GO

-- procedure para productos
CREATE PROCEDURE spProducts
AS 
BEGIN 
	SELECT P.ID_PRODUCTO, P.CODIGO_PRODUCTO, P.NOMBRE_PRODUCTO, P.DESCRIPCION, P.IMAGEN_PROD,
		   P.CANTIDAD_PRODUCTO, P.PRECIO_UNIDAD, C.NOMBRE_CATEGORIA from PRODUCTO P 
		   INNER JOIN CATEGORIA C ON P.ID_CATEGORIA = C.ID_CATEGORIA
END

/*---INSERT DATOS A CLIENTES----------
INSERT INTO CLIENTE (ID_CLIENTE,NOMBRE_CLIENTE,TELEFONO,DIRECCION,CORREO_CLIENTE,CLAVE_CLIENTE) VALUES 
(1,'YEFERSON',3023432657,'CLL25CN345','yeyecorrea838@gmail.com',12345),
(2,'JORGE',3435768978,'CLL24AN45','jorge@gmail,com',12323543),
(3,'SERGIO',32054333200,'CLL13BN34','sergio@gmail.com',234564);

------------------------------------

---INSERT DATOS A F_VENTA-----------
INSERT INTO F_VENTA (ID_F_VENTA,FECHA,NOMBRE_C,DOCUMENTO_C,TELEFONO_C,CANTIDAD,PRECIO,SUBTOTAL,ID_CLIENTE) VALUES 
(01,17/04/19,'YEFERSON',1020492202,3023432657,200,NULL,NULL,1),
(02,19/03/19,'SERGIO',1020492343,3023432967,20,NULL,NULL,2),
(03,1/04/19,'JORGE',0020493402,4023437857,100,NULL,NULL,3);

-------------------------------------

---INSERT DATOS A PRODUCTO-----------
INSERT INTO PRODUCTO (ID_PRODUCTO,NOMBRE_PRODUCTO,CODIGO_PRODUCTO,DESCRIPCION,EXISTENCIA_PROUCD,MARCA_PRODUCTO,CANTIDAD_PRODUCTO,CANTIDAD_PRODUCTO,
PRECIO_UNIDAD,PRECIO,ID_CATEGORIA,ID_F_VENTA,ID_MARCA)
VALUES (1,NULL,1,NULL,NULL,NULL,NULL,NULL,NULL ,NULL ,NULL ,1 ,1 ,1 ),
(2,NULL,2,NULL,NULL,NULL,NULL,NULL,NULL ,NULL ,NULL ,2 ,2 ,2 ),
(3,NULL,3,NULL,NULL,NULL,NULL,NULL,NULL ,NULL ,NULL ,3 ,3 ,3);
------------------------------------

---INSERT DATOS A CATEGORIA---------
INSERT INTO CATEGORIA(ID_CATEGORIA,NOMBRE_CATEGORIA) VALUES 
(1,NULL),
(2,NULL),
(3,NULL);

--------------------------------------

---INSERT DATOS A MARCA-------------
INSERT INTO MARCA (ID_MARCA,NOMBRE_MARCA) VALUES
(1,NULL),
(2,NULL),
(3,NULL);

----------CLIENTES------------------------

*/
-------INSERTAR CLIENTE---------------

CREATE PROCEDURE SPinsercion_cliente
@id_cliente INT,
@nombre_cliente VARCHAR(30),
@correo_cliente VARCHAR(30),
@clave_cliente VARCHAR(30),

@telefono VARCHAR(30),
@direccion VARCHAR(30)

AS 
BEGIN
IF NOT EXISTS (  SELECT ID_CLIENTE FROM CLIENTE WHERE ID_CLIENTE = @id_cliente)
INSERT INTO CLIENTE (ID_CLIENTE,NOMBRE_CLIENTE,TELEFONO,DIRECCION,CORREO_CLIENTE,CLAVE_CLIENTE) VALUES
(@id_cliente,@nombre_cliente,@correo_cliente,@clave_cliente,@telefono,@direccion)

ELSE 

UPDATE CLIENTE SET 
NOMBRE_CLIENTE = @nombre_cliente,
CORREO_CLIENTE = @clave_cliente,
CLAVE_CLIENTE = @clave_cliente,
TELEFONO = @telefono,
DIRECCION = @direccion
WHERE ID_CLIENTE = @id_cliente

END
GO

/*EXEC SPinsercion_cliente '4','carlos','3204540404','cll38#456','carlos@gmail.com','32949433'*/
/*SELECT * FROM CLIENTE*/

--------ACTUALIZAR CLIENTE--------------------

CREATE PROCEDURE SPactualizar_cliente
@id_cliente INT,
@nombre_cliente VARCHAR(30),
@correo_cliente VARCHAR(30),
@clave_cliente VARCHAR(30),
@telefono VARCHAR(30),
@direccion VARCHAR(30)

AS 
BEGIN

UPDATE CLIENTE SET 
NOMBRE_CLIENTE = @nombre_cliente,
CORREO_CLIENTE = @clave_cliente,
CLAVE_CLIENTE = @clave_cliente,
TELEFONO = @telefono,
DIRECCION = @direccion
WHERE ID_CLIENTE = @id_cliente

END
GO

/*EXEC SPactualizar_cliente '4','CARLOS','carlos123@gmail.com','30243','23432323432','cll234fd4'
SELECT * FROM CLIENTE*/

----------ELIMINAR CLIENTE------------------
CREATE PROCEDURE SPeliminar_cliente
@id_cliente INT

AS 
BEGIN

DELETE FROM CLIENTE WHERE ID_CLIENTE = @id_cliente

 
END
GO

/*EXEC SPeliminar_cliente '4'*/
/*SELECT * FROM CLIENTE*/

////////////////////////////////////////////////////////////////////////////////////////////////////

--------PRODUCTO----------------------

-----INSERTAR PRODUCTO--------------

CREATE PROCEDURE SPinsertar_producto
@id_producto INT,
@nombre_producto VARCHAR(30),
@codigo_producto VARCHAR(30),
@descripcion VARCHAR(30),
@existencia_produc VARCHAR(30),
@marca_producto VARCHAR (30),
@categoria_producto VARCHAR (30),
@precio_unidad DECIMAL(5,1),
@precio DECIMAL(5,1)


AS
BEGIN
IF NOT EXISTS (  SELECT ID_PRODUCTO FROM PRODUCTO WHERE ID_PRODUCTO = @id_producto)
INSERT INTO PRODUCTO (ID_PRODUCTO,NOMBRE_PRODUCTO,CODIGO_PRODUCTO,DESCRIPCION,EXISTENCIA_PROUCD,MARCA_PRODUCTO,CATEGORIA_PRODUCTO ,PRECIO_UNIDAD,PRECIO) VALUES
(@id_producto,@nombre_producto,@codigo_producto,@descripcion,@existencia_produc,@marca_producto,@categoria_producto,@precio_unidad,@precio)

ELSE 

UPDATE PRODUCTO SET 
NOMBRE_PRODUCTO = @nombre_producto,
CODIGO_PRODUCTO = @codigo_producto,
DESCRIPCION = @descripcion,
EXISTENCIA_PROUCD = @existencia_produc,
MARCA_PRODUCTO = @marca_producto,
CATEGORIA_PRODUCTO = @categoria_producto,	
PRECIO_UNIDAD = @precio_unidad,
PRECIO = @precio
WHERE ID_PRODUCTO = @id_producto 

END
GO


/*EXEC SPinsertar_producto '1','jabon','02','si','NO','si','ariel','4.5544','4.545544'*/
/*SELECT * FROM PRODUCTO*/

------------ELIMINAR PRODUCTO------------------

CREATE PROCEDURE SPeliminar_producto
@id_produc VARCHAR(30)
AS
BEGIN

DELETE FROM PRODUCTO WHERE ID_PRODUCTO = @id_produc

END
GO


/*EXEC SPeliminar_producto '1' */
/*SELECT * FROM PRODUCTO*/



--------------ACTUALIZAR PRODUCTO---------------
CREATE PROCEDURE SPactualizar_producto
@id_producto INT,
@nombre_producto VARCHAR(30),
@codigo_producto VARCHAR(30),
@descripcion VARCHAR(30),
@existencia_produc VARCHAR(30),
@marca_producto VARCHAR (30),
@categoria_producto VARCHAR (30),
@precio_unidad DECIMAL(5,1),
@precio DECIMAL(5,1)


AS
BEGIN

UPDATE PRODUCTO SET 
NOMBRE_PRODUCTO = @nombre_producto,
CODIGO_PRODUCTO = @codigo_producto,
DESCRIPCION = @descripcion,
EXISTENCIA_PROUCD = @existencia_produc,
MARCA_PRODUCTO = @marca_producto,
CATEGORIA_PRODUCTO = @categoria_producto,	
PRECIO_UNIDAD = @precio_unidad,
PRECIO = @precio
WHERE ID_PRODUCTO = @id_producto 

END
GO
/*EXEC SPinsertar_producto '1','jabon','03','si','jdjffjfjfjf','si','ariel','4.5544','4.545544'*/
/*SELECT * FROM PRODUCTO*/

////////////////////////////////////////////////////////////////////////////////////////////////
---------PROVEDOR---------------------

--------------INSERTAR MARCA-------

CREATE PROCEDURE SPinsertar_marca
@id_marca INT,
@nombre_marca VARCHAR (30) 

AS
BEGIN
IF NOT EXISTS (  SELECT ID_MARCA FROM MARCA WHERE ID_MARCA = @id_marca)
INSERT INTO MARCA(ID_MARCA,NOMBRE_MARCA) VALUES
(@id_marca,@nombre_marca)

ELSE

UPDATE MARCA SET 
NOMBRE_MARCA = @nombre_marca
WHERE ID_MARCA = @id_marca

END
GO

/*EXEC SPinsertar_marca '1','JABONES'*/
/*SELECT * FROM MARCA*/

------ACTUALIZAR PROVEEDOR------------
CREATE PROCEDURE SPactualizar_marca
@id_marca INT,
@nombre_marca VARCHAR (30) 


AS
BEGIN

  UPDATE MARCA SET 
NOMBRE_MARCA = @nombre_marca
WHERE ID_MARCA = @id_marca

END
GO

/*EXEC SPactualizar_marca '1','ariel'*/
/*SELECT * FROM MARCA*/
-----ELIMINAR PREVEEDOR----------------
CREATE PROCEDURE SPeliminar_marca
@id_marca INT
AS
BEGIN

DELETE FROM MARCA WHERE ID_MARCA = @id_marca

END
GO


/*EXEC SPeliminar_marca '1'*/
/*SELECT * FROM MARCA*/
--------------FACTURA--------------

---------INSERTAR FACTURA---------

CREATE PROCEDURE SPinsertar_factura
@id_f_venta INT,
@nombre_c VARCHAR (30),
@documento VARCHAR (30),
@telefono VARCHAR (30),
@cantidad INT,
@precio DECIMAL(6,2),
@subtotal DECIMAL(6,2),
@id_cliente INT


AS
BEGIN
IF NOT EXISTS (SELECT ID_F_VENTA FROM F_VENTA WHERE ID_F_VENTA = @id_f_venta)
INSERT INTO F_VENTA (ID_F_VENTA,NOMBRE_C,DOCUMENTO_C,TELEFONO_C,CANTIDAD,PRECIO,SUBTOTAL,ID_CLIENTE) VALUES
(@id_f_venta,@nombre_c,@documento,@telefono,@cantidad,@precio,@subtotal,@id_cliente)

ELSE

UPDATE F_VENTA SET 
NOMBRE_C = @nombre_c,
DOCUMENTO_C = @documento,
TELEFONO_C = @telefono,
CANTIDAD = @cantidad,
PRECIO = @cantidad,
SUBTOTAL = @subtotal
WHERE  ID_F_VENTA = @id_f_venta

END
GO

/*EXEC SPinsertar_factura '1','yeferson','122332332','2323323','234','3.445','4444.555','1'*/
/*SELECT * FROM F_VENTA*/


-----ACTUALIZAR FACTURA--------------------
CREATE PROCEDURE SPactualizar_factura
@id_f_venta INT,
@nombre_c VARCHAR (30),
@documento VARCHAR (30),
@telefono VARCHAR (30),
@cantidad INT,
@precio DECIMAL(6,2),
@subtotal DECIMAL(6,2),
@id_cliente INT

AS
BEGIN

UPDATE F_VENTA SET 
NOMBRE_C = @nombre_c,
DOCUMENTO_C = @documento,
TELEFONO_C = @telefono,
CANTIDAD = @cantidad,
PRECIO = @cantidad,
SUBTOTAL = @subtotal
WHERE  ID_F_VENTA = @id_f_venta

END
GO

/*EXEC SPactualizar_factura '1','YEFERSON','122332332','2323323','234','3.445','4444.555','1'*/
/*SELECT * FROM F_VENTA*/


------ELIMINAR FACTURA------------------
CREATE PROCEDURE SPeliminar_factura
@id_f_venta INT
AS
BEGIN
DELETE FROM F_VENTA WHERE ID_F_VENTA = @id_f_venta 

END
GO

/*EXEC SPeliminar_factura '1'*/
/*SELECT * FROM F_VENTA*/

-- Trigger --
select * from f_venta;
select * from producto;

CREATE TRIGGER trgActualizarProductos
ON F_VENTA FOR INSERT 
AS BEGIN 
DECLARE @ID_PRODUCTO AS INT 
DECLARE @CANTIDAD AS INT

SET @ID_PRODUCTO = (SELECT ID_PRODUCTO FROM INSERTED)
SET @CANTIDAD = (SELECT CANTIDAD FROM INSERTED)

UPDATE PRODUCTO
SET CANTIDAD_PRODUCTO = CANTIDAD_PRODUCTO - @CANTIDAD
WHERE ID_PRODUCTO LIKE @ID_PRODUCTO

END

INSERT INTO F_VENTA VALUES()