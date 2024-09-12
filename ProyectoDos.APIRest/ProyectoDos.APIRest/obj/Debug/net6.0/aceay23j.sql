IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Cliente] (
    [Cedula] nvarchar(450) NOT NULL,
    [Nombre] nvarchar(max) NOT NULL,
    [FechaNacimiento] int NOT NULL,
    [Telefono] nvarchar(max) NOT NULL,
    [Profesion] nvarchar(max) NOT NULL,
    [Correo] nvarchar(max) NOT NULL,
    [Entero] nvarchar(max) NOT NULL,
    [Contrasenna] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([Cedula])
);
GO

CREATE TABLE [Factura] (
    [IdFactura] nvarchar(450) NOT NULL,
    [Fecha] nvarchar(max) NOT NULL,
    [EsEliminado] bit NOT NULL,
    [precioConIva] float NOT NULL,
    [precioSinIva] float NOT NULL,
    CONSTRAINT [PK_Factura] PRIMARY KEY ([IdFactura])
);
GO

CREATE TABLE [Producto] (
    [id] nvarchar(450) NOT NULL,
    [descripcion] nvarchar(max) NOT NULL,
    [annoIngreso] int NOT NULL,
    [precio] int NOT NULL,
    [utilidad] int NOT NULL,
    [IdProveedor] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Producto] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Proveedor] (
    [IdProveedor] nvarchar(450) NOT NULL,
    [Descripcion] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Proveedor] PRIMARY KEY ([IdProveedor])
);
GO

CREATE TABLE [Tour] (
    [Id] nvarchar(450) NOT NULL,
    [Descripcion] nvarchar(max) NOT NULL,
    [Imagen] nvarchar(max) NOT NULL,
    [dias] nvarchar(max) NOT NULL,
    [Precio] int NOT NULL,
    [IdProveedor] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Tour] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [FacturaIntermedia] (
    [id] int NOT NULL IDENTITY,
    [FacturaId] nvarchar(450) NOT NULL,
    [ProductoId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_FacturaIntermedia] PRIMARY KEY ([id]),
    CONSTRAINT [FK_FacturaIntermedia_Factura_FacturaId] FOREIGN KEY ([FacturaId]) REFERENCES [Factura] ([IdFactura]) ON DELETE CASCADE,
    CONSTRAINT [FK_FacturaIntermedia_Producto_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Producto] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [FacturaTour] (
    [Id] int NOT NULL IDENTITY,
    [FacturaId] nvarchar(450) NOT NULL,
    [TourId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_FacturaTour] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_FacturaTour_Factura_FacturaId] FOREIGN KEY ([FacturaId]) REFERENCES [Factura] ([IdFactura]) ON DELETE CASCADE,
    CONSTRAINT [FK_FacturaTour_Tour_TourId] FOREIGN KEY ([TourId]) REFERENCES [Tour] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_FacturaIntermedia_FacturaId] ON [FacturaIntermedia] ([FacturaId]);
GO

CREATE INDEX [IX_FacturaIntermedia_ProductoId] ON [FacturaIntermedia] ([ProductoId]);
GO

CREATE INDEX [IX_FacturaTour_FacturaId] ON [FacturaTour] ([FacturaId]);
GO

CREATE INDEX [IX_FacturaTour_TourId] ON [FacturaTour] ([TourId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221129055555_initial', N'7.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [FacturaTour] DROP CONSTRAINT [FK_FacturaTour_Producto_TourId];
GO

ALTER TABLE [FacturaTour] ADD CONSTRAINT [FK_FacturaTour_Tour_TourId] FOREIGN KEY ([TourId]) REFERENCES [Tour] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221129060857_initialv1', N'7.0.0');
GO

COMMIT;
GO

