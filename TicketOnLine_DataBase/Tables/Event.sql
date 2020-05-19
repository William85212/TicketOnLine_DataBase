CREATE TABLE [dbo].[Event]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [NomSpectacle] NVARCHAR(50) NOT NULL, 
    [Realisateur] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Duree] TIME NOT NULL, 
    [Capacite] INT NOT NULL, 
    [PlaceRestante] INT NOT NULL, 
    [IdSalle] INT NOT NULL, 
    CONSTRAINT [FK_Event_Salle] FOREIGN KEY ([IdSalle]) REFERENCES [Salles]([Id])
)
