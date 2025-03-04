CREATE TABLE [dbo].[Favoris] (
    [UserId]    INT      NOT NULL,
    [RecipeId]  INT      NOT NULL,
    [CreatedAt] DATETIME DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC, [RecipeId] ASC),
    FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipe] ([RecipeId]),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

