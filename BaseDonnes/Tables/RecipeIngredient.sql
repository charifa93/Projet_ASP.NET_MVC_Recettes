CREATE TABLE [dbo].[RecipeIngredient] (
    [RecipeId]     INT           NOT NULL,
    [IngredientId] INT           NOT NULL,
    [Quantity]     NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([RecipeId] ASC, [IngredientId] ASC),
    CHECK (len([Quantity])>(0)),
    FOREIGN KEY ([IngredientId]) REFERENCES [dbo].[Ingredient] ([IngredientId]) ON DELETE CASCADE,
    FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipe] ([RecipeId]) ON DELETE CASCADE
);

