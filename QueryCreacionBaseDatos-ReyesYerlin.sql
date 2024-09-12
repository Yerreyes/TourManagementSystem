Create database [MisMinistros117890445]
go

USE [MisMinistros117890445]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/12/2022 09:07:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 2/12/2022 09:07:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Cedula] [nvarchar](450) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[FechaNacimiento] [int] NOT NULL,
	[Telefono] [nvarchar](max) NOT NULL,
	[Profesion] [nvarchar](max) NOT NULL,
	[Correo] [nvarchar](max) NOT NULL,
	[Entero] [nvarchar](max) NOT NULL,
	[Contrasenna] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 2/12/2022 09:07:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[IdFactura] [nvarchar](450) NOT NULL,
	[ClienteIdentificacion] [nvarchar](450) NOT NULL,
	[Fecha] [nvarchar](max) NOT NULL,
	[EsEliminado] [bit] NOT NULL,
	[precioConIva] [float] NOT NULL,
	[precioSinIva] [float] NOT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturaIntermedia]    Script Date: 2/12/2022 09:07:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaIntermedia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FacturaId] [nvarchar](450) NOT NULL,
	[ProductoId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_FacturaIntermedia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturaTour]    Script Date: 2/12/2022 09:07:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaTour](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FacturaId] [nvarchar](450) NOT NULL,
	[TourId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_FacturaTour] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 2/12/2022 09:07:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[id] [nvarchar](450) NOT NULL,
	[descripcion] [nvarchar](max) NOT NULL,
	[annoIngreso] [int] NOT NULL,
	[precio] [int] NOT NULL,
	[utilidad] [int] NOT NULL,
	[IdProveedor] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 2/12/2022 09:07:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[IdProveedor] [nvarchar](450) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tour]    Script Date: 2/12/2022 09:07:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour](
	[Id] [nvarchar](450) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Imagen] [nvarchar](max) NOT NULL,
	[dias] [nvarchar](max) NOT NULL,
	[Precio] [int] NOT NULL,
	[IdProveedor] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Tour] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221202122610_initial', N'7.0.0')
