USE [BANK]
GO

/****** Object: Table [dbo].[Account] Script Date: 17/09/2019 15:19:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Account] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [UserId]     UNIQUEIDENTIFIER NOT NULL,
    [Balance]    FLOAT (53)       NOT NULL,
    [DataRemove] DATETIME2 (7)    NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_Account_UserId]
    ON [dbo].[Account]([UserId] ASC);


GO
ALTER TABLE [dbo].[Account]
    ADD CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([Id] ASC);


GO
ALTER TABLE [dbo].[Account]
    ADD CONSTRAINT [FK_Account_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE;


