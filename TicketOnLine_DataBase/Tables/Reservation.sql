CREATE TABLE [dbo].[Reservation]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Date] DATETIME2 NOT NULL, 
    [NbrPlace] INT NOT NULL, 
    [Prix] INT NOT NULL, 
    [Idclient] INT NOT NULL, 
    [IdEvent] INT NOT NULL, 
    CONSTRAINT [FK_Reservation_Client] FOREIGN KEY ([Idclient]) REFERENCES [Client]([Id]), 
    CONSTRAINT [FK_Reservation_event] FOREIGN KEY ([IdEvent]) REFERENCES [Event]([Id])
)
