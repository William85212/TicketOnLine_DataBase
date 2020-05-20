CREATE TABLE [dbo].[DateEvent]
(
	[Id] INT NOT NULL, 
    [date] DATETIME2 NOT NULL, 
    [IdEvent] INT NOT NULL, 
    CONSTRAINT [PK_DateEvent] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_DateEvent_Event] FOREIGN KEY ([IdEvent]) REFERENCES [Event]([Id]) 
)
