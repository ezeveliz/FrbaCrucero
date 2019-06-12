USE GD1C2019;
GO

/* --------------------------------------------
	   Eliminacion de objetos prexistentes 
----------------------------------------------- */

IF OBJECT_ID('CONCORDIA.compra_cabina','U') IS NOT NULL
    DROP TABLE CONCORDIA.compra_cabina;

IF OBJECT_ID('CONCORDIA.recorrido_tramo','U') IS NOT NULL
    DROP TABLE CONCORDIA.recorrido_tramo;

IF OBJECT_ID('CONCORDIA.roles_funcionalidad','U') IS NOT NULL
    DROP TABLE CONCORDIA.roles_funcionalidad;

IF OBJECT_ID('CONCORDIA.cancelacion','U') IS NOT NULL
    DROP TABLE CONCORDIA.cancelacion;

IF OBJECT_ID('CONCORDIA.crucero_fuera_servicio','U') IS NOT NULL
    DROP TABLE CONCORDIA.crucero_fuera_servicio;

IF OBJECT_ID('CONCORDIA.crucero_fin_vida_util','U') IS NOT NULL
    DROP TABLE CONCORDIA.crucero_fin_vida_util;

IF OBJECT_ID('CONCORDIA.reserva','U') IS NOT NULL
    DROP TABLE CONCORDIA.reserva;

IF OBJECT_ID('CONCORDIA.pasaje','U') IS NOT NULL
    DROP TABLE CONCORDIA.pasaje;

IF OBJECT_ID('CONCORDIA.viaje','U') IS NOT NULL
    DROP TABLE CONCORDIA.viaje;

IF OBJECT_ID('CONCORDIA.medio_pago','U') IS NOT NULL
    DROP TABLE CONCORDIA.medio_pago;

IF OBJECT_ID('CONCORDIA.recorrido','U') IS NOT NULL
    DROP TABLE CONCORDIA.recorrido;

IF OBJECT_ID('CONCORDIA.tramo','U') IS NOT NULL
    DROP TABLE CONCORDIA.tramo;

IF OBJECT_ID('CONCORDIA.puerto','U') IS NOT NULL
    DROP TABLE CONCORDIA.puerto;

IF OBJECT_ID('CONCORDIA.cabina','U') IS NOT NULL
    DROP TABLE CONCORDIA.cabina;

IF OBJECT_ID('CONCORDIA.crucero','U') IS NOT NULL
    DROP TABLE CONCORDIA.crucero; 

IF OBJECT_ID('CONCORDIA.fabricante','U') IS NOT NULL
    DROP TABLE CONCORDIA.fabricante;

IF OBJECT_ID('CONCORDIA.usuario','U') IS NOT NULL
    DROP TABLE CONCORDIA.usuario;

IF OBJECT_ID('CONCORDIA.roles','U') IS NOT NULL
    DROP TABLE CONCORDIA.roles;

IF OBJECT_ID('CONCORDIA.funcionalidad','U') IS NOT NULL
    DROP TABLE CONCORDIA.funcionalidad;

IF OBJECT_ID('CONCORDIA.tipo_cabina','U') IS NOT NULL
    DROP TABLE CONCORDIA.tipo_cabina;


IF OBJECT_ID('CONCORDIA.Login_procedure') IS NOT NULL
    DROP PROCEDURE CONCORDIA.Login_procedure

IF OBJECT_ID('CONCORDIA.GetFuncionalidadesUsuario') IS NOT NULL
	DROP PROCEDURE CONCORDIA.getFuncionalidadesUsuario

IF OBJECT_ID('CONCORDIA.GetFuncionalidadesCliente') IS NOT NULL
	DROP PROCEDURE CONCORDIA.GetFuncionalidadesCliente

IF EXISTS (SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'CONCORDIA')
    DROP SCHEMA CONCORDIA
GO

GO
/* --------------------------------------------
				Creacion del esquema 
----------------------------------------------- */

CREATE SCHEMA CONCORDIA AUTHORIZATION gdCruceros2019;
GO


