
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/12/2019 23:55:09
-- Generated from EDMX file: E:\My Projects\Nour El-7abib Company\Nour El-7abib Company\Nour El-7abib Company\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Nour El-Habib Company DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Payment__Custome__6FE99F9F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Payment] DROP CONSTRAINT [FK__Payment__Custome__6FE99F9F];
GO
IF OBJECT_ID(N'[dbo].[FK__Quantity__Custom__66603565]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Quantity] DROP CONSTRAINT [FK__Quantity__Custom__66603565];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Account]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Account];
GO
IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO
IF OBJECT_ID(N'[dbo].[Payment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Payment];
GO
IF OBJECT_ID(N'[dbo].[Quantity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Quantity];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Quantities'
CREATE TABLE [dbo].[Quantities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NULL,
    [Quantity1] int  NOT NULL,
    [Weight] float  NOT NULL,
    [TotalWeight] float  NOT NULL,
    [Price] float  NOT NULL,
    [TotalPrice] float  NOT NULL,
    [CustomerId] int  NOT NULL,
    [Charge] float  NOT NULL,
    [Notes] nvarchar(max)  NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Payments'
CREATE TABLE [dbo].[Payments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Money] float  NOT NULL,
    [Date] datetime  NOT NULL,
    [CustomerId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Quantities'
ALTER TABLE [dbo].[Quantities]
ADD CONSTRAINT [PK_Quantities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [PK_Payments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerId] in table 'Quantities'
ALTER TABLE [dbo].[Quantities]
ADD CONSTRAINT [FK__Quantity__Custom__66603565]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Quantity__Custom__66603565'
CREATE INDEX [IX_FK__Quantity__Custom__66603565]
ON [dbo].[Quantities]
    ([CustomerId]);
GO

-- Creating foreign key on [CustomerId] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [FK__Payment__Custome__6FE99F9F]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Payment__Custome__6FE99F9F'
CREATE INDEX [IX_FK__Payment__Custome__6FE99F9F]
ON [dbo].[Payments]
    ([CustomerId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------