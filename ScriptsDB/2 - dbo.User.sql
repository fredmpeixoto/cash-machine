USE [BANK]
GO

/****** Object: Table [dbo].[User] Script Date: 17/09/2019 15:19:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Name]     NVARCHAR (MAX)   NULL,
    [Cpf]      VARCHAR (11)     NOT NULL,
    [Email]    VARCHAR (200)    NULL,
    [Password] NVARCHAR (MAX)   NULL
);


