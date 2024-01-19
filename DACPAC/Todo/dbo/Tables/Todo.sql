CREATE TABLE [dbo].[Todo] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [taskName]     VARCHAR (50)     NULL,
    [taskStatus]   VARCHAR (50)     DEFAULT ('NotCompleted') NULL,
    [note]         VARCHAR (50)     NULL,
    [priorityFlag] VARCHAR (5)      DEFAULT ('Low') NULL,
    [due]          DATETIME         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_PriorityFlag_Valid] CHECK ([priorityFlag]='High' OR [priorityFlag]='Low'),
    CONSTRAINT [CK_Status_Valid] CHECK ([taskStatus]='Completed' OR [taskStatus]='NotCompleted')
);

