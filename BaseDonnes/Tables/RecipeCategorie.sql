CREATE TABLE [dbo].[RecipeCategorie] (
    [RecipeId]   INT NOT NULL,
    [CategoryId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([RecipeId] ASC, [CategoryId] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categorie] ([CategoryId]) ON DELETE CASCADE,
    FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipe] ([RecipeId]) ON DELETE CASCADE
);

