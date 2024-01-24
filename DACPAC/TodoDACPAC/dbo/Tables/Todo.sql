CREATE TABLE [dbo].[Todo] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [taskName]     VARCHAR (50)     NOT NULL,
    [taskStatus]   VARCHAR (50)     DEFAULT ('NotCompleted') NULL,
    [note]         VARCHAR (50)     NULL,
    [priorityFlag] VARCHAR (5)      DEFAULT ('Low') NULL,
    [createdAt]    DATE             NULL,
    [Due]          VARCHAR (10)     DEFAULT ('Today') NULL,
    [categoryId]   UNIQUEIDENTIFIER NULL,
    [userId]       UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_NewColumn_Valid] CHECK ([Due]='Tomorrow' OR [Due]='Today'),
    CONSTRAINT [CK_PriorityFlag_Valid] CHECK ([priorityFlag]='High' OR [priorityFlag]='Low'),
    CONSTRAINT [CK_Status_Valid] CHECK ([taskStatus]='Completed' OR [taskStatus]='NotCompleted'),
    CONSTRAINT [FK_Todo_Category] FOREIGN KEY ([categoryId]) REFERENCES [dbo].[Category] ([Id]),
    CONSTRAINT [FK_Todo_User] FOREIGN KEY ([userId]) REFERENCES [dbo].[User] ([Id])
);

