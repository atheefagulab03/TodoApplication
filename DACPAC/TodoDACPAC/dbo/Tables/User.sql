CREATE TABLE [dbo].[User] (
    [Id]       UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [userName] VARCHAR (50)     NULL,
    [email]    VARCHAR (255)    NOT NULL,
    [password] VARCHAR (255)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([email] like '%_@__%.__%'),
    CONSTRAINT [CK_Password_Length] CHECK (len([password])>=(6)),
    CONSTRAINT [CK_UserName_Not_Null] CHECK ([userName] IS NOT NULL),
    UNIQUE NONCLUSTERED ([email] ASC)
);

