CREATE TABLE [dbo].[Category] (
    [Id]       UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [category] VARCHAR (25)     NULL,
    [userId]   UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_Category_Name_Not_Null] CHECK ([category] IS NOT NULL),
    FOREIGN KEY ([userId]) REFERENCES [dbo].[User] ([Id])
);

