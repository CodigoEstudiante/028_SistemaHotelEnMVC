
USE DB_HOTEL

GO

insert into ESTADO_HABITACION(IdEstadoHabitacion,Descripcion) values
(1,'DISPONIBLE'),
(2,'OCUPADO'),
(3,'LIMPIEZA')


go

insert into TIPO_PERSONA(IdTipoPersona, Descripcion) values
(1,'Administrador'),
(2,'Empleado'),
(3,'Cliente')

go


insert into PERSONA(documento,nombre,apellido,correo,clave,IdTipoPersona) values
('4545453','Naomi','Konoe','Konoe@gmail.com','123',1),
('4353434','Mizuki','Hayashi','Mizuki@gmail.com','456',2)

GO

insert into PERSONA(TipoDocumento,documento,nombre,apellido,correo,IdTipoPersona) values
('DNI','34345656','Bartolome','Abe','Abe@gmail.com',3),
('DNI','56567878','Hanan','Beppu','Beppu@gmail.com',3),
('DNI','34237878','Haru','Endo','Endo@gmail.com',3),
('PASAPORTE','78909078','Juan Luis','Vico','Vico@gmail.com',3),
('DNI','45456767','Victoriano','Araujo','Araujo@gmail.com',3),
('DNI','45343434','Kameyo','Hashimoto','Hashimoto@gmail.com',3),
('PASAPORTE','34232334','Nerea','Chavez','Chavez@gmail.com',3),
('DNI','78676756','Maria Sonia','Lillo','Lillo@gmail.com',3),
('DNI','78787979','Nagore','Quiros','Quiros@gmail.com',3),
('DNI','70707878','Maria Belen','Antunez','Antunez@gmail.com',3)


GO

insert into PRODUCTO(Nombre,Detalle,Precio,Cantidad) values
('GALLETAS DORAS','NINGUNA','0.70',50),
('REFRESCO POCMAS','350 ML','1.50',80),
('CHOCOLATE DMX','50 GRM','0.80',60),
('PAPAS DORADAS','150 GRM','2.60',20),
('REFRESCO OXA','300 ML','2',30),
('CIGARRILLOS DEM','10 UNID','3.50',55),
('AGUA LIFE','250 ML','3',45),
('GASEOSA ALMOADA','350 ML','4.50',30),
('CEREALES PANDA','NIN','2.70',40),
('SHAMPOO GH','200 ML','2.50',20)

GO
INSERT INTO CATEGORIA(Descripcion) VALUES
('Matrimonial'),
('Doble'),
('Individual')
GO

INSERT INTO PISO(Descripcion) VALUES
('PRIMERO'),
('SEGUNDO'),
('TERCERO')

GO

INSERT INTO HABITACION(numero,detalle,precio,IdEstadoHabitacion,IdPiso,IdCategoria) values
('001','WIFI + BAÑO + TV + CABLE','70',1,1,3),
('002','WIFI + BAÑO + TV + CABLE','80',1,1,2),
('003','BAÑO + TV + CABLE','60',1,1,3),
('004','WIFI + BAÑO + TV + CABLE','80',1,1,2),
('005','WIFI + BAÑO','50',1,1,3),

('006','WIFI + BAÑO + TV 4K + CABLE','80',1,2,3),
('007','WIFI + BAÑO + TV 4K + CABLE','90',1,2,2),
('008','WIFI + BAÑO + TV + CABLE','70',1,2,3),
('009','WIFI + BAÑO + TV + CABLE','80',1,2,2),
('010','WIFI + BAÑO + TV + CABLE','70',1,2,3),

('011','WIFI + BAÑO + TV 4K + CABLE','120',1,3,1),
('012','WIFI + BAÑO + TV 4K + CABLE','120',1,3,1),
('013','WIFI + BAÑO + TV 4K + CABLE','120',1,3,1),
('014','WIFI + BAÑO + TV + CABLE','85',1,3,2),
('015','WIFI + BAÑO + TV + CABLE','75',1,3,3)