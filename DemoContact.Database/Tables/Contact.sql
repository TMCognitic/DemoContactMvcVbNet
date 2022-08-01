CREATE TABLE [dbo].[Contact] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [LastName]  NVARCHAR (50)  NOT NULL,
    [FirstName] NVARCHAR (50)  NOT NULL,
    [BirthDay]  DATE           NOT NULL,
    [Email]     NVARCHAR (384) NOT NULL,
    [Phone]     NVARCHAR (20)  NULL,
    [UserId]    INT            NOT NULL,
    [IsDeleted] BIT            CONSTRAINT [DF_User_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [CK_Contact_BirthDay] CHECK (datepart(year,[BirthDay])>(1930)),
    CONSTRAINT [FK_Contact_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Contact_UserId]
    ON [dbo].[Contact]([UserId] ASC);


GO

CREATE TRIGGER [dbo].[TR_IO_Delete]
    ON [dbo].[Contact]
    INSTEAD OF DELETE
    AS
    BEGIN
        UPDATE Contact SET IsDeleted = 1 WHERE Id in (SELECT Id From Deleted)
    END