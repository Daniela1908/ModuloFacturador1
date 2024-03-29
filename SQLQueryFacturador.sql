USE [master]
GO
/****** Object:  Database [Facturas]    Script Date: 20/10/2019 7:21:28 p. m. ******/
CREATE DATABASE [Facturas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Facturas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.ION\MSSQL\DATA\Facturas.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Facturas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.ION\MSSQL\DATA\Facturas_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Facturas] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Facturas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Facturas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Facturas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Facturas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Facturas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Facturas] SET ARITHABORT OFF 
GO
ALTER DATABASE [Facturas] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Facturas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Facturas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Facturas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Facturas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Facturas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Facturas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Facturas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Facturas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Facturas] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Facturas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Facturas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Facturas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Facturas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Facturas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Facturas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Facturas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Facturas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Facturas] SET  MULTI_USER 
GO
ALTER DATABASE [Facturas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Facturas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Facturas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Facturas] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Facturas] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Facturas]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 20/10/2019 7:21:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cliente](
	[IdentificacionCliente] [varchar](30) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Direccion] [varchar](30) NULL,
	[Telefono] [varchar](30) NOT NULL,
	[Correo] [varchar](30) NOT NULL,
	[Sexo] [varchar](1) NULL,
	[EstadoCivil] [varchar](20) NULL,
	[Foto] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdentificacionCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 20/10/2019 7:21:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[NumeroDetalle] [int] IDENTITY(1,1) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Valor] [decimal](18, 0) NOT NULL,
	[CodProducto] [varchar](30) NOT NULL,
	[NumeroFactura] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NumeroDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 20/10/2019 7:21:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Factura](
	[NumeroFactura] [varchar](30) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Identificacion] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NumeroFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 20/10/2019 7:21:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[CodigoProducto] [varchar](30) NOT NULL,
	[Detalle] [varchar](30) NULL,
	[Precio] [decimal](18, 0) NULL,
	[Existencia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 20/10/2019 7:21:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Correo] [varchar](30) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Apellidos] [varchar](30) NOT NULL,
	[Contrasena] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD FOREIGN KEY([CodProducto])
REFERENCES [dbo].[Producto] ([CodigoProducto])
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD FOREIGN KEY([NumeroFactura])
REFERENCES [dbo].[Factura] ([NumeroFactura])
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD FOREIGN KEY([Identificacion])
REFERENCES [dbo].[cliente] ([IdentificacionCliente])
GO
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 20/10/2019 7:21:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IniciarSesion]
@Correo varchar(30),
@Contrasena varchar(20)
AS
BEGIN
SELECT *
FROM
Usuarios
WHERE
Correo=@Correo and Contrasena=@Contrasena
END
GO
USE [master]
GO
ALTER DATABASE [Facturas] SET  READ_WRITE 
GO


CREATE PROCEDURE [dbo].[CrearProducto]
@CodigoProducto varchar(30),
@Detalle varchar(30),
@Precio decimal,
@Existencia int,
@Activo bit
AS
BEGIN
INSERT INTO
Producto
VALUES
(@CodigoProducto, @Detalle, @Precio, @Existencia, @Activo)
END
GO

CREATE PROCEDURE [dbo].[CrearFactura]
@Cliente varchar(30),
@Usuario varchar(30)
AS
BEGIN
INSERT INTO
Factura(Fecha,Cliente,Usuario,Estado)
VALUES(
getdate(),
@Cliente,
@Usuario,
1)

SELECT * FROM
Factura
WHERE
NumeroFactura=SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE [dbo].[ModificarProducto]
@CodigoProducto varchar(30),
@Detalle varchar(30),
@Precio decimal,
@Existencia int,
@Activo bit
AS
BEGIN
UPDATE 
Producto
SET
Detalle=@Detalle,Precio=@Precio, Existencia=@Existencia, Activo=@Activo
WHERE
CodigoProducto=@CodigoProducto
END
GO 

CREATE PROCEDURE
[dbo].[ObtenerProductos]
AS
BEGIN
SELECT *
FROM
Producto
END
GO

CREATE PROCEDURE
[dbo].[ObtenerClientes]
AS
BEGIN
SELECT *
FROM
Cliente
END
GO

CREATE PROCEDURE
[dbo].[ObtenerClientesActivos]
AS
BEGIN
SELECT Documento, Nombre
FROM
Cliente
WHERE
Activo=1
END
GO

CREATE PROCEDURE [dbo].[CrearCliente]
@Documento varchar(30),
@Nombre varchar(30),
@Direccion varchar(30),
@Telefono varchar(30),
@Correo varchar(30),
@Activo bit
AS
BEGIN
INSERT INTO
Cliente
VALUES
(@Documento, @Nombre, @Direccion, @Telefono, @Correo, @Activo)
END
GO

CREATE PROCEDURE
[dbo].[ObtenerProductoPorCodigo]
@CodigoProducto varchar(30)
AS
BEGIN
SELECT *
FROM
Producto
WHERE
Codigoproducto=@CodigoProducto
END

GO


CREATE PROCEDURE
[dbo].[ObtenerClientePorDocumento]
@Documento varchar(30)
AS
BEGIN
SELECT *
FROM
Cliente
WHERE
Documento=@Documento
END

GO

CREATE PROCEDURE [dbo].[ModificarCliente]
@Documento varchar(30),
@Nombre varchar(30),
@Direccion varchar(30),
@Telefono varchar(30),
@Correo varchar(30),
@Activo bit
AS
BEGIN
UPDATE 
Cliente
SET
Nombre=@Nombre,Direccion=@Direccion, Telefono=@Telefono, Correo=@Correo, Activo=@Activo
WHERE
Documento=@Documento
END
GO 

CREATE PROCEDURE
[dbo].[ObtenerProductos]
AS
BEGIN
SELECT *
FROM
Producto
END
GO

CREATE TABLE
EstadoFactura
(
Codigo int primary key identity(1,1),
Descripcion varchar(10) not null
)


INSERT INTO 
EstadoFactura
(Descripcion)
VALUES
('En proceso'),
('Facturado'),
('Anulado')

SELECT * FROM
Factura

