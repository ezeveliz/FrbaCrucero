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

IF OBJECT_ID('CONCORDIA.cancelacion_pasaje','U') IS NOT NULL
    DROP TABLE CONCORDIA.cancelacion_pasaje;

IF OBJECT_ID('CONCORDIA.cancelacion_reserva','U') IS NOT NULL
    DROP TABLE CONCORDIA.cancelacion_reserva;

IF OBJECT_ID('CONCORDIA.cabina_pasaje','U') IS NOT NULL
    DROP TABLE CONCORDIA.cabina_pasaje;

IF OBJECT_ID('CONCORDIA.cabina_reserva','U') IS NOT NULL
    DROP TABLE CONCORDIA.cabina_reserva;

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


IF OBJECT_ID('CONCORDIA.InsertCrucero') IS NOT NULL
	DROP PROCEDURE CONCORDIA.InsertCrucero

IF OBJECT_ID('CONCORDIA.InsertarCabina') IS NOT NULL
	DROP PROCEDURE CONCORDIA.InsertarCabina

IF OBJECT_ID('CONCORDIA.BajaCrucero') IS NOT NULL
	DROP PROCEDURE CONCORDIA.BajaCrucero

IF OBJECT_ID('CONCORDIA.ObtenerIDCrucero') IS NOT NULL
	DROP PROCEDURE CONCORDIA.ObtenerIDCrucero

IF OBJECT_ID('CONCORDIA.RemplazarCruceroFVU') IS NOT NULL
	DROP PROCEDURE CONCORDIA.RemplazarCruceroFVU

IF OBJECT_ID('CONCORDIA.DesplazamientoDePasajes') IS NOT NULL
	DROP PROCEDURE CONCORDIA.DesplazamientoDePasajes

	
IF OBJECT_ID('CONCORDIA.CancelacionDePasajes') IS NOT NULL
	DROP PROCEDURE CONCORDIA.CancelacionDePasajes

IF OBJECT_ID('CONCORDIA.CancelacionDeTodosLosPasajes') IS NOT NULL
	DROP PROCEDURE CONCORDIA.CancelacionDeTodosLosPasajes


IF OBJECT_ID('CONCORDIA.ModificarCrucero') IS NOT NULL
	DROP PROCEDURE CONCORDIA.ModificarCrucero

IF OBJECT_ID('CONCORDIA.FueraServicioCrucero') IS NOT NULL
	DROP PROCEDURE CONCORDIA.FueraServicioCrucero

IF OBJECT_ID('CONCORDIA.IdCruceroRemplazante') IS NOT NULL
	DROP PROCEDURE CONCORDIA.IdCruceroRemplazante
	
IF OBJECT_ID('CONCORDIA.GenerarViaje') IS NOT NULL
	DROP PROCEDURE CONCORDIA.GenerarViaje

IF OBJECT_ID('CONCORDIA.ViajesDisponibles') IS NOT NULL
	DROP PROCEDURE CONCORDIA.ViajesDisponibles

IF OBJECT_ID('CONCORDIA.crearPasaje') IS NOT NULL
	DROP PROCEDURE CONCORDIA.crearPasaje 


IF OBJECT_ID('CONCORDIA.datosUsuario') IS NOT NULL
	DROP PROCEDURE CONCORDIA.datosUsuario

IF OBJECT_ID('CONCORDIA.valorViaje') IS NOT NULL
	DROP PROCEDURE CONCORDIA.valorViaje

IF OBJECT_ID('CONCORDIA.crearPasaje') IS NOT NULL
	DROP PROCEDURE CONCORDIA.crearPasaje
	
IF OBJECT_ID('CONCORDIA.cargarCabinaPasaje') IS NOT NULL
	DROP PROCEDURE 	CONCORDIA.cargarCabinaPasaje

IF OBJECT_ID('CONCORDIA.insertarUsuario') IS NOT NULL
	DROP PROCEDURE 	CONCORDIA.insertarUsuario

	
IF OBJECT_ID('CONCORDIA.validarCompra') IS NOT NULL
	DROP PROCEDURE 	CONCORDIA.validarCompra
	
IF OBJECT_ID('CONCORDIA.updateUsuario') IS NOT NULL
	DROP PROCEDURE 	CONCORDIA.updateUsuario

	
