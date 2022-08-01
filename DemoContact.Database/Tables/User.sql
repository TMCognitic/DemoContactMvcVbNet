CREATE TABLE [dbo].[User] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Email]  NVARCHAR (384) NOT NULL,
    [Passwd] BINARY (64)    NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UK_User_Email] UNIQUE NONCLUSTERED ([Email] ASC)
);

