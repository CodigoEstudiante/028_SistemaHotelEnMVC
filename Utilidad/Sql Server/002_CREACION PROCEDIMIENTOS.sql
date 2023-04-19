
USE DB_HOTEL

GO

--PROCEDIMIENTO PARA GUARDAR CATEGORIA
CREATE PROC sp_RegistrarCategoria(
@Descripcion varchar(50),
@Resultado bit output
)as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion)

		insert into CATEGORIA(Descripcion) values (
		@Descripcion
		)
	ELSE
		SET @Resultado = 0
	
end


go

--PROCEDIMIENTO PARA MODIFICAR CATEGORIA
create procedure sp_ModificarCategoria(
@IdCategoria int,
@Descripcion varchar(60),
@Estado bit,
@Resultado bit output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion =@Descripcion and IdCategoria != @IdCategoria)
		
		update CATEGORIA set 
		Descripcion = @Descripcion,
		Estado = @Estado
		where IdCategoria = @IdCategoria
	ELSE
		SET @Resultado = 0

end

GO


--PROCEDIMIENTO PARA GUARDAR PISOS
CREATE PROC sp_RegistrarPiso(
@Descripcion varchar(50),
@Resultado bit output
)as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM PISO WHERE Descripcion = @Descripcion)

		insert into PISO(Descripcion) values (
		@Descripcion
		)
	ELSE
		SET @Resultado = 0
	
end


go

--PROCEDIMIENTO PARA MODIFICAR PISOS
create procedure sp_ModificarPiso(
@IdPiso int,
@Descripcion varchar(60),
@Estado bit,
@Resultado bit output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM PISO WHERE Descripcion =@Descripcion and IdPiso != @IdPiso)
		
		update PISO set 
		Descripcion = @Descripcion,
		Estado = @Estado
		where IdPiso = @IdPiso
	ELSE
		SET @Resultado = 0

end

GO



--PROCEDIMIENTO PARA GUARDAR HABITACION
create PROC sp_RegistrarHabitacion(
@Numero varchar(50),
@Detalle varchar(100),
@Precio decimal(10,2),
@IdPiso varchar(50),
@IdCategoria varchar(50),
@Resultado bit output
)as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM HABITACION WHERE Numero = @Numero)

		insert into HABITACION(Numero,Detalle,Precio,IdPiso,IdCategoria,IdEstadoHabitacion) values (
		@Numero,@Detalle,@Precio,@IdPiso,@IdCategoria,1
		)
	ELSE
		SET @Resultado = 0
	
end


go

--PROCEDIMIENTO PARA MODIFICAR HABITACION
create procedure sp_ModificarHabitacion(
@IdHabitacion int,
@Numero varchar(50),
@Detalle varchar(100),
@Precio decimal(10,2),
@IdPiso varchar(50),
@IdCategoria varchar(50),
@Estado bit,
@Resultado bit output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM HABITACION WHERE Numero =@Numero and IdHabitacion != @IdHabitacion)
		
		update HABITACION set 
		Numero = @Numero,
		Detalle = @Detalle,
		Precio = @Precio,
		IdPiso = @IdPiso,
		IdCategoria = @IdCategoria,
		Estado = @Estado
		where IdHabitacion = @IdHabitacion
	ELSE
		SET @Resultado = 0

end

GO


--PROCEDIMIENTO PARA GUARDAR PRODUCTO
CREATE PROC sp_RegistrarProducto(
@Nombre varchar(50),
@Detalle varchar(50),
@Precio varchar(50),
@Cantidad varchar(50),
@Resultado bit output
)as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE Nombre = @Nombre)

		insert into PRODUCTO(Nombre,Detalle,Precio,Cantidad) values (
		@Nombre,@Detalle,@Precio,@Cantidad
		)
	ELSE
		SET @Resultado = 0
	
end


go

--PROCEDIMIENTO PARA MODIFICAR PRODUCTO
create procedure sp_ModificarProducto(
@IdProducto int,
@Nombre varchar(50),
@Detalle varchar(50),
@Precio varchar(50),
@Cantidad varchar(50),
@Estado bit,
@Resultado bit output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE Nombre =@Nombre and IdProducto != @IdProducto)
		
		update PRODUCTO set 
		Nombre = @Nombre,
		Detalle = @Detalle,
		Precio = @Precio,
		Cantidad = @Cantidad,
		Estado = @Estado
		where IdProducto = @IdProducto
	ELSE
		SET @Resultado = 0

end

GO


--PROCEDIMIENTO PARA GUARDAR PERSONA
create PROC sp_RegistrarPersona(
@TipoDocumento varchar(50),
@Documento varchar(50),
@Nombre varchar(50),
@Apellido varchar(50),
@Correo varchar(50),
@Clave varchar(50),
@IdTipoPersona int,
@Resultado bit output
)as
begin
	SET @Resultado = 1
	DECLARE @IDPERSONA INT 
	IF NOT EXISTS (SELECT * FROM persona WHERE Documento = @Documento)
	begin
		insert into persona(TipoDocumento, Documento,Nombre,Apellido,Correo,Clave,IdTipoPersona) values (
		@TipoDocumento,@Documento,@Nombre,@Apellido,@Correo,@Clave,@IdTipoPersona)
	end
	ELSE
		SET @Resultado = 0
	
end


go

--PROCEDIMIENTO PARA MODIFICAR PERSONA
create procedure sp_ModificarPersona(
@IdPersona int,
@TipoDocumento varchar(50),
@Documento varchar(50),
@Nombre varchar(50),
@Apellido varchar(50),
@Correo varchar(50),
@Clave varchar(50),
@IdTipoPersona int,
@Estado bit,
@Resultado bit output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM persona WHERE Documento =@Documento and IdPersona != @IdPersona)
		
		update PERSONA set
		TipoDocumento = @TipoDocumento,
		Documento = @Documento,
		Nombre = @Nombre,
		Apellido = @Apellido,
		Correo = @Correo,
		IdTipoPersona = @IdTipoPersona,
		Estado = @Estado
		where IdPersona = @IdPersona
	ELSE
		SET @Resultado = 0

end

go

create proc sp_registrarRecepcion(
@IdCliente int,
@TipoDocumento varchar(50),
@Documento varchar(50),
@Nombre varchar(50),
@Apellido varchar(50),
@Correo varchar(50),
@IdHabitacion int,
@FechaSalida datetime,
@PrecioInicial decimal(10,2),
@Adelanto decimal(10,2),
@PrecioRestante decimal(10,2),
@Observacion varchar(500),
@Resultado bit output
)
as
begin
	set @Resultado = 1
	begin try
		begin transaction
		if(not exists(select * from persona where IdPersona =@IdCliente ))
		begin
			insert into PERSONA(TipoDocumento,Documento,Nombre,Apellido,Correo,IdTipoPersona) values(
			@TipoDocumento,@Documento,@Nombre,@Apellido,@Correo,3)
			set @IdCliente = SCOPE_IDENTITY()  
		end

		update HABITACION set IdEstadoHabitacion = 2 where IdHabitacion = @IdHabitacion

		insert into RECEPCION(IdCliente,IdHabitacion,FechaSalida,PrecioInicial,Adelanto,PrecioRestante,Observacion,Estado) values
		(@IdCliente,@IdHabitacion,@FechaSalida,@PrecioInicial,@Adelanto,@PrecioRestante,@Observacion,1)

		commit transaction
	end try
	begin catch
		rollback
		set @Resultado = 0
	end catch

end