IF OBJECT_ID('CONCORDIA.cargarCabinaReserva') IS NOT NULL
	DROP PROCEDURE 	CONCORDIA.cargarCabinaReserva

IF OBJECT_ID('CONCORDIA.crearReserva') IS NOT NULL
	DROP PROCEDURE 	CONCORDIA.crearReserva

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
usua_dni DECIMAL(12,0),
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
orden TINYINT DEFAULT 1
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
cruc_id SMALLINT UNIQUE REFERENCES CONCORDIA.crucero,
cfvu_motivo varchar(50),
cfvu_fecha_baja DATETIME)

CREATE TABLE CONCORDIA.tipo_cabina(
tipo_cabi_id SMALLINT PRIMARY KEY IDENTITY(1,1),
tipo_cabi_recargo DECIMAL(4,2) not null,
tipo_cabi_descripcion varchar(50))

CREATE TABLE CONCORDIA.cabina(
cabi_id int PRIMARY KEY IDENTITY(1,1),
cruc_id SMALLINT REFERENCES CONCORDIA.crucero,
tipo_cabi_id SMALLINT REFERENCES CONCORDIA.tipo_cabina,
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
rese_creacion DATETIME DEFAULT GETDATE(),
rese_pagada TINYINT DEFAULT 0,
rese_inhabilitado TINYINT DEFAULT 0)

CREATE TABLE CONCORDIA.medio_pago(
medi_pago_id SMALLINT PRIMARY KEY IDENTITY(1,1),
medi_pago_tipo varchar(50) NOT NULL)

CREATE TABLE CONCORDIA.pasaje(
pasa_id INT PRIMARY KEY IDENTITY(1,1),
pasa_codviejo INT DEFAULT NULL,
viaj_id SMALLINT REFERENCES CONCORDIA.viaje NOT NULL,
usua_id INT REFERENCES CONCORDIA.usuario NOT NULL,
pasa_fecha_compra DATETIME NOT NULL DEFAULT GETDATE(),
medi_pago_id SMALLINT NOT NULL REFERENCES CONCORDIA.medio_pago,
cabi_id INT REFERENCES CONCORDIA.cabina,
pasa_cod_tajeta DECIMAL(10),
pasa_precio SMALLINT NOT NULL,
pasa_cancelado TINYINT DEFAULT 0)

CREATE TABLE CONCORDIA.cancelacion_reserva(
canc_id SMALLINT PRIMARY KEY IDENTITY(1,1),
rese_id INT REFERENCES CONCORDIA.reserva,
canc_descripcion varchar(50))

CREATE TABLE CONCORDIA.cancelacion_pasaje(
canc_id SMALLINT PRIMARY KEY IDENTITY(1,1),
pasa_id INT REFERENCES CONCORDIA.pasaje,
canc_descripcion varchar(50))

CREATE TABLE CONCORDIA.cabina_pasaje(
pasaje_id  iNT REFERENCES CONCORDIA.pasaje,
cabina_id INT REFERENCES CONCORDIA.cabina,
PRIMARY KEY( pasaje_id, cabina_id))

CREATE TABLE CONCORDIA.cabina_reserva(
reserva_id  iNT REFERENCES CONCORDIA.reserva,
cabina_id INT REFERENCES CONCORDIA.cabina,
PRIMARY KEY( reserva_id, cabina_id))

use GD1C2019;
GO

/* --------------------------------------------
  Migracion de tabla maestra a nuestas tablas 				
----------------------------------------------- */
	
/* Ingreso los roles en la tabla roles */
INSERT INTO CONCORDIA.roles (rol_descripcion)
	VALUES ('administrador'),
		   ('cliente');

/* Ingresa las funcionalidades */
INSERT INTO CONCORDIA.funcionalidad(func_descripcion)
	VALUES ('ABMRol'),
		   ('ABMusuario'),
		   ('ABMPuerto'),
		   ('ABMrecorrido'),
		   ('ABMCrucero'),
		   ('Compra/reserva pasajes'),
		   ('Pago reserva'),
		   ('Listado estadistico')