GO
INSERT [dbo].[Cliente] ([Cedula], [Nombre], [FechaNacimiento], [Telefono], [Profesion], [Correo], [Entero], [Contrasenna]) VALUES (N'01-1199-9988', N'Mrlon montero', 1998, N'8652-3212', N'mecanico autos', N'dfcvvc@gmail.com', N'Por un amigo', N'dfcxvcxvxccvx#sd')
GO
INSERT [dbo].[Cliente] ([Cedula], [Nombre], [FechaNacimiento], [Telefono], [Profesion], [Correo], [Entero], [Contrasenna]) VALUES (N'01-1199-9999', N'yerlin reyes', 2000, N'8652-3212', N'mecanico autos', N'yervdflin@gmail.com', N'Por un amigo', N'yer1reyes@')
GO
INSERT [dbo].[Factura] ([IdFactura], [ClienteIdentificacion], [Fecha], [EsEliminado], [precioConIva], [precioSinIva]) VALUES (N'Factaa630', N'01-1199-9999', N'2', 0, 87010, 77000)
GO
INSERT [dbo].[Factura] ([IdFactura], [ClienteIdentificacion], [Fecha], [EsEliminado], [precioConIva], [precioSinIva]) VALUES (N'Factaa774', N'01-1199-9999', N'23', 0, 21470, 19000)
GO
SET IDENTITY_INSERT [dbo].[FacturaIntermedia] ON 
GO
INSERT [dbo].[FacturaIntermedia] ([id], [FacturaId], [ProductoId]) VALUES (27, N'Factaa774', N'Priii-77115831')
GO
INSERT [dbo].[FacturaIntermedia] ([id], [FacturaId], [ProductoId]) VALUES (28, N'Factaa630', N'Priii-77115831')
GO
INSERT [dbo].[FacturaIntermedia] ([id], [FacturaId], [ProductoId]) VALUES (29, N'Factaa630', N'Priii-77115831')
GO
INSERT [dbo].[FacturaIntermedia] ([id], [FacturaId], [ProductoId]) VALUES (30, N'Factaa630', N'Priii-77115831')
GO
INSERT [dbo].[FacturaIntermedia] ([id], [FacturaId], [ProductoId]) VALUES (31, N'Factaa630', N'Priii-77115831')
GO
INSERT [dbo].[FacturaIntermedia] ([id], [FacturaId], [ProductoId]) VALUES (32, N'Factaa630', N'Priii-77115831')
GO
SET IDENTITY_INSERT [dbo].[FacturaIntermedia] OFF
GO
SET IDENTITY_INSERT [dbo].[FacturaTour] ON 
GO
INSERT [dbo].[FacturaTour] ([Id], [FacturaId], [TourId]) VALUES (27, N'Factaa774', N'Tourxx-47165563')
GO
INSERT [dbo].[FacturaTour] ([Id], [FacturaId], [TourId]) VALUES (28, N'Factaa774', N'Tourxx-47165563')
GO
INSERT [dbo].[FacturaTour] ([Id], [FacturaId], [TourId]) VALUES (29, N'Factaa630', N'Tourxx-47165563')
GO
SET IDENTITY_INSERT [dbo].[FacturaTour] OFF
GO
INSERT [dbo].[Producto] ([id], [descripcion], [annoIngreso], [precio], [utilidad], [IdProveedor]) VALUES (N'Priii-17922941', N'traje de bano', 2018, 15500, 1200, N'01-1111-2341')
GO
INSERT [dbo].[Producto] ([id], [descripcion], [annoIngreso], [precio], [utilidad], [IdProveedor]) VALUES (N'Priii-77115831', N'sombres de colores', 2019, 15000, 100, N'01-1111-2341')
GO
INSERT [dbo].[Proveedor] ([IdProveedor], [Descripcion]) VALUES (N'01-1111-2341', N'Provedor tour y productos de playa')
GO
INSERT [dbo].[Proveedor] ([IdProveedor], [Descripcion]) VALUES (N'02-2222-0202', N'proveedor de mannnzanas')
GO
INSERT [dbo].[Tour] ([Id], [Descripcion], [Imagen], [dias], [Precio], [IdProveedor]) VALUES (N'Tourxx-47165563', N'proveedro de laipies', N'd', N'Lunes a Viernes', 2000, N'02-2222-0202')
GO
INSERT [dbo].[Tour] ([Id], [Descripcion], [Imagen], [dias], [Precio], [IdProveedor]) VALUES (N'Tourxx-8045239', N'viaaje al pantano', N'd', N'Lunes a Viernes', 55000, N'01-1111-2341')
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente_CedulaCliente] FOREIGN KEY([ClienteIdentificacion])
REFERENCES [dbo].[Cliente] ([Cedula])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente_CedulaCliente]
GO
ALTER TABLE [dbo].[FacturaIntermedia]  WITH CHECK ADD  CONSTRAINT [FK_FacturaIntermedia_Factura_FacturaId] FOREIGN KEY([FacturaId])
REFERENCES [dbo].[Factura] ([IdFactura])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FacturaIntermedia] CHECK CONSTRAINT [FK_FacturaIntermedia_Factura_FacturaId]
GO
ALTER TABLE [dbo].[FacturaIntermedia]  WITH CHECK ADD  CONSTRAINT [FK_FacturaIntermedia_Producto_ProductoId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FacturaIntermedia] CHECK CONSTRAINT [FK_FacturaIntermedia_Producto_ProductoId]
GO
ALTER TABLE [dbo].[FacturaTour]  WITH CHECK ADD  CONSTRAINT [FK_FacturaTour_Factura_FacturaId] FOREIGN KEY([FacturaId])
REFERENCES [dbo].[Factura] ([IdFactura])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FacturaTour] CHECK CONSTRAINT [FK_FacturaTour_Factura_FacturaId]
GO
ALTER TABLE [dbo].[FacturaTour]  WITH CHECK ADD  CONSTRAINT [FK_FacturaTour_Tour_TourId] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tour] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FacturaTour] CHECK CONSTRAINT [FK_FacturaTour_Tour_TourId]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Proveedor_IdProveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Proveedor_IdProveedor]
GO
ALTER TABLE [dbo].[Tour]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Proveedor_IdProveedorT] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tour] CHECK CONSTRAINT [FK_Tour_Proveedor_IdProveedorT]
GO
