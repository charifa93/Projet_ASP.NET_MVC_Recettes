CREATE TABLE [dbo].[Ingredient] (
    [IngredientId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([IngredientId] ASC),
    CHECK (len([Name])>=(2)),
    UNIQUE NONCLUSTERED ([Name] ASC)
);

