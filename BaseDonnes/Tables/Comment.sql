CREATE TABLE [dbo].[Comment] (
    [CommentId]   INT            IDENTITY (1, 1) NOT NULL,
    [RecipeId]    INT            NOT NULL,
    [UserId]      INT            NOT NULL,
    [CommentText] NVARCHAR (500) NOT NULL,
    [CreatedAt]   DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([CommentId] ASC),
    CHECK (len([CommentText])>(2)),
    FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipe] ([RecipeId]) ON DELETE CASCADE,
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