INSERT INTO CONCORDIA.roles_funcionalidad(rol_id,func_id)
	VALUES (1,1),
		   (1,2),
	       (1,3),
 	       (1,4),
	       (1,5),
		   (1,6),
		   (1,7),
		   (1,8),
		   (2,6),
		   (2,7)

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
	FROM #TEMP1 M /*ver como agregarle orden*/ 
	JOIN CONCORDIA.tramo T ON T.puer_id_inicio = M.puerto_desde AND T.puer_id_fin = M.puerto_hasta 

	create table #tempRec (reco_id int , tram_id_fin int )

	insert into #tempRec ( reco_id, tram_id_fin)
	select distinct   RTI.reco_id, rtf.tram_id 
			from CONCORDIA.recorrido_tramo RTI
			JOIN CONCORDIA.recorrido_tramo RTF on RTI.reco_id = RTF.reco_id
			join CONCORDIA.tramo t1 on t1.tram_id = rti.tram_id
			join CONCORDIA.tramo t2 on t2.tram_id = rtf.tram_id
			where rti.tram_id <> rtf.tram_id  AND t1.puer_id_fin = t2.puer_id_inicio 

	UPDATE CONCORDIA.recorrido_tramo SET orden = '2'
	FROM CONCORDIA.recorrido_tramo RT
	JOIN #tempRec tp ON tp.reco_id =  RT.reco_id AND tp.tram_id_fin = RT.tram_id
	
	DROP TABLE #tempRec

/* Ingreso los datos en la tabla pasajes */
INSERT INTO CONCORDIA.pasaje (pasa_codviejo, viaj_id, usua_id, pasa_fecha_compra, medi_pago_id, pasa_precio, cabi_id )
	SELECT DISTINCT  M.PASAJE_CODIGO,V.viaj_id, M.usua_id , M.PASAJE_FECHA_COMPRA, '1', M.PASAJE_PRECIO, C.cabi_id 
	FROM #TEMP1 M
	JOIN CONCORDIA.cabina C ON M.cabina_nro = C.cabi_nro AND M.cabina_piso = C.cabi_piso AND M.crucero_id = C.cruc_id
	JOIN CONCORDIA.viaje v ON M.fecha_llegada  = V.viaj_llegada AND M.fecha_salida = V.viaj_salida AND M.recorrido_id = V.reco_id
	WHERE PASAJE_CODIGO IS NOT NULL 

/* Ingreso los datos en la tabla reserva */
INSERT INTO CONCORDIA.reserva( rese_codviejo, viaj_id , usua_id, rese_creacion)
	SELECT DISTINCT  M.RESERVA_CODIGO, V.viaj_id, M.usua_id, M.RESERV_FECHA
	FROM #TEMP1 M
	JOIN CONCORDIA.cabina C ON M.cabina_nro = C.cabi_nro AND M.cabina_piso = C.cabi_piso AND M.crucero_id = C.cruc_id
	JOIN CONCORDIA.viaje v ON M.fecha_llegada  = V.viaj_llegada AND M.fecha_salida = V.viaj_salida AND M.recorrido_id = V.reco_id
	WHERE RESERVA_CODIGO IS NOT NULL 

    DROP TABLE #TEMP1;
go

/* Ingreso los datos en la tabla cabina_reserva */
INSERT INTO  [GD1C2019].[CONCORDIA].cabina_reserva( reserva_id, cabina_id)
	SELECT DISTINCT R.rese_id, C.cabi_id
	FROM  [GD1C2019].[CONCORDIA].reserva R
	JOIN  [GD1C2019].gd_esquema.Maestra M ON R.rese_codviejo = M.RESERVA_CODIGO 
	JOIN  [GD1C2019].[CONCORDIA].cabina AS C ON M.cabina_nro = C.cabi_nro AND M.cabina_piso = C.cabi_piso
	join  [GD1C2019].[CONCORDIA].crucero CR on M.CRUCERO_IDENTIFICADOR = CR.cruc_identificador AND CR.cruc_id = C.cruc_id
	WHERE RESERVA_CODIGO IS NOT NULL

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

CREATE PROCEDURE CONCORDIA.BajaCrucero (@cruc_id int, @motivo varchar(50)) 
AS 
	BEGIN 
		UPDATE CONCORDIA.crucero SET cruc_inhabilitado = '1'
		FROM CONCORDIA.crucero
		WHERE cruc_id = @cruc_id
	END
	BEGIN 
		INSERT INTO CONCORDIA.crucero_fin_vida_util (cruc_id,cfvu_motivo,cfvu_fecha_baja)
		VALUES (@cruc_id, @motivo, CONVERT(DATE, GETDATE()))
	END
	
