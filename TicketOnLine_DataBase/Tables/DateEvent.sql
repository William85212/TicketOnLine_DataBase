CREATE TABLE [dbo].[DateEvent]
(
	[Id] INT NOT NULL IDENTITY, 
    [date] DATETIME2 NOT NULL, 
    [IdSalle] INT NOT NULL, 
    [IdEvent] INT NOT NULL, 
    [PlaceRestante] INT NOT NULL, 
    [PrixPlace] INT NOT NULL, 
    CONSTRAINT [PK_DateEvent] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_DateEvent_ToTable] FOREIGN KEY ([IdSalle]) REFERENCES [Salles]([Id]), 
    CONSTRAINT [FK_DateEvent_ToTable_1] FOREIGN KEY ([IdEvent]) REFERENCES [Event]([Id]), 

)
