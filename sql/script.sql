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

CREATE TABLE [Cidade] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(100) NOT NULL,
    [UF] varchar(2) NOT NULL,
    CONSTRAINT [PK_Cidade] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Pessoa] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NOT NULL,
    [CPF] varchar(11) NOT NULL,
    [Idade] int NOT NULL,
    [Id_Cidade] int NOT NULL,
    CONSTRAINT [PK_Pessoa] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pessoa_Cidade_Id_Cidade] FOREIGN KEY ([Id_Cidade]) REFERENCES [Cidade] ([Id])
);
GO

CREATE INDEX [IX_Pessoa_Id_Cidade] ON [Pessoa] ([Id_Cidade]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220525134500_Initial', N'6.0.5');
GO

COMMIT;
GO