GO

CREATE PROCEDURE CONCORDIA.FueraServicioCrucero (@cruc_id int, @motivo varchar(50), @fecha_alta varchar(20)) 
AS 
	BEGIN 
		UPDATE CONCORDIA.crucero SET cruc_inhabilitado = '1'
		FROM CONCORDIA.crucero
		WHERE cruc_id = @cruc_id
	END
	BEGIN 
		INSERT INTO CONCORDIA.crucero_fuera_servicio (cruc_id,cfs_motivo,cfs_fecha_baja,cfs_fecha_alta)
		VALUES (@cruc_id, @motivo, CONVERT(DATE, GETDATE()),CONVERT(DATE,@fecha_alta) )
	END		
GO

CREATE PROCEDURE CONCORDIA.ObtenerIDCrucero(@identificador varchar(50))
AS	
	BEGIN 
		DECLARE @RESULTADO int 
		DECLARE @cruceroExistente int
		SET @cruceroExistente = (SELECT cruc_id FROM CONCORDIA.crucero where cruc_identificador = @identificador and cruc_inhabilitado = '0') 
		
		IF(@cruceroExistente is null )
			SET @RESULTADO = -1
		ELSE 
			SET @RESULTADO = @cruceroExistente

		RETURN @RESULTADO
	END
GO

CREATE PROCEDURE CONCORDIA.RemplazarCruceroFVU(@cruc_id int, @cruc_id_remplazante int)
AS 
	BEGIN 
		declare @idPasaje int
		declare @idViaje int
		declare  @idCabina int
		declare  @idTipoCabina int
		
		UPDATE CONCORDIA.viaje SET cruc_id = @cruc_id_remplazante
		WHERE cruc_id = @cruc_id AND viaj_salida > GETDATE()
				
		DECLARE cursor_pasajes  CURSOR FOR select p.pasa_id, v.viaj_id, c.cabi_id, c.tipo_cabi_id from CONCORDIA.pasaje p join CONCORDIA.viaje v on p.viaj_id = v.viaj_id join CONCORDIA.cabina c on p.cabi_id = c.cabi_id	WHERE v.cruc_id = @cruc_id AND v.viaj_salida > GETDATE()
	
		OPEN cursor_pasajes

		FETCH NEXT FROM cursor_pasajes INTO @idPasaje, @idViaje, @idCabina, @idTipoCabina
		
			WHILE @@FETCH_STATUS = 0
			BEGIN
				UPDATE CONCORDIA.cabina_pasaje
				set cabina_id = (SELECT TOP (1) cabi_id
								 FROM CONCORDIA.cabina C
								 WHERE C.cruc_id = @cruc_id_remplazante AND
								 c.tipo_cabi_id = @idTipoCabina AND
								 c.cabi_id not in (SELECT cabi_id 
												   FROM CONCORDIA.cabina_pasaje CP 
												   WHERE CP.pasaje_id = @idPasaje))
				WHERE pasaje_id = @idPasaje AND cabina_id = @idCabina
			
				FETCH NEXT FROM cursor_pasajes INTO @idPasaje, @idViaje, @idCabina, @idTipoCabina
			END

			CLOSE cursor_pasajes
			DEALLOCATE	cursor_pasajes
	END
GO


