CREATE TABLE [dbo].[Categorie] (
    [CategoryId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([CategoryId] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC)
);