/* --------------------------------------------
				Creacion de las tablas
----------------------------------------------- */

CREATE TABLE CONCORDIA.funcionalidad(
func_id SMALLINT primary key identity(1,1),/* identity es el autoincremental */
func_descripcion varchar(50))

CREATE TABLE CONCORDIA.roles(
rol_id SMALLINT primary key identity(1,1),
rol_descripcion varchar(50),
rol_inhabilitado TINYINT DEFAULT 0)

CREATE TABLE CONCORDIA.roles_funcionalidad(
rol_id SMALLINT REFERENCES  CONCORDIA.roles,
func_id SMALLINT REFERENCES CONCORDIA.funcionalidad,
PRIMARY KEY(rol_id,func_id))

CREATE TABLE CONCORDIA.usuario(
usua_id int PRIMARY KEY identity(1,1),
usua_dni DECIMAL(8,0),
usua_nombre varchar(50),
usua_apellido varchar(50),
usua_email varchar(50),
usua_fecha_nac DATETIME,
rol_id SMALLINT REFERENCES CONCORDIA.roles,
usua_direccion varchar(255),
usua_telefono DECIMAL(15,0),
usua_username varchar(40) DEFAULT NULL,
usua_password VARBINARY(225) DEFAULT NULL,
usua_intentos TINYINT DEFAULT 3,
usua_inhabilitado TINYINT DEFAULT 0,
)

CREATE TABLE CONCORDIA.puerto(
puer_id SMALLINT PRIMARY KEY IDENTITY(1,1),
puer_ciudad varchar(50))

CREATE TABLE CONCORDIA.tramo(
tram_id SMALLINT PRIMARY KEY IDENTITY(1,1),
puer_id_inicio SMALLINT not null REFERENCES CONCORDIA.puerto,
puer_id_fin SMALLINT not null REFERENCES CONCORDIA.puerto,
tram_precio SMALLINT)

CREATE TABLE CONCORDIA.recorrido(
reco_id INT PRIMARY KEY IDENTITY(1,1),
reco_codViejo INT DEFAULT NULL,
reco_inhabilitado tinyint DEFAULT 0)

CREATE TABLE CONCORDIA.recorrido_tramo(
reco_id INT REFERENCES CONCORDIA.recorrido,
tram_id SMALLINT REFERENCES CONCORDIA.tramo,
PRIMARY KEY (reco_id,tram_id))

CREATE TABLE CONCORDIA.fabricante(
fabr_id SMALLINT PRIMARY KEY IDENTITY(1,1),
fabr_nombre varchar(50))

CREATE TABLE CONCORDIA.crucero(
cruc_id SMALLINT PRIMARY KEY IDENTITY(1,1),
cruc_identificador varchar(15),
cruc_modelo varchar(50),
fabr_id SMALLINT REFERENCES CONCORDIA.fabricante,
cruc_fecha_alta DATE DEFAULT GETDATE(),
cruc_inhabilitado tinyint DEFAULT 0)

CREATE TABLE CONCORDIA.crucero_fuera_servicio(
cfs_id smallint PRIMARY KEY IDENTITY(1,1),
cruc_id SMALLINT REFERENCES CONCORDIA.crucero,
cfs_motivo varchar(50),
cfs_fecha_baja DATETIME,
cfs_fecha_alta DATETIME)
 
CREATE TABLE CONCORDIA.crucero_fin_vida_util(
cfvu_id smallint PRIMARY KEY IDENTITY(1,1),
cruc_id SMALLINT REFERENCES CONCORDIA.crucero,
cfvu_motivo varchar(50),
cfvu_fecha_baja DATETIME,
cfvu_fecha_alta DATETIME)

CREATE TABLE CONCORDIA.tipo_cabina(
tipo_cabi_id SMALLINT PRIMARY KEY IDENTITY(1,1),
tipo_cabi_recargo DECIMAL(4,2) not null,
tipo_cabi_descripcion varchar(50))

