
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/20/2021 18:17:10
-- Generated from EDMX file: C:\Users\fisio\Documents\e-commerce\allforcamping\AllforCamping\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [allforcamping];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_compras_Toproducto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[compras] DROP CONSTRAINT [FK_compras_Toproducto];
GO
IF OBJECT_ID(N'[dbo].[FK_compras_Toproveedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[compras] DROP CONSTRAINT [FK_compras_Toproveedor];
GO
IF OBJECT_ID(N'[dbo].[FK_detalle_venta_Producto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[detalle_venta] DROP CONSTRAINT [FK_detalle_venta_Producto];
GO
IF OBJECT_ID(N'[dbo].[FK_detalle_venta_venta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[detalle_venta] DROP CONSTRAINT [FK_detalle_venta_venta];
GO
IF OBJECT_ID(N'[dbo].[FK_direcciones_usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[direcciones] DROP CONSTRAINT [FK_direcciones_usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_productos_ToTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[productos] DROP CONSTRAINT [FK_productos_ToTable];
GO
IF OBJECT_ID(N'[dbo].[FK_subcategorias_categorias]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[subcategorias] DROP CONSTRAINT [FK_subcategorias_categorias];
GO
IF OBJECT_ID(N'[dbo].[FK_tarjetas_usuarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tarjetas] DROP CONSTRAINT [FK_tarjetas_usuarios];
GO
IF OBJECT_ID(N'[dbo].[FK_ventas_paqueteria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ventas] DROP CONSTRAINT [FK_ventas_paqueteria];
GO
IF OBJECT_ID(N'[dbo].[FK_ventas_usuarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ventas] DROP CONSTRAINT [FK_ventas_usuarios];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[categorias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[categorias];
GO
IF OBJECT_ID(N'[dbo].[compras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[compras];
GO
IF OBJECT_ID(N'[dbo].[detalle_venta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[detalle_venta];
GO
IF OBJECT_ID(N'[dbo].[direcciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[direcciones];
GO
IF OBJECT_ID(N'[dbo].[empleados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[empleados];
GO
IF OBJECT_ID(N'[dbo].[paqueterias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[paqueterias];
GO
IF OBJECT_ID(N'[dbo].[productos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[productos];
GO
IF OBJECT_ID(N'[dbo].[proveedores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[proveedores];
GO
IF OBJECT_ID(N'[dbo].[subcategorias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[subcategorias];
GO
IF OBJECT_ID(N'[dbo].[tarjetas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tarjetas];
GO
IF OBJECT_ID(N'[dbo].[usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[usuarios];
GO
IF OBJECT_ID(N'[dbo].[ventas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ventas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'categorias'
CREATE TABLE [dbo].[categorias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nchar(10)  NOT NULL
);
GO

-- Creating table 'compras'
CREATE TABLE [dbo].[compras] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [proveedor] int  NULL,
    [producto] int  NULL,
    [cantidad] int  NULL,
    [total] float  NULL,
    [status] nchar(10)  NULL
);
GO

-- Creating table 'detalle_venta'
CREATE TABLE [dbo].[detalle_venta] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [producto] int  NOT NULL,
    [venta] int  NOT NULL,
    [cantidad] int  NOT NULL,
    [subtotal] int  NOT NULL
);
GO

-- Creating table 'direcciones'
CREATE TABLE [dbo].[direcciones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [usuario] int  NULL,
    [calle] nchar(10)  NOT NULL,
    [colonia] nchar(10)  NOT NULL,
    [municipio] nchar(10)  NOT NULL,
    [estado] nchar(10)  NOT NULL,
    [telefono] int  NOT NULL,
    [cp] int  NOT NULL
);
GO

-- Creating table 'empleados'
CREATE TABLE [dbo].[empleados] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nchar(10)  NOT NULL,
    [app] nchar(10)  NOT NULL,
    [apm] nchar(10)  NOT NULL,
    [area] nchar(10)  NOT NULL,
    [email] nchar(10)  NOT NULL,
    [pass] nchar(10)  NOT NULL
);
GO

-- Creating table 'paqueterias'
CREATE TABLE [dbo].[paqueterias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nchar(10)  NULL,
    [precio] float  NULL
);
GO

-- Creating table 'productos'
CREATE TABLE [dbo].[productos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nchar(10)  NOT NULL,
    [stock] int  NULL,
    [categoria] int  NOT NULL,
    [precio_compra] float  NOT NULL,
    [precio_venta] float  NOT NULL,
    [descripcion] varchar(max)  NOT NULL,
    [foto] nchar(10)  NULL
);
GO

-- Creating table 'proveedores'
CREATE TABLE [dbo].[proveedores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nchar(10)  NULL,
    [telefono] nchar(10)  NULL,
    [correo] nchar(10)  NULL
);
GO

-- Creating table 'subcategorias'
CREATE TABLE [dbo].[subcategorias] (
    [Id] int  NOT NULL,
    [nombre] nchar(100)  NULL,
    [categoria] int  NULL
);
GO

-- Creating table 'tarjetas'
CREATE TABLE [dbo].[tarjetas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre_cliente] nchar(40)  NULL,
    [usuario] int  NULL,
    [numero] int  NULL,
    [cvv] int  NULL,
    [fecha_vencimiento] nchar(10)  NULL
);
GO

-- Creating table 'usuarios'
CREATE TABLE [dbo].[usuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(80)  NOT NULL,
    [ap_pat] varchar(80)  NOT NULL,
    [ap_mat] varchar(80)  NOT NULL,
    [email] varchar(80)  NOT NULL,
    [telefono] varchar(20)  NOT NULL,
    [username] varchar(80)  NOT NULL,
    [pass] varchar(80)  NOT NULL,
    [calle] varchar(100)  NOT NULL,
    [cp] int  NOT NULL,
    [numext] int  NOT NULL,
    [colonia] varchar(80)  NOT NULL
);
GO

-- Creating table 'ventas'
CREATE TABLE [dbo].[ventas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [fecha] datetime  NOT NULL,
    [total] float  NOT NULL,
    [usuario] int  NOT NULL,
    [pago] nchar(10)  NOT NULL,
    [guia] nchar(10)  NULL,
    [fecha_envio] nchar(10)  NULL,
    [fecha_entrega] nchar(10)  NULL,
    [paqueteria] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'categorias'
ALTER TABLE [dbo].[categorias]
ADD CONSTRAINT [PK_categorias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'compras'
ALTER TABLE [dbo].[compras]
ADD CONSTRAINT [PK_compras]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'detalle_venta'
ALTER TABLE [dbo].[detalle_venta]
ADD CONSTRAINT [PK_detalle_venta]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'direcciones'
ALTER TABLE [dbo].[direcciones]
ADD CONSTRAINT [PK_direcciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'empleados'
ALTER TABLE [dbo].[empleados]
ADD CONSTRAINT [PK_empleados]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'paqueterias'
ALTER TABLE [dbo].[paqueterias]
ADD CONSTRAINT [PK_paqueterias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'productos'
ALTER TABLE [dbo].[productos]
ADD CONSTRAINT [PK_productos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'proveedores'
ALTER TABLE [dbo].[proveedores]
ADD CONSTRAINT [PK_proveedores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'subcategorias'
ALTER TABLE [dbo].[subcategorias]
ADD CONSTRAINT [PK_subcategorias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tarjetas'
ALTER TABLE [dbo].[tarjetas]
ADD CONSTRAINT [PK_tarjetas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'usuarios'
ALTER TABLE [dbo].[usuarios]
ADD CONSTRAINT [PK_usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ventas'
ALTER TABLE [dbo].[ventas]
ADD CONSTRAINT [PK_ventas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [categoria] in table 'productos'
ALTER TABLE [dbo].[productos]
ADD CONSTRAINT [FK_productos_ToTable]
    FOREIGN KEY ([categoria])
    REFERENCES [dbo].[categorias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_productos_ToTable'
CREATE INDEX [IX_FK_productos_ToTable]
ON [dbo].[productos]
    ([categoria]);
GO

-- Creating foreign key on [Id] in table 'subcategorias'
ALTER TABLE [dbo].[subcategorias]
ADD CONSTRAINT [FK_subcategorias_categorias]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[categorias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [producto] in table 'compras'
ALTER TABLE [dbo].[compras]
ADD CONSTRAINT [FK_compras_Toproducto]
    FOREIGN KEY ([producto])
    REFERENCES [dbo].[productos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_compras_Toproducto'
CREATE INDEX [IX_FK_compras_Toproducto]
ON [dbo].[compras]
    ([producto]);
GO

-- Creating foreign key on [proveedor] in table 'compras'
ALTER TABLE [dbo].[compras]
ADD CONSTRAINT [FK_compras_Toproveedor]
    FOREIGN KEY ([proveedor])
    REFERENCES [dbo].[proveedores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_compras_Toproveedor'
CREATE INDEX [IX_FK_compras_Toproveedor]
ON [dbo].[compras]
    ([proveedor]);
GO

-- Creating foreign key on [producto] in table 'detalle_venta'
ALTER TABLE [dbo].[detalle_venta]
ADD CONSTRAINT [FK_detalle_venta_Producto]
    FOREIGN KEY ([producto])
    REFERENCES [dbo].[productos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_detalle_venta_Producto'
CREATE INDEX [IX_FK_detalle_venta_Producto]
ON [dbo].[detalle_venta]
    ([producto]);
GO

-- Creating foreign key on [venta] in table 'detalle_venta'
ALTER TABLE [dbo].[detalle_venta]
ADD CONSTRAINT [FK_detalle_venta_venta]
    FOREIGN KEY ([venta])
    REFERENCES [dbo].[ventas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_detalle_venta_venta'
CREATE INDEX [IX_FK_detalle_venta_venta]
ON [dbo].[detalle_venta]
    ([venta]);
GO

-- Creating foreign key on [usuario] in table 'direcciones'
ALTER TABLE [dbo].[direcciones]
ADD CONSTRAINT [FK_direcciones_usuario]
    FOREIGN KEY ([usuario])
    REFERENCES [dbo].[usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_direcciones_usuario'
CREATE INDEX [IX_FK_direcciones_usuario]
ON [dbo].[direcciones]
    ([usuario]);
GO

-- Creating foreign key on [paqueteria] in table 'ventas'
ALTER TABLE [dbo].[ventas]
ADD CONSTRAINT [FK_ventas_paqueteria]
    FOREIGN KEY ([paqueteria])
    REFERENCES [dbo].[paqueterias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ventas_paqueteria'
CREATE INDEX [IX_FK_ventas_paqueteria]
ON [dbo].[ventas]
    ([paqueteria]);
GO

-- Creating foreign key on [usuario] in table 'tarjetas'
ALTER TABLE [dbo].[tarjetas]
ADD CONSTRAINT [FK_tarjetas_usuarios]
    FOREIGN KEY ([usuario])
    REFERENCES [dbo].[usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tarjetas_usuarios'
CREATE INDEX [IX_FK_tarjetas_usuarios]
ON [dbo].[tarjetas]
    ([usuario]);
GO

-- Creating foreign key on [usuario] in table 'ventas'
ALTER TABLE [dbo].[ventas]
ADD CONSTRAINT [FK_ventas_usuarios]
    FOREIGN KEY ([usuario])
    REFERENCES [dbo].[usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ventas_usuarios'
CREATE INDEX [IX_FK_ventas_usuarios]
ON [dbo].[ventas]
    ([usuario]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------