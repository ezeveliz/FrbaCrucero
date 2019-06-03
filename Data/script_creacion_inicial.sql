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

IF EXISTS (SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'CONCORDIA')
    DROP SCHEMA CONCORDIA
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
usua_password INT DEFAULT NULL,
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
reco_id INT PRIMARY KEY,
reco_inhabilitado tinyint DEFAULT 0)

CREATE TABLE CONCORDIA.recorrido_tramo(
reco_id INT REFERENCES CONCORDIA.recorrido,
tram_id SMALLINT REFERENCES CONCORDIA.tramo,
PRIMARY KEY (reco_id,tram_id))

CREATE TABLE CONCORDIA.fabricante(
fabr_id SMALLINT PRIMARY KEY IDENTITY(1,1),
fabr_nombre varchar(50))

CREATE TABLE CONCORDIA.crucero(
cruc_id varchar(15) PRIMARY KEY,
cuc_modelo varchar(50),
fabr_id SMALLINT REFERENCES CONCORDIA.fabricante,
cruc_inhabilitado tinyint DEFAULT 0)

CREATE TABLE CONCORDIA.crucero_fuera_servicio(
cfs_id smallint PRIMARY KEY IDENTITY(1,1),
cruc_id varchar(15) REFERENCES CONCORDIA.crucero,
cfs_motivo varchar(50),
cfs_fecha_baja DATETIME,
cfs_fecha_alta DATETIME)
 
CREATE TABLE CONCORDIA.crucero_fin_vida_util(
cfvu_id smallint PRIMARY KEY IDENTITY(1,1),
cruc_id varchar(15) REFERENCES CONCORDIA.crucero,
cfvu_motivo varchar(50),
cfvu_fecha_baja DATETIME,
cfvu_fecha_alta DATETIME)

CREATE TABLE CONCORDIA.tipo_cabina(
tipo_cabi_id SMALLINT PRIMARY KEY IDENTITY(1,1),
tipo_cabi_recargo DECIMAL(4,2) not null,
tipo_cabi_descripcion varchar(50))

CREATE TABLE CONCORDIA.cabina(
cabi_id int PRIMARY KEY IDENTITY(1,1),
cruc_id varchar(15) REFERENCES CONCORDIA.crucero,
tipo_cabi_id SMALLINT REFERENCES CONCORDIA.tipo_cabina,
cabi_estado TINYINT DEFAULT 0,
cabi_piso decimal(2,0),
cabi_nro decimal(3,0))

CREATE TABLE CONCORDIA.viaje(
viaj_id SMALLINT PRIMARY KEY IDENTITY(1,1),
viaj_salida DATETIME NOT NULL,
viaj_llegada DATETIME,
viaj_llegada_estimada DATETIME NOT NULL,
cruc_id varchar(15) REFERENCES CONCORDIA.crucero,
reco_id INT REFERENCES CONCORDIA.recorrido)

CREATE TABLE CONCORDIA.reserva(
rese_id INT PRIMARY KEY,
viaj_id SMALLINT REFERENCES CONCORDIA.viaje NOT NULL,
usua_id INT REFERENCES CONCORDIA.usuario NOT NULL,
rese_cant_pasajeros DECIMAL(2,0) NOT NULL,
rese_creacion DATETIME DEFAULT GETDATE())

CREATE TABLE CONCORDIA.medio_pago(
medi_pago_id SMALLINT PRIMARY KEY IDENTITY(1,1),
medi_pago_tipo varchar(50) NOT NULL)

CREATE TABLE CONCORDIA.pasaje(
pasa_id INT PRIMARY KEY ,
viaj_id SMALLINT REFERENCES CONCORDIA.viaje NOT NULL,
usua_id INT REFERENCES CONCORDIA.usuario NOT NULL,
pasa_cant_pasajeros DECIMAL(2,0) NOT NULL,
pasa_fecha_compra DATETIME NOT NULL DEFAULT GETDATE(),
medi_pago_id SMALLINT NOT NULL REFERENCES CONCORDIA.medio_pago,
pasa_cod_tajeta DECIMAL(10),
pasa_precio SMALLINT NOT NULL)

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

INSERT INTO CONCORDIA.roles (rol_descripcion)
	VALUES ('Administrativo'),
		   ('Cliente');

DECLARE @SHA2_25 INT
SET @SHA2_25 = HASHBYTES('SHA2_256','w23e')

/* Ingreso el usuario admin */
INSERT INTO CONCORDIA.usuario (usua_dni, usua_nombre, usua_apellido, usua_email, usua_fecha_nac, rol_id, usua_direccion, usua_telefono, usua_username ,usua_password)
	VALUES (11111111,'ADMIN','','',CONVERT(DATETIME,'11-7-2010',102), 1, '', 153458912, 'admin', @SHA2_25);

/* Ingreso los medios de pago */	
INSERT INTO CONCORDIA.medio_pago
	VALUES ('Debito'),
		   ('Efectivo');

/* Ingreso los usuarios de la tabla maestra */
INSERT INTO CONCORDIA.usuario (rol_id, usua_dni,usua_nombre, usua_apellido, usua_email, usua_fecha_nac, usua_direccion, usua_telefono)
	SELECT  '2',M.CLI_DNI, M.CLI_NOMBRE, M.CLI_APELLIDO,  M.CLI_MAIL, M.CLI_FECHA_NAC, M.CLI_DIRECCION, M.CLI_TELEFONO
	from gd_esquema.Maestra M
	group by M.CLI_DNI, M.CLI_NOMBRE, M.CLI_APELLIDO,  M.CLI_MAIL, M.CLI_FECHA_NAC, M.CLI_DIRECCION, M.CLI_TELEFONO

