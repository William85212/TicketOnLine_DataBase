CREATE TABLE [dbo].[Commentaire]
(
	[Id] INT NOT NULL identity , 
    [Commentaire] NVARCHAR(MAX) NOT NULL, 
    [jaime] int null,
    [jaimePas] int null,
    [IdClient] INT NOT NULL, 
    [IdEvent] INT NOT  NULL, 
    CONSTRAINT [PK_Commentaire] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Commentaire_ToTable] FOREIGN KEY (IdClient) REFERENCES [Client]([Id]), 
    CONSTRAINT [FK_Commentaire_Evenement] FOREIGN KEY ([IdEvent]) REFERENCES [Event]([Id]), 
    
)
