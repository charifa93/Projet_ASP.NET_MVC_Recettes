CREATE TABLE [dbo].[User] (
    [UserId]    INT              IDENTITY (1, 1) NOT NULL,
    [Username]  NVARCHAR (50)    NOT NULL,
    [Email]     NVARCHAR (100)   NOT NULL,
    [Password]  VARBINARY (64)   NOT NULL,
    [Salt]      UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt] DATETIME         DEFAULT (getdate()) NULL,
    [RoleName]  NVARCHAR (8)     DEFAULT ('User') NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([RoleName]) REFERENCES [dbo].[Role] ([RoleName]) ON DELETE CASCADE,
    UNIQUE NONCLUSTERED ([Email] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC)
);