CREATE TABLE CONCORDIA.cabina(
cabi_id int PRIMARY KEY IDENTITY(1,1),
cruc_id SMALLINT REFERENCES CONCORDIA.crucero,
tipo_cabi_id SMALLINT REFERENCES CONCORDIA.tipo_cabina,
cabi_estado TINYINT DEFAULT 0,
cabi_piso decimal(2,0),
cabi_nro decimal(3,0))

CREATE TABLE CONCORDIA.viaje(
viaj_id SMALLINT PRIMARY KEY IDENTITY(1,1),
viaj_codViejo INT DEFAULT NULL,
viaj_salida DATETIME NOT NULL,
viaj_llegada DATETIME,
viaj_llegada_estimada DATETIME NOT NULL,
cruc_id SMALLINT REFERENCES CONCORDIA.crucero,
reco_id INT REFERENCES CONCORDIA.recorrido)

CREATE TABLE CONCORDIA.reserva(
rese_id INT PRIMARY KEY IDENTITY(1,1),
rese_codViejo INT DEFAULT NULL,
viaj_id SMALLINT REFERENCES CONCORDIA.viaje NOT NULL,
usua_id INT REFERENCES CONCORDIA.usuario NOT NULL,
cabi_id INT REFERENCES CONCORDIA.cabina NOT NULL,
rese_cant_pasajeros DECIMAL(2,0) NOT NULL,
rese_creacion DATETIME DEFAULT GETDATE())

CREATE TABLE CONCORDIA.medio_pago(
medi_pago_id SMALLINT PRIMARY KEY IDENTITY(1,1),
medi_pago_tipo varchar(50) NOT NULL)

CREATE TABLE CONCORDIA.pasaje(
pasa_id INT PRIMARY KEY IDENTITY(1,1),
pasa_codviejo INT DEFAULT NULL,
viaj_id SMALLINT REFERENCES CONCORDIA.viaje NOT NULL,
usua_id INT REFERENCES CONCORDIA.usuario NOT NULL,
pasa_cant_pasajeros DECIMAL(2,0) NOT NULL,
pasa_fecha_compra DATETIME NOT NULL DEFAULT GETDATE(),
medi_pago_id SMALLINT NOT NULL REFERENCES CONCORDIA.medio_pago,
cabi_id INT REFERENCES CONCORDIA.cabina,
pasa_cod_tajeta DECIMAL(10),
pasa_precio SMALLINT NOT NULL,
pasa_cancelado TINYINT DEFAULT 0)

CREATE TABLE CONCORDIA.cancelacion(
canc_id SMALLINT PRIMARY KEY IDENTITY(1,1),
pasa_id INT REFERENCES CONCORDIA.pasaje,
canc_descripcion varchar(50))

CREATE TABLE CONCORDIA.compra_cabina(
pasaje_id  iNT REFERENCES CONCORDIA.pasaje,
cabina_id INT REFERENCES CONCORDIA.cabina,
PRIMARY KEY( pasaje_id, cabina_id))

use GD1C2019;
GO

/* --------------------------------------------
  Migracion de tabla maestra a nuestas tablas 				
----------------------------------------------- */
	
/* Ingreso los roles en la tabla roles */
INSERT INTO CONCORDIA.roles (rol_descripcion)
	VALUES ('Administrativo'),
		   ('Cliente');

/* Ingresa las funcionalidades */
INSERT INTO CONCORDIA.funcionalidad(func_descripcion)
	VALUES ('ABMRol'),
		   ('ABMusuario'),
		   ('ABMPuerto'),
		   ('ABMrecorrido'),
		   ('ABMCrucero'),
		   ('CompraPasajes')

INSERT INTO CONCORDIA.roles_funcionalidad(rol_id,func_id)
	VALUES (1,1),
		   (1,2),
	       (1,3),
 	       (1,4),
	       (1,5),
		   (2,6)

/* Genero una contraseña para el usuario admin */
DECLARE @SHA2_25 VARBINARY(225)
SET @SHA2_25 = HASHBYTES('SHA2_256','w23e')

