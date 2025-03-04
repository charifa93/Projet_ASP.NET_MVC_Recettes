CREATE TABLE [dbo].[Note] (
    [RatingId]    INT      IDENTITY (1, 1) NOT NULL,
    [RecipeId]    INT      NOT NULL,
    [UserId]      INT      NOT NULL,
    [RatingValue] INT      NULL,
    [CreatedAt]   DATETIME DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([RatingId] ASC),
    CHECK ([RatingValue]>=(1) AND [RatingValue]<=(5)),
    FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipe] ([RecipeId]) ON DELETE CASCADE,
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

