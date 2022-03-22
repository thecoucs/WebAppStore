USE [master]
GO
/****** Object:  Database [STORE]    Script Date: 21/03/2022 11:15:29 p. m. ******/
CREATE DATABASE [STORE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'STORE', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\STORE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'STORE_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\STORE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [STORE] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [STORE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [STORE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [STORE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [STORE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [STORE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [STORE] SET ARITHABORT OFF 
GO
ALTER DATABASE [STORE] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [STORE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [STORE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [STORE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [STORE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [STORE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [STORE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [STORE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [STORE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [STORE] SET  DISABLE_BROKER 
GO
ALTER DATABASE [STORE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [STORE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [STORE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [STORE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [STORE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [STORE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [STORE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [STORE] SET RECOVERY FULL 
GO
ALTER DATABASE [STORE] SET  MULTI_USER 
GO
ALTER DATABASE [STORE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [STORE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [STORE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [STORE] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [STORE] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [STORE] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'STORE', N'ON'
GO
ALTER DATABASE [STORE] SET QUERY_STORE = OFF
GO
USE [STORE]
GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 21/03/2022 11:15:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NUMERO_DOCUMENTO] [varchar](20) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[APELLIDO] [varchar](50) NOT NULL,
	[TELEFONO] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_CLIENTE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 21/03/2022 11:15:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](100) NOT NULL,
	[PRECIO] [numeric](8, 0) NOT NULL,
 CONSTRAINT [PK_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPO_DOCUMENTO]    Script Date: 21/03/2022 11:15:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPO_DOCUMENTO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[ABREVIATURA] [varchar](2) NOT NULL,
 CONSTRAINT [PK_TIPO_DOCUMENTO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VENTA]    Script Date: 21/03/2022 11:15:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VENTA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_PRODUCTO] [int] NOT NULL,
	[FK_CLIENTE] [int] NOT NULL,
	[CANTIDAD] [int] NOT NULL,
	[VALOR_TOTAL] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_VENTA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CLIENTE] ON 

INSERT [dbo].[CLIENTE] ([ID], [NUMERO_DOCUMENTO], [NOMBRE], [APELLIDO], [TELEFONO]) VALUES (1, N'1016065874', N'Carlos', N'Quesada', CAST(3124567891 AS Numeric(18, 0)))
INSERT [dbo].[CLIENTE] ([ID], [NUMERO_DOCUMENTO], [NOMBRE], [APELLIDO], [TELEFONO]) VALUES (2, N'51577789', N'Patricia', N'Macias', CAST(3185624753 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[CLIENTE] OFF
GO
SET IDENTITY_INSERT [dbo].[PRODUCTO] ON 

INSERT [dbo].[PRODUCTO] ([ID], [NOMBRE], [PRECIO]) VALUES (1, N'Maleta', CAST(50000 AS Numeric(8, 0)))
INSERT [dbo].[PRODUCTO] ([ID], [NOMBRE], [PRECIO]) VALUES (2, N'Zapatos', CAST(100000 AS Numeric(8, 0)))
INSERT [dbo].[PRODUCTO] ([ID], [NOMBRE], [PRECIO]) VALUES (3, N'Computador', CAST(2000000 AS Numeric(8, 0)))
INSERT [dbo].[PRODUCTO] ([ID], [NOMBRE], [PRECIO]) VALUES (4, N'Audifonos', CAST(20000 AS Numeric(8, 0)))
SET IDENTITY_INSERT [dbo].[PRODUCTO] OFF
GO
SET IDENTITY_INSERT [dbo].[VENTA] ON 

INSERT [dbo].[VENTA] ([ID], [FK_PRODUCTO], [FK_CLIENTE], [CANTIDAD], [VALOR_TOTAL]) VALUES (1, 1, 1, 5, CAST(250000 AS Numeric(18, 0)))
INSERT [dbo].[VENTA] ([ID], [FK_PRODUCTO], [FK_CLIENTE], [CANTIDAD], [VALOR_TOTAL]) VALUES (2, 1, 1, 6, CAST(300000 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[VENTA] OFF
GO
ALTER TABLE [dbo].[VENTA]  WITH CHECK ADD  CONSTRAINT [FK_VENTA_PRODUCTO] FOREIGN KEY([FK_PRODUCTO])
REFERENCES [dbo].[PRODUCTO] ([ID])
GO
ALTER TABLE [dbo].[VENTA] CHECK CONSTRAINT [FK_VENTA_PRODUCTO]
GO
/****** Object:  StoredProcedure [dbo].[PROC_ACTUALIZAR_CLIENTE]    Script Date: 21/03/2022 11:15:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_ACTUALIZAR_CLIENTE] @ID INT, @NUMERO_DOCUMENTO VARCHAR(20), @NOMBRE VARCHAR(50), @APELLIDO VARCHAR(50), @TELEFONO NUMERIC(18,0)
AS
BEGIN
	UPDATE CLIENTE SET NUMERO_DOCUMENTO = @NUMERO_DOCUMENTO, NOMBRE = @NOMBRE, APELLIDO = @APELLIDO, TELEFONO = @TELEFONO
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_ACTUALIZAR_PRODUCTO]    Script Date: 21/03/2022 11:15:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_ACTUALIZAR_PRODUCTO] @ID INT , @NOMBRE VARCHAR(100), @PRECIO NUMERIC(8,0)
AS
BEGIN
	UPDATE PRODUCTO SET NOMBRE = @NOMBRE, PRECIO = @PRECIO
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_CONSULTA_CLIENTE_CODIGO]    Script Date: 21/03/2022 11:15:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_CONSULTA_CLIENTE_CODIGO] @ID INT
AS
BEGIN
	SELECT ID, NUMERO_DOCUMENTO, NOMBRE, APELLIDO, TELEFONO
	FROM CLIENTE
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_CONSULTA_CLIENTES]    Script Date: 21/03/2022 11:15:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_CONSULTA_CLIENTES]
AS
BEGIN
	SELECT ID, NUMERO_DOCUMENTO, NOMBRE, APELLIDO, TELEFONO
	FROM CLIENTE
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_CONSULTA_PRODUCTO_CODIGO]    Script Date: 21/03/2022 11:15:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_CONSULTA_PRODUCTO_CODIGO] @ID INT
AS
BEGIN
	SELECT ID, NOMBRE, PRECIO
	FROM PRODUCTO
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_CONSULTA_PRODUCTOS]    Script Date: 21/03/2022 11:15:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_CONSULTA_PRODUCTOS]
AS
BEGIN
	SELECT ID, NOMBRE, PRECIO
	FROM PRODUCTO
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_CONSULTAR_VENTAS]    Script Date: 21/03/2022 11:15:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_CONSULTAR_VENTAS] 
AS
BEGIN
	SELECT VE.ID, PR.ID, PR.NOMBRE, PR.PRECIO, CL.ID, CL.NUMERO_DOCUMENTO, CL.NOMBRE, CL.APELLIDO, CL.TELEFONO, VE.CANTIDAD, VE.VALOR_TOTAL
	FROM VENTA VE
	JOIN PRODUCTO PR ON VE.FK_PRODUCTO = PR.ID 
	JOIN CLIENTE CL ON VE.FK_CLIENTE= CL.ID 
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_CREAR_CLIENTE]    Script Date: 21/03/2022 11:15:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_CREAR_CLIENTE] @NUMERO_DOCUMENTO VARCHAR(20), @NOMBRE VARCHAR(50), @APELLIDO VARCHAR(50), @TELEFONO NUMERIC(18,0)
AS
BEGIN
	INSERT INTO CLIENTE (NUMERO_DOCUMENTO, NOMBRE, APELLIDO, TELEFONO)
	VALUES (@NUMERO_DOCUMENTO, @NOMBRE, @APELLIDO, @TELEFONO)
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_CREAR_PRODUCTO]    Script Date: 21/03/2022 11:15:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_CREAR_PRODUCTO] @NOMBRE VARCHAR(100), @PRECIO NUMERIC(8,0)
AS
BEGIN
	INSERT INTO PRODUCTO (NOMBRE, PRECIO)
	VALUES (@NOMBRE, @PRECIO)
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_ELIMINAR_CLIENTE]    Script Date: 21/03/2022 11:15:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_ELIMINAR_CLIENTE] @ID INT
AS
BEGIN
	DELETE 
	FROM CLIENTE
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_ELIMINAR_PRODUCTO]    Script Date: 21/03/2022 11:15:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_ELIMINAR_PRODUCTO] @ID INT
AS
BEGIN
	DELETE 
	FROM PRODUCTO
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_GUARDAR_VENTA]    Script Date: 21/03/2022 11:15:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_GUARDAR_VENTA] @ID_PRODUCTO INT, @ID_CLIENTE INT, @CANTIDAD INT, @VALOR_TOTAL NUMERIC(18,0)
AS
BEGIN
	INSERT INTO VENTA (FK_PRODUCTO, FK_CLIENTE, CANTIDAD,VALOR_TOTAL)
	VALUES (@ID_PRODUCTO, @ID_CLIENTE, @CANTIDAD, @VALOR_TOTAL)
END
GO
USE [master]
GO
ALTER DATABASE [STORE] SET  READ_WRITE 
GO