/* Ingreso el usuario admin */
INSERT INTO CONCORDIA.usuario (usua_dni, usua_nombre, usua_apellido, usua_email, usua_fecha_nac, rol_id, usua_direccion, usua_telefono, usua_username ,usua_password)
	VALUES (11111111,'ADMIN','','',CONVERT(DATETIME,'11-7-2010',102), 1, '', 153458912, 'admin', @SHA2_25);

/* Ingreso los medios de pago */	
INSERT INTO CONCORDIA.medio_pago
	VALUES ('Debito'),
		   ('Efectivo');

/* Ingreso los usuarios de la tabla maestra */
INSERT INTO CONCORDIA.usuario (rol_id, usua_dni, usua_nombre, usua_apellido, usua_email, usua_fecha_nac, usua_direccion, usua_telefono)
	SELECT  '2',M.CLI_DNI, M.CLI_NOMBRE, M.CLI_APELLIDO,  M.CLI_MAIL, M.CLI_FECHA_NAC, M.CLI_DIRECCION, M.CLI_TELEFONO
	from gd_esquema.Maestra M
	group by M.CLI_DNI, M.CLI_NOMBRE, M.CLI_APELLIDO,  M.CLI_MAIL, M.CLI_FECHA_NAC, M.CLI_DIRECCION, M.CLI_TELEFONO

/* Ingreso los datos en la tabla puertos */
INSERT INTO CONCORDIA.puerto(puer_ciudad)
	SELECT DISTINCT PUERTO_DESDE
	FROM gd_esquema.Maestra 	
	UNION
	SELECT DISTINCT PUERTO_HASTA
	FROM gd_esquema.Maestra 	

/* Ingreso los datos en la tabla recorridos */
INSERT INTO CONCORDIA.recorrido (reco_codViejo)
	SELECT DISTINCT M.RECORRIDO_CODIGO
	FROM gd_esquema.Maestra M

/* Ingreso los datos en la tabla tramos*/
INSERT INTO CONCORDIA.tramo (puer_id_inicio, puer_id_fin ,tram_precio)
	select DISTINCT pd.puer_id, ph.puer_id, RECORRIDO_PRECIO_BASE
	from gd_esquema.Maestra M, CONCORDIA.puerto ph, CONCORDIA.puerto pd
	where m.PUERTO_DESDE = pd.puer_ciudad and m.PUERTO_HASTA = ph.puer_ciudad

/* Ingreso los datos en la tabla fabricantes */
INSERT INTO CONCORDIA.fabricante(fabr_nombre)
	SELECT DISTINCT M.CRU_FABRICANTE
	FROM gd_esquema.Maestra M

/* Ingreso los datos en la tabla Crucero*/
INSERT INTO CONCORDIA.crucero ( cruc_identificador, cruc_modelo, fabr_id )
	SELECT DISTINCT M.CRUCERO_IDENTIFICADOR, M.CRUCERO_MODELO, F.fabr_id
	FROM gd_esquema.Maestra M, CONCORDIA.fabricante F
	WHERE F.fabr_nombre = M.CRU_FABRICANTE

/*Ingreso los datos en la tabla tipo_cabina*/
INSERT INTO CONCORDIA.tipo_cabina ( tipo_cabi_descripcion, tipo_cabi_recargo )
	SELECT DISTINCT M.CABINA_TIPO, M.CABINA_TIPO_PORC_RECARGO
	from gd_esquema.Maestra M

/* Ingreso los datos en la tabla cabina */
INSERT INTO CONCORDIA.cabina( cabi_nro, cabi_piso,  cruc_id, tipo_cabi_id)
	SELECT DISTINCT M.CABINA_NRO, M.CABINA_PISO, C.cruc_id, T.tipo_cabi_id
	FROM gd_esquema.Maestra M	
	JOIN CONCORDIA.tipo_cabina T ON M.CABINA_TIPO = T.tipo_cabi_descripcion
	JOIN CONCORDIA.crucero C ON C.cruc_identificador = M.CRUCERO_IDENTIFICADOR