CREATE PROCEDURE CONCORDIA.IdCruceroRemplazante (@cruc_id int)
AS	
	BEGIN 
				
		CREATE TABLE #TEMP_NO_REMPLZANATES(
			id int identity(1,1) primary key,
			cruc_id int)

		DECLARE @fechaDesde date = getdate();
		DECLARE @remplazo_id int 

		DECLARE @viajes TABLE
			(viaj_id int,
			 viaj_salida date,
			 viaj_llegada date)

		
		/* Obtengo todos los viajes del crucero al que voy a remplazar */
		INSERT INTO @viajes (viaj_id, viaj_salida, viaj_llegada)
			SELECT viaj_id, viaj_salida, viaj_llegada
			FROM CONCORDIA.viaje v
			where cruc_id = @cruc_id and v.viaj_salida > convert(date,@fechaDesde)

		DECLARE @FECHA_DESDE DATE
		DECLARE @FECHA_HASTA DATE
 
		DECLARE @count INT
		SELECT @count = COUNT(*) FROM @viajes;

		/*Creo una tabal con la cantidad de cabinas de cada tipo del crucero que voy a remplazar*/ 
		SELECT tipo_cabi_id, COUNT(*) cantidad
		INTO #cantidadCabinasARemplazar
		FROM CONCORDIA.cabina
		WHERE cruc_id = @cruc_id
		GROUP BY tipo_cabi_id

		/*Hago una iteracion por cada viaje del crucero a remplzarar */
		IF @count = 0 
			SET @remplazo_id = 0 
		ELSE 
			BEGIN

				WHILE  @count > 0
					BEGIN
					/* Seteo las fechas de inicio y fin del viaje al que voy a remplazar */
					SET @FECHA_DESDE = (select top (1) viaj_salida from @viajes)
					SET @FECHA_HASTA = (select top (1) viaj_llegada from @viajes)	

					/* Inserto los cruceros que no cumplen con el criterio de remplazo */
					INSERT INTO #TEMP_NO_REMPLZANATES (cruc_id)
						SELECT V.cruc_id
						FROM CONCORDIA.viaje v 
						WHERE (convert(date,v.viaj_salida) between convert(date,@FECHA_DESDE)  and convert(date,@FECHA_HASTA) or
							  convert(date,v.viaj_llegada) between convert(date,@FECHA_DESDE)  and  convert(date,@FECHA_HASTA)or
							  convert(date,@FECHA_DESDE) > convert(date,v.viaj_salida) and convert(date,@FECHA_HASTA) < convert(date,v.viaj_llegada))
					  
							
					DELETE TOP (1) FROM @viajes
					SELECT @count = COUNT(*) FROM @viajes;
					END
		
					select c.cruc_id ,CA.tipo_cabi_id , COUNT(CA.tipo_cabi_id) cant_tipo
					into #crucerosConFechasDisponibles 
					from CONCORDIA.crucero C 
					JOIN CONCORDIA.cabina CA ON C.cruc_id = CA.cruc_id
					where C.cruc_id NOT IN 
						(SELECT T.cruc_id 
						FROM #TEMP_NO_REMPLZANATES T group by T.cruc_id) 
						AND c.cruc_inhabilitado = 0
					group by c.cruc_id ,CA.tipo_cabi_id 

				/*Hago una consulta si existe algun crucero no exista en la tabla no remplazantes y tomo el primero */
				SET @remplazo_id = (SELECT DISTINCT TOP(1) C.cruc_id
									FROM  #crucerosConFechasDisponibles C
									JOIN #cantidadCabinasARemplazar CR ON CR.tipo_cabi_id = C.tipo_cabi_id
									WHERE C.cant_tipo >= CR.cantidad
									GROUP BY C.cruc_id
									HAVING COUNT(*) = (SELECT COUNT(*) FROM #cantidadCabinasARemplazar))
		
				/* si no existe ninguno lo seteo en -1*/
				IF(@remplazo_id IS NULL) 
					SET @remplazo_id = -1

			END
				DROP TABLE #TEMP_NO_REMPLZANATES

		END 

	RETURN @remplazo_id
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

CREATE PROCEDURE CONCORDIA.CancelacionDePasajes (@cruc_id int, @motivo varchar(50),@fecha_hasta varchar(50))
AS	
	BEGIN 

		UPDATE PASAJE SET pasa_cancelado = '1' 
		FROM CONCORDIA.pasaje P
		JOIN CONCORDIA.viaje V ON P.viaj_id = V.viaj_id
		WHERE V.viaj_salida BETWEEN  Convert(date,GETDATE()) AND Convert(date,@fecha_hasta) AND V.cruc_id = @cruc_id

		INSERT INTO CONCORDIA.cancelacion_pasaje(pasa_id, canc_descripcion)
			SELECT pasa_id, @motivo       
			FROM CONCORDIA.pasaje P
			JOIN CONCORDIA.viaje V on V.viaj_id = P.viaj_id 
			WHERE V.viaj_salida BETWEEN Convert(date,GETDATE()) AND Convert(date,@fecha_hasta) AND V.cruc_id = @cruc_id

	END
GO

CREATE PROCEDURE CONCORDIA.CancelacionDeTodosLosPasajes (@cruc_id int, @motivo varchar(50))
AS	
	BEGIN 
		BEGIN
			UPDATE PASAJE SET pasa_cancelado = '1' 
			FROM CONCORDIA.pasaje P
			JOIN CONCORDIA.viaje V ON P.viaj_id = V.viaj_id
			WHERE V.viaj_salida >  Convert(date,GETDATE())  AND V.cruc_id = @cruc_id
		END

		BEGIN
			INSERT INTO CONCORDIA.cancelacion_pasaje(pasa_id, canc_descripcion)
				SELECT P.pasa_id, @motivo    
				FROM CONCORDIA.pasaje P
				JOIN CONCORDIA.viaje V on V.viaj_id = P.viaj_id 
				WHERE V.viaj_salida > Convert(date,GETDATE())  AND  V.cruc_id = @cruc_id
		END
	END
GO


/**************** Modificacion Crucero **********************************/

CREATE PROCEDURE CONCORDIA.ModificarCrucero (@cruc_id int, @fabr_id int, @fecha_alta varchar(30))
AS 
	BEGIN 
		UPDATE CONCORDIA.crucero 
		SET fabr_id = @fabr_id, cruc_fecha_alta = CONVERT(DATE, @fecha_alta)
		WHERE cruc_id = @crUc_id 
	END
GO


/**************** Generacion de viajes **********************************/

CREATE PROCEDURE CONCORDIA.GenerarViaje (@fech_inicio varchar(20), @fech_fin varchar(20), @cruc_id int, @reco_id int)
AS  
	DECLARE @RESULTADO INT
	DECLARE @cruceroLibre INT
	BEGIN 
		SET @cruceroLibre = (SELECT COUNT(*)
						FROM CONCORDIA.viaje v 
						WHERE (v.cruc_id = @cruc_id AND
							  (convert(date,v.viaj_salida) between convert(date,@fech_inicio)  and convert(date,@fech_fin) or
							  convert(date,v.viaj_llegada) between convert(date,@fech_inicio)  and  convert(date,@fech_fin)or
							  convert(date,@fech_inicio) > convert(date,v.viaj_salida) and convert(date,@fech_fin) < convert(date,v.viaj_llegada))
							  )) 
		
		IF (@cruceroLibre = 0)
			BEGIN
				INSERT INTO CONCORDIA.viaje (viaj_salida, viaj_llegada, viaj_llegada_estimada, cruc_id, reco_id)
					VALUES (CONVERT(date,@fech_inicio), CONVERT(date,@fech_fin), CONVERT(date,@fech_fin), @cruc_id, @reco_id)
			
				SET @RESULTADO = (SELECT viaj_id FROM CONCORDIA.viaje WHERE viaj_salida = CONVERT(date,@fech_inicio) AND viaj_llegada = CONVERT(date,@fech_fin) AND cruc_id = @cruc_id)
		
			END
		
		ELSE 
			BEGIN
				SET @RESULTADO = '-1'
			END
	END
	
	RETURN @RESULTADO
GO

/******************** Compra/Reserva *********************/

CREATE PROCEDURE CONCORDIA.ViajesDisponibles (@FECHA_BUSQUEDA VARCHAR(30), @PUERTO_INICIO INT, @PUERTO_FIN INT)
AS
	BEGIN

		CREATE TABLE #CABINASOCUPADAS(cabi_id int)

		CREATE TABLE #VIAJESPOSIBLES(viaj_id int)	  

		INSERT INTO #VIAJESPOSIBLES (viaj_id)
			 SELECT  V.viaj_id 
			 FROM CONCORDIA.viaje V
			 JOIN CONCORDIA.recorrido_tramo RTI ON v.reco_id = RTI.reco_id
			 JOIN CONCORDIA.recorrido_tramo RTF ON v.reco_id = RTF.reco_id
		     join CONCORDIA.tramo TI on TI.tram_id = rti.tram_id AND RTI.orden = '1'
			 join CONCORDIA.tramo TF on TF.tram_id = rtf.tram_id AND RTF.orden = (SELECT MAX(orden) FROM CONCORDIA.recorrido_tramo RTS WHERE RTS.reco_id = V.reco_id )
			 JOIN CONCORDIA.puerto PS ON PS.puer_id = TI.puer_id_inicio 
		     JOIN CONCORDIA.puerto PF ON PF.puer_id = TF.puer_id_fin 
		     JOIN CONCORDIA.crucero CR ON CR.cruc_id = V.cruc_id
		     WHERE V.viaj_salida = CONVERT(DATE, @FECHA_BUSQUEDA) AND PS.puer_id = @PUERTO_INICIO AND PF.puer_id = @PUERTO_FIN AND CR.cruc_inhabilitado = '0'
	
	
		INSERT INTO #CABINASOCUPADAS (cabi_id)
			(SELECT DISTINCT cp.cabina_id
			 FROM CONCORDIA.cabina_pasaje cp
			 join CONCORDIA.pasaje p on cp.pasaje_id = p.pasa_id
			 join CONCORDIA.viaje v on p.viaj_id = v.viaj_id
			 where v.viaj_id IN  (SELECT *
									FROM #VIAJESPOSIBLES )) 

		INSERT INTO #CABINASOCUPADAS (cabi_id)
			(SELECT DISTINCT cr.cabina_id
			 FROM CONCORDIA.cabina_reserva cr	
			 join CONCORDIA.reserva r on cr.reserva_id = r.rese_id
			 join CONCORDIA.viaje v on r.viaj_id = v.viaj_id
			 where v.viaj_id IN  (SELECT *
									FROM #VIAJESPOSIBLES )
					AND R.rese_inhabilitado = 0
					AND R.rese_pagada != 1)
					

			SELECT V.viaj_id, V.cruc_id, C.cabi_id, C.cabi_nro, C.cabi_piso, TC.tipo_cabi_descripcion, TC.tipo_cabi_recargo
			FROM CONCORDIA.viaje V
			JOIN CONCORDIA.cabina C ON V.cruc_id = C.cruc_id
			JOIN CONCORDIA.tipo_cabina TC ON TC.tipo_cabi_id = C.tipo_cabi_id 
			WHERE v.viaj_id IN (SELECT *
								FROM #VIAJESPOSIBLES)
			AND C.cabi_id NOT IN (SELECT *
										FROM #CABINASOCUPADAS) 
																				
		DROP TABLE  #CABINASOCUPADAS
		DROP TABLE  #VIAJESPOSIBLES

	END 
GO

CREATE PROCEDURE CONCORDIA.datosUsuario (@usua_dni int)
AS 
	BEGIN
		SELECT TOP (1)  U.usua_email, U.usua_nombre, U.usua_apellido, U.usua_direccion, U.usua_fecha_nac, U.usua_telefono, U.usua_id
		FROM CONCORDIA.usuario U
		WHERE U.usua_dni = @usua_dni
	END
GO

CREATE PROCEDURE CONCORDIA.valorViaje (@viaj_id int)
AS
	BEGIN
		DECLARE @RESULTADO INT = 
		(SELECT SUM(T.tram_precio)
		 FROM CONCORDIA.viaje V
		 JOIN CONCORDIA.recorrido_tramo RT ON RT.reco_id = V.reco_id
		 JOIN CONCORDIA.tramo T ON RT.tram_id = T.tram_id  
		 WHERE viaj_id =  @viaj_id)
	END

	RETURN @RESULTADO
GO

/******************* Compra ***********************/
CREATE PROCEDURE CONCORDIA.crearPasaje (@viaj_id int,@usua_id int, @medi_pago_id int, @precio int )
AS
	DECLARE @ID_PASAJE INT
	BEGIN 
		INSERT INTO CONCORDIA.pasaje (viaj_id, usua_id, pasa_fecha_compra, medi_pago_id, pasa_precio)
		values (@viaj_id, @usua_id, GETDATE(), @medi_pago_id, @precio)

		SET @ID_PASAJE = (SELECT top (1) pasa_id
		FROM CONCORDIA.pasaje P
		WHERE P.viaj_id = @viaj_id AND P.usua_id = @usua_id) 
	END
	RETURN  @ID_PASAJE
GO 

CREATE PROCEDURE CONCORDIA.updateUsuario ( @usua_id int ,@usua_dni int, @usua_nombre varchar(30), @usua_apellido varchar(30), @usua_email varchar(30), @usua_direccion varchar(20), @usua_fecha_nac varchar(30) , @usua_telefono int)
AS

	BEGIN 
		update CONCORDIA.usuario 
		set  usua_dni = @usua_dni, usua_nombre =  @usua_nombre, usua_apellido = @usua_apellido , usua_email = @usua_email, usua_direccion = @usua_direccion, usua_fecha_nac = Convert(date,@usua_fecha_nac), usua_telefono = @usua_telefono 
		where usua_id = @usua_id

	END
GO 

CREATE PROCEDURE CONCORDIA.insertarUsuario ( @usua_dni int, @usua_nombre varchar(30), @usua_apellido varchar(30), @usua_email varchar(30), @usua_direccion varchar(20), @usua_fecha_nac varchar(30) , @usua_telefono int)
AS
	DECLARE @ID_REMPLAZO INT
	BEGIN 
		INSERT INTO CONCORDIA.usuario ( usua_dni, usua_nombre, usua_apellido, usua_email, usua_direccion, usua_fecha_nac, usua_telefono)
		values ( @usua_dni, @usua_nombre , @usua_apellido , @usua_email , @usua_direccion , Convert(date,@usua_fecha_nac) , @usua_telefono )
	
		SET @ID_REMPLAZO = (SELECT TOP (1) usua_id FROM CONCORDIA.usuario WHERE usua_dni = @usua_dni)
	
	END
	RETURN @ID_REMPLAZO 
GO 

CREATE PROCEDURE CONCORDIA.cargarCabinaPasaje(@pasa_id int, @cabi_id int)
AS
	BEGIN

		INSERT INTO CONCORDIA.cabina_pasaje (pasaje_id,cabina_id)
		values(@pasa_id, @cabi_id)

	END
GO

CREATE PROCEDURE CONCORDIA.validarCompra (@usua_id int,@viaj_id int)
AS	
	DECLARE @validacionViajesPasados INT
	DECLARE @validacionDisponibilidadFecha INT
	DECLARE @validarReserva INT
	DECLARE @fechaDesde varchar(20) = (SELECT v.viaj_salida from  CONCORDIA.viaje v where v.viaj_id = @viaj_id) 
	DECLARE @fechaHasta varchar(20)  = (SELECT v.viaj_llegada from  CONCORDIA.viaje v where v.viaj_id = @viaj_id)
	DECLARE @RESULTADO INT

	BEGIN 
		
		SET @validarReserva = (SELECT COUNT(*) FROM CONCORDIA.reserva WHERE usua_id = @usua_id AND viaj_id = @viaj_id AND rese_inhabilitado = 0 AND rese_pagada = 0 )
		SET @validacionViajesPasados = (SELECT COUNT(*) FROM CONCORDIA.pasaje WHERE usua_id = @usua_id AND viaj_id = @viaj_id)
		SET @validacionDisponibilidadFecha = (SELECT COUNT(*)
											FROM CONCORDIA.pasaje P 
											join CONCORDIA.viaje V ON P.viaj_id = V.viaj_id
											WHERE (P.usua_id = @usua_id AND
												   convert(date,V.viaj_salida) between convert(date,@fechaDesde)  and convert(date,@fechaHasta) or
												   convert(date,v.viaj_llegada) between convert(date,@fechaDesde)  and  convert(date,@fechaHasta)or
												   convert(date,@fechaDesde) > convert(date,v.viaj_salida) and convert(date,@fechaHasta) < convert(date,v.viaj_llegada)))

		SET @RESULTADO = @validacionViajesPasados + @validacionDisponibilidadFecha + @validarReserva
	END

	RETURN @RESULTADO
GO 
/*************** Reserva *******************************/

CREATE PROCEDURE CONCORDIA.crearReserva (@viaj_id int,@usua_id int )
AS
	DECLARE @ID_RESERVA INT
	BEGIN 
		INSERT INTO CONCORDIA.reserva (viaj_id, usua_id, rese_creacion)
		values (@viaj_id, @usua_id, GETDATE())

		SET @ID_RESERVA = (SELECT top (1) rese_id
		FROM CONCORDIA.reserva R
		WHERE R.viaj_id = @viaj_id AND R.usua_id = @usua_id) 
	END
	RETURN  @ID_RESERVA
GO 


CREATE PROCEDURE CONCORDIA.cargarCabinaReserva(@rese_id int, @cabi_id int)
AS
	BEGIN

		INSERT INTO CONCORDIA.cabina_reserva(reserva_id,cabina_id)
		values(@rese_id, @cabi_id)

	END
GO

