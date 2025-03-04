CREATE TABLE [dbo].[Recipe] (
    [RecipeId]     INT            IDENTITY (1, 1) NOT NULL,
    [UserId]       INT            NOT NULL,
    [Title]        NVARCHAR (100) NOT NULL,
    [Description]  NVARCHAR (500) NULL,
    [Instructions] NVARCHAR (MAX) NOT NULL,
    [CreatedAt]    DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([RecipeId] ASC),
    CHECK (len([Title])>=(3)),
    CONSTRAINT [FK_Recipe_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE CASCADE
);