/* CREO UNA TABLA TEMPORAL DONDE INCORPORO LOS ID DE PUERTOS RECORRIDOS Y CRUCEROS */
CREATE TABLE #TEMP1(
	TEMP_ID INT PRIMARY KEY IDENTITY(1,1),
	usua_id INT,
	fecha_salida datetime,
	fecha_llegada datetime,
	fecha_llegada_estimada datetime,
	pasaje_codigo INT,
	PASAJE_FECHA_COMPRA DATETIME,
	recorrido_id  SMALLINT,
	crucero_id SMALLINT,
	RESERVA_CODIGO INT,
	PASAJE_PRECIO INT,
	RESERV_FECHA DATETIME,
	cabina_nro smallint,
	cabina_piso smallint,
	puerto_desde smallint,
	puerto_hasta smallint
	 )

/* Ingreso los datos en la tabla temporal */
INSERT INTO #TEMP1( usua_id ,fecha_salida ,fecha_llegada, fecha_llegada_estimada, pasaje_codigo, PASAJE_FECHA_COMPRA, recorrido_id , crucero_id, RESERVA_CODIGO, RESERV_FECHA, PASAJE_PRECIO, cabina_nro, cabina_piso, puerto_desde, puerto_hasta)
	SELECT U.usua_id, M.FECHA_SALIDA, M.FECHA_LLEGADA, M.FECHA_LLEGADA_ESTIMADA, M.PASAJE_CODIGO, M.PASAJE_FECHA_COMPRA, R.reco_id, C.cruc_id, M.RESERVA_CODIGO, M.RESERVA_FECHA, M.PASAJE_PRECIO, M.CABINA_NRO, M.CABINA_PISO, D.puer_id, h.puer_id
	from gd_esquema.Maestra M
	join CONCORDIA.crucero C on M.CRUCERO_IDENTIFICADOR = C.cruc_identificador 
	join CONCORDIA.recorrido R on M.RECORRIDO_CODIGO = R.reco_codViejo
	join CONCORDIA.usuario U ON M.CLI_DNI = U.usua_dni AND M.CLI_APELLIDO = U.usua_apellido
	join CONCORDIA.puerto D ON PUERTO_DESDE = D.puer_ciudad
	join CONCORDIA.puerto H ON PUERTO_HASTA = H.puer_ciudad

/* Ingreso los datos en la tabla viajes */
INSERT INTO CONCORDIA.viaje(reco_id, viaj_salida, viaj_llegada, viaj_llegada_estimada, cruc_id)	
	select DISTINCT  M.recorrido_id, M.fecha_salida, M.fecha_llegada, M.fecha_llegada_estimada, M.crucero_id
	from #TEMP1 M

/* Ingreso los datos en la tabla recorridos_tramo */
INSERT INTO CONCORDIA.recorrido_tramo(reco_id, tram_id)
	SELECT DISTINCT M.recorrido_id, T.tram_id 
	FROM #TEMP1 M
	JOIN CONCORDIA.tramo T ON T.puer_id_inicio = M.puerto_desde AND T.puer_id_fin = M.puerto_hasta 

/* Ingreso los datos en la tabla pasajes */
INSERT INTO CONCORDIA.pasaje (pasa_codviejo, viaj_id, usua_id, pasa_cant_pasajeros, pasa_fecha_compra, medi_pago_id, pasa_precio, cabi_id )
	SELECT DISTINCT  M.PASAJE_CODIGO,V.viaj_id, M.usua_id, '1' , M.PASAJE_FECHA_COMPRA, '1', M.PASAJE_PRECIO, C.cabi_id 
	FROM #TEMP1 M
	JOIN CONCORDIA.cabina C ON M.cabina_nro = C.cabi_nro AND M.cabina_piso = C.cabi_piso AND M.crucero_id = C.cruc_id
	JOIN CONCORDIA.viaje v ON M.fecha_llegada  = V.viaj_llegada AND M.fecha_salida = V.viaj_salida AND M.recorrido_id = V.reco_id
	WHERE PASAJE_CODIGO IS NOT NULL 