INSERT INTO CONCORDIA.puerto(puer_ciudad)
	SELECT DISTINCT PUERTO_DESDE
	FROM gd_esquema.Maestra 	
	UNION
	SELECT DISTINCT PUERTO_HASTA
	FROM gd_esquema.Maestra 	

INSERT INTO CONCORDIA.tramo (puer_id_inicio, puer_id_fin ,tram_precio)
	select DISTINCT pd.puer_id, ph.puer_id, RECORRIDO_PRECIO_BASE
	from gd_esquema.Maestra M, CONCORDIA.puerto ph, CONCORDIA.puerto pd
	where m.PUERTO_DESDE = pd.puer_ciudad and m.PUERTO_HASTA = ph.puer_ciudad
	order by RECORRIDO_PRECIO_BASE

INSERT INTO CONCORDIA.recorrido (reco_id)
	SELECT DISTINCT M.RECORRIDO_CODIGO
	FROM gd_esquema.Maestra M

/*  Completar 
INSERT INTO CONCORDIA.recorrido_tramo()
	SELECT M.RECORRIDO_CODIGO
	FROM gd_esquema.Maestra M, CONCORDIA.tramo t
*/
INSERT INTO CONCORDIA.fabricante(fabr_nombre)
	SELECT DISTINCT M.CRU_FABRICANTE
	FROM gd_esquema.Maestra M
	
INSERT INTO CONCORDIA.crucero ( cruc_id, cuc_modelo, fabr_id )
	SELECT DISTINCT M.CRUCERO_IDENTIFICADOR, M.CRUCERO_MODELO, F.fabr_id
	FROM gd_esquema.Maestra M, CONCORDIA.fabricante F
	WHERE F.fabr_nombre = M.CRU_FABRICANTE

INSERT INTO CONCORDIA.tipo_cabina ( tipo_cabi_descripcion, tipo_cabi_recargo )
	SELECT DISTINCT M.CABINA_TIPO, M.CABINA_TIPO_PORC_RECARGO
	from gd_esquema.Maestra M

INSERT INTO CONCORDIA.cabina( cabi_nro, cabi_piso,  cruc_id, tipo_cabi_id)
	SELECT DISTINCT M.CABINA_NRO, M.CABINA_PISO, M.CRUCERO_IDENTIFICADOR,T.tipo_cabi_id
	FROM gd_esquema.Maestra M, CONCORDIA.tipo_cabina T	
	WHERE   M.CABINA_TIPO = T.tipo_cabi_descripcion


INSERT INTO CONCORDIA.viaje( viaj_salida, viaj_llegada, viaj_llegada_estimada, cruc_id, reco_id)	
select DISTINCT  FECHA_SALIDA, FECHA_LLEGADA, FECHA_LLEGADA_ESTIMADA, CRUCERO_IDENTIFICADOR, RECORRIDO_CODIGO
from gd_esquema.Maestra

CREATE TABLE #TEMP1(
	TEMP_ID INT PRIMARY KEY IDENTITY(1,1),
	usua_id INT,
	PASAJE_CODIGO int ,
	PASAJE_PRECIO SMALLINT,
	PASAJE_FECHA_COMPRA DATETIME,
	viaje_id  SMALLINT,
	RESERVA_CODIGO INT,
	RESERV_FECHA DATETIME
	 )

INSERT INTO #TEMP1 ( usua_id, PASAJE_CODIGO, PASAJE_PRECIO, PASAJE_FECHA_COMPRA, viaje_id, RESERVA_CODIGO, RESERV_FECHA)
	SELECT DISTINCT U.usua_id, M.PASAJE_CODIGO,M.PASAJE_PRECIO, M.PASAJE_FECHA_COMPRA, V.viaj_id, M.RESERVA_CODIGO, M.RESERVA_FECHA
	FROM gd_esquema.Maestra M, CONCORDIA.usuario U, CONCORDIA.viaje V
	WHERE M.CLI_DNI = u.usua_dni AND
	  M.CLI_APELLIDO = U.usua_apellido AND
	  M.CLI_NOMBRE = U.usua_nombre AND 
	  M.FECHA_SALIDA = V.viaj_salida AND
	  M.FECHA_LLEGADA = V.viaj_llegada AND
	  M.FECHA_LLEGADA_ESTIMADA = V.viaj_llegada_estimada AND
	  M.RECORRIDO_CODIGO = V.reco_id

INSERT INTO CONCORDIA.pasaje (pasa_id,viaj_id, usua_id, pasa_cant_pasajeros, pasa_fecha_compra, medi_pago_id, pasa_precio )
SELECT DISTINCT PASAJE_CODIGO, viaje_id, usua_id, '1' , PASAJE_FECHA_COMPRA,'1', PASAJE_PRECIO
FROM #TEMP1
WHERE PASAJE_CODIGO IS NOT NULL 

INSERT INTO CONCORDIA.reserva( rese_id,viaj_id, usua_id, rese_cant_pasajeros, rese_creacion)
SELECT DISTINCT RESERVA_CODIGO, viaje_id, usua_id,'1', RESERV_FECHA
FROM #TEMP1
WHERE RESERVA_CODIGO IS NOT NULL 


select DISTINCT RECORRIDO_CODIGO, PUERTO_DESDE, PUERTO_HASTA 
from gd_esquema.Maestra


go