/* Ingreso los datos en la tabla reserva */
INSERT INTO CONCORDIA.reserva( rese_codviejo, viaj_id , usua_id, rese_creacion, rese_cant_pasajeros, cabi_id )
	SELECT DISTINCT  M.RESERVA_CODIGO, V.viaj_id, M.usua_id, M.RESERV_FECHA, '1', C.cabi_id
	FROM #TEMP1 M
	JOIN CONCORDIA.cabina C ON M.cabina_nro = C.cabi_nro AND M.cabina_piso = C.cabi_piso AND M.crucero_id = C.cruc_id
	JOIN CONCORDIA.viaje v ON M.fecha_llegada  = V.viaj_llegada AND M.fecha_salida = V.viaj_salida AND M.recorrido_id = V.reco_id
	WHERE RESERVA_CODIGO IS NOT NULL 

    DROP TABLE #TEMP1;
go
/* --------------------------------------------
         Creacion de Store Procedues 				
----------------------------------------------- */

USE GD1C2019;
GO

CREATE PROCEDURE CONCORDIA.Login_procedure(@username VARCHAR(20) , @password VARCHAR(10))
AS
 BEGIN
	DECLARE @intentos TINYINT, @hash VARBINARY(225), @pass VARBINARY(225), @cantidad INT 
	
	SET @intentos = (SELECT usua_intentos FROM CONCORDIA.usuario WHERE usua_username = @username)
    SET @hash = HASHBYTES('SHA2_256',@password); --La que ingreso
	SET @pass = (SELECT usua_password FROM CONCORDIA.usuario WHERE usua_username = 'admin') -- La real

	IF(@intentos IS NULL) 	--me fijo si esta el usuario
		SET @cantidad = -1

		ELSE IF(@hash <> @pass)  --comparo las contrasenias
			BEGIN
				SET @cantidad = @intentos -1
				IF(@intentos<> 0)  --verifico la cantidad de ceros. si aun le quedan, hago el update
					UPDATE CONCORDIA.usuario SET usua_intentos = @intentos - 1 WHERE usua_username = @username
			END				
		ELSE IF (@intentos <> 0) 
			BEGIN
				SET @cantidad = 4   --Todo bien! Contrasenia correcta!
				UPDATE CONCORDIA.usuario SET usua_intentos = 3 WHERE usua_username = @username
			END 
	RETURN @cantidad
 END
GO

USE GD1C2019;
GO

CREATE PROCEDURE CONCORDIA.GetFuncionalidadesUsuario(@usua_id int)
AS
 BEGIN
	
	DECLARE @rolId BIGINT -- Lo que viene por parametro es el usua_username, necesito el id para comparar con RolXusuario
	
	SET @rolId = (SELECT rol_id FROM CONCORDIA.usuario WHERE usua_id = @usua_id)
 
	SELECT DISTINCT RF.func_id, F.func_descripcion
	FROM CONCORDIA.roles R, CONCORDIA.roles_funcionalidad RF
	join CONCORDIA.funcionalidad F on rf.func_id = F.func_id
	WHERE RF.rol_id=1 AND  R.rol_inhabilitado=0

 END
GO


USE GD1C2019;
GO

CREATE PROCEDURE CONCORDIA.GetFuncionalidadesCliente
AS
 BEGIN
	
	DECLARE @rolId BIGINT -- Lo que viene por parametro es el usua_username, necesito el id para comparar con RolXusuario
	
 
	SELECT DISTINCT RF.func_id, F.func_descripcion
	FROM CONCORDIA.roles R, CONCORDIA.roles_funcionalidad RF
	join CONCORDIA.funcionalidad F on rf.func_id = F.func_id
	WHERE RF.rol_id=2 AND  R.rol_inhabilitado=0

 END
GO
/********************* Alta Crucero **********************/

USE GD1C2019;
GO

CREATE PROCEDURE CONCORDIA.InsertCrucero (@identificador varchar(50), @modelo varchar(50), @fabricante_id int, @fecha_alta varchar(50))
AS 
 BEGIN
	DECLARE @RESULTADO int 
	DECLARE @cruceroExistente int
	SET @cruceroExistente = (SELECT cruc_id FROM CONCORDIA.crucero where cruc_identificador = @identificador) 
	IF(@cruceroExistente is null )
		BEGIN	
			INSERT INTO CONCORDIA.crucero(cruc_identificador, cruc_modelo, fabr_id, cruc_fecha_alta)
				VALUES (@identificador, @modelo, @fabricante_id, CONVERT(date,@fecha_alta))
			SET @RESULTADO = (SELECT cruc_id from CONCORDIA.crucero where cruc_identificador = @identificador)
		END
	ELSE 
		BEGIN
			SET @RESULTADO = -1
		END

	RETURN @RESULTADO
  END 
GO

USE GD1C2019;
GO

CREATE PROCEDURE CONCORDIA.InsertarCabina (@piso int, @nro int,@cruc_id int, @tipo_id SMALLINT )
AS
	BEGIN 
		
		INSERT INTO CONCORDIA.cabina(cabi_nro, cabi_piso, cruc_id, tipo_cabi_id)
			VALUES (@nro, @piso, @cruc_id, @tipo_id)

	END
GO

/************* Baja de cruceros *******************/

CREATE PROCEDURE CONCORDIA.RemplazarCruceroFVU(@identificador_crucero varchar(20))
AS 
	BEGIN 
		DECLARE @id_crucero int = (SELECT cruc_id FROM CONCORDIA.crucero WHERE cruc_identificador = @identificador_crucero)
		DECLARE @fechaHoy date = CONVERT (date, GETDATE())  

		SELECT P.viaj_id
		FROM CONCORDIA.pasaje p
		JOIN CONCORDIA.viaje V ON P.viaj_id = V.viaj_id
		WHERE  v.cruc_id = @id_crucero AND v.viaj_salida > @fechaHoy
		 
		
	END
GO

CREATE PROCEDURE CONCORDIA.DesplazamientoDePasajes(@cruc_id int, @cant_dias int , @fecha_hasta date)
AS
	BEGIN 

	UPDATE CONCORDIA.viaje SET viaj_llegada = DATEADD (day ,@cant_dias ,viaj_llegada ), 
							   viaj_salida = DATEADD (day , @cant_dias,viaj_salida ), 
							   viaj_llegada_estimada = DATEADD (day , @cant_dias,viaj_llegada_estimada )
		   where viaj_salida BETWEEN CONVERT (DATE,GETDATE()) AND  CONVERT(DATE,@fecha_hasta) AND cruc_id = @cruc_id

	END
GO

CREATE PROCEDURE CONCORDIA.CancelacionDePasajes (@cruc_id int, @motivo varchar(50),@fecha_desde date)
AS	
	BEGIN 

		UPDATE pasaje SET pasa_cancelado = '1' 
		FROM CONCORDIA.pasaje P
		JOIN CONCORDIA.viaje V ON P.viaj_id = V.viaj_id
		WHERE V.viaj_salida > @fecha_desde AND V.cruc_id = @cruc_id

		INSERT INTO CONCORDIA.cancelacion (pasa_id, canc_descripcion)
			SELECT pasa_id, @motivo       
			FROM CONCORDIA.pasaje P
			JOIN CONCORDIA.viaje V on V.viaj_id = P.viaj_id 
			WHERE V.viaj_salida > @fecha_desde AND V.cruc_id = @cruc_id

	END
GO

/**************** Modificacion Crucero **********************************/

select *
from CONCORDIA.crucero
where cruc_identificador = 'que'

select *
from CONCORDIA.fabricante	
select cruc_id, cruc_identificador, cruc_modelo, fabr_id, cruc_inhabilitado, cruc_fecha_alta from CONCORDIA.crucero where cruc_id like '%1%'
select cruc_id, cruc_identificador, cruc_modelo, fabr_id, cruc_inhabilitado from CONCORDIA.crucero WHERE  cruc_id LIKE %1%